using MudBlazor;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudBooleanFormComponentInstance : MudBlazorFormComponentInstanceBase<MudBlazorBooleanField>
    {
        public MudBooleanFormComponentInstance() : base(token => token?.ToString())
        {
        }
        public Placement LabelPlacement { get; set; }
        
        public Size Size { get; set; }

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = base.GetFormInputParameters();

            result.Add(nameof(MudBlazorBooleanField.LabelPlacement), LabelPlacement);
            result.Add(nameof(MudBlazorBooleanField.Size), Size);

            return result;
        }
    }
}