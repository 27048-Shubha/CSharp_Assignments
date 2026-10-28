namespace Assignment17_Reflections.Task6
{
    using System.Reflection;
    using System.Reflection.Emit;
    using Assignment17_Reflections.Utilities;

    internal class Task6
    {
        public IStudentService CreateMock(string name, int age)
        {
            AssemblyBuilder assembly = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName("MockAssembly"), AssemblyBuilderAccess.Run);

            ModuleBuilder module = assembly.DefineDynamicModule("MockModule");

            TypeBuilder type = module.DefineType("StudentMock", TypeAttributes.Public);
            type.AddInterfaceImplementation(typeof(IStudentService));

            FieldBuilder nameField = type.DefineField("_name", typeof(string), FieldAttributes.Private);
            FieldBuilder ageField = type.DefineField("_age", typeof(int), FieldAttributes.Private);

            foreach (MethodInfo method in typeof(IStudentService).GetMethods())
            {
                MethodBuilder mb = type.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    Type.EmptyTypes);

                ILGenerator il = mb.GetILGenerator();

                if (method.Name == "GetStudentName")
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, nameField);
                }
                else if (method.Name == "GetAge")
                {
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, ageField);
                }
                else if (method.Name == "DisplayDetails")
                {
                    il.Emit(OpCodes.Ldstr, "Student: ");
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, nameField);
                    il.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(string) })!);
                    il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) })!);

                    il.Emit(OpCodes.Ldstr, "Age: ");
                    il.Emit(OpCodes.Ldarg_0);
                    il.Emit(OpCodes.Ldfld, ageField);
                    il.Emit(OpCodes.Box, typeof(int));
                    il.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new[] { typeof(string), typeof(object) })!);
                    il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new[] { typeof(string) })!);
                }

                il.Emit(OpCodes.Ret);
                type.DefineMethodOverride(mb, method);
            }

            ConstructorBuilder ctor = type.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                new[] { typeof(string), typeof(int) });

            ILGenerator cil = ctor.GetILGenerator();
            cil.Emit(OpCodes.Ldarg_0);
            cil.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes)!);

            cil.Emit(OpCodes.Ldarg_0);
            cil.Emit(OpCodes.Ldarg_1);
            cil.Emit(OpCodes.Stfld, nameField);

            cil.Emit(OpCodes.Ldarg_0);
            cil.Emit(OpCodes.Ldarg_2);
            cil.Emit(OpCodes.Stfld, ageField);

            cil.Emit(OpCodes.Ret);

            Type mockType = type.CreateType()!;
            return (IStudentService)Activator.CreateInstance(mockType, name, age)!;
        }

        public void RunTask()
        {
            IStudentService mock = this.CreateMock("Shubha", 20);
            Console.WriteLine($"Student Name: {mock.GetStudentName() ?? "null"} ");
            Console.WriteLine($"Student Age: {mock.GetAge()}");
            mock.DisplayDetails();

            Console.WriteLine("Mock execution is successful");
        }
    }
}
