using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace HotelManagement.Services
{
    public class HotelManagementSignInManager : SignInManager<HotelManagementUser, string>
    {
        public HotelManagementSignInManager(HotelManagementUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(HotelManagementUser user)
        {
            return user.GenerateUserIdentityAsync((HotelManagementUserManager)UserManager);
        }

        public static HotelManagementSignInManager Create(IdentityFactoryOptions<HotelManagementSignInManager> options, IOwinContext context)
        {
            return new HotelManagementSignInManager(context.GetUserManager<HotelManagementUserManager>(), context.Authentication);
        }
    }
}
