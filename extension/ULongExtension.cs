namespace AdventOfCode
{
    public static class ULongExtension
    {
        public static ulong Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, ulong> summer)
        {
            ulong total = 0;

            foreach (TSource item in source)
                total += summer(item);

            return total;
        }
    }
}