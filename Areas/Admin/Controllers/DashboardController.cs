using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")] //arealarla çalışıldığı zaman controller başına area şeklinde bir ifade girmemiz gerekiyor
    //tag helperlerın ilgili yönlendirmeleri yapabilmesi, endpointlerle controllerları eşleştirebilmesi için 
    //attribute yapısına ( [] içindeki yapıya ) ihtiyaç var
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}