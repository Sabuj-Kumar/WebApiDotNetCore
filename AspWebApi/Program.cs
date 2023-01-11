using AspWebApi.DataContext;
using AspWebApi.Intefaces.Managers;
using AspWebApi.Manager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddControllers();

// Dependancy Injection
builder.Services.AddTransient<Imanager, PostManager>();// every time create new object
/*builder.Services.AddScoped<Imanager, PostManager>();// create scope wise object.
builder.Services.AddSingleton<Imanager, PostManager>();// create only one object for hole application*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
