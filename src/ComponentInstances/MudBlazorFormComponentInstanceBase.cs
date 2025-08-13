using Microsoft.AspNetCore.Components;
using MudBlazor;
using Newtonsoft.Json.Linq;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public abstract class MudBlazorFormComponentInstanceBase<TComponent>(Func<JToken?, object?> convertValue) 
        :   InputFormComponentInstance<TComponent>(convertValue)
            where TComponent : class
    {
        public bool Underline { get; set; }

        public Color Color { get; set; }

        public Variant Variant { get; set; } = Variant.Outlined;

        public string? PlaceHolder { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = new Dictionary<string, object?>
            {
                [nameof(MudBlazorFormComponentBase<string>.Underline)] = Underline,
                [nameof(MudBlazorFormComponentBase<string>.Color)] = Color,

                [nameof(MudBlazorFormComponentBase<string>.PlaceHolder)] = PlaceHolder,
                [nameof(MudBlazorFormComponentBase<string>.Variant)] = Variant
            };

            return result;
        }
    }
}
