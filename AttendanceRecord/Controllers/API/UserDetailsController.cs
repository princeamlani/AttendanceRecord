using AttendanceRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AttendanceRecord.Controllers.API
{
    public class UserDetailsController : ApiController
    {
        ApplicationDbContext _context;

        public UserDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/UserDetails
        [HttpGet] 
        public IHttpActionResult GetUsers()
        {
            var user = _context.UserDetails.ToList();
            return Ok(user);
        }

        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = _context.UserDetails.SingleOrDefault(u => u.Id == id);
            return Ok(user);
        }

        [HttpPost]
        public IHttpActionResult AddUser(UserDetails user)
        {
            user.ModifiedDate = DateTime.Now;
            user.CreatedDate = DateTime.Now;

            _context.UserDetails.Add(user);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + user.Id), user);
        }

        [HttpPut]
        public IHttpActionResult UpdateUser(int id, UserDetails user)
        {
            var userdetails = _context.UserDetails.SingleOrDefault(u => u.Id == id);

            if(userdetails== null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            userdetails.Name = user.Name;
            userdetails.Role = user.Role;
            userdetails.ModifiedDate = DateTime.Now;
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + userdetails.Id), userdetails);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            var userdetails = _context.UserDetails.SingleOrDefault(u => u.Id == id);

            if (userdetails == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.UserDetails.Remove(userdetails);
            _context.SaveChanges();

            return Ok("User Deleted!");
        }
    }
}
