using System;

namespace Aufgabe_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            String whichType = args[0];
            double d = double.Parse(args[1]);

            if (whichType.Equals("k"))
            {
                getKugelInfo(d);
            }

            if (whichType.Equals("w"))
            {
                getCubeInfo(d);
            }

            if (whichType.Equals("o"))
            {
                getOktaederInfo(d);
            }

        }

        static public double getCubeVolume(double dd)
        {
            double double_DD = dd * dd;
            return double_DD;

        }

        static public double getCubeSurface(double dd)
        {
            double surface_DD = (6 * dd) * (6 * dd);
            return surface_DD;
        }

        static public void getCubeInfo(double dd_info)
        {
            double volumen_output = Math.Round(getCubeVolume(dd_info), 2);
            double surface_output = Math.Round(getCubeSurface(dd_info), 2);
            Console.WriteLine("Würfel: A = " + surface_output + "  |  V = " + volumen_output);
        }

        static public double getKugelVolume(double dd)
        {
            double volume_DD = ((Math.PI * dd) * (Math.PI * dd) * (Math.PI * dd)) / 6;
            return volume_DD;
        }

        static public double getKugelSurface(double dd)
        {
            double kugelsurface_DD = (Math.PI * (dd) * (dd));
            return kugelsurface_DD;
        }

        static public void getKugelInfo(double dd_info)
        {
            double volumen_output = Math.Round(getKugelVolume(dd_info), 2);
            double surface_output = Math.Round(getKugelSurface(dd_info), 2);
            Console.WriteLine("Kugel: A = " + surface_output + "  |  V = " + volumen_output);
        }


        static public double getOktaederVolume(double dd)
        {
            double oktaederVolume = (Math.Sqrt(2)) * ((dd) * (dd) * (dd)) / 3;
            return oktaederVolume;
        }

        static public double getOktaederSurface(double dd)
        {
            double oktaederSurface = 2 * (Math.Sqrt(3)) * ((dd) * (dd));
            return oktaederSurface;
        }

        static public void getOktaederInfo(double dd_info)
        {
            double volumen_output = Math.Round(getOktaederVolume(dd_info), 2);
            double surface_output = Math.Round(getOktaederSurface(dd_info), 2);
            Console.WriteLine("Okaeder: A = " + surface_output + "  |  V = " + volumen_output);
        }
    }
}
