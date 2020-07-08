using AttendanceRecord.Models;
using AttendanceRecord.Repository;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace AttendanceRecord.Controllers.API
{
    public class UserAttendanceController : ApiController
    {
        ApplicationDbContext _context;
        UserRepository _userRepo;

        public UserAttendanceController()
        {
            _context = new ApplicationDbContext();
            _userRepo = new UserRepository();
        }

        [HttpGet]
        public IHttpActionResult GetUsersAttendance()
        {
            var userAttendance = _userRepo.GetUsersAttendance();
            return Ok(userAttendance);
        }

        [HttpGet]
        public IHttpActionResult GetUsersAttendance(int id)
        {
            var userAttendance = _userRepo.GetUsersAttendancebyId(id);
            return Ok(userAttendance);
        }

        [HttpPost]
        public IHttpActionResult AddAttendance(UserAttendance attendance)
        {
            var user = _context.UserDetails.SingleOrDefault(u => u.Id == attendance.UserDetailsId);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            attendance.Name = user.Name;
            attendance.SwipeTime = DateTime.Now;
            attendance.ModifiedDate = DateTime.Now;
            attendance.CreatedDate = DateTime.Now;

            _context.UserAttendance.Add(attendance);
            _context.SaveChanges();

            return Ok("Attendance logged successfully!");
        }

        [HttpPut]
        public IHttpActionResult UpdateAttendance(int id, UserAttendance attendance)
        {
            var userAttendance = _context.UserAttendance.SingleOrDefault(a => a.Id == id);

            attendance.Name = userAttendance.Name;
            attendance.ModifiedDate = DateTime.Now;
          
            _context.SaveChanges();

            return Ok("Attendance updated successfully!");
        }
    }
}
