using MudBlazor;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudTextFormComponentInstance : MudBlazorFormComponentInstanceBase<MudBlazorTextField>
    {
        public MudTextFormComponentInstance() : base(token => token?.ToString())
        {
        }

        public Typo Typo { get; set; } = Typo.inherit;

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = base.GetFormInputParameters();
            result.Add(nameof(MudBlazorTextField.Typo), Typo);

            return result;
        }
    }
}