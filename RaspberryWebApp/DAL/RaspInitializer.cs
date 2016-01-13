using RaspberryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryWebApp.DAL
{
    public class RaspInitializer : DropCreateDatabaseIfModelChanges<RaspContext>

    //DropCreateDatabaseIfModelChanges
    //DropCreateDatabaseAlways
    {
        protected override void Seed(RaspContext context)
        {

            var devices = new List<Device>();
            var relays = new List<Relay>();
            var relayevents = new List<RelayEvent>();

            Device device1 = new Device();
            device1.devicenumber = 0;
            device1.Name = "0001d";
            device1.ID = Guid.NewGuid();

            devices.Add(device1);

            Relay rel1 = new Relay();

            rel1.DeviceID = device1.ID;
            rel1.Index = 0;
            rel1.Name = "r01:0001d";
            rel1.ID = Guid.NewGuid();
            relays.Add(rel1);

            RelayEvent ev11 = new RelayEvent { end = DateTime.Now, start = DateTime.Now, ID = Guid.NewGuid(), DurationType = "1", duration = 15, RelayID = rel1.ID };
            relayevents.Add(ev11);


            devices.ForEach(s => context.Devices.Add(s));
            context.SaveChanges();

            relays.ForEach(s => context.Relays.Add(s));
            context.SaveChanges();

            relayevents.ForEach(s => context.RelayEvents.Add(s));
            context.SaveChanges();
            
        }

    }
}