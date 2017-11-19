using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
using System.Threading;

namespace LegoClasses
{
    public class Legobot
    {
        public Brick brick { get; set; }

        public async void ConnectToBrick()
        {
            brick = new Brick(new UsbCommunication());
            await brick.ConnectAsync();
            brick.Ports[InputPort.Two].SetMode(ColorMode.Color);
        }

        public async void Forward()
        {
            await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A | OutputPort.D, 20, 1000, false);
            //brick.BatchCommand.TurnMotorAtPower(OutputPort.A | OutputPort.D, 30);
            //await brick.BatchCommand.SendCommandAsync();
        }

        public async void Reverse()
        {
            await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A | OutputPort.D, -35, 1000, false);
        }

        public async void Stop()
        {
            await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A | OutputPort.D, 0, 2000, false);
        }

        public async void Turn15Right()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 40, 300, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -40, 300, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public async void Turn15Left()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -40, 300, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 40, 300, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public async void Turn90Right()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 30, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -30, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public async void Turn90Left()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 30, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -30, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public float DetectDistance()
        {
            return brick.Ports[InputPort.Three].SIValue;
        }

        public float DetectColour()
        {
            float[] Colours = new float[10];
            int i = 0;
            while (i < 10)
            {
                Colours[i] = Colours[i] + brick.Ports[InputPort.Two].SIValue;
                Console.WriteLine("ColourArray" + Colours[i]);
                i++;
                Thread.Sleep(100);

            }

            Colours.Sum();
            Colours.Average();
            float ColourDetected = Colours.Average();
            return ColourDetected;
        }

        public async void ReadColourTurn()
        {
            float distance = brick.Ports[InputPort.Three].SIValue;
            if (distance < 6)
            {
                DetectColour();
                Console.WriteLine(DetectColour());
                if (DetectColour() == 0)
                {
                    Stop();
                    Reverse();
                    Turn15Right();
                }
                else
                {
                    Stop();
                    Reverse();
                    Turn15Left();
                }
            }
        }

    }
}
