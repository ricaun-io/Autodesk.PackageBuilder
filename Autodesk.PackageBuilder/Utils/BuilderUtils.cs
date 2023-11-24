namespace Autodesk.PackageBuilder;

public static class BuilderUtils
{
    public static TBuilder Build<TBuilder>() where TBuilder : IBuilder, new()
    {
        return Activator.CreateInstance<TBuilder>();
    }

    public static void Build<TBuilder>(string path)
        where TBuilder : IBuilder, new()
    {
        var builder = Activator.CreateInstance<TBuilder>();
        builder.Build(path);
    }

    public static void Build<TBuilder>(Action<TBuilder> config, string path)
        where TBuilder : IBuilder, new()
    {
        var builder = Build(config);
        builder.Build(path);
    }

    public static void Build<TBuilder>(string path, Action<TBuilder> config)
        where TBuilder : IBuilder, new()
    {
        var builder = Build(config);
        builder.Build(path);
    }

    public static TBuilder Build<TBuilder>(Action<TBuilder> config)
        where TBuilder : IBuilder, new()
    {
        var builder = Activator.CreateInstance<TBuilder>();
        config?.Invoke(builder);
        return builder;
    }
}