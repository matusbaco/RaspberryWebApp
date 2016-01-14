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
    public class RelayEventsController : Controller
    {
        private RaspContext db = new RaspContext();


        // GET: RelayEvents/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            if (relayEvent == null)
            {
                return HttpNotFound();
            }
            return View(relayEvent);
        }

        // GET: RelayEvents/Create
        public ActionResult Create(Guid id)
        {
            ViewData["relayparentid"] = id;
            RelayEvent eventToCreate = new RelayEvent();
            eventToCreate.RelayID = id;
            eventToCreate.start = DateTime.Now;
            eventToCreate.duration = 1;
            eventToCreate.end = eventToCreate.start.AddMinutes(5);
            return View(eventToCreate);
        }

        // POST: RelayEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RelayID,start,duration,DurationType")] RelayEvent relayEvent)
        {
            if (ModelState.IsValid)
            {
                relayEvent.ID = Guid.NewGuid();
                int durationMultipler = 1;
                if (relayEvent.DurationType == "1")
                {
                    durationMultipler = 5;
                }
                else if (relayEvent.DurationType == "2")
                {
                    durationMultipler = 60;
                }
                relayEvent.end = relayEvent.start.AddMinutes(durationMultipler * relayEvent.duration);

                db.RelayEvents.Add(relayEvent);
                db.SaveChanges();

                return RedirectToAction("Details", "Relays", new { id = relayEvent.RelayID });

            }

            return View(relayEvent);
        }

        // GET: RelayEvents/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            if (relayEvent == null)
            {
                return HttpNotFound();
            }
            return View(relayEvent);
        }

        // POST: RelayEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RelayID,start,end,duration,DurationType")] RelayEvent relayEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relayEvent).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details", "Relays", new { id = relayEvent.RelayID });


            }
            return View(relayEvent);
        }

        // GET: RelayEvents/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            if (relayEvent == null)
            {
                return HttpNotFound();
            }
            return View(relayEvent);
        }

        // POST: RelayEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RelayEvent relayEvent = db.RelayEvents.Find(id);
            db.RelayEvents.Remove(relayEvent);
            db.SaveChanges();
            return RedirectToAction("Details", "Relays", new { id = relayEvent.RelayID });
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
