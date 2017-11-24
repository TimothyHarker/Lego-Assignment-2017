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
                    if (distance > 147)
                    {
                        et.Reverse();
                    }
                }

                et.DetectColour();
                float ColourDetected = et.DetectColour();
                Console.WriteLine("Colour Detected: " + ColourDetected);

                //BlackRedLoop
                if (ColourDetected == 5) //Red
                {
                    ColourOne = true;
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Right();
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 0) //Black
                {
                    ColourTwo = true;
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn15Left();
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else if (ColourDetected == 3) //Blue
                {
                    ColourOne = false;
                    ColourTwo = false;
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Right();
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
                else //1 = Yellow
                {
                    ColourOne = false;
                    ColourTwo = false;
                    Thread.Sleep(2000);
                    et.Reverse();
                    Thread.Sleep(2000);
                    et.Turn90Left();
                    Debug.WriteLine(ColourOne);
                    Debug.WriteLine(ColourTwo);
                }
            }

            Debug.Write("Home Base Found");

        }
    }
}
