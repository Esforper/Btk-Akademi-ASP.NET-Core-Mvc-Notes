using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
//  public class ProductSummary : ViewComponent //coding by Conventiona göre bunu bir daha yapmamız lazım
//  yeniden isimlendirdikten sonra view ifaesi yapmamız lazım
    public class ProductSummaryViewComponent : ViewComponent
    {
        /*
        //bu bölüm DI çerçevesini destekliyor
        // private readonly RepositoryContext _context;   

        // public ProductSummary(RepositoryContext context)    //böylelikle veri tabanına bağlıyız
        // {
        //     _context = context;
        // }   Bu kullanım olduğunda veri tabanında satışa sunulmayacak ürünler vs olduğu vakit onları da saymaya çalışır
        //o nedenle burada servis manageri kullanmak daha mantıklı
         */

        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }





        //özel bir fonskiyona ihtiyacımız olacak
        /*
        // public string Invoke()
        // {
        //     return _context.Products.Count().ToString();
        //     dönüş ifadesi string olduğu için tostring olarak dönüş yaptık
        // }
        */
        
        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
            //GetAllProducts metodu içerisinde ürünün satışta olma olmama controlü yapılıyordur
        }

    }
}