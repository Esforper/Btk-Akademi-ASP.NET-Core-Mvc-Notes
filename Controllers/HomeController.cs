using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Cotrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    
}