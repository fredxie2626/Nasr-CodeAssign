using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeAssign.Models.Contacts;
using System.IO;
using System.Xml;

namespace CodeAssign.Controllers.ContactController
{
    public class ContactsController : Controller
    {
        private ContactContext db = new ContactContext();
        // GET: Search Contact

        public ActionResult Index(String SearchBy, String Search)
        {
            if (string.IsNullOrEmpty(Search))
            {
                return View();
            }
            else
            {
                if (SearchBy == "FirstName")
                {
                    return View(db.Contacts.Where(x => x.FirstName == Search).ToList());
                }
                else if (SearchBy == "LastName")
                {
                    return View(db.Contacts.Where(x => x.LastName == Search).ToList());
                }
                else if (SearchBy == "Email")
                {
                    return View(db.Contacts.Where(x => x.Email == Search).ToList());
                }
                else
                {
                    string[] tokens = Search.Split(',');
                    Contact nearest = CompareNearest(tokens[0],
                                                     tokens[1]);
                    return View(db.Contacts.Where(x => x.ContactId == nearest.ContactId).ToList());
                }
            }
        }

        // GET: Contacts
        public ActionResult ListAll()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");

            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,FirstName,LastName,Email,Address,CityId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                setLatitudeLongitude(contact);

                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", contact.CityId);
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,FirstName,LastName,Email,Address,CityId,ProvinceId,Latitude,Longitude")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                setLatitudeLongitude(contact);

                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void setLatitudeLongitude(Contact contact)
        {
            StreamReader sr = null;

            City city = db.Cities.Find(contact.CityId);
            Province province = db.Provinces.Find(city.ProvinceId);

            string url = "http://maps.google.com/maps/api/geocode/xml?address="
                + contact.Address + " " + city.CityName + " " + province.ProvinceCode + " "
                       + "&sensor=false";

            WebClient wc = new WebClient();
            try
            {
                sr = new StreamReader(wc.OpenRead(url));
            }
            catch (Exception ex)
            {
                throw new Exception("The Error Occured" + ex.Message);
            }

            try
            {
                XmlTextReader xmlReader = new XmlTextReader(sr);
                bool latread = false;
                bool longread = false;

                while (xmlReader.Read())
                {
                    xmlReader.MoveToElement();
                    switch (xmlReader.Name)
                    {
                        case "lat":

                            if (!latread)
                            {
                                xmlReader.Read();
                                contact.Latitude = Convert.ToDouble(xmlReader.Value);
                                latread = true;

                            }
                            break;
                        case "lng":
                            if (!longread)
                            {
                                xmlReader.Read();
                                contact.Longitude = Convert.ToDouble(xmlReader.Value);
                                longread = true;
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An Error Occured" + ex.Message);
            }
        }

        public JsonResult GetFirstNames(String term)
        {
            List<String> contacts;
            contacts = db.Contacts.Where(x => x.FirstName.StartsWith(term)).ToList()
                       .Select(y => y.FirstName).ToList();

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLastNames(String term)
        {
            List<String> contacts;
            contacts = db.Contacts.Where(x => x.LastName.StartsWith(term)).ToList()
                       .Select(y => y.LastName).ToList();

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmails(String term)
        {
            List<String> contacts;
            contacts = db.Contacts.Where(x => x.Email.StartsWith(term)).ToList()
                       .Select(y => y.Email).ToList();

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }

        public Contact CompareNearest(String Latitude, String Longitude)
        {
            double currentLatitude = Convert.ToDouble(Latitude);
            double currentLongitude = Convert.ToDouble(Longitude);


            List<Contact> contacts = db.Contacts.ToList();

            Contact nearestContact = contacts.First();
            foreach (var place in contacts)
            {
                if (Distance(currentLatitude, currentLongitude, place.Latitude, place.Longitude) <
                    Distance(currentLatitude, currentLongitude, nearestContact.Latitude, nearestContact.Longitude))
                    nearestContact = place;
            }

            return nearestContact;
        }

        private double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(degToRad(lat1)) * Math.Sin(degToRad(lat2)) + Math.Cos(degToRad(lat1)) * Math.Cos(degToRad(lat2)) * Math.Cos(degToRad(theta));
            dist = Math.Acos(dist);
            dist = radToDeg(dist);
            dist = (dist * 60 * 1.1515) / 0.6213711922;
            return (dist);
        }

        private double degToRad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double radToDeg(double rad)
        {
            return (rad * 180.0 / Math.PI);
        }
    }
}
