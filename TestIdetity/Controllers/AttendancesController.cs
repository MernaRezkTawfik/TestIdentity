using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TestIdetity.Models;

namespace TestIdetity.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {

        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var UserId = User.Identity.GetUserId();
            if(_context.Attendances.Any(a=> a.AttendeeId==UserId && a.GigId == dto.GigId))//check attendance not exist
               
                return BadRequest("The attendance is already exist");
            

            var attendances = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId =UserId
            };
            _context.Attendances.Add(attendances);
            _context.SaveChanges();
            return Ok();
        }
    }
}
