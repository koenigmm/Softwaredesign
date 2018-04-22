using System;
using System.Text;
using System.Collections;

namespace Aufgabe_3_Zahlensysteme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertDecimalToHexal(4));
            Console.WriteLine(ConvertHexalToDezimal(100));
            Console.WriteLine(Math.Pow(100, 2));
            Console.WriteLine(ConvertToBaseFromDecimal(3, 100));
            Console.WriteLine(ConvertToDecimalFromBase(5, 100));
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

        public static int ConvertHexalToDezimal(int hexal)
        {
            //int count = 4;
            int temp = hexal;
            double hex = 6;
            double ii = 0;

            ArrayList hexalAsList = new ArrayList();
            do
            {
                hexalAsList.Add(temp % 10);
                temp /= 10;
            } while (temp > 0);  //Dreht schon um

            int[] hexalAsArray = hexalAsList.ToArray(typeof(int)) as int[];
            double output = 0;
            int forOutput = 0;

            for (int i = 0; i < hexalAsArray.Length; i++)
            {
                ii = i; //macht aus i double;
                output += output + hexalAsArray[i] * Math.Pow(hex, i);
            }
            forOutput = Convert.ToInt32(output);
            return forOutput;
        }

        public static int ConvertToBaseFromDecimal(int toBase, int dec)
        {
            int arraySize = 6;
            int[] value = new int[arraySize];
            int i = 0;
            int toBaseOut = 0;
            StringBuilder myStringbuilder = new StringBuilder();
            //int reverseHexaValue = 0; 

            while (dec > 0)
            {
                value[i] = dec % toBase;
                i++;
                dec = dec / toBase;
            }

            Array.Reverse(value);

            foreach (int k in value)
            {
                myStringbuilder.Append(k);
            }

            toBaseOut = int.Parse(myStringbuilder.ToString());


            return toBaseOut;
        }


        public static int ConvertToDecimalFromBase(int fromBase, int number)
        {
            //int count = 4;
            int temp = number;
            double fromBaseValue = fromBase;

            ArrayList valueAsList = new ArrayList();
            do
            {
                valueAsList.Add(temp % 10);
                temp /= 10;
            } while (temp > 0);  //Dreht schon um

            int[] valueAsArray = valueAsList.ToArray(typeof(int)) as int[];
            double output = 0;
            int forOutput = 0;

            for (int i = 0; i < valueAsArray.Length; i++)
            {
                output += output + valueAsArray[i] * Math.Pow(fromBaseValue, i);
            }
            forOutput = Convert.ToInt32(output);
            return forOutput;
        }


        //noch in Arbeit 
        public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase)
        {
            int placeholder1 = 0;
            int placeholder2 = 0;
            int dezimal = 10;
            if (fromBase != dezimal && fromBase != 0)
            {
                placeholder1 = ConvertToDecimalFromBase(fromBase, number);
                placeholder2 = ConvertToBaseFromDecimal(toBase, number);
            }

            if (toBase == dezimal)
                return placeholder1;
            else return placeholder2;
        }


        public static int ReverseInt(int nonReverse) // wird nicht gebraucht 
        {
            int reverse = 0;
            while (nonReverse > 0)
            {
                int rest = nonReverse % 10;
                reverse = (reverse * 10) + rest;
                nonReverse /= 10;
            }
            return reverse;
        }
    }
}