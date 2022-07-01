using Crud_Blazor.Data;
using Crud_Blazor.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddScoped<ClgStudentDetailsService>();
services.AddAuthentication("Identity.Application").AddCookie();
services.AddScoped<IFileUpload, FileUpload>();
#region Connection String
services.AddDbContext<AppDBContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("BlazorDBContext")));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapDefaultControllerRoute();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();