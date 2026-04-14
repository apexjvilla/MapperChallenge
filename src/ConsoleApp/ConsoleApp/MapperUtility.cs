namespace ConsoleApp
{
    public static class MapperUtility
    {
        public static TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
        {
            return new TTarget();
        }
    }
}
