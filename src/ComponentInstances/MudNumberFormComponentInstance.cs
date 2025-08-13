using MudBlazor;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudNumberFormComponentInstance : MudBlazorFormComponentInstanceBase<MudBlazorNumberField>
    {
        public MudNumberFormComponentInstance() : base(token => (double?)token)
        {
        }

        public Typo Typo { get; set; } = Typo.inherit;

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = base.GetFormInputParameters();
            result.Add(nameof(MudBlazorNumberField.Typo), Typo);

            return result;
        }
    }
}