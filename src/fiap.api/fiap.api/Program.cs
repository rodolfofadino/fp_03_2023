
using fiap.core.Contexts;
using fiap.core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InstrumentosContext>
    (options => options.UseSqlServer(connection));

builder.Services.AddControllers(config => {
    config.RespectBrowserAcceptHeader = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddCors(x => {
    x.AddPolicy("default", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });

    x.AddPolicy("restrita", builder =>
    {
        builder.WithOrigins( "api.meudominio.com.br,www.meudominio.com.br".Split(",")) ;
    });
});


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "fiap.api", Version = "v1" });
});

builder.Services.Configure<RouteOptions>(opt => opt.LowercaseUrls = true);




var app = builder.Build();



app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "fiap.api v1"));

app.UseRouting();

//app.UseCors(config => config.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors("restrita");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



////minimal api
//app.MapGet("/instrumentos",
//    async (InstrumentosContext context) =>
//    await context.Instrumentos.ToListAsync());

//app.MapGet("/instrumentos/{id}", async (int id, InstrumentosContext context)
//    => await context.Instrumentos.FirstOrDefaultAsync(i => i.Id == id));

//app.MapPost("/instrumentos", async (Instrumento model, InstrumentosContext context)
//    =>
//    {
//        context.Instrumentos.Add(model);
//        await context.SaveChangesAsync();
//        return model;
//    });

app.Run();