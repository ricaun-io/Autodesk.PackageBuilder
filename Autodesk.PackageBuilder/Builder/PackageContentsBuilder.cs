using Autodesk.PackageBuilder.Model.Application;

namespace Autodesk.PackageBuilder;

public class PackageContentsBuilder : IBuilder
{
    private readonly ApplicationPackage _applicationPackage;
    private readonly ApplicationPackageBuilder _applicationPackageBuilder;
    private readonly CompanyDetailsBuilder _companyDetailsBuilder;
    private readonly ComponentsBuilder _components;

    public IApplicationPackageBuilder ApplicationPackage => _applicationPackageBuilder;

    public ICompanyDetailsBuilder CompanyDetails => _companyDetailsBuilder;

    public IComponentsEntryBuilder Components => _components;

    public PackageContentsBuilder()
    {
        _applicationPackage = new ApplicationPackage();
        _applicationPackageBuilder = new ApplicationPackageBuilder(_applicationPackage);
        _companyDetailsBuilder = new CompanyDetailsBuilder(_applicationPackage.CompanyDetails);
        _components = new ComponentsBuilder(_applicationPackage.Components);
    }

    public string Build(string path)
    {
        return _applicationPackage.SerializeFile(path, "PackageContents.xml");
    }

    public override string ToString()
    {
        return _applicationPackage.SerializeObject();
    }
}