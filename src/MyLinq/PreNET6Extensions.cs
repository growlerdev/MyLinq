using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class PreNET6Extensions
    {

#if !NET6_0

//NET6.0 ADDED MINBY, MAXBY, & DISTINCTBY

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> items, Func<TSource, TKey> keySelector)
        {
            return items.GroupBy(keySelector)
                .Select(gp => gp.FirstOrDefault());
        }

        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            var comparer = Comparer<TKey>.Default;
            TSource minElement = default;
            TKey minKey = default;
            bool firstElement = true;

            foreach (var element in source)
            {
                var key = keySelector(element);
                if (firstElement || comparer.Compare(key, minKey) < 0)
                {
                    minElement = element;
                    minKey = key;
                    firstElement = false;
                }
            }

            if (firstElement)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }

            return minElement;
        }

        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }

            var comparer = Comparer<TKey>.Default;
            TSource maxElement = default;
            TKey maxKey = default;
            bool firstElement = true;

            foreach (var element in source)
            {
                var key = keySelector(element);
                if (firstElement || comparer.Compare(key, maxKey) > 0)
                {
                    maxElement = element;
                    maxKey = key;
                    firstElement = false;
                }
            }

            if (firstElement)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }

            return maxElement;
        }

#endif

    }
}
