using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Autodesk.PackageBuilder.Model;

namespace Autodesk.PackageBuilder;

public static class SerializeExtensions
{
    /// <summary>
    /// Serializer IPackageSerializable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="toSerialize"></param>
    /// <param name="path"></param>
    /// <param name="forceFile"></param>
    /// <returns></returns>
    public static string SerializeFile<T>(this T toSerialize, string path, string forceFile = null) where T : IPackageSerializable
    {
        if (forceFile is null) return InternalSerializeFile(toSerialize, path);

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

        return InternalSerializeFile(toSerialize, path);
    }

    /// <summary>
    /// Serializer XmlSerializer
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
    /// Serializer IPackageSerializable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="toSerialize"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    private static string InternalSerializeFile<T>(this T toSerialize, string path) where T : IPackageSerializable
    {
        File.WriteAllText(path, toSerialize.SerializeObject());
        return path;
    }

    /// <summary>
    /// Utf8StringWriter
    /// </summary>
    public sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}