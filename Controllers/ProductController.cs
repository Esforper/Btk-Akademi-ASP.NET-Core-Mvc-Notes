using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Cotrollers
{
    public class ProductController : Controller
    {

        // * Dependency Injection
        //--- Dependency Injection paterni    --- servis kaydı varsa servis kaydını newliyor
           // private readonly RepositoryContext _context;    //RepositoryContext e ihtiyaç olduğunda servis devreye girecek
            //Program.cs de yazdığımız bir servis, Bağlantı dizesini otomatik olarak oluşturacak, bunu newleyecek ve bize
            //kullanabileceğimiz bi context ifadesi vermiş olacak

            private readonly IRepositoryManager _manager;
            public ProductController(IRepositoryManager manager)
            {
                _manager = manager;
            }
            //---


        //public IEnumerable<Product> Index() //endpointe product dediğimizde bize bir ürün getirecek
        //{ 

        //var context = new RepositoryContext(); şeklinde yazamıyoruz çünkü RepositoryContextda default bir construct yok
                // var context = new RepositoryContext(     //bu kısım üst kısmı yazmadan önceydi, uzun hal gibi düşün
                // new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source = C:\\Kodlar\\backend çalışma\\mvc\\ProductDb.db").Options );
            //options : Prop
            //normalde bizden bir options istiyor ama biz başta builder verdik , sonra bu builder classından
            //devam ettik

          //  return _context.Products;   //böylelikle Productlara erişim sağlamış olucaz
            // return new List<Product>()     //List tanımı IEnumerable interfacesini kabul ettiği için ikisini bağlayabildik
            // {   
            //     new Product(){ProductId=1,ProductName="Computer",Price=5}


            // };
        //   }

        public IActionResult Index()
        {
            //Product DbSet şeklinde tanımlı duruyor. 
            //List of Product göndermesi sağlanıyor
            var model = _manager.Product.GetAllProducts(false);    //false , değişiklikleri izlesin mi diye
            return View(model);


        }

        public IActionResult Get(int id)    //Id ye bağlı tek bir tane Product
        {
          //  Product product = _context.Products.First(p => p.ProductId.Equals(Id));    //boş bir product yaptık
            //_contextdeki product ifadesi , 
            //product p ile temsil ediliyor 
            //producttaki ProductId değeri parametreden gelen Id değerine eşit olan bir ürün yakalarsa o ilk ürünü döndürecek
            // sorgu tasarımı.
          //  return View(product); //product nesnesini bir view içinde göstermeye çalışacaz
          var model = _manager.Product.GetOneProduct(id ,false);
          return View(model);
        }






    }
    
}