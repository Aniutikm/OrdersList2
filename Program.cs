using Microsoft.EntityFrameworkCore;
using WebApplicationAngularWebPortal;
using WebApplicationAngularWebPortal.Entities;
using WebApplicationAngularWebPortal.Repository;

var builder = WebApplication.CreateBuilder(args);


var sqliteDatabaseFile = builder.Configuration.GetValue<string?>("SQLiteDatabaseFile", null) ?? throw new Exception("The `SQLiteDatabaseFile` configuration setting is not set.");
var connectionString = builder.Configuration.GetConnectionString("AppOrdersDatabase") ?? throw new Exception("The `AppOrdersDatabase` connection string is not set.");

if (File.Exists(sqliteDatabaseFile))
{
	File.Delete(sqliteDatabaseFile);
}


 using var databaseService = new DatabaseService(connectionString!);
 databaseService.InitializeDatabase();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddControllers();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllersWithViews()
	.AddNewtonsoftJson(options =>
		options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
	);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();
