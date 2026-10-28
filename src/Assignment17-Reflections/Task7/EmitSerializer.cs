namespace Assignment17_Reflections.Task7
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text.Json;

    public static class EmitSerializer
    {
        private static readonly Dictionary<Type, Func<object, object?[]>>
            Cache = new();

        public static string Serialize(object obj)
        {
            Type type = obj.GetType();

            if (!Cache.TryGetValue(type, out var getter))
            {
                getter = CreateGetter(type);
                Cache[type] = getter;
            }

            PropertyInfo[] properties = GetProperties(type);
            object?[] values = getter(obj);

            var data = new Dictionary<string, object?>();

            for (int i = 0; i < properties.Length; i++)
            {
                data[properties[i].Name] = values[i];
            }

            return JsonSerializer.Serialize(data);
        }

        private static PropertyInfo[] GetProperties(Type type)
        {
            return Array.FindAll(
                type.GetProperties(),
                p => p.CanRead &&
                     p.GetIndexParameters().Length == 0 &&
                     p.GetMethod?.IsPublic == true);
        }

        private static Func<object, object?[]> CreateGetter(Type type)
        {
            PropertyInfo[] properties = GetProperties(type);

            DynamicMethod method = new DynamicMethod(
                "GetValues",
                typeof(object[]),
                new[] { typeof(object) },
                typeof(EmitSerializer).Module,
                true);

            ILGenerator il = method.GetILGenerator();

            il.Emit(OpCodes.Ldc_I4, properties.Length);
            il.Emit(OpCodes.Newarr, typeof(object));

            for (int i = 0; i < properties.Length; i++)
            {
                il.Emit(OpCodes.Dup);
                il.Emit(OpCodes.Ldc_I4, i);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Castclass, type);

                il.Emit(OpCodes.Callvirt, properties[i].GetMethod!);

                if (properties[i].PropertyType.IsValueType)
                {
                    il.Emit(OpCodes.Box, properties[i].PropertyType);
                }

                il.Emit(OpCodes.Stelem_Ref);
            }

            il.Emit(OpCodes.Ret);

            return (Func<object, object?[]>)method.CreateDelegate(
                typeof(Func<object, object?[]>));
        }
    }
}
