using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManagement.Entities;
using HotelManagement.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelManagement.Areas.Dashboard.ViewModels
{
    public class UsersListingModel
    {
        public IEnumerable<HotelManagementUser> Users { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public string RoleID { get; set; }

        public Pager Pager { get; set; }
    }
    public class UserActionModel
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        //public string RoleID { get; set; }
        //public IdentityRole Role { get; set; }

        //public IEnumerable<IdentityRole> Roles { get; set; }
    }
}