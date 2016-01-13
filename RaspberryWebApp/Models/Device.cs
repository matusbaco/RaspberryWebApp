using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryWebApp.Models
{
    public class Device
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public int devicenumber { get; set; }
        public string Name { get; set; }
        public bool IsSuccess { get; set; }
        public List<Relay> Relays { get; set; }
        public Device()
        {
            Relays = new List<Relay>();
        }
    }
}
