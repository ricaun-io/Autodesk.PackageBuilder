namespace Autodesk.PackageBuilder
{
    /// <summary>
    /// IBuilder
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Build
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string Build(string path);
    }
}