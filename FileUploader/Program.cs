using Microsoft.EntityFrameworkCore;
using FileUploader.Data;
using FileUploader.Interfaces;
using FileUploader.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ApplicationDbContext>();


//MSSQL DB Conn:
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


//MySQL DB Conn
//string _GetConnStringName = builder.Configuration.GetConnectionString("DefaultConnectionMySQL");
//builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(_GetConnStringName, ServerVersion.AutoDetect(_GetConnStringName)));




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICommon, Common>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AttachmentFile}/{action=Index}/{id?}");

app.Run();
