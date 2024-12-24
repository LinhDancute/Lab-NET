using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVCDemo.Models;

namespace WebMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult UserIndex()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Auth");
            }
            
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult AdminIndex()
        {
            return View();
        }
    }   
}
