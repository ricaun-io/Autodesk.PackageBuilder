# Autodesk.PackageBuilder

[![Autodesk](https://img.shields.io/badge/Autodesk-black?logo=autodesk&logoColor=white)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![AutoCAD](https://img.shields.io/badge/AutoCAD-E51050.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![Revit](https://img.shields.io/badge/Revit-186BFF.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![3ds Max](https://img.shields.io/badge/3ds%20Max-37A5CC.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![Inventor](https://img.shields.io/badge/Inventor-DBAE03.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![Maya](https://img.shields.io/badge/Maya-37A5CC.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![Navisworks](https://img.shields.io/badge/Navisworks-186BFF.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
<!-- 
[![Vault](https://img.shields.io/badge/Vault-DBAE03.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![Fusion 360](https://img.shields.io/badge/Fusion%20360-FF6B00.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
-->

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/Autodesk.PackageBuilder)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/Autodesk.PackageBuilder/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/Autodesk.PackageBuilder/actions)
[![Release](https://img.shields.io/nuget/v/Autodesk.PackageBuilder?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/Autodesk.PackageBuilder)

This package is intended to build Autodesk `PackageContent.xml` and `RevitAddin.addin/InventorAddin.addin` using C# fluent API.

## Autodesk Product Version Table

| Product      | RuntimeRequirements::SeriesMin/SeriesMax | RuntimeRequirements::Platform        |
|--------------|------------------------------------------|--------------------------------------|
| AutoCAD      | R24.0 (2021), R23.1 (2020), R23.0 (2019) | AutoCAD*                             |
| Revit        | R2021, R2020, R2019, R2018, R2017        | Revit                                |
| Maya         | 2021, 2020, 2019, 2018, ...              | Maya                                 |
| 3ds Max      | 2021, 2020, 2019, 2018, ...              | 3ds Max&#124;3ds Max Design          |
| Inventor     | (version is taken from add-in manifest)  | Inventor                             |
| Navisworks   | Nw18 (2021), Nw17 (2020), Nw16 (2019)    | NAVMAN&#124;NAVSIM                   |
| Vault        | V2021, V2020, V2019, ...                 | Vault                                |
| Fusion 360   | (No version, leave empty)                | Fusion 360                           |

* [AppBundle: Autodesk Products - 2020](https://www.autodesk.com/autodesk-university/class/AppBundle-Cross-Distribution-Autodesk-Products-App-Store-and-Forge-2020)

## Examples

### Create PackageContents.xml

To get the `PackageContents.xml` like this:
```xml
<?xml version="1.0" encoding="utf-8"?>
<ApplicationPackage SchemaVersion="1.0" ProductType="Application" AutodeskProduct="Revit" Name="RevitAddin" AppVersion="1.0.0">
  <CompanyDetails Name="Company Name" Email="email" Url="url" />
  <Components Description="Revit 2021">
    <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R2021" SeriesMax="R2021" />
    <ComponentEntry AppName="RevitAddin" ModuleName="./Contents/2021/RevitAddin.addin" />
  </Components>
  <Components Description="Revit 2022">
    <RuntimeRequirements OS="Win64" Platform="Revit" SeriesMin="R2022" SeriesMax="R2022" />
    <ComponentEntry AppName="RevitAddin" ModuleName="./Contents/2022/RevitAddin.addin" />
  </Components>
</ApplicationPackage>
```

Inherit your builder class from `PackageContentsBuilder` base class.
```C#
public class DemoPackageBuilder : PackageContentsBuilder
{
    public DemoPackageBuilder()
    {
        ApplicationPackage
            .Create()
            .ProductType(ProductTypes.Application)
            .AutodeskProduct(AutodeskProducts.Revit)
            .Name("RevitAddin")
            .AppVersion("1.0.0");

        CompanyDetails
            .Create("Company Name")
            .Email("email")
            .Url("url");

        Components
            .CreateEntry("Revit 2021")
            .OS("Win64")
            .Platform("Revit")
            .SeriesMin("R2021")
            .SeriesMax("R2021")
            .AppName("RevitAddin")
            .ModuleName(@"./Contents/2021/RevitAddin.addin");

        Components
            .CreateEntry("Revit 2022")
            .RevitPlatform(2022)
            .AppName("RevitAddin")
            .ModuleName(@"./Contents/2022/RevitAddin.addin");
    }
}
```

Or use `BuilderUtils.Build<PackageContentsBuilder>()`.

```C#
var builder = BuilderUtils.Build<PackageContentsBuilder>(builder =>
{
    builder.ApplicationPackage
        .Create()
        .ProductType(ProductTypes.Application)
        .AutodeskProduct(AutodeskProducts.Revit)
        .Name("RevitAddin")
        .AppVersion("1.0.0");

    builder.CompanyDetails
        .Create("Company Name")
        .Email("email")
        .Url("url");

    builder.Components
        .CreateEntry("Revit 2021")
        .OS("Win64")
        .Platform("Revit")
        .SeriesMin("R2021")
        .SeriesMax("R2021")
        .AppName("RevitAddin")
        .ModuleName(@"./Contents/2021/RevitAddin.addin");

    builder.Components
        .CreateEntry("Revit 2022")
        .RevitPlatform(2022)
        .AppName("RevitAddin")
        .ModuleName(@"./Contents/2022/RevitAddin.addin");
});
```

## Getting results

### String result

```C#
var builder = new DemoPackageBuilder();
var result = builder.ToString();
```

### .xml file

```C#
var builder = new DemoPackageBuilder();
builder.Build("PackageContents.xml");

// or

BuilderUtils.Build<DemoPackageBuilder>("PackageContents.xml");

// or

BuilderUtils.Build<DemoPackageBuilder>("PackageContents.xml", builder => {...});

// or

BuilderUtils.Build<DemoPackageBuilder>(builder => {...}, "PackageContents.xml");

// or

BuilderUtils.Build<DemoPackageBuilder>(builder => {...}).Build("PackageContents.xml");
```

### Create RevitAddin.addin

To get the `RevitAddin.addin` like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>RevitAddin</Name>
    <AddInId>11111111-2222-3333-4444-555555555555</AddInId>
    <Assembly>RevitAddin.dll</Assembly>
    <FullClassName>RevitAddin.App</FullClassName>
    <VendorId>RevitAddin</VendorId>
    <VendorDescription>RevitAddin</VendorDescription>
  </AddIn>
</RevitAddIns>
```

Inherit your builder class from `RevitAddInsBuilder` base class.

```C#
public class DemoAddinBuilder : RevitAddInsBuilder
{
    public DemoAddinBuilder()
    {
        AddIn.CreateEntry("Application")
            .Name("RevitAddin")
            .AddInId("11111111-2222-3333-4444-555555555555")
            .Assembly("RevitAddin.dll")
            .FullClassName("RevitAddin.App")
            .VendorId("RevitAddin")
            .VendorDescription("RevitAddin");
    }
}
```

Or use `BuilderUtils.Build<RevitAddInsBuilder>()`.

```C#
var builder = BuilderUtils.Build<RevitAddInsBuilder>(builder =>
{
    builder.AddIn.CreateEntry("Application")
        .Name("RevitAddin")
        .AddInId("11111111-2222-3333-4444-555555555555")
        .Assembly("RevitAddin.dll")
        .FullClassName("RevitAddin.App")
        .VendorId("RevitAddin")
        .VendorDescription("RevitAddin");
});
```

## Getting results

### String result

```C#
var builder = new DemoAddinBuilder();
var result = builder.ToString();
```

### .addin file

```C#
var builder = new DemoAddinBuilder();
builder.Build("RevitAddin.addin");

// or

BuilderUtils.Build<DemoAddinBuilder>("RevitAddin.addin");

// or

BuilderUtils.Build<DemoAddinBuilder>("RevitAddin.addin", builder => {...});

// or

BuilderUtils.Build<DemoAddinBuilder>(builder => {...}, "RevitAddin.addin");

// or

BuilderUtils.Build<DemoAddinBuilder>(builder => {...}).Build("RevitAddin.addin");
```

### Not implemented Attribute and Element

If the `Attribute` or `Element` is not implemented, you can use `DataBuilder` to access the methods `CreateAttribute` and `CreateElement`.

```C#
var builder = BuilderUtils.Build<PackageContentsBuilder>(builder =>
{
    builder.Components
        .CreateEntry("Revit 2021")
        .DataBuilder.CreateAttribute("Attribute", "Value");

    builder.Components
        .CreateEntry("Revit 2022")
        .DataBuilder.CreateElement("Element", "Value");

    builder.Components
        .CreateEntry("Revit 2023")
        .DataBuilder.CreateAttribute<ComponentEntry>("Attribute", "Value");

    builder.Components
        .CreateEntry("Revit 2024")
        .DataBuilder.CreateElement<ComponentEntry>("Element", "Value");
});
```

#### Create custom Element/Attribute

The class `ExtensibleData` could be used to create custom `Element`.
```C#
public class CustomElement : ExtensibleData
{
    [XmlAttribute]
    public string Name { get; set; }
    [XmlElement]
    public string Value { get; set; }
}
```

The `ExtensibleData` uses a `XmlSerializer` to serialize the object. 
Use the `DataBuilder` to access the methods `CreateElement` and `CreateAttribute` to create custom elements or attributes.

```C#
var builder = BuilderUtils.Build<PackageContentsBuilder>(builder =>
{
    var custom = new CustomElement()
    {
        Name = "Name",
        Value = "Value"
    };

    var componentRevit2021 = builder.Components
        .CreateEntry("Revit 2021");

    componentRevit2021.DataBuilder.CreateAttribute("Attribute", true);
    componentRevit2021.DataBuilder.CreateElement("Element", true);
    componentRevit2021.DataBuilder.CreateElement("CustomElement", custom);
});
```

This is the result of the above code:

```xml
<?xml version="1.0" encoding="utf-8"?>
<ApplicationPackage>
    <CompanyDetails />
    <Components Description="Revit 2021" Attribute="True">
    <Element>true</Element>
    <CustomElement Name="Name">
        <Value>Value</Value>
    </CustomElement>
    </Components>
</ApplicationPackage>
```

## Package Inspiration / Reference

This package was inspired by [InnoSetup.ScriptBuilder](https://github.com/ReactiveBIM/InnoSetup.ScriptBuilder) package.

## License

This package is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this package? Please [star this project on GitHub](https://github.com/ricaun-io/Autodesk.PackageBuilder/stargazers)!
