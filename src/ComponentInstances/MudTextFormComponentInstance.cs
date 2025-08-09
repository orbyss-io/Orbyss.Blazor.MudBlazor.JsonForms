using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudTextFormComponentInstance : InputFormComponentInstance<MudTextField<string>>
    {
        public MudTextFormComponentInstance() : base(token => token?.ToString())
        {
        }

        public Variant Variant { get; set; } = Variant.Outlined;

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = new Dictionary<string, object?>
            {
                [nameof(MudTextField<string>.Variant)] = Variant,
                [nameof(MudTextField<string>.ErrorText)] = ErrorHelperText,
                [nameof(MudTextField<string>.Error)] = !string.IsNullOrWhiteSpace(ErrorHelperText),
                [nameof(MudTextField<string>.HasErrors)] = !string.IsNullOrWhiteSpace(ErrorHelperText)
            };

            return result;
        }
    }
}