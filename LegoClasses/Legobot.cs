using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;

namespace LegoClasses
{
    public class Legobot
    {
        public Brick brick { get; set; }

        public async void ConnectToBrick()
        {
            brick = new Brick(new UsbCommunication());
            await brick.ConnectAsync();
        }

        public async void Forward()
        {
            await brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.A | OutputPort.D, 30);
            //brick.BatchCommand.TurnMotorAtPower(OutputPort.A | OutputPort.D, 30);
            //await brick.BatchCommand.SendCommandAsync();
        }

        public async void Reverse()
        {
            await brick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.A | OutputPort.D, -30);
        }

        public async void Stop()
        {
            await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A | OutputPort.D, 0, 2000, false);
        }

        public async void Turn15Left()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 30, 300, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -30, 300, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public async void Turn15Right()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, -30, 300, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, 30, 300, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public async void Turn90Left()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 30, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -30, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

        public async void Turn90Right()
        {
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.A, 30, 1000, false);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.D, -30, 1000, false);
            await brick.BatchCommand.SendCommandAsync();
        }

    }
}
