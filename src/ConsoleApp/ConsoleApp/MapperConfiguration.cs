namespace ConsoleApp
{
    public sealed class MapperConfiguration
    {
        public static MapperConfiguration Default { get; } = new();

        public bool IgnorePropertyNameCase { get; init; }

        public bool StrictMode { get; init; }

        public bool ThrowOnMappingError { get; init; }

        public Action<string, Exception>? OnMappingError { get; init; }
    }
}
