using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryWebApp.Models
{

    public class Relay
    {
        public List<RelayEvent> RelayEvents { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Guid DeviceID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

    }
}
