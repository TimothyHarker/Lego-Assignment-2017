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

    }
}
