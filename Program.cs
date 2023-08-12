using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
//builder ile bir web uygulaması inşa edilecek
builder.Services.AddControllersWithViews(); //servis kaydı yapıldı

var app = builder.Build();
app.UseRouting(); //uygulamanın viewse , controllera ihtiyacının yanı sıra bir routinge ihtiyacı var
app.UseHttpsRedirection();  //Redirectionlar da işletilebilir (ekleyebiliriz) ?
app.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}"); //tanım yaptık
 /* app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"); şeklinde de tanımlanabilir */

app.Run();
