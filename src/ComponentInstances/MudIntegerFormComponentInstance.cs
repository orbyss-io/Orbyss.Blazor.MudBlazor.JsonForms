using MudBlazor;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudIntegerFormComponentInstance : MudBlazorFormComponentInstanceBase<MudBlazorIntegerField>
    {
        public MudIntegerFormComponentInstance() : base(token => (int?)token)
        {
        }

        public Typo Typo { get; set; } = Typo.inherit;

        protected override IDictionary<string, object?> GetFormInputParameters()
        {
            var result = base.GetFormInputParameters();
            result.Add(nameof(MudBlazorIntegerField.Typo), Typo);

            return result;
        }
    }
}