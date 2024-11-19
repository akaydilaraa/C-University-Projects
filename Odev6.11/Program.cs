using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev6._11
{
    public class Motor
    {
        public int Guc { get; set; }
        public string Tip { get; set; }

        public Motor(int guc, string tip)
        {
            Guc = guc;
            Tip = tip;
        }

        public string MotorBilgi()
        {
            return $"{Guc} HP, {Tip}";
        }
    }

    public class Otomobil
    {
        public string Marka { get; set; }
        public Motor Motor { get; set; }

        public Otomobil(string marka, Motor motor)
        {
            Marka = marka;
            Motor = motor;
        }

        public string OtomobilBilgi()
        {
            return $"{Marka} - {Motor.MotorBilgi()}";
        }
    }

    // Kullanım
    class Program
    {
        static void Main(string[] args)
        {
            Motor motor = new Motor(150, "Dizel");
            Otomobil otomobil = new Otomobil("Toyota", motor);

            Console.WriteLine(otomobil.OtomobilBilgi());
            Console.Read();
        }
    }
}
