using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Vacation_Manager.Areas.Identity.IdentityHostingStartup))]
namespace Vacation_Manager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}