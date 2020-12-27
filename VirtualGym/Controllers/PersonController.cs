using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGym.Models;


namespace VirtualGym.Controllers
{
    public class PersonController : Controller
    {
        private ApplicationDbContext _context;

        public PersonController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Person
        public ActionResult Index()
        {
            return View(_context.Person.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Phone, Role, ImageFile")] Person person)
        {
            
                                

            
            var fileName = Path.GetFileNameWithoutExtension(person.ImageFile.FileName);
            var extension = Path.GetExtension(person.ImageFile.FileName);
            if (person.ImageFile != null)
            {
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                person.Image = fileName;
                var uploadDir = "~/App_Files/Images";

                person.ImageFile.SaveAs(Path.Combine(Server.MapPath(uploadDir), fileName));

                _context.Person.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View("Create", person);

        }


        public ActionResult Details(int id)
        {
            var person = _context.Person.SingleOrDefault(p => p.Id == id);

            if (person == null)
                return HttpNotFound();

            return View(person);
        }

        public ActionResult Edit(int id)
        {
            var person = _context.Person.SingleOrDefault(p => p.Id == id);

            if (person == null)
                return HttpNotFound();

            return View(person);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
                return View("Edit", person);

            var editedPerson = _context.Person.SingleOrDefault(p => p.Id == person.Id);
            editedPerson.FirstName = person.FirstName;
            editedPerson.LastName = person.LastName;
            editedPerson.Phone = person.Phone;
            editedPerson.Role = person.Role;
            
            _context.SaveChanges();

            return RedirectToAction("Index","Person");
        }

        public ActionResult Delete(int id)
        {
            var person = _context.Person.SingleOrDefault(p => p.Id == id);

            if (person == null)
                return HttpNotFound();

            _context.Person.Remove(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}