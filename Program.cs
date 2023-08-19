using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    //normalde sadece bu bir de Repositories in kalması gerekiyordu.
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
//builder ile bir web uygulaması inşa edilecek
builder.Services.AddControllersWithViews(); //servis kaydı yapıldı
builder.Services.AddDbContext<RepositoryContext>(Options =>
{
    Options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));      //bu kayıt sayesinde ProductControllerda erişim yaptık
    //repositoryContext in newlenmesini sağlıyoruz, ihtiyacı olan bağlantı dizesini appsettings den alıp vermiş oluyor
    // sqlconnection = appsettings.json dosyasındaki şey
    //Btk Akademi asp.net core mvc 4.6 . video
});
// ne zaman RepositoryContext gerekirse bir bağlantı oluşacak

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//ICategoryRepository ifadesi için CategoryRepository yi tanımlamış olduk

builder.Services.AddAutoMapper(typeof(Program));

//IRepositoryManager arabirimi ile karşılaşırsa RepositoryManager classını getirecek

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
//Configuration işlemi



var app = builder.Build();

app.UseStaticFiles();   //uygulamanın statik dosyalar kullanabileceğini belirtiyor.
//bootstrap , jquery , font-awsome gibi kütüphaneleri indirmemize de yarıyor
//bunları indirirken libman dan yararlanarak indiriyoruz



app.UseRouting(); //uygulamanın viewse , controllera ihtiyacının yanı sıra bir routinge ihtiyacı var
app.UseHttpsRedirection();  //Redirectionlar da işletilebilir (ekleyebiliriz) ?
//app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); //tanım yaptık
//9.2 de artık bunu kullanmıyoruz
/* app.MapControllerRoute(
   name:"default",
   pattern:"{controller=Home}/{action=Index}/{id?}"); şeklinde de tanımlanabilir */
// * burada tek bir end point tanımı var sadece

app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoint.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");
});

app.Run();
