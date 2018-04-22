﻿using System;
using System.Text;

namespace Aufgabe_3_Zahlensysteme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertDecimalToHexal(4));
        }

        public static int ConvertDecimalToHexal(int dec)
        {
            int hex = 6;
            int arraySize = 4;
            int[] hexaValue = new int[arraySize];
            int i = 0;
            int hexaOut = 0;
            StringBuilder myStringbuilder = new StringBuilder();
            //int reverseHexaValue = 0; 
            
            while (dec > 0)
            {
                hexaValue[i] = dec % hex;
                i++;
                dec = dec / hex;
            }

            Array.Reverse(hexaValue);

            foreach (int k in hexaValue)
            {
                myStringbuilder.Append(k);
            }

            hexaOut = int.Parse(myStringbuilder.ToString());


            return hexaOut;
        }

        public static int ConvertHexalToDezimal(int hexal )
        {
                        
        }

        public static int ReverseInt (int nonReverse)
        {
            int reverse = 0;
            while (nonReverse >0)
            {
                int rest = nonReverse % 10;
                reverse = (reverse * 10) + rest;
                nonReverse /= 10;
            }
            return reverse;
        }
    }
}
