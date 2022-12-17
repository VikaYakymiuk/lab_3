using System;
using System.Reflection;

class Person
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
public class Constructors
{
    public static void Main()
    {
        Type person_Type = typeof(Person);

        ConstructorInfo emptyCtor = person_Type.GetConstructor(new Type[] { });
        ConstructorInfo ageCtor = person_Type.GetConstructor(new[] { typeof(int) });
        ConstructorInfo nameAgeCtor = person_Type.GetConstructor(new[] { typeof(string), typeof(int) });



        string name = Console.ReadLine();

        int age = int.Parse(Console.ReadLine());

        bool swapped = false;
        if (nameAgeCtor == null)
        {
            nameAgeCtor = person_Type.GetConstructor(new[] { typeof(int), typeof(string) });
            swapped = true;
        }

        Person Person = (Person)emptyCtor.Invoke(new object[] { });
        Person personAge = (Person)ageCtor.Invoke(new object[] { age });
        Person personAgeName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

        Console.WriteLine("{0} {1}", Person.Name, Person.Age);
        Console.WriteLine("{0} {1}", personAge.Name, personAge.Age);
        Console.WriteLine("{0} {1}", personAgeName.Name, personAgeName.Age);
    }
}
