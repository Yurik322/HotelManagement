using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace HotelManagement.Services
{
    public class HotelManagementRolesManager : RoleManager<IdentityRole>
    {
        public HotelManagementRolesManager(IRoleStore<IdentityRole, string> roleStore) : base(roleStore)
        {
        }
        public static HotelManagementRolesManager Create(IdentityFactoryOptions<HotelManagementRolesManager> options,
            IOwinContext context)
        {
            return new HotelManagementRolesManager(new RoleStore<IdentityRole>(context.Get<HotelManagementContext>()));
        }
    }
}
