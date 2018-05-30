using System;
using System.Collections.Generic;

namespace DesPatternSingleton
{

    public class Person
    {
        private string Name;
        private int Age;
        private int Id;

        public Person(string _name, int _age)  //Konstruktor
        {
            Age = _age;
            Name = _name;
            Id = IDGenerator.GetInstance().GibMirNeId();
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


            foreach (var person in personen)
                Console.WriteLine(person);

            //Console.WriteLine("Hello World!");
        }
    }
}
