using Microsoft.EntityFrameworkCore;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) => {
            services.AddDbContext<SampleAppContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("SampleAppContextConnection")));

            services.AddDefaultIdentity<SampleAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SampleAppContext>();
        });
    }
}