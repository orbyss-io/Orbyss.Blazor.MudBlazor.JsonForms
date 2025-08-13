using MudBlazor;
using MudExtensions.Utilities;
using Orbyss.Blazor.JsonForms;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.JsonForms.ComponentInstances.Interfaces;
using Orbyss.Blazor.JsonForms.Context.Interfaces;
using Orbyss.Blazor.JsonForms.Context.Models;
using Orbyss.Blazor.JsonForms.Interpretation;
using Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.MudBlazor.JsonForms.Components;
using ZXing.Common.ReedSolomon;

namespace Orbyss.Blazor.MudBlazor.JsonForms
{
    public class MudFormComponentInstanceProvider(MudFormComponentInstanceProviderOptions? options = null)
        : IFormComponentInstanceProvider
    {
        private readonly Dictionary<string, StepperLocalizedStrings> stepperLocalizedStrings = new(StringComparer.OrdinalIgnoreCase)
        {
            ["EN"] = new StepperLocalizedStrings
            {
                Completed = "Completed",
                Finish = "Finish",
                Next = "Next",
                Optional = "Optional",
                Previous = "Previous",
                Skip = "Skip",
                Skipped = "Skipped"
            },

            ["NL"] = new StepperLocalizedStrings
            {
                Completed = "Ingevuld",
                Finish = "Afronden",
                Next = "Volgende",
                Optional = "Optioneel",
                Previous = "Vorige",
                Skip = "Overslaan",
                Skipped = "Overgeslagen"
            },

            ["DE"] = new StepperLocalizedStrings
            {
                Completed = "Abgeschlossen",
                Finish = "Runde",
                Next = "Weiter",
                Optional = "Optional",
                Previous = "Vorherige",
                Skip = "Überspringen",
                Skipped = "Überspringen"
            },

            ["FR"] = new StepperLocalizedStrings
            {
                Completed = "Complété",
                Finish = "Arrondir",
                Next = "Suivant",
                Optional = "Optionnel",
                Previous = "Précédent",
                Skip = "Sauter",
                Skipped = "Sauté"
            },

            ["ES"] = new StepperLocalizedStrings
            {
                Completed = "Completado",
                Finish = "Terminar",
                Next = "Siguiente",
                Optional = "Opcional",
                Previous = "Previo",
                Skip = "Omitir",
                Skipped = "Omitió"
            }
        };

        private static readonly MudButtonFormComponentInstance DefaultAddButton = new(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EN"] = "Add",
                ["ES"] = "Añadir",
                ["DE"] = "Hinzufügen",
                ["NL"] = "Toevoegen",
                ["FR"] = "Ajouter"
            }
        )
        {
            Color = Color.Success,
            Variant = Variant.Filled
        };

        private static readonly MudButtonFormComponentInstance DefaultUpdateButton = new(
           new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
           {
               ["EN"] = "Update",
               ["ES"] = "Actualizar",
               ["DE"] = "Aktualisieren",
               ["NL"] = "Bijwerken",
               ["FR"] = "Actualiser"
           }
        )
        {
            Color = Color.Primary,
            Variant = Variant.Filled
        };

        private static readonly MudButtonFormComponentInstance DefaultNextButton = new(
           new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
           {
               ["EN"] = "Next",
               ["ES"] = "Siguiente",
               ["DE"] = "Folgende",
               ["NL"] = "Volgende",
               ["FR"] = "Suivant"
           }
        )
        {
            Color = Color.Primary,
            Variant = Variant.Filled,
            EndIcon = Icons.Material.Filled.ArrowRight
        };

        private static readonly MudButtonFormComponentInstance DefaultPreviousButton = new(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EN"] = "Previous",
                ["ES"] = "Anterior",
                ["DE"] = "Vorherige",
                ["NL"] = "Vorige",
                ["FR"] = "Précédent"
            }
        )
        {
            Color = Color.Default,
            Variant = Variant.Outlined,
            StartIcon = Icons.Material.Filled.ArrowLeft
        };

        private static readonly MudButtonFormComponentInstance DefaultSubmitButton = new(
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["EN"] = "Submit",
                ["ES"] = "Enviar",
                ["DE"] = "Einreichen",
                ["NL"] = "Indienen",
                ["FR"] = "Soumettre"
            }
        )
        {
            Color = Color.Primary,
            Variant = Variant.Filled
        };

        private MudButtonFormComponentInstance GetSubmitButton()
        {
            var formType = options?.FormType ?? FormType.Submit;

            return formType switch
            {
                FormType.Add => DefaultAddButton,
                FormType.Update => DefaultUpdateButton,
                _ => DefaultSubmitButton
            };
        }

        public virtual ButtonFormComponentInstanceBase GetButton(FormButtonType type, IJsonFormContext? form = null)
        {
            var result = GetButtonInternal(type, form);
            if (options?.ConfigureButton is not null)
            {
                return options.ConfigureButton(result, type, form);
            }

            return result;
        }

        private MudButtonFormComponentInstance GetButtonInternal(FormButtonType type, IJsonFormContext? form = null)
        {
            return type switch
            {
                FormButtonType.Submit => GetSubmitButton(),
                FormButtonType.Previous => DefaultPreviousButton,
                FormButtonType.Next => DefaultNextButton,

                _ => throw new NotSupportedException($"Form button type '{type}' is not supported")
            };
        }

        public virtual IFormComponentInstance GetGrid(IJsonFormContext? form = null, FormPageContext? page = null)
        {
            var result = new MudGridFormComponentInstance
            {
                Class = "mb-4"
            };

            if (options?.ConfigureGrid is not null)
            {
                return options.ConfigureGrid(result, form, page);
            }

            return result;
        }

        public virtual IFormComponentInstance GetGridColumn(IFormElementContext? column = null)
        {
            var result = new MudGridColumnFormComponentInstance
            {
                Xs = 4
            };

            if (options?.ConfigureColumn is not null)
            {
                return options.ConfigureColumn(result, column);
            }

            return result;
        }

        public virtual IFormComponentInstance GetGridRow(IFormElementContext? row)
        {
            if (row is not null && row is not FormControlContext)
            {
                // This means that the layout is another layout. In MudBlazor we will then create another MudItem as a wrapper around the inner layout

                return new MudRowFormComponentInstance
                {
                    InnerGridComponent = new MudGridFormComponentInstance
                    {
                        Spacing = 2,
                        Justify = Justify.FlexStart
                    }
                };
            }

            var result = new MudRowFormComponentInstance();

            if (options?.ConfigureRow is not null)
            {
                return options.ConfigureRow(result, row);
            }

            return result;
        }

        public virtual InputFormComponentInstanceBase GetInputField(IJsonFormContext context, FormControlContext control)
        {
            var type = control.Interpretation.ControlType;

            return type switch
            {
                ControlType.Boolean => GetBooleanField(control),
                ControlType.String => GetTextField(control),
                ControlType.Enum => GetDropDownField(control),
                ControlType.EnumList => GetMultiDropDownField(control),
                ControlType.DateTime => GetDateTimeField(control),
                ControlType.DateTimeUtcTicks => GetDateTimeUtcTicksField(control),
                ControlType.DateOnly => GetDateOnlyField(control),
                ControlType.DateOnlyUtcTicks => GetDateUtcTicksField(control),

                ControlType.Integer => GetIntegerField(control),
                ControlType.Number => GetNumberField(control),

                _ => throw new NotSupportedException($"Cannot create an input field for type '{type}'")
            };
        }

        public virtual ListFormComponentInstanceBase GetList(FormListContext? list = null)
        {
            var result = new ListFormComponentInstance<MudListComponent>();
            if (options?.ConfigureList is not null)
            {
                return options.ConfigureList(result, list);
            }
            return result;
        }

        public virtual ListItemFormComponentInstance GetListItem(IFormElementContext? listItem = null)
        {
            var result = new ListItemFormComponentInstance<MudListItemComponent>();
            if (options?.ConfigureListItem is not null)
            {
                return options.ConfigureListItem(result, listItem);
            }
            return result;
        }

        public virtual NavigationFormComponentInstanceBase GetNavigation(IJsonFormContext formContext)
        {
            StepperLocalizedStrings localizedStrings;

            if (string.IsNullOrWhiteSpace(formContext.ActiveLanguage))
            {
                localizedStrings = new();
            }
            else if (stepperLocalizedStrings.TryGetValue(formContext.ActiveLanguage, out StepperLocalizedStrings? value))
            {
                localizedStrings = value;
            }
            else
            {
                localizedStrings = new();
            }

            var result = new MudStepperFormComponentInstance
            {
                Color = Color.Primary,
                Variant = Variant.Filled,
                LocalizedStrings = localizedStrings
            };

            if (options?.ConfigureNavigation is not null)
            {
                return options.ConfigureNavigation(result, formContext);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetTextField(FormControlContext control)
        {
            var result = new MudTextFormComponentInstance();

            if (options?.ConfigureTextInput is not null)
            {
                return options.ConfigureTextInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDropDownField(FormControlContext control)
        {
            var result = new MudDropdownFormComponentInstance();

            if (options?.ConfigureDropdownInput is not null)
            {
                return options.ConfigureDropdownInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetMultiDropDownField(FormControlContext control)
        {
            var result = new MudMultiDropDownFormComponentInstance();

            if (options?.ConfigureMultiDropdownInput is not null)
            {
                return options.ConfigureMultiDropdownInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateTimeField(FormControlContext control)
        {
            var result = new MudDateTimePickerFormComponentInstance();

            if (options?.ConfigureDateTimeInput is not null)
            {
                return options.ConfigureDateTimeInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateOnlyField(FormControlContext control)
        {
            var result = new MudDatePickerFormComponentInstance();

            if (options?.ConfigureDateOnlyInput is not null)
            {
                return options.ConfigureDateOnlyInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateTimeUtcTicksField(FormControlContext control)
        {
            var result = new MudDateTimeUtcTicksPickerFormComponentInstance();

            if (options?.ConfigureDateTimeUtcTicksInput is not null)
            {
                return options.ConfigureDateTimeUtcTicksInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetDateUtcTicksField(FormControlContext control)
        {
            var result = new MudDateUtcTicksPickerFormComponentInstance();

            if (options?.ConfigureDateUtcTicksInput is not null)
            {
                return options.ConfigureDateUtcTicksInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetIntegerField(FormControlContext control)
        {
            var result = new MudIntegerFormComponentInstance();

            if (options?.ConfigureIntegerInput is not null)
            {
                return options.ConfigureIntegerInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetNumberField(FormControlContext control)
        {
            var result = new MudNumberFormComponentInstance();

            if (options?.ConfigureNumberInput is not null)
            {
                return options.ConfigureNumberInput(result, control);
            }
            return result;
        }

        protected virtual InputFormComponentInstanceBase GetBooleanField(FormControlContext control)
        {
            var result = new MudBooleanFormComponentInstance();

            if (options?.ConfigureBooleanInput is not null)
            {
                return options.ConfigureBooleanInput(result, control);
            }
            return result;
        }
    }
}