using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AttendanceRecord.Models
{
    public class GetUserAttendance
    {
        public int UserDetailsId { get; set; }

        public string Name { get; set; }

        public string InDoor { get; set; }

        public string OutDoor { get; set; }

        public string SwipeInTime { get; set; }

        public string SwipeOutTime { get; set; }

        public string Duration { get; set; }

        public string date { get; set; }
    }
}