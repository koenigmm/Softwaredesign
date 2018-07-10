using System;
using System.Collections;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Person
    {
        public string NameOfPerson;
        public int Health = 100, BaseHealth = 100;
        private string sex;
        public int BaseDemage = 10;
        public bool boss = false;
        public bool Attackable = false;
        public bool Alive = true;
        public Room RoomPerson;
        public Weapon EqWeapon;
        public ArrayList Inventory = new ArrayList();
        public bool ShowInLook = true;
        //public string[,] Dialog = new string[4, 3];  //5mal drei fragen und antworten
        public Dictionary<int, string> Fragen = new Dictionary<int, string>();
        public Dictionary<int, string> Antworten = new Dictionary<int, string>();
        public string Introduction;
        public bool IsMonster = false;

        public static void SetSexFemale(Person person2setSex)
        {
            person2setSex.sex = "female";
        }
        public static void SetSexMale(Person person2setSex)
        {
            person2setSex.sex = "male";
        }

        public static string ReturnSex(Person inputPereson)
        {
            return inputPereson.sex;
        }

        public static void MoveRoom(Person person2Move)
        {
            string inputConsole = "";
            Console.WriteLine("Mögliche Richtungen n für Norden, o für Osten, s für Süden, w für Westen");
            ShowPosibleRoomsForMove(person2Move);
            try
            {
                inputConsole = Console.ReadLine();
                char direction = Convert.ToChar(inputConsole);
                CheckMoveCharException(direction); //NOSW Reihenfolge
                try
                {
                    char[] casesNOSW = { 'n', 'o', 's', 'w' };
                    for (int i = 0; i < casesNOSW.Length; i++)
                    {
                        if (person2Move.RoomPerson.ExitNOSW[i] != null && casesNOSW[i] == direction)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Du betrittst " + person2Move.RoomPerson.ExitNOSW[i].RoomName);
                            person2Move.RoomPerson.ExitNOSW[i].ListOfPerson.Add(person2Move);
                            person2Move.RoomPerson.ListOfPerson.Remove(person2Move);
                            person2Move.RoomPerson = person2Move.RoomPerson.ExitNOSW[i];
                            Room.Look(person2Move.RoomPerson);
                        }
                        else if (person2Move.RoomPerson.ExitNOSW[i] == null && casesNOSW[i] == direction)
                        {
                            throw new Exception();
                        }
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du kannst hier nicht lang");
                    Console.ResetColor();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Deine Eingabe " + inputConsole + " bitte gebe einen gültigen Buchstaben ein (n, o, s, w)");
                Console.ResetColor();
            }
        }

        public static void ShowPosibleRoomsForMove(Person inputPlayer)
        {
            string[] casesNOSW = { "Norden", "Osten", "Süden", "Westen" };
            for (int i = 0; i < inputPlayer.RoomPerson.ExitNOSW.Length; i++)
            {
                if (inputPlayer.RoomPerson.ExitNOSW[i] != null)
                {
                    Console.WriteLine("In diese Richtung(en) kannst Du gehen: {0}, {1}", casesNOSW[i], inputPlayer.RoomPerson.ExitNOSW[i].RoomName);
                }
            }
        }

        public static void SetRoom(Person p, Room r)
        {
            p.RoomPerson = r;
            r.ListOfPerson.Add(p);
        }

        public static void CheckMoveCharException(char inputChar)
        {
            char[] AllowedCharsMove = new char[] { 'n', 's', 'o', 'w' };
            bool badCharFound = false;

            foreach (char c in AllowedCharsMove)
            {
                if (inputChar == c)
                {
                    badCharFound = false;
                    break;
                }
                else badCharFound = true;
            }
            if (badCharFound)
            {
                throw new Exception();
            }
        }

        public static Person Person2Attack(Person attacker)
        {

            String inputConsole = "";
            List<Person> posibleTargets = new List<Person>();
            foreach (Person p in attacker.RoomPerson.ListOfPerson)
            {
                if (p.Attackable)
                {
                    posibleTargets.Add(p);
                }
            }
            Person[] posibleTargetsArray = posibleTargets.ToArray();

            for (int i = 0; i < posibleTargetsArray.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Index {0}, {1}", i, posibleTargetsArray[i].NameOfPerson);
                Console.ResetColor();
            }
            if (posibleTargetsArray.Length != 0)
            {
                Console.WriteLine("Wähle einen Feind, in dem du den passenen Index eingibst");
                inputConsole = Console.ReadLine();

                try
                {
                    int parsedIndex = int.Parse(inputConsole);
                    return posibleTargetsArray[parsedIndex];
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Stelle sicher das ein das ein besetzter Index ausgewhält wurde bzw. eine Zahl eingeben wurde " + inputConsole);
                    Console.ResetColor();
                    return null;
                }
            }
            else return null;

        }
        public static void Attack(Person attacker)
        {
            Person target = Person2Attack(attacker);

            if (target != null)
            {
                while (attacker.Alive || target.Alive)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(attacker.NameOfPerson + " " + attacker.Health + "HP greift an " + target.NameOfPerson);
                    Console.ResetColor();
                    target.Health -= attacker.BaseDemage;

                    if (CheckAlive(target))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(target.NameOfPerson + " " + target.Health + "HP schlägt zurück");
                        Console.ResetColor();
                        attacker.Health -= target.BaseDemage;
                    }
                    if (CheckAlive(attacker) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Game Over");
                        Console.ResetColor();
                        Player.Gamestarted = false;
                        break;

                    }
                    else if (target.Alive == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(target.NameOfPerson + " ist gestorben");
                        Console.ResetColor();

                        foreach (Item c in target.Inventory)
                        {
                            if (c != null)
                            {
                                target.RoomPerson.ListOfItems.Add(c);
                                //target.Inventory.Remove(c); Geht nicht unerklerliche Fehlermeldung
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("{0} hat {1} fallengelassen", target.NameOfPerson, c.ItemName);
                                Console.ResetColor();
                            }
                        }
                        //arget.RoomPerson.ListOfMonster.Remove(target);
                        Console.WriteLine();
                        target.RoomPerson.ListOfPerson.Remove(target);

                        if (target.Alive == false && target.boss == true)
                        {
                            Console.WriteLine("Glückwunsch der Weg ist frei. Das Spiel ist beendet");
                            Player.Gamestarted = false;
                        }
                        break;
                    }

                }
            }
        }

        public static bool CheckAlive(Person p)
        {
            if (p.Health <= 0)
            {
                p.Alive = false;
                return false;
            }
            else return true;
        }
    }

    public class Monster : Person
    {

    }

}
