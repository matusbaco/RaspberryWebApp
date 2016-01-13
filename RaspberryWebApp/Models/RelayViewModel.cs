using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryWebApp.Models
{
    public class RelayViewModel
    {
        public Relay Relay { get; set; }
        public List<RelayEvent> RelayEvents { get; set; }

    }
}
