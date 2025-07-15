# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [2.0.1] / 2025-07-15
### Features
- Support `Navisworks` extensible data.
### PackageBuilder
- Add `NavisworksExtensibleData` to support `AppType` configuration.

## [2.0.0] / 2025-05-16 - 2025-06-05
### Features
- Support `AutoCAD` bundle.
- Support `Inventor` bundle and add-in.
- Support `3ds Max` bundle.
- Support `Maya` bundle.
- Support `Navisworks` bundle.
- Support custom `Element` and `Attribute`.
- Add `IncludeSymbols` to support `SymbolPackageFormat`.
### PackageBuilder
- Add `ExtensibleData` with custom `IXmlSerializable`.
- Add `ExtensibleDataExtension` with `CreateEntryElement` and `CreateAttribute`.
- Add `DataBuilderBase` and `DataBuilderBaseExtension`.
- Add `AutoCADUtils` to support `AutoCADApplication` and `AutoCADPlatform`.
- Add `AutoCADExtensibleData` to support `LoadOnAppearance` and `Commands`.
- Add `AutoCADCommands` and `AutoCADCommand` in `AutoCADExtensibleData`.
- Add `InventorUtils` to support `InventorApplication` and `InventorPlatform`.
- Rename `AddInEntryBuilder` to `RevitAddInEntryBuilder`.
- Add `IInventorAddInEntryBuilder`, `InventorAddInEntryBuilder` and `InventorAddIn`.
- Update `InventorUtils` to have `SupportedSoftwareVersion` extension method.
- Add `Max3dsUtils` to support `Max3dsApplication` and `Max3dsPlatform`.
- Update `InventorUtils` to use `SeriesMin/SeriesMax` for `App Store` only.
- Add `MayaUtils` to support `MayaApplication` and `MayaPlatform`.
- Add `NavisworksUtils` to support `NavisworksApplication` and `NavisworksPlatform`.
- Add `AppNameSpace` and `UpgradeCode` to `PackageBuilder`.
- Update `ProductCode` and `UpgradeCode` to convert `Guid` to `ToStringBraces`.
- Update `AppVersion` to convert `Version` to `ToString(3)`.
### Tests
- Add `DataBuild_Tests` to test `DataBuilder`
- Add `PackageContentsBuilder_AutoCAD_Tests` and `PackageContentsBuilder_Revit_Tests`.
- Add `InventorAddInsBuilder_Tests` to test `InventorAddInEntryBuilder`.
- Add `PackageContentsBuilder_Inventor_Tests` to test `InventorUtils`.
- Add `PackageContentsBuilder_Max3ds_Tests` to test `Max3dsUtils`.
- Add `PackageContentsBuilder_Maya_Tests` to test `MayaUtils`.
- Add `PackageContentsBuilder_Navisworks_Tests` to test `NavisworksUtils`.

## [1.0.6] / 2023-11-24 - 2023-12-06
### Features
- `Tests` project.
- Update `BuilderUtils` to return instance and features (#16).
### PackageBuilder
- Enable `DocumentationFile` in package.
- Update `BuilderUtils` to return instance.
- Obsolete and internal `AllowLoadingIntoExistingSession`
- Update `Example` Guid.
### Tests
- Test `Constants`
- Test `BuilderUtils`
- Test `Builder` create file.
- Test `RevitAddInsBuilder`
- Test `PackageContentsBuilder`
- Add `AssertBuilderUtils`
- Test `RevitUtils`

## [1.0.5] / 2021-12-21
- Update Build Project
- 2021-12-21
- Remove Folder Build Project
- 2021-12-17
- Test Example
- Rename Example
- Set Visible `false` LICENSE $ README

## [1.0.4] / 2021-12-09
- Add Readme inside Package
- Update Readme
- Remove `AllowLoadingIntoExistingSession` AddInModel.cs

## [1.0.3] / 2021-12-07
- Clear Build
- Update Develop.yml `branches-ignore:`
- Add ricaun.Nuke

## [1.0.2] / 2021-12-05
- Move icon to Resources
- Deploy without CI
- Change `NugetApiUrl: ${{ secrets.NUGET_API_URL }}`
- Change `NugetApiKey: ${{ secrets.NUGET_API_KEY }}`
- Change To `https://api.nuget.org/v3/index.json`
- Add LICENCE to package

## [1.0.1] / 2021-11-26
- Add Examples

## [1.0.0] / 2021-11-26
- First Release

[vNext]: ../../compare/1.0.0...HEAD
[2.0.1]: ../../compare/2.0.0...2.0.1
[2.0.0]: ../../compare/1.0.6...1.2.0
[1.0.6]: ../../compare/1.0.5...1.0.6
[1.0.5]: ../../compare/1.0.4...1.0.5
[1.0.4]: ../../compare/1.0.3...1.0.4
[1.0.3]: ../../compare/1.0.2...1.0.3
[1.0.2]: ../../compare/1.0.1...1.0.2
[1.0.1]: ../../compare/1.0.0...1.0.1
[1.0.0]: ../../compare/1.0.0