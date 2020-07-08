using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using AttendanceRecord.Models;
using System.Data;

namespace AttendanceRecord.Repository
{
    public class UserRepository
    {
        string con;
        SqlConnection conn;

        public UserRepository()
        {
            con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(con);
        }

        public List<GetUserAttendance> GetUsersAttendance()
        {
            List<GetUserAttendance> userAttendance = new List<GetUserAttendance>();
            SqlCommand com = new SqlCommand("sp_GetUserAttendance", conn);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            userAttendance = (from DataRow dr in dt.Rows

                        select new GetUserAttendance()
                        {
                            UserDetailsId = Convert.ToInt32(dr["UserDetailsId"]),
                            Name = Convert.ToString(dr["Name"]),
                            date= Convert.ToString(dr["Date"]),
                            InDoor = Convert.ToString(dr["InDoor"]),
                            SwipeInTime = Convert.ToString(dr["InTime"]),
                            OutDoor = Convert.ToString(dr["OutDoor"]),
                            SwipeOutTime = Convert.ToString(dr["OutTime"]),
                            Duration = Convert.ToString(dr["Duration"]),
                            
                        }).ToList();

            return userAttendance;
        }

        public List<GetUserAttendance> GetUsersAttendancebyId(int id)
        {
            List<GetUserAttendance> userAttendance = new List<GetUserAttendance>();
            SqlCommand com = new SqlCommand("sp_GetUserAttendancebyId", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();

            userAttendance = (from DataRow dr in dt.Rows
                              select new GetUserAttendance()
                              {
                                  UserDetailsId = Convert.ToInt32(dr["UserDetailsId"]),
                                  Name = Convert.ToString(dr["Name"]),
                                  date = Convert.ToString(dr["Date"]),
                                  InDoor = Convert.ToString(dr["InDoor"]),
                                  SwipeInTime = Convert.ToString(dr["InTime"]),
                                  OutDoor = Convert.ToString(dr["OutDoor"]),
                                  SwipeOutTime = Convert.ToString(dr["OutTime"]),
                                  Duration = Convert.ToString(dr["Duration"]),
                                  
                              }).ToList();

            return userAttendance;
        }
    }
}