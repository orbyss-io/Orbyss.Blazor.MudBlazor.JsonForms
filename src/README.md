# 📦 Orbyss.Blazor.MudBlazor.JsonForms

**A full-featured MudBlazor-based UI renderer for [Orbyss.Blazor.JsonForms](https://github.com/orbyss-io/Orbyss.Blazor.JsonForms).**  
This package brings the power of [MudBlazor](https://mudblazor.com/) components to schema-driven forms using the [jsonforms.io](https://jsonforms.io/) standard.  

All you need to generate your JSON forms are:  
- **JSON Schema** – defines the data structure (types, constraints, etc.)  
- **UI Schema** – controls layout and per-control options  
- **Translation Schema** – handles localization, labels, and error messages  

The package is meant to support all functionality that is also natively supported by jsonforms.io, but not all functionality could be tested and implemented.  
Please — if any functionality is not working as expected — either [open an issue](https://github.com/orbyss-io/Orbyss.Blazor.MudBlazor.JsonForms/issues), or fork the repo and create a PR.  
This is an open source project. **Together we can make it better, faster.**  

If you notice anything that is not working as you expect, please either let us know, or implement your own components (see [Orbyss.Blazor.JsonForms README](https://github.com/orbyss-io/Orbyss.Blazor.JsonForms) for how to do that).  

> **Important Note:** This project is an independent Blazor-based implementation and is **not** affiliated with or supported by the [jsonforms.io](https://jsonforms.io/) team. Please direct all support requests for this package to the Orbyss.io team, not jsonforms.io.

---

## 🎯 What is this?

This package implements the **`IFormComponentInstanceProvider`** interface for MudBlazor — plugging directly into the [Orbyss.Blazor.JsonForms](https://github.com/orbyss-io/Orbyss.Blazor.JsonForms) core form engine.

✅ You don’t need to write your own component provider  
✅ Just install this NuGet package and use `<JsonForm ... />` as normal  
✅ Make sure to either inject `MudFormComponentInstanceProvider` in your DI container, or pass a fresh instance as parameter to  
`<JsonForm ComponentInstanceProvider=@provider ... >`

---

## 🧱 Components Rendered with MudBlazor

All form controls are implemented using MudBlazor components:

- ✅ `MudTextField`, `MudSelect`, `MudSwitch`, `MudDatePicker`, etc.  
- ✅ Supports layout controls like Grid, Columns, Lists, Buttons, and Stepper Navigation  
- ✅ Fully compatible with cascading properties: `Language`, `Disabled`, `ReadOnly`  
- ✅ Custom UI behavior via `options` in your UI schema  

---

## 🚀 Quickstart

```bash
dotnet add package Orbyss.Blazor.MudBlazor.JsonForms
```

### 1️⃣ Add CSS & JS to `index.html`
```html
<link href="_content/MudBlazor/MudBlazor.min.css?v=@(MudBlazor.Metadata.Version)" rel="stylesheet" />
<link href="_content/CodeBeam.MudBlazor.Extensions/MudExtensions.min.css" rel="stylesheet" />

<script src="_content/MudBlazor/MudBlazor.min.js?v=@(MudBlazor.Metadata.Version)"></script>
<script src="_content/CodeBeam.MudBlazor.Extensions/mudExtensions.min.js"></script>
```

### 2️⃣ Register MudBlazor and JsonForms in `MauiProgram.cs`

```csharp
builder.Services.AddMudServices();
builder.Services.AddMudExtensions();

// Optionally configure JsonForms with custom component settings:
var instanceProviderOptions = new MudFormComponentInstanceProviderOptions
{
    ConfigureButton = (@default, type, form) =>
    {
        @default.Size = Size.Medium;

        if (type == Orbyss.Blazor.JsonForms.FormButtonType.Submit)
        {
            @default.EndIcon = Icons.Material.Filled.Send;
        }

        return @default;
    },

    ConfigureDropdownInput = (@default, control) =>
    {
        @default.Searchable = true;
        @default.SearchCaseSensitive = false;
        @default.SearchOperator = DropdownSearchOperator.Contains;

        return @default;
    }
};
builder.Services.AddMudBlazorJsonForms(instanceProviderOptions);
```

---

## ⚙️ Customization

You can override the default behavior by subclassing the `MudFormComponentInstanceProvider`:

```csharp
public class CustomProvider : MudFormComponentInstanceProvider
{
    public override InputFormComponentInstanceBase GetInputField(IJsonFormContext context, FormControlContext control)
    {
        if (control.Interpretation.JsonPath == "$.properties.mySpecialField") 
            return new MyCustomInputInstance();

        return base.GetInputField(context, control);
    }
}
```

This lets you hook into form rendering at the component level for specific fields.

---

## 🔄 Under the hood: Powered by 3 schemas

Like all Orbyss JSON Forms integrations, this renderer works using:

| Schema                  | Purpose                                           |
|-------------------------|---------------------------------------------------|
| **JSON Schema**         | Defines data structure (types, constraints, etc.) |
| **UI Schema**           | Controls layout, per-control options, [rules](https://jsonforms.io/docs/uischema/rules/) |
| **Translation Schema**  | Manages localization, labels, error messages      |

All schema interactions are fully supported.

---

## 🧩 Other UI Options

Prefer a different component library? Try:

- 🎨 [Orbyss.Blazor.Syncfusion.JsonForms](https://www.nuget.org/packages/Orbyss.Blazor.Syncfusion.JsonForms)  
- Or implement your own renderer via `IFormComponentInstanceProvider`

---

## 📄 License
MIT License  
© Orbyss.io

---

## 🔗 Links

- 🌍 **Website**: [https://orbyss.io](https://orbyss.io)  
- 📦 **Core Engine**: [Orbyss.Blazor.JsonForms](https://www.nuget.org/packages/Orbyss.Blazor.JsonForms)  
- 📦 **This Package**: [Orbyss.Blazor.MudBlazor.JsonForms](https://www.nuget.org/packages/Orbyss.Blazor.MudBlazor.JsonForms)  
- 🧑‍💻 **GitHub**: [https://github.com/orbyss-io](https://github.com/orbyss-io)  
- 📚 **MudBlazor Docs**: [MudBlazor](https://mudblazor.com/)  
- 📝 **License**: [MIT](./LICENSE)  

---

## 🤝 Contributing

This project is open source and contributions are welcome!

Whether it's bug fixes, improvements, documentation, or ideas — we encourage developers to get involved.  
Just fork the repo, create a branch, and open a pull request.

We follow standard .NET open-source conventions:
- Write clean, readable code
- Keep PRs focused and descriptive
- Open issues for larger features or discussions

No formal contribution guidelines — just be constructive and respectful.

---

⭐️ Found this useful? [Give us a star](https://github.com/orbyss-io/Orbyss.Blazor.MudBlazor.JsonForms/stargazers) and help spread the word!
