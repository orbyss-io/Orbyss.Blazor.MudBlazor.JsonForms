using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using MudExtensions.Services;
using Orbyss.Blazor.MudBlazor.JsonForms;
using Orbyss.Blazor.MudBlazor.JsonForms.Extensions;

namespace MudBlazor.JsonForms.Demo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddMudServices();
            builder.Services.AddMudExtensions();

            var instanceProviderOptions = new MudFormComponentInstanceProviderOptions
            {
                ConfigureButton = (@default, type, form) =>
                {
                    @default.Size = Size.Medium;

                    if(type == Orbyss.Blazor.JsonForms.FormButtonType.Submit)
                    {
                        @default.EndIcon = Icons.Material.Filled.Send;
                    }

                    return @default;
                },

                ConfigureDropdownInput = (@default, control) =>
                {
                    @default.Searchable = true;
                    @default.SearchCaseSensitive = false;
                    @default.SearchOperator = DropdownSearchOperator.Contains;

                    return @default;
                }
            };
            builder.Services.AddMudBlazorJsonForms(instanceProviderOptions);

            return builder.Build();
        }
    }
}
