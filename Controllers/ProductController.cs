using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Cotrollers
{
    public class ProductController : Controller
    {
        public IEnumerable<Product> Index() //endpointe product dediğimizde bize bir ürün getirecek
        {
            return new List<Product>()  
            {   
                new Product(){ProductId=1,ProductName="Computer",Price=5}


            };
        }







    }
    
}