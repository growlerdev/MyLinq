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
            var itemsToRemove = new List<T>(items.Where(predicate));

            foreach (var i in items)
            {
                if (!itemsToRemove.Contains(i))
                {
                    yield return i;
                }
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
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

        public static T GetNextOrDefault<T>(this IEnumerable<T> items, T item)
        {
            var itemList = items.ToList();
            var index = itemList.IndexOf(item);
            return object.Equals(item, itemList.Last()) ? default(T) : itemList[index + 1];
        }

        public static T GetPreviousOrDefault<T>(this IEnumerable<T> items, T item)
        {
            var itemList = items.ToList();
            var index = itemList.IndexOf(item);
            return object.Equals(item, itemList.First()) ? default(T) : itemList[index - 1];
        }

        public static void AddMany<T>(this List<T> items, T item, int qty)
        {
            for (int i = 0; i < qty; i++)
            {
                items.Add(item);
            }
        }
    }
}
