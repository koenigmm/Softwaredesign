using System;
using System.Collections;
using System.Collections.Generic;

namespace TextAdventure
{
    public class Item
    {
        public string ItemName;
        public string Description;
        public Item CombinableTo;
        public virtual bool IsHealthpotion()
        {
            return false;
        }
        public virtual bool IsWeapon()
        {
            return false;
        }

        public static void TakeItem(Person p)
        {
            if (p.RoomPerson.ListOfItems.Count > 0)
            {
                Item i = GetItemToTake(p);
                p.Inventory.Add(i);
                p.RoomPerson.ListOfItems.Remove(i);
                Console.WriteLine("{0} wurde aufgehoben", i.ItemName);
            }
            else
            {
                Console.WriteLine("Du kannst in in disem Raum nichts aufheben");
            }
        }

        public static Item GetItemToTake(Person p)
        {
            int index = 0;
            string consoleInput = string.Empty;
            bool whileLoopHelper = true;
            int parsedInput = 0;
            Item[] arrayOfItems = (Item[])p.RoomPerson.ListOfItems.ToArray(typeof(Item));



            if (arrayOfItems != null)
            {
                Console.WriteLine("");
                Console.WriteLine("In dem Raum {0} können folgende Gegenstände aufgehoben werden", p.RoomPerson.RoomName);
                foreach (Item c in p.RoomPerson.ListOfItems)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Index: {0}, {1}", index, c.ItemName);
                    Console.ResetColor();
                    index++;
                }
                while (whileLoopHelper)
                {
                    Console.WriteLine("Bitte gebe den Index des Items ein, welches Du aufheben möchtest");
                    consoleInput = Console.ReadLine();
                    try
                    {
                        parsedInput = int.Parse(consoleInput);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein. Du hast {0} eingeben", consoleInput);
                        Console.ResetColor();
                        continue;
                    }
                    try
                    {
                        whileLoopHelper = false;
                        return arrayOfItems[parsedInput];
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein. Du hast {0} eingeben", consoleInput);
                        Console.ResetColor();
                        continue;
                    }
                }
            }
            return null;
        }
        public static void DropItem(Person p)
        {
            if (p.Inventory.Count > 0)
            {
                Item i = GetItemToDrop(p);
                p.RoomPerson.ListOfItems.Add(i);
                Console.WriteLine("Der Gegenstand {0} wurde aus Deinem Inventar entfernt", i.ItemName);
                p.Inventory.Remove(i);
            }
            else
            {
                Console.WriteLine("Du kannst nichts fallen lassen");
            }
        }


        public static Item GetItemToDrop(Person p)
        {
            ShowInventory(p);
            string consoleInput = string.Empty;
            int parsedInput = 0;
            Item[] arrayOfInventory = (Item[])p.Inventory.ToArray(typeof(Item));
            bool whileLoopHelper = true;

            if (p.Inventory.Count > 0)
            {
                while (whileLoopHelper)
                {
                    try
                    {
                        Console.WriteLine("Wähle einen Gegenstand, der aus deinem Ivnentar entfernt werden soll. Der Gegenstand befindet sich dann in dem Raum, in dem du dich befindest");
                        consoleInput = Console.ReadLine();
                        parsedInput = int.Parse(consoleInput);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein");
                        Console.ResetColor();
                        continue;
                    }
                    try
                    {
                        return arrayOfInventory[parsedInput];
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe einen gültigen Index ein. Du hast {0} eingegben", consoleInput);
                    }
                }
            }


            return null;
        }

        public static void CombineItem(Person p)
        {
            Item a = ChooseItemToCombine(p, "Wähle das erste Item");
            Item b = ChooseItemToCombine(p, "Wähle das zweite Item");

            if (a != b)
            {
                if (a.CombinableTo == b.CombinableTo)
                {
                    p.Inventory.Add(a.CombinableTo);
                    p.Inventory.Remove(a);
                    p.Inventory.Remove(b);
                    Console.WriteLine(a.ItemName + " und " + b.ItemName + " kombiniert zu " + a.CombinableTo.ItemName);
                }
                else Console.WriteLine("{0} ist nicht kombinierbar mit {1} ", a, b);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Zwei gleiche Gegenstände können nicht kombiniert werden");
                Console.ResetColor();
            }
        }

        public static Item ChooseItemToCombine(Person p, string order)
        {
            int parsedInput = 0;
            bool whileLoopHelper = true;
            Item[] arrayOfInventory = (Item[])p.Inventory.ToArray(typeof(Item));
            Console.WriteLine(order);
            string consoleInput = string.Empty;
            if (p.Inventory != null)
            {
                ShowInventory(p);
                while (whileLoopHelper)
                {
                    Console.WriteLine("Bitte wähle ein Item welches du kombinieren möchtest. Gebe bitte den passenden Index ein");
                    try
                    {
                        consoleInput = Console.ReadLine();
                        parsedInput = int.Parse(consoleInput);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein du hast {0} eingegeben", consoleInput);
                        Console.ResetColor();
                        continue;
                    }
                    try
                    {
                        return arrayOfInventory[parsedInput];
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe einen gültigen Index ein. Du hast {0} eingegeben", consoleInput);
                        Console.ResetColor();
                        continue;
                    }
                }
            }
            return null;
        }

        public static void ShowInventory(Person inputPerson)
        {
            int index = 0;
            if (inputPerson.Inventory != null)
            {
                Console.WriteLine("Hier ist der Inhalt deines Inventars");
                foreach (Item c in inputPerson.Inventory)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Index: {0}, {1}", index, c.ItemName);
                    Console.ResetColor();
                    index++;
                }
            }
            else
            {
                Console.WriteLine("Dein Inventar ist leer");
            }
        }
    }

    public class Weapon : Item
    {
        public int Demage_Weapon;
        public override bool IsWeapon()
        {
            return true;
        }

        public static void EquipWeapon(Person p2equipWeapon)
        {
            if (p2equipWeapon.EqWeapon == null)
            {
                Weapon weapon2equip = GetWeapon2Equip(p2equipWeapon);

                if (weapon2equip != null)
                {
                    p2equipWeapon.BaseDemage += weapon2equip.Demage_Weapon;
                    p2equipWeapon.EqWeapon = weapon2equip;
                    p2equipWeapon.Inventory.Remove(weapon2equip);
                    Console.WriteLine("Du hast {0} ausgerüstet", p2equipWeapon.EqWeapon.ItemName);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du hast keine Waffe in deinem Iventar");
                }
            }
            else
            {
                Console.WriteLine("Du hast bereits eine Waffe ausgerüstet");
            }

        }

        public static Weapon GetWeapon2Equip(Person p)
        {
            ArrayList listOfIventory = new ArrayList();
            ArrayList ListOfWeaponInInventory = new ArrayList();
            List<Weapon> ListWeapon = new List<Weapon>();

            foreach (Item c in p.Inventory)
            {
                if (c.IsWeapon())
                {
                    ListOfWeaponInInventory.Add(c);
                }
            }
            if (ListOfWeaponInInventory != null)
            {
                int parsedInput = 0;
                bool whileLoopHelper = true;
                string consoleInput = string.Empty;

                foreach (Weapon c in ListOfWeaponInInventory)
                {
                    ListWeapon.Add(c);
                }
                Weapon[] WeaponArray = ListWeapon.ToArray();

                while (whileLoopHelper)
                {
                    Console.WriteLine("Bitte wähle eine Waffe, welche Du ausrüsten möchtest, gebe dazu einfach den passenden Index ein");
                    int index = 0;
                    foreach (var c in WeaponArray)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Index {0}, {1}", index, c.ItemName);
                        Console.ResetColor();
                        index++;
                    }
                    consoleInput = Console.ReadLine();
                    try
                    {
                        parsedInput = int.Parse(consoleInput);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein Du hast {0} eingegeben", consoleInput);
                        Console.ResetColor();
                        continue;
                    }
                    try
                    {
                        return WeaponArray[parsedInput];
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe einen gültigen Index ein Du hast {0} eingegeben", parsedInput);
                        Console.ResetColor();
                    }
                }
            }
            return null;
        }

        public static void EqWeaponBackToInventory(Person p)
        {
            if (p.EqWeapon != null)
            {
                Console.WriteLine("Deine ausgerüstete Waffe {0} wurde wieder zurück ins Inventar gelegt", p.EqWeapon.ItemName);
                p.Inventory.Add(p.EqWeapon);
                p.BaseDemage -= p.EqWeapon.Demage_Weapon;
                p.EqWeapon = null;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du hast keine Waffe ausgerüstet");
                Console.ResetColor();
            }
        }
    }

    public class HealthPotion : Item
    {
        public int Value_Health = 20;
        public override bool IsHealthpotion()
        {
            return true;
        }

        public static void UseHealthPostion(Person p2UseHP)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            HealthPotion hp2Use = GetHealthpotion2Use(p2UseHP);
            Console.Write("Deine Gesundheit wurde von {0} um {1} erhöht ", p2UseHP.Health, hp2Use.Value_Health);
            p2UseHP.Health += hp2Use.Value_Health;
            p2UseHP.Inventory.Remove(hp2Use);
            if (p2UseHP.Health >= p2UseHP.BaseHealth)
            {
                p2UseHP.Health = p2UseHP.BaseHealth;
            }
            Console.Write("Sie beträgt nun {0}, beachte Tränke können dich nur bis zum maximum deiner Gesunheit heilen {1}", p2UseHP.Health, p2UseHP.BaseHealth);
            Console.ResetColor();
        }

        public static HealthPotion GetHealthpotion2Use(Person inputPerson)
        {
            bool whileLoopHelper = true;
            string consoleInput = string.Empty;
            int parsedInput = 0;

            ArrayList ListofInventorOnylPostions = new ArrayList();
            List<HealthPotion> ListOfHealpotions = new List<HealthPotion>();

            if (inputPerson.Inventory != null)
            {
                foreach (Item c in inputPerson.Inventory)
                {
                    if (c.IsHealthpotion())
                    {
                        ListofInventorOnylPostions.Add(c);
                    }
                }
                foreach (HealthPotion c in ListofInventorOnylPostions)
                {
                    ListOfHealpotions.Add(c);
                }

                if (ListOfHealpotions == null)
                {
                    Console.WriteLine("Du hast keine Heiltränke in deinem Inventar");
                    whileLoopHelper = false;
                }

                HealthPotion[] arrayOfHealthpotions = ListOfHealpotions.ToArray();

                while (whileLoopHelper)
                {
                    int index = 0;
                    foreach (var c in arrayOfHealthpotions)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Index {0}, {1}", index, c.ItemName);
                        Console.ResetColor();
                        index++;
                    }
                    index = 0;

                    Console.WriteLine("Bitte wähle einen Heiltrank durch Eingabe des passenden Index");
                    consoleInput = Console.ReadLine();
                    try
                    {
                        parsedInput = int.Parse(consoleInput);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein. Du hat {0} eingegeben", consoleInput);
                        Console.ResetColor();
                        ListOfHealpotions.Clear();
                        continue;
                    }
                    try
                    {
                        return arrayOfHealthpotions[parsedInput];
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe einen gültigen Index ein. Du hast {0} eingegeben", parsedInput);
                        Console.ResetColor();
                        ListOfHealpotions.Clear();
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Du hast keine Heiltränge");
            }
            return null;
        }

    }
}


