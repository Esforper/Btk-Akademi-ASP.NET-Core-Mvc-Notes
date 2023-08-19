using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //ViewBag.Categories = _manager.CategoryService.GetAllCategories(false); //IEnumerable formatta kategori nesnesine
            //erişim yapabiliyoruz , başka bir şekilde tanımlamak istersek (tag helperlar ile de)
            ViewBag.Categories = new SelectList(_manager.CategoryService.GetAllCategories(false),"CategoryId","CategoryName","1");
            //burada seçilebilir bir lista tanımı oluşturduk.
            //veri tabanındaki kayıtları item olarak belirledik
            //CategoryId alanını id alanı , text alanı olarak CategoryName alanı belirlendi
            //1 alanı da default olarak seçili olarak gelsin diye yazıldı
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