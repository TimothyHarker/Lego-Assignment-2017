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
            /*    Home home = new Home();
                et.ConnectToBrick();

                float[] HomeArray = new float[2];
                int i = 0;
                if (home.GoHome == 1)
                {
                    while (et.DetectColour )
                }
                while (i < 2)
                {
                    HomeArray[i] = HomeArray[i] + Co
                    i++;
                }*/
            Console.WriteLine(et.DetectDistance());
            Console.WriteLine("Where is Home? \n" +
              "Enter 0 for BlackRed. \n" +
              "Enter 1 for BlueRed \n" +
              "Enter 2 for BlueYellow \n" +
              "Enter 3 for YellowBlack.");
            int Home = Convert.ToInt32(Console.ReadLine());
            while (Home > 3)
            {
                Console.WriteLine("Please enter a valid selection to continue.");
                Home = Convert.ToInt32(Console.ReadLine());
            }
            bool RainbowDetected = false;
            while (RainbowDetected == false)
            {
                Thread.Sleep(2000);
                float distance = et.DetectDistance();
                Console.WriteLine("Distance Detected: " + distance);
                while (distance > 6)
                {
                    et.Forward();
                    Thread.Sleep(500);
                    distance = et.DetectDistance();
                    Console.WriteLine("Distance Detected: " + distance);
                    if (distance > 147)
                    {
                        et.Reverse();
                    }
                }

                et.DetectColour();
                float ColourDetected = et.DetectColour();
                Console.WriteLine("Colour Detected: " + ColourDetected);

                if (Home == 0)//BlackRedLoop
                {
                    if (ColourDetected == 5) //Red
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Right();
                    }
                    else if (ColourDetected == 0) //Black
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Left();
                    }
                    else if (ColourDetected == 3) //Blue
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Right();
                    }
                    else //1 = Yellow
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Left();
                    }
                }

                else if (Home == 1) //BlueRed
                {
                    if (ColourDetected == 5) //Blue
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Right();
                    }
                    else if (ColourDetected == 3) //Red
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Left();
                    }
                    else if (ColourDetected == 1) //Yellow
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Right();
                    }
                    else //Black
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Left();
                    }
                }

                else if (Home == 2)//BlueYellowLoop
                {
                    if (ColourDetected == 1) //Yellow
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Right();
                    }
                    else if (ColourDetected == 3) //Blue
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Left();
                    }
                    else if (ColourDetected == 0) //Black
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Right();
                    }
                    else //Red
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Left();
                    }
                }

                else //BlackYellow Loop
                {
                    if (ColourDetected == 0) //Black
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Right();
                    }
                    else if (ColourDetected == 1) //Yellow
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn15Left();
                    }
                    else if (ColourDetected == 5) //Red
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Right();
                    }
                    else //3 = Blue
                    {
                        Thread.Sleep(2000);
                        et.Reverse();
                        Thread.Sleep(2000);
                        et.Turn90Left();
                    }
                }
            }
        }
    }
}
