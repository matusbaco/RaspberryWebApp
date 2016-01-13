using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryWebApp.Models
{
    public class DeviceViewModel
    {

        public Device Device { get; set; }
        public List<Relay> Relays { get; set; }

    }
}
