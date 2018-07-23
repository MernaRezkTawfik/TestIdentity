using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestIdetity.Dtos;
using TestIdetity.Models;

namespace TestIdetity.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {

        private ApplicationDbContext _context;
        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDto f)
        {
            var UserId = User.Identity.GetUserId();

            if (_context.Followings.Any(g => g.FolloweeId == UserId && g.FolloweeId == f.FolloweeId))
                return BadRequest("Following already exist");

            var followings = new Following
            {
                FolloweeId = f.FolloweeId,
                FollowerId = UserId


            };

            _context.Followings.Add(followings);
            _context.SaveChanges();
            return Ok();
        }
    }
}
