using System;
using Crud_Blazor.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Crud_Blazor.Areas.Identity.IdentityHostingStartup))]
namespace Crud_Blazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Crud_BlazorContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Crud_BlazorContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Crud_BlazorContext>();
            });
        }
    }
}