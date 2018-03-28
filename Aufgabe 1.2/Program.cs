using System;

namespace Aufgabe_1._2
{
    class Program
    {
        static string[] subjects = { "Harry", "Hermine", "Ron", "Hagrid", "Snape", "Dumbledore" };
        static string[] verbs = { "braut", "liebt", "studiert", "hasst", "zaubert", "zerstört" };
        static string[] objects = { "Zaubertränke", "den Grimm", "Lupin", "Hogwards", "die Karte des Rumtreibers", "Dementoren" };

        static void Main(string[] args)
        {

            String[] vers1 = getVerse();
            String[] vers2 = getVerse();
            String[] vers3 = getVerse();
            String[] vers4 = getVerse();
            String[] vers5 = getVerse();

            for (int i = 0; i < vers1.Length; i++)
            {
                Console.Write(vers1[i] + " ");

            }
            Console.WriteLine("");

            for (int i = 0; i < vers2.Length; i++)
            {
                Console.Write(vers2[i] + " ");

            }
            Console.WriteLine("");

            for (int i = 0; i < vers3.Length; i++)
            {
                Console.Write(vers3[i] + " ");

            }
            Console.WriteLine("");

            for (int i = 0; i < vers4.Length; i++)
            {
                Console.Write(vers4[i] + " ");

            }

            Console.WriteLine("");

            for (int i = 0; i < vers5.Length; i++)
            {
                Console.Write(vers5[i] + " ");

            }
            Console.WriteLine("");

        }

        public static int getRandomInt(String[] satzteil)
        {
            Random rnd = new Random();
            int output = rnd.Next(0, satzteil.Length);
            return output;
        }

        public static String[] getVerse()
        {
            String[] output = { subjects[getRandomInt(subjects)], verbs[getRandomInt(verbs)], objects[getRandomInt(objects)] };
            return output;
        }
    }
}
