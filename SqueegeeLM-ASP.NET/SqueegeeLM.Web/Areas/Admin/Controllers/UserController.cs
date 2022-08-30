namespace SqueegeeLM.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SqueegeeLM.Data.Models;

    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<User> userManager;

        public UserController(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void ManageUsers()
        {

        }
    }
}
