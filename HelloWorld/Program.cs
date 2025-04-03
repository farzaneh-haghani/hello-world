// See https://aka.ms/new-console-template for more information
using System;

namespace FirstProject
{
    public static class Program
    {
        public static void Main()
        {
            Class1 x = new Class1();
            Class1 y = new Class1() { MyProperty = 13, MyProperty2 = 14 };
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


    
}
// 