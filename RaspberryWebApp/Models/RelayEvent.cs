using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RaspberryWebApp.Models
{
    public class RelayEvent
    {
        public Guid RelayID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int duration { get; set; }
        public IEnumerable<SelectListItem> DurationTypes { get; set; }
        public string DurationType { get; set; }
        public RelayEvent()
        {
            DurationTypes = GetEventDurationType();
            duration = 15;
        }


        public SelectListItem[] GetEventDurationType()
        {
            return new SelectListItem[] {
                    new SelectListItem() {
                 Text = "Minutes",
                    Value ="1",
                     Selected=true,
                },
               new SelectListItem() {
                      Text ="Hours",
                    Value ="2",

                },
            };
        }
    }
}
