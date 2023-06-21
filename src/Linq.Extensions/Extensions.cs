using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.ComponentModel;

namespace System.Linq
{
    public static class Extensions
    {
        public static IEnumerable<T> ExceptWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            var itemsToRemove = items.Where(predicate);
            return items.Except(itemsToRemove);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }

        public static IEnumerable<T> DistinctBy<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            return items.GroupBy(predicate)
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

        public static IEnumerable<int> LessThanOrEqualTo(this IEnumerable<int> items, int minValue)
            => items.Cast<double>().LessThanOrEqualTo(minValue).Cast<int>();
        public static IEnumerable<float> LessThanOrEqualTo(this IEnumerable<float> items, float minValue)
            => items.Cast<double>().LessThanOrEqualTo(minValue).Cast<float>();
        public static IEnumerable<double> LessThanOrEqualTo(this IEnumerable<double> items, double minValue)
        {
            return items.Where(i => i <= minValue);
        }

        public static IEnumerable<int> LessThan(this IEnumerable<int> items, int minValue)
            => items.Cast<double>().LessThan(minValue).Cast<int>();
        public static IEnumerable<float> LessThan(this IEnumerable<float> items, float minValue)
            => items.Cast<double>().LessThan(minValue).Cast<float>();
        public static IEnumerable<double> LessThan(this IEnumerable<double> items, double minValue)
        {
            return items.Where(i => i < minValue);
        }

        public static IEnumerable<int> GreaterThanOrEqualTo(this IEnumerable<int> items, int minValue)
            => items.Cast<double>().GreaterThanOrEqualTo(minValue).Cast<int>();
        public static IEnumerable<float> GreaterThanOrEqualTo(this IEnumerable<float> items, float minValue)
            => items.Cast<double>().GreaterThanOrEqualTo(minValue).Cast<float>();
        public static IEnumerable<double> GreaterThanOrEqualTo(this IEnumerable<double> items, double minValue)
        {
            return items.Where(i => i >= minValue);
        }

        public static IEnumerable<int> GreaterThan(this IEnumerable<int> items, int minValue)
            => items.Cast<double>().GreaterThan(minValue).Cast<int>();
        public static IEnumerable<float> GreaterThan(this IEnumerable<float> items, float minValue)
            => items.Cast<double>().GreaterThan(minValue).Cast<float>();
        public static IEnumerable<double> GreaterThan(this IEnumerable<double> items, double minValue)
        {
            return items.Where(i => i > minValue);
        }

        public static IEnumerable<int> WithinRange(this IEnumerable<int> items, int minValue, int maxValue, bool includeMinValue = true, bool includeMaxValue = true)
            => items.Cast<double>().WithinRange(minValue, maxValue, includeMinValue, includeMaxValue).Cast<int>();
        public static IEnumerable<float> WithinRange(this IEnumerable<float> items, float minValue, int maxValue, bool includeMinValue = true, bool includeMaxValue = true)
            => items.Cast<double>().WithinRange(minValue, maxValue, includeMinValue, includeMaxValue).Cast<float>();
        public static IEnumerable<double> WithinRange(this IEnumerable<double> items, double minValue, int maxValue, bool includeMinValue = true, bool includeMaxValue = true)
        {
            Func<double, bool> minEq = includeMinValue ?  i => i >= minValue : i => i > minValue;
            Func<double, bool> maxEq = includeMaxValue ?  i => i <= maxValue : i => i < maxValue;

            var minVals = items.Where(minEq);
            return minVals
                .Where(maxEq)
                .DefaultIfEmpty();
        }

        public static T GetNextOrDefault<T>(this IEnumerable<T> items, T item) => GetNextOrDefault<T>(items.ToList(), item);
        public static T GetNextOrDefault<T>(this List<T> items, T item)
        {
            var index = items.IndexOf(item);
            return object.Equals(item, items.Last()) ? default(T) : items[index + 1];
        }

        public static T GetPreviousOrDefault<T>(this IEnumerable<T> items, T item) => GetPreviousOrDefault<T>(items.ToList(), item);
        public static T GetPreviousOrDefault<T>(this List<T> items, T item)
        {
            var index = items.IndexOf(item);
            return object.Equals(item, items.First()) ? default(T) : items[index - 1];
        }

        public static void AddMany<T>(this IEnumerable<T> items, T item, int qty) => AddMany(items.ToList(), item, qty);
        public static void AddMany<T>(this List<T> items, T item, int qty)
        {
            for (int i = 0; i < qty; i++)
            {
                items.Add(item);
            }
        }

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

    }
}
