using MemberDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MemberDemoApp.ViewModel
{
    public class AccountViewModel
    {
        public static List<SelectListItem> GetRoles(int RoleId)
        {
            List<SelectListItem> Roles = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["PracticeDemo"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand ("usp_getRolesbyRoleId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RoleId", RoleId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        var item = new SelectListItem();
                        item.Text = reader["RoleName"].ToString(); 
                        item.Value = reader["RoleName"].ToString();
                        Roles.Add(item);
                    }
                }
            }
                return Roles; 
        }
        public static UserProfileModel getUserProfile (int UserId)
        {
            UserProfileModel userProfile = new UserProfileModel();
            using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["PracticeDemo"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand ("usp_getUserProfilebyUserId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    userProfile.userId = reader.GetValue(0).ToString(); 
                    userProfile.userName = reader.GetValue(1).ToString();
                    userProfile.fullName = reader.GetValue(2).ToString();
                    userProfile.Email = reader.GetValue(3).ToString();
                    userProfile.Gender = reader.GetValue(4).ToString();
                    userProfile.Address = reader.GetValue(5).ToString();
                }
            }
                return userProfile;
        }

        public static void updateUserProfile(UserProfileModel userProfile)
        {
            using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["PracticeDemo"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand ("usp_UpdateUserProfile", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", WebSecurity.CurrentUserId);
                    cmd.Parameters.AddWithValue("@FullName", userProfile.fullName);
                    cmd.Parameters.AddWithValue("@Email", userProfile.Email);
                    cmd.Parameters.AddWithValue("@Address", userProfile.Address);
                    cmd.Parameters.AddWithValue("@Gender", userProfile.Gender);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<AllUsersModel> GetAllUsers()
        {
            List<AllUsersModel> users = new List<AllUsersModel>();
            using (SqlConnection conn = new SqlConnection (ConfigurationManager.ConnectionStrings["PracticeDemo"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand ("usp_getAllUsers", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    while(reader.Read())
                    {
                        AllUsersModel user = new AllUsersModel();
                        user.UserId = Convert.ToInt32( reader["UserId"]);
                        user.UserName = reader["UserName"].ToString();
                        user.fullName = reader["FullName"].ToString();
                        user.Email = reader["Email"].ToString();
                        user.Gender = reader["Gender"].ToString();
                        users.Add(user);
                    }
                }
            }
                return users;
        }
    }
}