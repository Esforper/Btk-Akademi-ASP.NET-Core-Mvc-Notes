var builder = WebApplication.CreateBuilder(args);
//builder ile bir web uygulaması inşa edilecek
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/btk", () => "BTK Akademi");

app.Run();
