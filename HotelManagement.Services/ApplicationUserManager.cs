//-----------------------------------------------------------------------
// <copyright file="AccommodationUserManager.cs" company="My">
//    Created by yurik_322 on 20/08/12.
// </copyright>
//-----------------------------------------------------------------------
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