namespace Assignment17_Reflections.Task4
{
    using System.Reflection;
    using System.Reflection.Emit;

    /// <summary>
    /// Manages dynamic type builder (task 4)
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Executes the workflow of the task 4.
        /// </summary>
        public void RunTask()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("DYNAMIC TYPE BUILDER");
            Console.WriteLine(new string('=', 50));

            AssemblyName assemblyName = new AssemblyName("BookAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(
                assemblyName, AssemblyBuilderAccess.Run);

            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("BookModule");

            TypeBuilder typeBuilder = moduleBuilder.DefineType(
                "Book", TypeAttributes.Public);

            FieldBuilder nameField = typeBuilder.DefineField(
                "_name", typeof(string), FieldAttributes.Private);

            PropertyBuilder nameProperty = typeBuilder.DefineProperty(
                "Name", PropertyAttributes.None, typeof(string), null);

            MethodBuilder getter = typeBuilder.DefineMethod(
                "get_Name", MethodAttributes.Public, typeof(string), Type.EmptyTypes);

            ILGenerator getterIL = getter.GetILGenerator();
            getterIL.Emit(OpCodes.Ldarg_0);
            getterIL.Emit(OpCodes.Ldfld, nameField);
            getterIL.Emit(OpCodes.Ret);

            MethodBuilder setter =
                typeBuilder.DefineMethod(
                    "set_Name", MethodAttributes.Public, typeof(void), new Type[] { typeof(string) });

            ILGenerator setterIL = setter.GetILGenerator();
            setterIL.Emit(OpCodes.Ldarg_0);
            setterIL.Emit(OpCodes.Ldarg_1);
            setterIL.Emit(OpCodes.Stfld, nameField);
            setterIL.Emit(OpCodes.Ret);

            nameProperty.SetGetMethod(getter);
            nameProperty.SetSetMethod(setter);

            MethodBuilder displayMethod =
                typeBuilder.DefineMethod(
                    "DisplayDetails", MethodAttributes.Public, typeof(void), Type.EmptyTypes);

            ILGenerator displayIL = displayMethod.GetILGenerator();
            displayIL.Emit(OpCodes.Ldstr, "Book Name: ");
            displayIL.Emit(OpCodes.Ldarg_0);
            displayIL.Emit(OpCodes.Ldfld, nameField);

            displayIL.Emit(
                OpCodes.Call,
                typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }) !);

            displayIL.Emit(
                OpCodes.Call,
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }) !);

            displayIL.Emit(OpCodes.Ret);

            Type bookType = typeBuilder.CreateType();
            Console.WriteLine("[SUCCESS] Dynamic Book type created!");
            Console.WriteLine($"Type Name : {bookType.Name}");
            Console.WriteLine($"Namespace : {bookType.Namespace ?? "None"}");

            object book = Activator.CreateInstance(bookType);
            Console.WriteLine("[SUCCESS] Book object created!");

            bookType.GetProperty("Name") !.SetValue(book, "Harry Potter and the Chamber of Secrets");
            Console.WriteLine("[SUCCESS] Property assigned.");

            bookType.GetMethod("DisplayDetails") !.Invoke(book, null);
            Console.WriteLine(new string('=', 50));
        }
    }
}
