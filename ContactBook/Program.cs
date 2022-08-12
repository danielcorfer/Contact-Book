using ContactBook.Database;
using ContactBook.Interfaces;
using ContactBook.Models;
using ContactBook.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddScoped<IContactService, ContactService>();
ConfigureDb(builder.Services);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });
var app = builder.Build();


app.UseFileServer();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.Run();

static void ConfigureDb(IServiceCollection services)
{
    var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    var connectionString = config.GetConnectionString("Default");
    services.AddDbContext<ApplicationDbContext>(b => b.UseSqlServer(connectionString));
}

