namespace Autodesk.PackageBuilder
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Model;

    public static class SerializeExtensions
    {
        /// <summary>
        /// Serializar IPackageSerializable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SerializeFile<T>(this T toSerialize, string path, string forceFile = null) where T : IPackageSerializable
        {
            if (forceFile != null)
            {
                var name = Path.GetFileNameWithoutExtension(forceFile);
                var pathExt = Path.GetExtension(path);
                if (name != string.Empty)
                {
                    if (pathExt == string.Empty) path = Path.Combine(path, name);
                }

                var extension = Path.GetExtension(forceFile);
                if (extension != string.Empty)
                {
                    path = Path.ChangeExtension(path, extension);
                }
            }
            return SerializeFile(toSerialize, path);
        }
        /// <summary>
        /// Serializar IPackageSerializable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string SerializeFile<T>(this T toSerialize, string path) where T : IPackageSerializable
        {
            File.WriteAllText(path, toSerialize.SerializeObject());
            return path;
        }

        /// <summary>
        /// Serializar XmlSerializer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toSerialize"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(this T toSerialize) where T : IPackageSerializable
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            using (var sw = new Utf8StringWriter())
            {
                using (var tx = new XmlTextWriter(sw))
                {
                    tx.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(tx, toSerialize, namespaces);
                    string strXmlText = sw.ToString();
                    return strXmlText;
                }
            }
        }

        /// <summary>
        /// Utf8StringWriter
        /// </summary>
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}