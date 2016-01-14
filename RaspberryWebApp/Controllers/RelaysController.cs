using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaspberryWebApp.DAL;
using RaspberryWebApp.Models;

namespace RaspberryWebApp.Controllers
{
    public class RelaysController : Controller
    {
        private RaspContext db = new RaspContext();

        // GET: Relays/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relay relay = db.Relays.Find(id);
            if (relay == null)
            {
                return HttpNotFound();
            }
            DateTime todayZero = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            
            var relayEvents = db.RelayEvents.Where(x => x.RelayID == relay.ID ).ToList<RelayEvent>();
            //&& (x.start <= todayZero && x.end >=todayZero
            relay.RelayEvents = relayEvents;
            return View(relay);
        }

        // GET: Relays/Create
        public ActionResult Create(Guid id)
        {         
            Relay relay = new Relay();         
            relay.DeviceID = id;
            return View(relay);
        }

        // POST: Relays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DeviceID")] Relay relay)
        {
            if (ModelState.IsValid)
            {
                relay.ID = Guid.NewGuid();
                relay.Index = GetFreeIndex(relay);
                db.Relays.Add(relay);
                db.SaveChanges();
                return RedirectToAction("Details", "Devices", new { id = relay.DeviceID });
            }

            return View(relay);
        }

        private int GetFreeIndex(Relay relay)
        {
            var relays = db.Relays.Where(x => x.DeviceID == relay.DeviceID).ToList<Relay>();

            for (int i = 0; i <= relays.Count(); i++)
            {
                if (!relays.Where(x => x.Index == i).Any())
                {
                    return i;
                }

            }

            return relays.Count()+1;
        }

        // GET: Relays/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relay relay = db.Relays.Find(id);
            if (relay == null)
            {
                return HttpNotFound();
            }
            return View(relay);
        }

        // POST: Relays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Index,Name,DeviceID")] Relay relay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Devices", new { id = relay.DeviceID });
            }
            return View(relay);
        }

        // GET: Relays/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relay relay = db.Relays.Find(id);
            if (relay == null)
            {
                return HttpNotFound();
            }
            return View(relay);
        }

        // POST: Relays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Relay relay = db.Relays.Find(id);
            db.Relays.Remove(relay);
            db.SaveChanges();
            return RedirectToAction("Details", "Devices", new { id = relay.DeviceID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
