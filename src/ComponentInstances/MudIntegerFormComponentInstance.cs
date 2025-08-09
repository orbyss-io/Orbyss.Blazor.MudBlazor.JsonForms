using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudIntegerFormComponentInstance : InputFormComponentInstance<MudNumericField<int?>>
    {
        public MudIntegerFormComponentInstance() : base(t => (int?)t)
        {
        }

        public Variant Variant { get; set; } = Variant.Outlined;

        public string? PlaceHolder { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = new Dictionary<string, object?>
            {
                [nameof(MudNumericField<int?>.Placeholder)] = PlaceHolder,
                [nameof(MudNumericField<int?>.Variant)] = Variant,
                [nameof(MudNumericField<int?>.ErrorText)] = ErrorHelperText,
                [nameof(MudNumericField<int?>.HasErrors)] = !string.IsNullOrWhiteSpace(ErrorHelperText),
                [nameof(MudNumericField<int?>.Error)] = !string.IsNullOrWhiteSpace(ErrorHelperText)
            };

            return result;
        }
    }
}