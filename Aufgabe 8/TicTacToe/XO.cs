using System;

namespace TicTacToe
{
    public class TicTacToe
    {
        private static int firstLine = 2, secondLine = 5, thirdLine = 9;
        private static string startGameMessage = "Start TicTacToe. Press q or enter exit to leave the game";
        private static string invitation = "Please choose your index";
        private static char[] gameData = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static bool[] usedIndices = new bool[gameData.Length];
        private static bool win = false;

        public static void XO_Game()
        {
            int counter = 1;
            char turn = 'X';
            int input = 12;
            char charX = 'X';
            char charO = 'O';

            Console.WriteLine(startGameMessage);
            PrintTicTacToe();
            //Start Game
            Console.WriteLine("");
            Console.WriteLine(turn + " " + invitation + "       Round: " + counter);

            for (int i = 0; counter <= gameData.Length; i++)
            {
                CheckWinCondition(gameData);

                if (win)
                {
                    break;
                }
                string inputConsole = Console.ReadLine();

                if (inputConsole == "q" || inputConsole == "exit")
                {
                    break;
                }

                try
                {
                    input = Int32.Parse(inputConsole) - 1;                    //Prüft bereits ob inputConsole in Zahl umgewandelt werden kann
                    CheckInput(input);                                        //Prüft ob input im Bereich 1 bis 9 ist
                    try
                    {
                        CheckIfIntAlreadyUsed(input);
                        gameData[input] = turn;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Index: " + (input + 1) + " is already used. Please enter a new number (1-9)");
                        Console.ResetColor();
                        counter--;
                    }

                    usedIndices[input] = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number (1-9). You entered : " + inputConsole);
                    Console.ResetColor();
                    counter--;
                }

                counter++;
                PrintTicTacToe();

                if (counter % 2 == 0)
                    turn = charO;
                else turn = charX;

                Console.WriteLine("");
                Console.WriteLine("");
                if (counter < 10)
                {
                    Console.WriteLine(turn + " " + invitation + "       Round: " + counter);
                }
            }
        }

        private static void PrintTicTacToe()
        {
            //Ausgabe Spielfeld
            Console.WriteLine("");

            for (int i = 0; i <= firstLine; i++)
            {
                Console.Write(gameData[i] + "   ");
            }

            Console.WriteLine("");

            for (int i = firstLine + 1; i <= secondLine; i++)
            {
                Console.Write(gameData[i] + "   ");
            }

            Console.WriteLine("");

            for (int i = secondLine + 1; i <= thirdLine - 1; i++)
            {
                Console.Write(gameData[i] + "   ");
            }
        }

        private static void CheckInput(int intToCheck)
        {
            if (intToCheck < 0 || intToCheck > 9)
                throw new Exception();
        }

        private static void CheckIfIntAlreadyUsed(int intToCheck)
        {
            if (usedIndices[intToCheck] == true)
            {
                throw new Exception();
            }
        }

        private static void CheckWinCondition(char[] charArrayToTest)
        {
            /*
            int[] case1 =  {0,1,2};
            int[] case2 =  {3,4,5};
            int[] case3 =  {6,7,8}; 
            int[] case4 =  {0,3,6};
            int[] case5 =  {1,4,7};
            int[] case6 =  {2,5,8};t
            int[] caseDiag1 =  {0,4,8};
            int[] caseDiag2 =  {6,4,2};
             */


            //TODO Eleganteren Weg finden
            if (charArrayToTest[0] == charArrayToTest[1] && charArrayToTest[2] == charArrayToTest[0] && charArrayToTest[2] == charArrayToTest[1])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[0] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[4] == charArrayToTest[4] && charArrayToTest[5] == charArrayToTest[4] && charArrayToTest[5] == charArrayToTest[4])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[3] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[6] == charArrayToTest[7] && charArrayToTest[8] == charArrayToTest[6] && charArrayToTest[8] == charArrayToTest[7])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[6] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[0] == charArrayToTest[3] && charArrayToTest[6] == charArrayToTest[0] && charArrayToTest[6] == charArrayToTest[3])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[0] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[1] == charArrayToTest[4] && charArrayToTest[7] == charArrayToTest[1] && charArrayToTest[7] == charArrayToTest[4])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[1] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[2] == charArrayToTest[5] && charArrayToTest[8] == charArrayToTest[2] && charArrayToTest[8] == charArrayToTest[5])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[2] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[0] == charArrayToTest[4] && charArrayToTest[8] == charArrayToTest[0] && charArrayToTest[8] == charArrayToTest[4])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[0] + " is the winner");
                Console.WriteLine("");
            }
            if (charArrayToTest[6] == charArrayToTest[4] && charArrayToTest[2] == charArrayToTest[6] && charArrayToTest[2] == charArrayToTest[4])
            {
                win = true;
                Console.WriteLine("Player " + charArrayToTest[6] + " is the winner");
                Console.WriteLine("");
            }



        }
    }
}