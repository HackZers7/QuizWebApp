using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace QuizWebApp;

public static class ThrowHelper
{
    public static void ThrowIfNull(object? argument,
        [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument is null) throw new ArgumentNullException(paramName);
    }

    public static TValue ThrowIfKeyNotFound<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        if (!dictionary.ContainsKey(key)) throw new KeyNotFoundException(key?.ToString());

        return dictionary[key];
    }
}