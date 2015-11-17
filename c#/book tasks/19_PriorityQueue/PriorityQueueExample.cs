using System;

class PriorityQueueExample
{
    public static void Main()
    {
        var people = new PriorityQueue<Person>();
        people.Enqueue(new Person("Petar", 25));
        people.Enqueue(new Person("Petya", 24));
        people.Enqueue(new Person("Pesho", 25));
        people.Enqueue(new Person("Maria", 22));
        people.Enqueue(new Person("Ivan", 19));

        while (people.Count > 0)
        {
            Console.WriteLine(people.Dequeue());
        }
    }
}