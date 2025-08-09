using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudRowFormComponentInstance : FormComponentInstance<MudGridRow>
    {
        public MudGridFormComponentInstance? InnerGridComponent { get; init; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudGridRow.InnerGridComponent)] = InnerGridComponent
            };
        }
    }
}