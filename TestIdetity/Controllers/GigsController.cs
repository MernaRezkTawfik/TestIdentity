using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestIdetity.Models;
using TestIdetity.ViewModels;

namespace TestIdetity.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs

            [Authorize]
        public ActionResult Create()
        {
            var viewmodel = new GigFormViewModel
            {
                Genres = _context.genres.ToList()
            };
            return View(viewmodel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                viewmodel.Genres = _context.genres.ToList();
                return View("Create", viewmodel);
                
            }
            
           
            var gig = new Gig()
            {
                ArtistId= User.Identity.GetUserId(),
                Venue = viewmodel.Venue,
                DateTime =viewmodel.GetDateTime(),
             
                GenreId=viewmodel.Genre

            };
            _context.gigs.Add(gig);
            _context.SaveChanges();
           return  RedirectToAction("Index", "Home");

        }
        [Authorize]
        public ActionResult Attending()
        {
            var id = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == id)
                .Select(a => a.gig)
                .Include(g=>g.Artist)
                .Include(g=>g.genre)
                .ToList();

                var viewmodel = new HomeViewModel
                {
                    UpComingGigs=gigs,
                    Actions=User.Identity.IsAuthenticated,
                    Heading="Gigs I'm Attending"

                };


                return View("Gigs",viewmodel);
        }
    }
}