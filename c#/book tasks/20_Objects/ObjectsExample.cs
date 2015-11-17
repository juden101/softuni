using System;

public class ObjectsExample
{
    public static void Main()
    {
        Animal[] animals = {
            new Dog(5, "Rex", Gender.Male),
            new Cat(19, "Grumpy", Gender.Female),
            new Kitten(1, "Kitty", Gender.Male),
            new Tomcat(5, "Tom", Gender.Male),
            new Frog(5, "Froggy", Gender.Other),
            new Dog(9, "Sharo", Gender.Male)
        };

        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}