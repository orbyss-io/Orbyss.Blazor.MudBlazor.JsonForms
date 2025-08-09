using Orbyss.Blazor.JsonForms;
using Orbyss.Blazor.JsonForms.ComponentInstances;
using Orbyss.Blazor.JsonForms.Context.Interfaces;
using Orbyss.Blazor.JsonForms.Context.Models;
using Orbyss.Blazor.MudBlazor.JsonForms.ComponentInstances;
using Orbyss.Components.Json.Models;

namespace Orbyss.Blazor.MudBlazor.JsonForms
{
    public sealed class MudFormComponentInstanceProviderOptions
    {
        public delegate ButtonFormComponentInstance ConfigureButtonDelegate(MudButtonFormComponentInstance defaultButton, FormButtonType type, IJsonFormContext? form);

        public delegate FormComponentInstance ConfigureGridDelegate(MudGridFormComponentInstance defaultGrid, IJsonFormContext? form, FormPageContext? page);

        public delegate FormComponentInstance ConfigureColumnDelegate(MudGridColumnFormComponentInstance defaultColumn, IFormElementContext? column);

        public delegate FormComponentInstance ConfigureRowDelegate(MudRowFormComponentInstance defaultRow, IFormElementContext? row);

        public delegate InputFormComponentInstanceBase ConfigureTextInputDelegate(MudTextFormComponentInstance defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureNumberInputDelegate(MudNumberFormComponentInstance defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureIntegerInputDelegate(MudIntegerFormComponentInstance defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureDropdownInputDelegate(MudDropdownFormComponentInstance defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureMultiDropdownInputDelegate(MudMultiDropDownFormComponentInstance defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureDateInputDelegate<TDate>(DateOnlyInputFormComponentInstanceBase<TDate> defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureDateTimeInputDelegate<TDate>(DateTimeInputFormComponentInstanceBase<TDate> defaultInput, FormControlContext control);

        public delegate InputFormComponentInstanceBase ConfigureBooleanInputDelegate(MudBooleanFormComponentInstance defaultInput, FormControlContext control);

        public delegate ListFormComponentInstance ConfigureListDelegate(ListFormComponentInstance defaultList, FormListContext? list);

        public delegate ListItemFormComponentInstance ConfigureListItemDelegate(ListItemFormComponentInstance defaultList, IFormElementContext? listItem);

        public delegate NavigationFormComponentInstance ConfigureNavigationDelegate(MudStepperFormComponentInstance defaultNavigation, IJsonFormContext formContext);

        public FormType FormType { get; set; } = FormType.Submit;

        public ConfigureButtonDelegate? ConfigureButton { get; set; }

        public ConfigureGridDelegate? ConfigureGrid { get; set; }

        public ConfigureColumnDelegate? ConfigureColumn { get; set; }

        public ConfigureRowDelegate? ConfigureRow { get; set; }

        public ConfigureTextInputDelegate? ConfigureTextInput { get; set; }

        public ConfigureNumberInputDelegate? ConfigureNumberInput { get; set; }

        public ConfigureIntegerInputDelegate? ConfigureIntegerInput { get; set; }

        public ConfigureDropdownInputDelegate? ConfigureDropdownInput { get; set; }

        public ConfigureMultiDropdownInputDelegate? ConfigureMultiDropdownInput { get; set; }

        public ConfigureDateTimeInputDelegate<DateTime?>? ConfigureDateTimeInput { get; set; }

        public ConfigureDateInputDelegate<DateOnly?>? ConfigureDateOnlyInput { get; set; }

        public ConfigureDateTimeInputDelegate<DateTimeUtcTicks?>? ConfigureDateTimeUtcTicksInput { get; set; }

        public ConfigureDateInputDelegate<DateUtcTicks?>? ConfigureDateUtcTicksInput { get; set; }

        public ConfigureBooleanInputDelegate? ConfigureBooleanInput { get; set; }

        public ConfigureListDelegate? ConfigureList { get; set; }

        public ConfigureListItemDelegate? ConfigureListItem { get; set; }

        public ConfigureNavigationDelegate? ConfigureNavigation { get; set; }
    }
}