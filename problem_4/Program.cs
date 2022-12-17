using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                this.name = "No name";
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            try
            {
                this.age = value;
            }
            catch (Exception invalidException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(int age)
        : this()
    {
        this.name = "No name";
        this.age = age;
    }

    public Person(string name, int age)
        : this(age)
    {
        this.name = name;
        this.age = age;
    }
}
public class Poll
{
    public static void Main()
    {
        var people = new List<Person>();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var person_Information = Console.ReadLine().Split();
            var name = person_Information[0];
            var age = int.Parse(person_Information[1]);

            var person = new Person(name, age);
            people.Add(person);
        }

        var result = people.Where(p => p.Age > 30).ToList().OrderBy(p => p.Name);

        foreach (var person in result)
        {
            Console.WriteLine($"\n{person.Name} - {person.Age}");
        }
    }
}
