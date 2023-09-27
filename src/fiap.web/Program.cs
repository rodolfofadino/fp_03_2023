

using fiap.core.Contexts;
using fiap.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InstrumentosContext>
    (options => options.UseSqlServer(connection));




builder.Services.AddControllersWithViews();
//builder.Services.AddScoped 1 por request
//builder.Services.AddSingleton 1 por aplicacao rodando
//builder.Services.AddTransient 1 instancia do objeto por codigo que solicite ele


var app = builder.Build();

//app.UseMiddleware<MeuLogMiddleware>();

app.UseMeuMiddlewareDaFiapCustomizado();



//app.Use(async (context, next) =>
//{
//    await next();

//});

//app.Use(async (context, next) =>
//{
//    await next();

//});

//app.Use(async (context, next) =>
//{
//    await next();

//});




//app.Use(async (context, next) =>
//{

//    await context.Response.WriteAsync("Antes");

//    //if (context.Request.Path == "")
//    //{
//    //    return;
//    //}

//    await next();

//    await context.Response.WriteAsync("Depois");

//});

//app.Run(async (context) =>

//{

//    await context.Response.WriteAsync("Hello World!");

//});

//app.Map("/admin", myApp => {
//    myApp.Run(async context => {
//        await context.Response.WriteAsync("Admin");
//    });
//});

//app.MapWhen(context => context.Request.Query.ContainsKey("fiap"), myApp => {
//    myApp.Run( async context => {
//        await context.Response.WriteAsync("fiap");
//    });
//});







if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
}



app.UseStaticFiles();



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
  //  pattern: "{controller=Home}/teste/{action=Index}/{id?}"
    pattern: "{controller=Home}/{action=Index}/{id?}"
);



app.Run();









//app.MapGet("/", () => 

//"Boa noite Fiap 🚀"

//);

//app.MapGet("/login", () =>

//"Login 🚀"

//);
