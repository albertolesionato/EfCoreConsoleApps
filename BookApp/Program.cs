// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine($"{new Test().x == null}");

class Test {
    public Foo x = null!;
}

class Foo {}