using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudDropdownFormComponentInstance : DropdownFormComponentInstance<MudDropDownComponent>
    {
        public DropdownSearchOperator SearchOperator { get; set; }

        public bool SearchCaseSensitive { get; set; }

        protected override IDictionary<string, object?> GetDropdownParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudDropDownComponent.SearchOperator)] = SearchOperator,
                [nameof(MudDropDownComponent.SearchCaseSensitive)] = SearchCaseSensitive
            };
        }
    }
}