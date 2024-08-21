using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index(string email)
		{
            ViewBag.email = email;
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailModel  confirmMailModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailModel.Email.ToString());
            if (ModelState.IsValid)
            {
                if (user.ConfirmCode == confirmMailModel.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("Index", "Login");
                }
            }
            ViewBag.message = "Girilen Kod Yanlış Tekrar Deneyiniz";
            return View();
        }
    }
}
