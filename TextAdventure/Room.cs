using System;
using System.Collections;

namespace TextAdventure
{
    public class Room
    {
        public Room[] ExitNOSW = new Room[4];

        public string RoomName;
        public string RoomDescription;
        public ArrayList ListOfPerson = new ArrayList();
        public ArrayList ListOfItems = new ArrayList();
        //public ArrayList ListOfMonster = new ArrayList(); 
        public static void Look(Room inputRoom)
        {
            if (Player.Gamestarted)
            {
                Console.WriteLine("Das siehst du: ");
                Console.WriteLine(inputRoom.RoomDescription);
                Console.ForegroundColor = ConsoleColor.Cyan;
                ShowItemsInRoom(inputRoom);
                ShowMonsterInRoom(inputRoom);
                ShowPersonInRoom(inputRoom);
            }
        }

        public static void ShowPersonInRoom(Room inputRoom)
        {
            foreach (Person c in inputRoom.ListOfPerson)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (Person.ReturnSex(c) == "male" && c.ShowInLook)
                {

                    Console.WriteLine("Ein Mann: " + c.NameOfPerson);

                }

                if (Person.ReturnSex(c) == "female" && c.ShowInLook)
                {
                    Console.WriteLine("Eine Frau: " + c.NameOfPerson);
                }
                Console.ResetColor();
            }
        }

        public static void ShowMonsterInRoom(Room inputRoom)
        {
            foreach (Person m in inputRoom.ListOfPerson)
            {
                if (m.IsMonster)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Ein Monster: " + m.NameOfPerson);
                    Console.ResetColor();
                }
            }
        }

        public static void ShowItemsInRoom(Room inputRoom)
        {
            foreach (Item c in inputRoom.ListOfItems)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ein Item: " + c.ItemName);
                Console.ResetColor();
            }
        }


    }


}