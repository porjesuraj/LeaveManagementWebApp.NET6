using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Data.Employee;
using LeaveManagement.Web.IRepository;
using LeaveManagement.Web.Repository;
using LeaveManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


#region DI Services

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IEmailSender>(options => new EmailSender("localhost",25,"no-reply@leavemanagement.com"));

builder.Services.AddScoped( typeof(IGenericRepository<>),typeof(GenericRepository<>) );
builder.Services.AddScoped<ILeaveTypesRepository, LeaveTypesRepository>();
builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

#endregion

#region Added AutoMapper Service
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

#endregion

#region Logger

builder.Host.UseSerilog((ctx, lc) =>
                                    lc.WriteTo.Console()
                                    .ReadFrom.Configuration(ctx.Configuration));
#endregion


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
