using System;
using System.Collections.Generic;

namespace DesPatternSingleton
{

    public class Person
    {
        private string Name;
        private int Age;
        private int Id;
        public static List<Person> globalPerson = new List<Person>();

        public Person(string _name, int _age)  //Konstruktor
        {
            Age = _age;
            Name = _name;
            Id = IDGenerator.GetInstance().GibMirNeId();
            globalPerson.Add(this);
        }

        public override string ToString()
        {
            return "Name:" + Name + ", Age: " + Age + ", " + "Id: " + Id;
        }
    }

    /*
    class GlobalVariables
    {
        // public static int letzteID = 1;
        public static IDGenerator DerIdMacher = new IDGenerator();
    }
    */

    public class IDGenerator
    {
        private IDGenerator()
        {
            letzteID = 1;
        }

        private static IDGenerator _instance;

        public static IDGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new IDGenerator();
            return _instance;
        }

        private int letzteID;
        public int GibMirNeId()
        {
            return letzteID++;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {


            List<Person> personen = new List<Person>();
            /*
                Aufgabe Neue Personen sollen sich selbst in eine Liste eintragen
             */

            /*
            // Eine Stelle, an der Personen angelegt werden
            personen.Add(new Person("Walter", 14));
            personen.Add(new Person("Babara", 67));
            personen.Add(new Person("Sieglinde", 47));
            personen.Add(new Person("Brunhilde", 19));


            // Eine ANDERE Stelle, an der Personen angelegt werden
            personen.Add(new Person("Thomas", 12));
            personen.Add(new Person("Gerhart", 24));
            personen.Add(new Person("Waldtraut", 34));
            personen.Add(new Person("Siegmund", 59));
            personen.Add(new Person("Tuniglinde", 74));
             */


            new Person("Walter", 24);
            new Person("Siegmund", 70);
            new Person("Waldtraut", 70);
            new Person("Brunhilde", 60);
            new Person("Thomas", 14);
            new Person("Gerhart", 40);

            /*
            foreach (var person in personen)
                Console.WriteLine(person);
             */

            foreach (var person2 in Person.globalPerson)
                Console.WriteLine(person2);

            //Console.WriteLine("Hello World!");
        }
    }
}
