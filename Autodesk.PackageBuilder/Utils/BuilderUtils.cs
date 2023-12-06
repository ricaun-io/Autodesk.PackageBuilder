namespace Autodesk.PackageBuilder
{
    using System;

    /// <summary>
    /// BuilderUtils
    /// </summary>
    public static class BuilderUtils
    {
        /// <summary>
        /// Create a new instance of the <typeparamref name="TBuilder"/> type.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <returns></returns>
        public static TBuilder Build<TBuilder>()
            where TBuilder : IBuilder, new()
        {
            return Activator.CreateInstance<TBuilder>();
        }

        /// <summary>
        /// Create a new instance of the <typeparamref name="TBuilder"/> type and <see cref="IBuilder.Build(string)"./>.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static TBuilder Build<TBuilder>(string path)
            where TBuilder : IBuilder, new()
        {
            var builder = Build<TBuilder>();
            builder.Build(path);
            return builder;
        }

        /// <summary>
        /// Create a new instance of the <typeparamref name="TBuilder"/> type, <paramref name="config"/> the instance, and <see cref="IBuilder.Build(string)"./>.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <param name="path"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TBuilder Build<TBuilder>(string path, Action<TBuilder> config)
            where TBuilder : IBuilder, new()
        {
            return Build(config, path);
        }

        /// <summary>
        /// Create a new instance of the <typeparamref name="TBuilder"/> type, <paramref name="config"/> the instance, and <see cref="IBuilder.Build(string)"./>.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <param name="config"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static TBuilder Build<TBuilder>(Action<TBuilder> config, string path)
            where TBuilder : IBuilder, new()
        {
            var builder = Build(config);
            builder.Build(path);
            return builder;
        }

        /// <summary>
        /// Create a new instance of the <typeparamref name="TBuilder"/> type and <paramref name="config"/> the instance./>.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <param name="config"></param>
        /// <returns></returns>
        public static TBuilder Build<TBuilder>(Action<TBuilder> config)
            where TBuilder : IBuilder, new()
        {
            var builder = Build<TBuilder>();
            config?.Invoke(builder);
            return builder;
        }
    }
}
