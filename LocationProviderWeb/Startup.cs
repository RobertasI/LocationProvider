using LocationProviderWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LocationProviderWeb.Startup))]
namespace LocationProviderWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            _createRolesAndUsers();
        }

        private void _createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.lt"
                };

                string userPWD = "admin";

                var userChecker = UserManager.Create(user, userPWD);

                if (userChecker.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Client"))
            {
                var role = new IdentityRole
                {
                    Name = "Client"
                };
                roleManager.Create(role);

                //
                var user = new ApplicationUser
                {
                    UserName = "robertas.ilginis",
                    Email = "robertas.ilginis@stud.vgtu.lt"
                };

                string userPWD = "Klientas.1";

                var userChecker = UserManager.Create(user, userPWD);

                if (userChecker.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Client");
                }
                
            }
        }
    }
}
