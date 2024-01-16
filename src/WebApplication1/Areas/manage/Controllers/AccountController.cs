using Hook.Core.Entities;
using Hook.MVC.Areas.manage.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hook.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _usermanger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser>usermanger,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _usermanger = usermanger;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1=new IdentityRole("SuperAdmin");
        //    var role2 = new IdentityRole("Admin");
        //    var role3 = new IdentityRole("Memeber");
        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);

        //    await _roleManager.CreateAsync(role3);
        //    return Ok();
        //}
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    var admin = new AppUser 
        //    { 
        //        FullName="Ulker Veliyeva",
        //        UserName="SuperAdmin"
        //    };
        //    await _usermanger.CreateAsync(admin,"Admin123@");
        //    await _usermanger.AddToRoleAsync(admin,"SuperAdmin");
        //    return Ok();
        //}
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryTokenAttribute]
        [HttpPost]
        public async Task<IActionResult> Login(AdminViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user= await _usermanger.FindByNameAsync(vm.UserName);
            if (user==null)
            {
                ModelState.AddModelError("","Username or password is incorrect");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }

            return RedirectToAction("index","dashboard");
        }
    }
}
