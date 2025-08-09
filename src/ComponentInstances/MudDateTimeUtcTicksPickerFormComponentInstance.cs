using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudDateTimeUtcTicksPickerFormComponentInstance : DateTimeUtcTicksInputFormComponentInstance
    {
        public MudDateTimeUtcTicksPickerFormComponentInstance() : base(typeof(MudBlazorDateTimePicker<>))
        {
        }

        public Variant Variant { get; set; }
        public Color Color { get; set; }
        public bool Underline { get; set; }

        public string? Format { get; set; }

        public bool AmPm { get; set; }

        protected override IDictionary<string, object?> GetDateTimeInputParameter()
        {
            return new Dictionary<string, object?>
            {
                [nameof(Variant)] = Variant,
                [nameof(Color)] = Color,
                [nameof(Underline)] = Underline,
                [nameof(Format)] = Format,
                [nameof(AmPm)] = AmPm
            };
        }
    }
}