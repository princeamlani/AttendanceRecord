using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceRecord.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}