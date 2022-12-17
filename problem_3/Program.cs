using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

public class Family
{
    public Family()
    {
        this.People = new List<Person>();
    }

    public List<Person> People { get; set; }

    public void AddMember(Person person)
    {
        this.People.Add(person);
    }

    public Person GetOldestMember(List<Person> people)
    {
        return people.FirstOrDefault(x => x.Age == people.Max(y => y.Age));
    }
}



class Program
{
    static void Main(string[] args)
    {
        var people = new Family();

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var person_Information = Console.ReadLine().Split();
            var name = person_Information[0];
            int age = int.Parse(person_Information[1]);

            var person = new Person(name, age);
            people.AddMember(person);
        }

        var oldest_Person = people.GetOldestMember(people.People);
        Console.WriteLine($"\n The oldest member is {oldest_Person.Name} {oldest_Person.Age}");

    }
}
