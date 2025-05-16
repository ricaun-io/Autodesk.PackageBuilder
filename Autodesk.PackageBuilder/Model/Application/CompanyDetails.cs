namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    public class CompanyDetails : DataBase
    {
        public CompanyDetails() { }
        public CompanyDetails(string name, string url, string email = null)
        {
            Name = name;
            Url = url;
            Email = email;
        }
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Url { get; set; }

        [XmlAttribute]
        public string Email { get; set; }
    }
}