using Blazored.LocalStorage;
using MalenkijMelo.Services;
using MalenkijMelo.Services.Base;
using MalenkijMelo.Services.IHttpClientServices;
using MudBlazor.Services;
using MalenkijMelo.Share.Assemblers;
using Microsoft.Extensions.Options;

namespace MalenkijMelo.Web.Extensions
{
    public static class AddBlazorServicesExtension
    {
        public static void AddBlazorServices(this IServiceCollection services)
        {
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.ShowTransitionDuration = 200;
                config.SnackbarConfiguration.HideTransitionDuration = 300;
            });
            services.AddBlazoredLocalStorage();
            services.AddBlazorBootstrap();
            services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });

            services.ConfigureAssambles();
            services.AddHttpClientServices();

            
        }

        private static void AddHttpClientServices(this IServiceCollection services)
        {
            services.AddScoped<IJobHttpClientService, JobHttpClientService>();
            services.AddScoped<IUserHttpClientService, UserHttpClientService>();
            services.AddScoped<IUserAuthHttpClientService, UserAuthHttpClientService>();
            services.AddScoped<IUserJobActionHttpClientService, UserJobActionHttpClientService>();
        }

        private static void ConfigureAssambles(this IServiceCollection services)
        {
            services.AddScoped<JobAssembler>();
            services.AddScoped<UserAssembler>();
            services.AddScoped<UserJobActionAssembler>();
        }
    }
}
