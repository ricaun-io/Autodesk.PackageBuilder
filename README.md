# Autodesk.PackageBuilder

![Build](https://github.com/ricaun-io/Autodesk.PackageBuilder/actions/workflows/Build.yml/badge.svg)

## Package 
```xml
<PropertyGroup>
    <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
    <PackageProjectUrl>https://github.com/ricaun-io/Autodesk.PackageBuilder</PackageProjectUrl>
    <RepositoryUrl>https://github.com/ricaun-io/Autodesk.PackageBuilder</RepositoryUrl>
    <RepositoryType>github</RepositoryType>
    <SignAssembly>false</SignAssembly>
    <PackageIcon>icon.png</PackageIcon>
    <PackageIconUrl />
</PropertyGroup>

<ItemGroup>
    <None Include="icon.png">
        <Pack>True</Pack>
        <PackagePath></PackagePath>
    </None>
</ItemGroup>
```