using Microsoft.Extensions.DependencyInjection;
using Orbyss.Blazor.JsonForms;
using Orbyss.Blazor.JsonForms.Context.Interfaces;
using Orbyss.Blazor.JsonForms.Extensions;

namespace Orbyss.Blazor.MudBlazor.JsonForms.Extensions
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection AddMudBlazorJsonForms(this IServiceCollection services, MudFormComponentInstanceProviderOptions? options = null, Func<IServiceProvider, IJsonFormContext>? jsonFormContextFactory = null)
        {
            return services
                .AddJsonForms(jsonFormContextFactory)
                .AddSingleton<IFormComponentInstanceProvider>(new MudFormComponentInstanceProvider(options));
        }

        public static IServiceCollection AddMudBlazorJsonForms<TFormComponentInstanceProvider>(this IServiceCollection services, Func<IServiceProvider, IJsonFormContext>? jsonFormContextFactory = null)
            where TFormComponentInstanceProvider : class, IFormComponentInstanceProvider
        {
            return services
                .AddJsonForms(jsonFormContextFactory)
                .AddSingleton<IFormComponentInstanceProvider, TFormComponentInstanceProvider>();
        }
    }
}
