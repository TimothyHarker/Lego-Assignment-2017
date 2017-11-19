using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegoClasses;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
using System.Threading;
namespace LegoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Legobot et = new Legobot();
            et.ConnectToBrick();
            Thread.Sleep(2000);
            float distance = et.DetectDistance();
            Console.WriteLine("Distance Detected: "+ distance);
            while (distance > 6)
            { 
                et.Forward();
                Thread.Sleep(2000);
                distance = et.DetectDistance();
                Console.WriteLine("Distance Detected: "+ distance);
            }
            et.DetectColour();
            float ColourDetected = et.DetectColour();
            Console.WriteLine("Colour Detected: "+ ColourDetected);
            if (ColourDetected == 0)
            {
                Thread.Sleep(2000);
                et.Reverse();
                Thread.Sleep(2000);
                et.Turn15Right();
            }
            else
            {
                Thread.Sleep(2000);
                et.Reverse();
                Thread.Sleep(2000);
                et.Turn15Left();


            }
            Console.ReadLine();
        }
    }
}
