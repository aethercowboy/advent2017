﻿using System.Collections.Generic;
using System.Linq;

namespace advent.Extensions
{
    public static class EnumerableExtensions
    {
        public static T NthOrDefault<T>(this IEnumerable<T> list, int index)
        {
            return list == null
                    ? default(T)
                    : list.Skip(index).FirstOrDefault()
                ;
        }

        public static string AsString(this IEnumerable<int>list)
        {
            return string.Join(",", list);
        }

        public static IEnumerable<IList<string>> GenerateRoutes(this IList<string> locs)
        {
            var list = new List<IList<string>>();

            if (locs.Count == 1)
            {
                list.Add(locs);
                return list;
            }

            foreach (var loc in locs)
            {
                var subLocs = locs.Where(x => x != loc).ToList();
                var subRoutes = GenerateRoutes(subLocs);
                foreach (var subRoute in subRoutes)
                {
                    var subList = new List<string> { loc };
                    subList.AddRange(subRoute);
                    list.Add(subList);
                }
            }

            return list;
        }
    }
}