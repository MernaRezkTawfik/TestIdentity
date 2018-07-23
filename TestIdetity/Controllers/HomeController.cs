using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestIdetity.Models;
using TestIdetity.ViewModels;
using System.Data.Entity;

namespace TestIdetity.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
       [HttpGet]
        public ActionResult Index()
        {
            var UpcomingGigs = _context.gigs
                .Include(g => g.Artist)
                .Include(g => g.genre);
                //.Where(g=>  g.DateTime > DateTime.Now);  //filter only gigs in future
            

            var viewmodel = new HomeViewModel
            {
                UpComingGigs = UpcomingGigs,
                Actions = User.Identity.IsAuthenticated,
                Heading="Upcoming Gigs"
            };
            return View("Gigs",viewmodel);
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}