using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using webgk.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm connection string vào builder
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TapHoaDBEntities")));

// Thêm dịch vụ Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "67IT WITH HTTP API V1", Version = "v1" });
});

// Cấu hình authentication và cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

// Cấu hình các dịch vụ khác nếu cần
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình middleware nếu cần
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "67IT WITH HTTP API V1");
    c.RoutePrefix = "api_docs";
});

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"Statics")),
    RequestPath = new PathString("/statics")
});

app.UseRouting();

// Thêm Authentication và Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
