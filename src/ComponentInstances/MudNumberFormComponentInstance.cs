using MudBlazor;
using Newtonsoft.Json.Linq;
using Orbyss.Blazor.JsonForms.ComponentInstances;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudNumberFormComponentInstance : InputFormComponentInstanceBase
    {
        public override Type ComponentType => typeof(MudNumericField<double?>);

        protected override object? ConvertValue(JToken? value)
        {
            if (double.TryParse($"{value}", Culture, out var doubleValue))
            {
                return doubleValue;
            }

            return null;
        }

        public string? Format { get; set; }

        public Variant Variant { get; set; } = Variant.Outlined;

        public string? PlaceHolder { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = new Dictionary<string, object?>
            {
                [nameof(MudNumericField<double?>.Format)] = Format,
                [nameof(MudNumericField<double?>.Placeholder)] = PlaceHolder,
                [nameof(MudNumericField<double?>.Variant)] = Variant,
                [nameof(MudNumericField<double?>.ErrorText)] = ErrorHelperText,
                [nameof(MudNumericField<double?>.HasErrors)] = !string.IsNullOrWhiteSpace(ErrorHelperText),
                [nameof(MudNumericField<double?>.Error)] = !string.IsNullOrWhiteSpace(ErrorHelperText)
            };

            return result;
        }
    }
}