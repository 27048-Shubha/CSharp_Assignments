# Value Types vs Reference Types in C#

### Value Type

A value type stores its actual data directly.

- `struct` is a value type by default.
- Usually stored on the stack when declared as a local variable.
- When passed as a method argument, a copy of the value is passed.
- Any modifications are applied only to the copied value.
- Changes do not affect the original variable.

### Reference Type

A reference type stores a reference to an object.

- `class` is a reference type by default.
- The actual object data is stored on the heap.
- The variable itself contains a reference that points to the object.
- When passed as a method argument, a copy of the reference is passed.
- Both references point to the same object in memory.
- Changes made through one reference are visible through the other.

## Program Output

### Input

```text
Enter name: Shubha
Enter age: 20
```

### Contents Before Modification

```text
--------------------------------------------
Contents inside PersonStruct:
Name: Shubha
Age: 20
--------------------------------------------
Contents inside PersonClass:
Name: Shubha
Age: 20
--------------------------------------------
```

### Contents After Modification

```text
--------------------------------------------
Contents inside PersonStruct:
Name: Shubha
Age: 20
--------------------------------------------
Contents inside PersonClass:
Name: Shree
Age: 15
--------------------------------------------
```

## Observation

### PersonStruct

The values remain unchanged after the modification method is called.

This is because `PersonStruct` is a value type. When it is passed to a method, a copy of the struct is passed. Any modifications are made only to the copied instance, leaving the original object unchanged.

### PersonClass

The values are modified after the modification method is called.

This is because `PersonClass` is a reference type. The method receives a reference to the same object, and any changes made through that reference affect the original object.

