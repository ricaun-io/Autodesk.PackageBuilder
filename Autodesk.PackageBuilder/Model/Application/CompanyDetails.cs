namespace Autodesk.PackageBuilder.Model.Application
{
    using System.Xml;
    using System.Xml.Serialization;
    /// <summary>
    /// Represents company information including name, URL, and optional email address.
    /// </summary>
    public class CompanyDetails : DataBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetails"/> class.
        /// </summary>
        public CompanyDetails() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetails"/> class with the specified name, URL, and optional email.
        /// </summary>
        /// <param name="name">The name of the company.</param>
        /// <param name="url">The URL of the company.</param>
        /// <param name="email">The email address of the company (optional).</param>
        public CompanyDetails(string name, string url, string email = null)
        {
            Name = name;
            Url = url;
            Email = email;
        }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the company.
        /// </summary>
        [XmlAttribute]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the email address of the company.
        /// </summary>
        [XmlAttribute]
        public string Email { get; set; }
    }
}