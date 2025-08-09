using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public sealed class MudGridColumnFormComponentInstance : FormComponentInstance<MudGridColumn>
    {
        public int? Xs { get; set; }

        public int? Sm { get; set; }

        public int? Md { get; set; }

        public int? Lg { get; set; }

        protected override IDictionary<string, object?> GetParametersCore()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudGridColumn.Lg)] = Lg,
                [nameof(MudGridColumn.Sm)] = Sm,
                [nameof(MudGridColumn.Md)] = Md,
                [nameof(MudGridColumn.Xs)] = Xs
            };
        }
    }
}