using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;
using LegoClasses;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Legobot et = new Legobot();

        public MainWindow()
        {
            InitializeComponent();
            et.ConnectToBrick();
        }

        private void RedBlackBTN_Click_1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(et.DetectDistance());
            bool ColourOne = false;
            bool ColourTwo = false;

            while (ColourOne != true || ColourTwo != true)
            {
                Thread.Sleep(2000);
                float distance = et.DetectDistance();
                Debug.WriteLine("Distance Detected: " + distance);
                while (distance > 6)
                {
                    et.Forward();
                    Thread.Sleep(500);
                    distance = et.DetectDistance();
                    Debug.WriteLine("Distance Detected: " + distance);

                }

                et.DetectColour();
                float ColourDetected = et.DetectColour();
                Console.WriteLine("Colour Detected: " + ColourDetected);

                //BlackRedLoop
                if (ColourDetected == 5) //Red
                {

                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Right();
                    ColourOne = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 0) //Black
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Left();
                    ColourTwo = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 3) //Blue
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Right();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else //1 = Yellow
                {

                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Left();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
            }

            et.BaseFound();
            Debug.Write("Home Base Found");

        }

        private void BlueRedBTN_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(et.DetectDistance());
            bool ColourOne = false;
            bool ColourTwo = false;

            while (ColourOne != true || ColourTwo != true)
            {
                Thread.Sleep(2000);
                float distance = et.DetectDistance();
                Debug.WriteLine("Distance Detected: " + distance);
                while (distance > 6)
                {
                    et.Forward();
                    Thread.Sleep(500);
                    distance = et.DetectDistance();
                    Debug.WriteLine("Distance Detected: " + distance);
                }

                et.DetectColour();
                float ColourDetected = et.DetectColour();
                Console.WriteLine("Colour Detected: " + ColourDetected);

                //BlueRedLoop
                if (ColourDetected == 3) //Blue
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Right();
                    ColourOne = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 5) //red
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Left();
                    ColourTwo = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 1) //Yellow
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Right();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else //Black
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Left();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
            }
            et.BaseFound();
            Debug.Write("Home Base Found");
        }

        private void BlueYellowBTN_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(et.DetectDistance());
            bool ColourOne = false;
            bool ColourTwo = false;

            while (ColourOne != true || ColourTwo != true)
            {
                Thread.Sleep(2000);
                float distance = et.DetectDistance();
                Debug.WriteLine("Distance Detected: " + distance);
                while (distance > 6)
                {
                    et.Forward();
                    Thread.Sleep(500);
                    distance = et.DetectDistance();
                    Debug.WriteLine("Distance Detected: " + distance);
                }

                et.DetectColour();
                float ColourDetected = et.DetectColour();
                Console.WriteLine("Colour Detected: " + ColourDetected);

                //BlueYellowLoop
                if (ColourDetected == 1) //Yellow
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Right();
                    ColourOne = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 3) //Blue
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Left();
                    ColourTwo = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 0) //Black
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Right();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else //Red
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Left();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
            }
            et.BaseFound();
            Debug.Write("Home Base Found");
        }

        private void YellowBlackBTN_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(et.DetectDistance());
            bool ColourOne = false;
            bool ColourTwo = false;

            while (ColourOne != true || ColourTwo != true)
            {
                Thread.Sleep(2000);
                float distance = et.DetectDistance();
                Debug.WriteLine("Distance Detected: " + distance);
                while (distance > 6)
                {
                    et.Forward();
                    Thread.Sleep(500);
                    distance = et.DetectDistance();
                    Debug.WriteLine("Distance Detected: " + distance);

                }

                et.DetectColour();
                float ColourDetected = et.DetectColour();
                Console.WriteLine("Colour Detected: " + ColourDetected);

                //YellowBlackLoop
                if (ColourDetected == 0) //Black
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Right();
                    ColourOne = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 1) //Yellow
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Left();
                    ColourTwo = true;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 5) //Red
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Right();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else //3 = Blue
                {
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Left();
                    ColourOne = false;
                    ColourTwo = false;
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
            }
            et.BaseFound();
            Debug.Write("Home Base Found");
        }
    }
}
