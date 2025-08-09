using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudBooleanFormComponentInstance : InputFormComponentInstance<MudCheckBox<bool>>
    {
        public MudBooleanFormComponentInstance() : base(token => (bool?)token)
        {
        }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudCheckBox<bool>.ErrorText)] = ErrorHelperText,
                [nameof(MudCheckBox<bool>.HasErrors)] = !string.IsNullOrWhiteSpace(ErrorHelperText),
                [nameof(MudCheckBox<bool>.Error)] = !string.IsNullOrWhiteSpace(ErrorHelperText)
            };
        }
    }
}