using MudBlazor;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;

namespace Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances
{
    public class MudButtonFormComponentInstance : ButtonFormComponentInstance
    {
        public MudButtonFormComponentInstance(IDictionary<string, string> textTranslations) : base(typeof(MudButtonComponent), textTranslations)
        {
        }

        public MudButtonFormComponentInstance(string text) : base(typeof(MudButtonComponent), text)
        {
        }

        public Variant Variant { get; init; }

        public Color Color { get; init; }

        public string? StartIcon { get; init; }

        public string? EndIcon { get; init; }

        public Size Size { get; init; } = Size.Small;

        protected override IDictionary<string, object?> GetButtonParameters()
        {
            return new Dictionary<string, object?>
            {
                [nameof(MudButtonComponent.Variant)] = Variant,
                [nameof(MudButtonComponent.Color)] = Color,

                [nameof(MudButtonComponent.Size)] = Size,
                [nameof(MudButtonComponent.StartIcon)] = StartIcon,
                [nameof(MudButtonComponent.EndIcon)] = EndIcon
            };
        }
    }

    public sealed class MudAddButtonFormComponentInstance : MudButtonFormComponentInstance
    {
        private static readonly IDictionary<string, string> textTranslations = new Dictionary<string, string>
        {
            ["EN"] = "Add",
            ["NL"] = "Toevoegen",
            ["DE"] = "Hinzufügen",
            ["FR"] = "Ajouter",
            ["ES"] = "Añadir"
        };

        public MudAddButtonFormComponentInstance() : base(textTranslations)
        {
            Variant = Variant.Filled;
            Color = Color.Success;
            StartIcon = Icons.Material.Filled.Add;
        }
    }

    public sealed class MudUpdateButtonFormComponentInstance : MudButtonFormComponentInstance
    {
        private static readonly IDictionary<string, string> textTranslations = new Dictionary<string, string>
        {
            ["EN"] = "Update",
            ["NL"] = "Opslaan",
            ["DE"] = "Aktualisieren",
            ["FR"] = "Actualiser",
            ["ES"] = "Actualizar"
        };

        public MudUpdateButtonFormComponentInstance() : base(textTranslations)
        {
            Color = Color.Primary;
            Variant = Variant.Filled;
            StartIcon = Icons.Material.Filled.Save;
        }
    }

    public sealed class MudSubmitButtonFormComponentInstance : MudButtonFormComponentInstance
    {
        private static readonly IDictionary<string, string> textTranslations = new Dictionary<string, string>
        {
            ["EN"] = "Submit",
            ["NL"] = "Verzenden",
            ["DE"] = "Einreichen",
            ["FR"] = "Soumettre",
            ["ES"] = "Enviar"
        };

        public MudSubmitButtonFormComponentInstance() : base(textTranslations)
        {
            Color = Color.Primary;
            Variant = Variant.Filled;
        }
    }

    public sealed class MudNextButtonFormComponentInstance : MudButtonFormComponentInstance
    {
        private static readonly IDictionary<string, string> textTranslations = new Dictionary<string, string>
        {
            ["EN"] = "Next",
            ["NL"] = "Volgende",
            ["DE"] = "Weiter",
            ["FR"] = "Suivant",
            ["ES"] = "Siguiente"
        };

        public MudNextButtonFormComponentInstance() : base(textTranslations)
        {
            Color = Color.Primary;
            Variant = Variant.Filled;
            EndIcon = Icons.Material.Filled.ArrowForward;
        }
    }

    public sealed class MudPreviousButtonFormComponentInstance : MudButtonFormComponentInstance
    {
        private static readonly IDictionary<string, string> textTranslations = new Dictionary<string, string>
        {
            ["EN"] = "Previous",
            ["NL"] = "Vorige",
            ["DE"] = "Vorherige",
            ["FR"] = "Précédent",
            ["ES"] = "Anterior"
        };

        public MudPreviousButtonFormComponentInstance() : base(textTranslations)
        {
            Color = Color.Primary;
            Variant = Variant.Outlined;
            StartIcon = Icons.Material.Filled.ArrowBack;
        }
    }
}