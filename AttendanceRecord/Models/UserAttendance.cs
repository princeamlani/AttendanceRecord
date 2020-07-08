using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceRecord.Models
{
    public class UserAttendance
    {
        public int Id { get; set; }

        public UserDetails UserDetails { get; set; }

        public int UserDetailsId { get; set; }

        public string Name { get; set; }

        public string Door { get; set; }

        public DateTime SwipeTime { get; set; }

        public string SwipeType { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}