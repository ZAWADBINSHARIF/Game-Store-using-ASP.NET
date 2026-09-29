using System;

namespace FirstProjects;

class FirstClass
{
    string Name = "Zawad";

    public FirstClass()
    {
        Console.WriteLine(Name);
    }

    public FirstClass(string childClassName)
    {
        Console.WriteLine(childClassName);
    }
}

class SecondClass(string sayHi) : FirstClass(sayHi)
{
    //
}

public static class Testing
{
    public static void Main(String[] args)
    {
        new SecondClass("Hi");
    }
}