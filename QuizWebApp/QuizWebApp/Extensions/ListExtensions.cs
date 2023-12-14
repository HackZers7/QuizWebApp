using System.Collections.Generic;
using System.Linq;

namespace QuizWebApp.Extensions;

public static class ListExtensions
{
    public static IEnumerable<(T element, int index, bool isFirst, bool isLast)> Enumerate<T>(this IEnumerable<T> list)
    {
        var len = list.Count();
        return list.Select((el, i) => (el, i, i == 0, i == len - 1));
    }
}