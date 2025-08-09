using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudGridFormComponentInstance : FormComponentInstance<MudGridComponent>
    {
        public Justify Justify { get; set; }

        public int? Spacing { get; set; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudGridComponent.Justify)] = Justify,
                [nameof(MudGridComponent.Spacing)] = Spacing
            };
        }
    }
}