using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product)
        //bu noktada buraya bir breakpoint koyularak test etmek en mantıklısı ondan sonra veri tabanına kaydedilebilir
        //bunun için base ye metod yazıcaz
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateProduct(product);
                // return View();
                return RedirectToAction("Index");
            }
            return View();  //eğer model durumu uygun değilse kendi üzerine dönmesini sağlıyor


        }


        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            //routtan aldı id ile sayfaya yansıtacaz
            //* asp for aktif olduğu için direkt gerekli yerlere mevcut değerleri yazıcak
            //?  asp for ile bir değeri varsa direkt yansıtabiliyoruz
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]   //bunu yazmasak da olur
       // [ValidateAntiForgeryToken]  //bu olursa kod çalışmıyor , öyle her yere koyma o nedenle
        public IActionResult Delete([FromRoute(Name ="id")]int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
            
        }



    }
}