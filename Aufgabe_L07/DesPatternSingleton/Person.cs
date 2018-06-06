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
            Id = IDGenerator.Instance.GibMirNeId();
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

        public static IDGenerator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IDGenerator();
                return _instance;
            }
        }

        private int letzteID;
        public int GibMirNeId()
        {
            return letzteID++;
        }
    }
}