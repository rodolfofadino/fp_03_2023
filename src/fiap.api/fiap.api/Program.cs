
using fiap.core.Contexts;
using fiap.core.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InstrumentosContext>
    (options => options.UseSqlServer(connection));

builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
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