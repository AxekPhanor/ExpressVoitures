using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Repositories;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpressVoituresDbContext>(
    opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ExpressVoituresDbContext>();

builder.Services.AddTransient<IVoitureRepository, VoitureRepository>();
builder.Services.AddTransient<IVoitureService, VoitureService>();
builder.Services.AddTransient<IVoitureEnregistreRepository, VoitureEnregistreRepository>();
builder.Services.AddTransient<IVoitureEnregistreService, VoitureEnregistreService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Creation des rôles 
using (var scope = app.Services.CreateScope())
{
    using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole { Name = "User" });
        await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
