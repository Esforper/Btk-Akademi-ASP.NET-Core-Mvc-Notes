using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);
//builder ile bir web uygulaması inşa edilecek
builder.Services.AddControllersWithViews(); //servis kaydı yapıldı
builder.Services.AddDbContext<RepositoryContext>(Options =>
{
    Options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"));      //bu kayıt sayesinde ProductControllerda erişim yaptık
    //repositoryContext in newlenmesini sağlıyoruz, ihtiyacı olan bağlantı dizesini appsettings den alıp vermiş oluyor
    // sqlconnection = appsettings.json dosyasındaki şey
    //Btk Akademi asp.net core mvc 4.6 . video
});
// ne zaman RepositoryContext gerekirse bir bağlantı oluşacak

var app = builder.Build();
app.UseRouting(); //uygulamanın viewse , controllera ihtiyacının yanı sıra bir routinge ihtiyacı var
app.UseHttpsRedirection();  //Redirectionlar da işletilebilir (ekleyebiliriz) ?
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}"); //tanım yaptık
 /* app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"); şeklinde de tanımlanabilir */

app.Run();
