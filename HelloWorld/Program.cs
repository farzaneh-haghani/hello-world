// See https://aka.ms/new-console-template for more information
using System;

public static class Program
{
    public static void Main()
    {
        Class1 x = new Class1();
        Class1 y   = new Class1(){MyProperty =13, MyProperty2 = 14};
        // set the property
        //x.MyProperty = 12; // doesn't work because it's init 
        x.MyProperty2 = 13; // pretend there is something that does x.SetValue(12)
        
        ChildClass y2 = new ChildClass();
        // new ChildClass allocates memory to store a ChildClass object (which includes a Class1 object inside)
        // then it calls it's own ctor and then it calls the Class1 ctor.
        y2.MyProperty2 = 14; // public access
        //y.visibleToChildren; // protected access doesn't work
        
        System.Console.WriteLine("Hello, World!");
    }
}


public class Class1
{
    // property = combination of a field and the methods to access it
    public int MyProperty
    {
        get => _myProperty;
        init => _myProperty = value;
    } // pretend it has created an invisible field to store an int.

    public int MyProperty2
    {
        set
        {
            if (value > 10) throw new Exception();
        }
    }

    // This is the full code for a Property
    // "invisible" field is called _propertyWithField;
    protected  int _propertyWithField;
    public int PropertyWithField
    {
        get => _propertyWithField;
        protected set => _propertyWithField = value;
    }

    // fields
    private int _number;
    private int _number2;
    private string _name;
    protected float visibleToChildren;
    private readonly int _myProperty;

    //constructor
    // when you do Class1 myClass = new Class1();
    public Class1()
    {
        _number = 0;
        _name = "Wai";
        MyProperty = 12;
    }

    // when you do Class1 myClass = new Class1(2,"Farzaneh");
    public Class1(int number, string name)
    {
        _number = number;
        _name = name;
        MyProperty = _number;
    }
    
    //methods
    public void PrintNumber(float another)
    {
        Console.WriteLine(_number + another);
    }
    
}

public class ChildClass : Class1 // ChildClass is the derived(child) class, and Class1 is the base(parent) class
// Only one parent is allowed
{
    // if we didn't declare a ctor, C# just pretends there is ChildClass() with an empty function body
    // BUT it will call Class1()
    
    // but we can tell it which Class1 ctor to call explicitly
    // new ChildClass() will call Class1(8, "test") and then print "ChildClass" 
    public ChildClass() : base(8, "test")
    {
        Console.WriteLine("ChildClass");
    }
    
    public float GetBaseClassValue()
    {
        return visibleToChildren; // can see protected base fields from here
    }
}

// 