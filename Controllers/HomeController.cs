using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Cotrollers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Hello Store App";
        }
    }
    
}