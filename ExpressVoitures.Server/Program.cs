using ExpressVoitures.Server.Data;
using ExpressVoitures.Server.Models.Repositories;
using ExpressVoitures.Server.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("DeveloppementPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
}); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpressVoituresDbContext>(
    opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ExpressVoituresDbContext>();

builder.Services.AddScoped<IMarqueRepository, MarqueRepository>();
builder.Services.AddScoped<IMarqueService, MarqueService>();
builder.Services.AddScoped<IAnneeRepository, AnneeRepository>();
builder.Services.AddScoped<IAnneeService, AnneeService>();
builder.Services.AddScoped<IModeleRepository, ModeleRepository>();
builder.Services.AddScoped<IModeleService, ModeleService>();
builder.Services.AddScoped<IFinitionRepository, FinitionRepository>();
builder.Services.AddScoped<IFinitionService, FinitionService>();
builder.Services.AddScoped<IVoitureRepository, VoitureRepository>();
builder.Services.AddScoped<IVoitureService, VoitureService>();
builder.Services.AddScoped<IVoitureEnregistreRepository, VoitureEnregistreRepository>();
builder.Services.AddScoped<IVoitureEnregistreService, VoitureEnregistreService>();
builder.Services.AddScoped<IAnnonceRepository, AnnonceRepository>();
builder.Services.AddScoped<IAnnonceService, AnnonceService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DeveloppementPolicy");
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
