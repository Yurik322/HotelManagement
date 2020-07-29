using HotelManagement.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelManagement.Services
{
    internal class ApplicationUserManager
    {
        private UserStore<HotelManagementUser> userStore;

        public ApplicationUserManager(UserStore<HotelManagementUser> userStore)
        {
            this.userStore = userStore;
        }
    }
}