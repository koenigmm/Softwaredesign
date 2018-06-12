using System;
namespace DesPatternDecorator
{
    public class Spielfigur
    {
        public  virtual void  Drohe()
        {
            Console.Write("Drohung");
        }
    }

    class Monster : Spielfigur
    {
        public override void Drohe()
        {
            Console.Write("Grrrrr!");
        }
    } 


    class Held : Spielfigur
    {
        public override void Drohe()
        {
            Console.Write("Weiche zurück!");
        }        
    }


    // Decorator
    class ErkaelteteFigur : Spielfigur
    {
        private Spielfigur _original;

        public ErkaelteteFigur(Spielfigur original)
        {
            _original = original; 
        }
        public override void Drohe()
        {
            _original.Drohe();
            Console.Write(" Hust!");
        }
    }

    class HeisereFigur : Spielfigur
    {
        private Spielfigur _original;

        public HeisereFigur(Spielfigur original)
        {
            _original = original; 
        }
        public override void Drohe()
        {
            Console.Write("Räusper...");
            _original.Drohe();
        }
    }

        class RoechelndeFigur : Spielfigur
    {
        private Spielfigur _original;

        public RoechelndeFigur(Spielfigur original)
        {
            _original = original; 
        }
        public override void Drohe()
        {
            _original.Drohe();
            Console.Write(" Röchel...!");
        }
    }
}