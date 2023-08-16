using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace StoreApp.Cotrollers
{
    public class CategoryController :  Controller
    {
        private IRepositoryManager _manager;

        public CategoryController(IRepositoryManager manager)
        {
            _manager = manager; //manager kendisi hem productı hem de controlleri çözebilecek durumda.
        }

        // IEnumerable<Category> Index()
        // {
        //     return _manager.Category.FindAll(false);
        //     //managere git , category e git , FindAll ile ilgili ifadeleri dön
        //     //false : değişiklikleri izlesinmi durumu  için
        // }

        public IActionResult Index()
        {
            var model = _manager.Category.FindAll(false);
            return View(model);
        }
    }
}