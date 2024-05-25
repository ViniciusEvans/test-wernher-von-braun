using Application;
using Domain;

namespace Web;

public static class Services
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<DeviceService>();
        services.AddSingleton<DevicesListProvider>();
        services.AddSingleton<UserListProvider>();
    }
}

