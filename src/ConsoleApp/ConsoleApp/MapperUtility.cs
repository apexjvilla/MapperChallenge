using System.Collections.Concurrent;
using System.Reflection;

namespace ConsoleApp
{
    public static class MapperUtility
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            if(source is null)
                throw new ArgumentNullException(nameof(source));

            // Cache properties per type to avoid repeated reflection
            ConcurrentDictionary<Type, PropertyInfo[]> propertiesCache = new();

            TTarget target = new();

            PropertyInfo[] sourceProperties = propertiesCache.GetOrAdd(
                typeof(TSource),
                t=>t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                );

            PropertyInfo[] targetProperties = propertiesCache.GetOrAdd(
                typeof(TTarget),
                t=>t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                );

            foreach (PropertyInfo targetProp in targetProperties)
            {
                if (!targetProp.CanWrite) continue;

                try
                {
                    PropertyInfo? sourceProp = sourceProperties.FirstOrDefault(sp =>
                            sp.Name == targetProp.Name
                            && sp.PropertyType == targetProp.PropertyType
                            && sp.CanRead);

                    if (sourceProp is null) continue;

                    var value = sourceProp.GetValue(source);

                    targetProp.SetValue(target, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error mapping {targetProp.Name}: {ex.Message}");
                }
            }

            return target;
        }
    }
}
