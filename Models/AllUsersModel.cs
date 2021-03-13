using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberDemoApp.Models
{
    public class AllUsersModel
    {

        public int UserId { get; set; }
        public string fullName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string Gender { get; set; }

    }
}