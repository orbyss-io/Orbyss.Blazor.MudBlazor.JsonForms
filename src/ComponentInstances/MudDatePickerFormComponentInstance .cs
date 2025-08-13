using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudDatePickerFormComponentInstance : DateOnlyInputFormComponentInstance
    {
        public MudDatePickerFormComponentInstance() : base(typeof(MudBlazorDatePicker<>))
        {
        }

        public Variant Variant { get; set; } = Variant.Outlined;

        public Color Color { get; set; }

        public bool Underline { get; set; }

        public string? Format { get; set; }

        protected override IDictionary<string, object?> GetDateInputParameter()
        {
            return new Dictionary<string, object?>
            {
                [nameof(Variant)] = Variant,
                [nameof(Color)] = Color,
                [nameof(Underline)] = Underline,
                [nameof(Format)] = Format
            };
        }
    }
}