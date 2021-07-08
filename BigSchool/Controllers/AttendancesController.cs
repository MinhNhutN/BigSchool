using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace BigSchool.Controllers
{
    public class AttendancesController : Controller
    {
        // GET: Attendances
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if (context.Attendances.Any(p => p.Attendee == userID && p.CourseID == attendanceDto.Id))
            {
                return BadRequest("The attendance already exists!");
            }
            var attendance = new Attendance() { CourseID = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();

        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}