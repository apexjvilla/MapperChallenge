using System.Collections.Concurrent;
using System.Reflection;

namespace ConsoleApp
{
    public static class MapperUtility
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertiesCache = new();

        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
            => Map<TSource, TTarget>(source, MapperConfiguration.Default);

        public static TTarget Map<TSource, TTarget>(TSource source, MapperConfiguration? configuration) where TTarget : new()
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            configuration ??= MapperConfiguration.Default;

            TTarget target = new();

            PropertyInfo[] sourceProperties = PropertiesCache.GetOrAdd(
                typeof(TSource),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                );

            PropertyInfo[] targetProperties = PropertiesCache.GetOrAdd(
                typeof(TTarget),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                );

            StringComparer comparer = configuration.IgnorePropertyNameCase
                ? StringComparer.OrdinalIgnoreCase
                : StringComparer.Ordinal;

            Dictionary<string, PropertyInfo> sourceLookup = sourceProperties
                .Where(sp => sp.CanRead)
                .GroupBy(sp => sp.Name, comparer)
                .ToDictionary(g => g.Key, g => g.First(), comparer);

            foreach (PropertyInfo targetProp in targetProperties)
            {
                if (!targetProp.CanWrite) continue;

                if (!sourceLookup.TryGetValue(targetProp.Name, out PropertyInfo? sourceProp))
                {
                    if (configuration.StrictMode)
                        throw new InvalidOperationException(
                            $"Strict mode enabled: source property '{targetProp.Name}' was not found.");

                    continue;
                }

                if (sourceProp.PropertyType != targetProp.PropertyType)
                {
                    if (configuration.StrictMode)
                        throw new InvalidOperationException(
                            $"Strict mode enabled: property '{targetProp.Name}' has incompatible types. Source: {sourceProp.PropertyType.Name}, Target: {targetProp.PropertyType.Name}.");

                    continue;
                }

                try
                {
                    object? value = sourceProp.GetValue(source);

                    targetProp.SetValue(target, value);
                }
                catch (Exception ex)
                {
                    if (configuration.ThrowOnMappingError)
                        throw new InvalidOperationException(
                            $"Error mapping property '{targetProp.Name}'.",
                            ex);

                    configuration.OnMappingError?.Invoke(targetProp.Name, ex);
                }
            }

            return target;
        }
    }
}
