using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGym.Models;

namespace VirtualGym.Controllers
{
    public class GymController : Controller
    {
        private ApplicationDbContext _context;

        public GymController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Gym
        [Route("Gym")]
        public ActionResult Index()
        {
            var model = _context.Gym.ToList();
            return View(model);
        }

        [Route("Gym/CreateNewGym")]
        public ActionResult CreateNewGym()
        {
            return View("CreateNewGym");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Exclude ="Id")] Gym newGym)
        {
            if (!ModelState.IsValid)    
                return View(newGym);

            if (newGym.Id == 0)
                _context.Gym.Add(newGym);
            else
            {
                var gym = _context.Gym.SingleOrDefault(g => g.Id == newGym.Id);
                gym.Name = newGym.Name;
                gym.Phone = newGym.Phone;
                gym.Address = newGym.Address;
                gym.Policy = newGym.Policy;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Gym");
        }

        [Route("Gym/Details/{id}")]
        public ActionResult Details(int id)
        {
            var gym = _context.Gym.SingleOrDefault(g => g.Id == id);
            
            if (gym == null)
                return HttpNotFound();

            return View(gym);
        }

        [Route("Gym/Update/{id}")]
        public ActionResult Update(int id)
        {
            var gym = _context.Gym.SingleOrDefault(g => g.Id == id);

            if (gym == null)
                return HttpNotFound();

            return View(gym);
        }

        public ActionResult Delete(int id)
        {
            var gym = _context.Gym.SingleOrDefault(g => g.Id == id);

            if (gym == null)
                return HttpNotFound();

            _context.Gym.Remove(gym);
            _context.SaveChanges();

            return RedirectToAction("Index", "Gym");

            

            
        }

    }
}