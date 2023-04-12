
using apointify.Models;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Domain;
using Microsoft.EntityFrameworkCore;
using apointify.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("apointifyContextConnection") ?? throw new InvalidOperationException("Connection string 'apointifyContextConnection' not found.");

builder.Services.AddDbContext<apointifyContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<apointifyContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddIdentityCore<OmParmarContext>().AddEntityFrameworkStores<OmParmarContext>();




builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();


//builder.Services.AddSingleton<IHttpContextAccessor, IHttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
});

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

app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
