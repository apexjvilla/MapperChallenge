using System.Reflection;

namespace ConsoleApp
{
    public static class MapperUtility
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            if(source is null)
                throw new ArgumentNullException(nameof(source));

            TTarget target = new();

            PropertyInfo[] sourceProperties = typeof(TSource)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            PropertyInfo[] targetProperties = typeof(TTarget)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo targetProp in targetProperties)
            {
                if (!targetProp.CanWrite) continue;

                PropertyInfo? sourceProp = sourceProperties.FirstOrDefault(sp => 
                        sp.Name == targetProp.Name 
                        && sp.PropertyType == targetProp.PropertyType
                        && sp.CanRead);

                if (sourceProp is null) continue;

                var value = sourceProp.GetValue(source);

                targetProp.SetValue(target, value);
            }

            return target;
        }
    }
}
