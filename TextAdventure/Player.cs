using System;

namespace TextAdventure
{
    class Game
    {
        static void Main()
        {
            Player.StartGame();
        }
    }
    class Player : Person
    {
        public static bool Gamestarted = false;

        public static void StartGame()
        {
            //Console.Clear();
            Gamestarted = true;
            //Console.WriteLine("Welcome to PLATZHALTER which is an interactive Text Adventure. If you need help simply enter help in the command Line");

            Room forest = new Room();
            forest.RoomName = "Dunkler Wald";
            forest.RoomDescription = "Du bist tiefer im Wald. Die Rufe sind längt verstummt. Aus sicherer Distanz betrachtest du eine Kreatur. Es ist ein ausgewachsenes Exemplar der mutierten Wildschweine die euch angegriffen haben.";

            Room street = new Room();
            street.RoomName = "Ort des Angriffs";
            street.RoomDescription = "Der Ort des Angriffs. Du siehst das Monster, welches euch angriff. Die Waren liegen noch auf der Straße. Du wirst das Monster besiegen müssen.";

            Room cave = new Room();
            cave.RoomName = "Eine kleine Höhle";
            cave.RoomDescription = "Du siehst eine Skelett ein Tagebuch und einige Gegenstände. In dem Tagebuch steht, dass er der Assistent des Magiers war. Er ist geflohen weil er die Menschen warnen wollte. Die Monster verperrten ihm den Weg. Er ist wohl verhungert.";

            Room campBandits = new Room();
            campBandits.RoomName ="Das Lager der Banditen";
            campBandits.RoomDescription ="Du siehst eine Gruppe von Banditen. Du hast dich hinter einigen Kisten versteckt. Du siehst das Öl vor dir.";

            Room playerStartRoom = new Room();
            playerStartRoom.RoomName = "Das Lager der Karawane";
            playerStartRoom.RoomDescription = "Ein notdürftiges Lager. Es bietet keinen Schutz";
            playerStartRoom.ExitNOSW[3] = forest;
            playerStartRoom.ExitNOSW[0] = cave;
            playerStartRoom.ExitNOSW[1] = street;
            playerStartRoom.ExitNOSW[2] = campBandits;
            forest.ExitNOSW[1] = playerStartRoom;
            cave.ExitNOSW[2] = playerStartRoom;
            street.ExitNOSW[3] = playerStartRoom;
            campBandits.ExitNOSW[0] = playerStartRoom;


            Person haendlerin = new Person();
            haendlerin.NameOfPerson = "Theodora die Händlerin";
            SetSexFemale(haendlerin);
            Person.SetRoom(haendlerin, playerStartRoom);
            haendlerin.Introduction = "Im Süden ist ein Lager Banditen. Es gibt Gerüchte, dass sie ihre Schwerter mit giftigen Ölen bestreichen.";

            Person schmied = new Person();
            schmied.NameOfPerson = "Siegmung der Schmied";
            SetSexMale(schmied);
            Person.SetRoom(schmied, playerStartRoom);
            schmied.Introduction = "Es wird bald Nacht. Wenn wir nicht bald von hier verschwinden, dann verschwinden wir für immer";
            

            schmied.Fragen.Add(0, "Hast Du noch Schwerter? Ich habe meines beim Angriff verloren");
            schmied.Fragen.Add(1, "Was meinst Du hat uns angegriffen?");
            schmied.Fragen.Add(2, "Was könnte ich verwenden um die Vieher loszuwerden?");
            schmied.Fragen.Add(3, "Das Gespräch beenden");
            schmied.Antworten.Add(0, "Nein keines mehr, sie sind alle in den Kisten die wir auf der Straße zurücklasen mussten (Osten). ");
            schmied.Antworten.Add(1, "Diese Dinger sahen aus wie Wildschweine. Mutierte Wildschweine. Aber kann das sein?");
            schmied.Antworten.Add(2, "Hier hinten liegt eine Schleuder, vielleicht kannst du damit etwas anfangen. Vielleicht findest du auch etwas in der Höhle im Norden");
            schmied.Antworten.Add(3, "Bis später");

            haendlerin.Fragen.Add(0, "Hast du irgendetwas was mir im Kampf gegen diese Dinger helfen könnte?");
            haendlerin.Fragen.Add(1, "Du meinst die überlassen mir das Öl?");
            haendlerin.Fragen.Add(2, "Welches Tier gibt solche Geräusche von sich?");
            haendlerin.Fragen.Add(3, "Das Gespräch beenden");
            haendlerin.Antworten.Add(0, "Nein leider nicht, aber das Öl der Banditen wäre Hilfreich, wenn du ein Schwert hättest");
            haendlerin.Antworten.Add(1, "Vielleiht greifen sie dich auch an. Versuche es doch unbemerkt an dich zu nehmen. Die haben es bestimmt auch geklaut. Oder versuche mit ihnen zu Reden");
            haendlerin.Antworten.Add(2, "Nichts gutes. Wahrscheinlich noch mehr Kreaturen aus dem Brutkasten des Hofmagiers. Es sind zwar nur Gerüchte, aber du hast ja gesehen was uns angegriffen hat. Wer weiß was der König mit den Monstern vor hat.");
            haendlerin.Antworten.Add(3, "Bis später");


            Weapon einfachesSchwert = new Weapon();
            einfachesSchwert.Demage_Weapon = 20;
            einfachesSchwert.Description = "Ein einfaches Schwert";
            einfachesSchwert.ItemName = "Einfaches Schwert";

            Weapon oil = new Weapon();
            oil.Demage_Weapon = 0;
            oil.Description = "Ein tödliches Öl. Besonders praktisch in Kombination mit einem Schwert";
            oil.ItemName = "Giftöl";
            campBandits.ListOfItems.Add(oil);

            Weapon mightySword = new Weapon { Demage_Weapon = 100, Description = "Ein mächtiges Schwert", ItemName = "Mächtiges Schwert" };
            oil.CombinableTo = mightySword;
            einfachesSchwert.CombinableTo = mightySword;
            //playerStartRoom.ListOfItems.Add(mightySword);

            Weapon schleuder = new Weapon();
            schleuder.ItemName = "Schleuder";
            schleuder.Description = "Eine einfache Schleuder";
            playerStartRoom.ListOfItems.Add(schleuder);

            Weapon bullet = new Weapon();
            bullet.ItemName = "Geschoss";
            bullet.Description = "Explosives Geschoss";
            cave.ListOfItems.Add(bullet);

            Weapon sprengSchleuder = new Weapon();
            sprengSchleuder.ItemName = "Sprengschleuder";
            sprengSchleuder.Description = "Eine Sprengschleuder";
            bullet.CombinableTo = sprengSchleuder;
            schleuder.CombinableTo = sprengSchleuder;
            sprengSchleuder.Demage_Weapon = 40;

            HealthPotion ordinaryHealthpostion = new HealthPotion { Description = "Nichts besonderes, es heilt dich ", ItemName = "Gewöhnlicher Heiltrank" };
            cave.ListOfItems.Add(ordinaryHealthpostion);

            Player mainPlayer = new Player();
            mainPlayer.ShowInLook = false;
            mainPlayer.Attackable = false;
            Person.SetRoom(mainPlayer, playerStartRoom);
            mainPlayer.Health = 80;
            Monster monsterA = new Monster();
            monsterA.NameOfPerson = "Mutiertes Wildschwein";
            monsterA.Attackable = true;
            monsterA.BaseDemage = 20;
            monsterA.IsMonster = true;
            Monster.SetRoom(monsterA, street);
            monsterA.Inventory.Add(einfachesSchwert);

            Monster bigMonster = new Monster();
            bigMonster.NameOfPerson = "Ausgewachsenes mutiertes Wildschwein";
            bigMonster.Attackable = true;
            bigMonster.BaseDemage = 30;
            bigMonster.BaseHealth = 300;
            bigMonster.Health = 300;
            bigMonster.boss = true;
            bigMonster.IsMonster = true;
            Monster.SetRoom(bigMonster,forest);


            SetPlayer(mainPlayer);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Willkommen {0}. Als Teil einer Gruppe von Kaufleuten und Handwerkern bist du gestrandet.", mainPlayer.NameOfPerson);
            Console.WriteLine("Entstellte Kreaturen griffen Deine Karawane an. In der Eile ist ein Teil der Waren verloren gegangen. Der Weg vor dir führt dich tiefer in den Wald. Du hörst qualvolle Rufe.");
            Console.WriteLine("Keine Menschenrufe. Keine Tierrufe.");
            Console.WriteLine("Wappne Dich mit allem was Du findest und stelle Dich den Gefahren des Waldes ");
            Console.ResetColor();
            Room.Look(mainPlayer.RoomPerson);

            CheckCommand(mainPlayer);
        }

        private static bool ExitCheck(string toTest)
        {
            if (toTest == "q")
            {
                Gamestarted = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du hast das Spiel beendet");
                Console.ResetColor();
                return true;
            }
            else return false;
        }

        private static void CheckCommand(Person p)
        {
            while (Gamestarted)
            {
                Help();
                string input = Console.ReadLine();

                try
                {
                    if (ExitCheck(input) == false)
                    {

                        if (input == "help")
                        {
                            Help();

                        }
                        else if (input == "move")
                        {
                            Person.MoveRoom(p);

                        }
                        else if (input == "attack")
                        {
                            Person.Attack(p);

                        }
                        else if (input == "talk")
                        {
                            Player.Talk(GetConversationPartner(p));

                        }
                        else if (input == "combine")
                        {
                            Item.CombineItem(p);

                        }
                        else if (input == "inventory")
                        {
                            Item.ShowInventory(p);

                        }
                        else if (input == "look")
                        {
                            Room.Look(p.RoomPerson);

                        }
                        else if (input == "take")
                        {
                            Item.TakeItem(p);

                        }
                        else if (input == "drop")
                        {
                            Item.DropItem(p);

                        }
                        else if (input == "heal")
                        {
                            HealthPotion.UseHealthPostion(p);

                        }
                        else if (input == "equip")
                        {
                            Weapon.EquipWeapon(p);

                        }

                        else if (input == "unarm")
                        {
                            Weapon.EqWeaponBackToInventory(p);

                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    //if (ExitCheck(input) == true)
                    //  break;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bitte wähle einen gültigen Befehl bzw. achte darauf, ob ein Befehl ausführbar ist bspw. heal ohne Heiltrank im Inventar ist nicht möglich. Etwas fallenzulassen ohne etwas im Inventar zu haben ist auch nicht möglich. Du hast {0} eingegeben", input);
                    Console.ResetColor();

                }
            }

        }

        private static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("Wähle bitte einen Befehl");
            Console.WriteLine("Mögliche Befehle: talk, attack, inventory, combine, move, take, drop, equip, unarm, heal, look und q (Spiel beenden)");
        }
        private static void SetPlayer(Person p)
        {
            SetPlayerName(p);
            SetPlayerSex(p);
        }
        private static void SetPlayerName(Person p)
        {
            if (Gamestarted)
            {
                Console.WriteLine("Bitte gib deinen Namen ein");
                string input = Console.ReadLine();
                ExitCheck(input);
                p.NameOfPerson = input;
            }

        }
        private static void SetPlayerSex(Person p)
        {
            string input = "";
            bool InputIsCorrect = false;
            while (InputIsCorrect == false && Gamestarted == true)
                try
                {
                    Console.WriteLine("Bitte wähle dein Geschlecht(female or male)");
                    input = Console.ReadLine();

                    if (ExitCheck(input))
                    {
                        break;
                    }

                    if (input == "male")
                    {
                        Person.SetSexMale(p);
                        InputIsCorrect = true;
                    }

                    else if (input == "female")
                    {
                        Person.SetSexFemale(p);
                        InputIsCorrect = true;
                    }
                    else throw new Exception();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bitte wähle female oder male, Deine Eingabe war " + input);
                    Console.ResetColor();
                }
        }

        private static void Talk(Person conversationPartner)
        {
            string input = string.Empty;
            int parsedInput = 0;
            bool whileLoopHelper = false;

            Console.WriteLine("");

            Console.WriteLine("Du redest mit " + conversationPartner.NameOfPerson);
            Console.WriteLine(conversationPartner.Introduction);

            while (whileLoopHelper == false)
            {
                try
                {
                    ShowQuestions(conversationPartner);
                    Console.WriteLine("Wähle eine Frage durch Eingabe des passenden Indices");
                    input = Console.ReadLine();
                    try
                    {
                        parsedInput = int.Parse(input);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bitte gebe eine Zahl ein. Deine Eingabe war {0}", input);
                        Console.ResetColor();
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine(conversationPartner.Antworten[parsedInput]);
                    if (parsedInput == conversationPartner.Fragen.Count - 1)  //Verabschiedung immer letzter Wert
                    {
                        Console.WriteLine("Die Konversation wurde beendet");
                        break;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bitte gebe einen gültigen Index an. Du hast {0} eingegeben", parsedInput);
                    Console.ResetColor();
                }
            }
        }
        public static void ShowQuestions(Person personWithQuestions)
        {
            foreach (var c in personWithQuestions.Fragen)
            {
                Console.WriteLine("Index: {0}, {1}", c.Key, c.Value);
            }
        }

        public static Person GetConversationPartner(Person inputPlayer)
        {
            int index = 0;
            string consoleInput = string.Empty;
            int parsedInput = 0;
            bool whileLoopHelper = false;
            foreach (Person c in inputPlayer.RoomPerson.ListOfPerson)
            {
                if (c.ShowInLook && c.IsMonster == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Index: {0} , Person: {1}", index, c.NameOfPerson);
                    Console.ResetColor();
                    index++;
                }
            }
            Person[] arrayOfPersons = (Person[])inputPlayer.RoomPerson.ListOfPerson.ToArray(typeof(Person));

            while (whileLoopHelper == false)
            {
                try
                {
                    Console.WriteLine("Wähle die Person, mit der Du reden möchtest durch Eingabe des passenden Index");
                    consoleInput = Console.ReadLine();
                    parsedInput = int.Parse(consoleInput);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bitte gebe eine Zahl ein. Du hast {0} eingeben ", consoleInput);
                    Console.ResetColor();
                    continue;
                }
                try
                {
                    if (parsedInput > arrayOfPersons.Length)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Diese Person gibt es nicht. Du hast {0} eingeben", parsedInput);
                    Console.ResetColor();
                    continue;
                }

                for (int i = 0; i < arrayOfPersons.Length; i++)
                {
                    if (i == parsedInput)
                    {
                        return arrayOfPersons[parsedInput];
                    }
                }
            }
            //Ende der Schleife
            return null;
        }
    }
}
