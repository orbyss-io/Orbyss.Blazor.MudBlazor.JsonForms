using MudBlazor;
using MudExtensions.Utilities;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudStepperFormComponentInstance : NavigationFormComponentInstance<MudStepperComponent>
    {
        public Variant Variant { get; set; }

        public Color Color { get; set; }

        public StepperLocalizedStrings? LocalizedStrings { get; set; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudStepperComponent.Variant)] = Variant,
                [nameof(MudStepperComponent.Color)] = Color,
                [nameof(MudStepperComponent.LocalizedStrings)] = LocalizedStrings ?? new()
            };
        }
    }
}