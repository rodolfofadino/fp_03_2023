

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


var app = builder.Build();



app.UseRouting();

///minha-nova-feauture/detalhes

//app.MapControllerRoute(
//    name: "minhaft",
//    defaults: new { Controller = "DetalheTeste", Action = "Detalhes" },
//    pattern: "home/detalhes"
//);

app.MapControllerRoute(
    name: "default",
   // defaults: new { Controller = "Home", Action = "Index" },
    pattern: "{controller=Home}/teste/{action=Index}/{id?}"
);



app.Run();









//app.MapGet("/", () => 

//"Boa noite Fiap 🚀"

//);

//app.MapGet("/login", () =>

//"Login 🚀"

//);
