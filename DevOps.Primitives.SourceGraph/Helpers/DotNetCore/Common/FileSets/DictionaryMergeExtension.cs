using System.Collections.Generic;

namespace DevOps.Primitives.SourceGraph.Helpers.DotNetCore.Common.FileSets
{
    public static class DictionaryMergeExtension
    {
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dict, in KeyValuePair<TKey, TValue> data)
            => dict.Merge(data.Key, data.Value);

        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dict, in TKey key, in TValue value)
        {
            if (!dict.ContainsKey(key)) dict.Add(key, value);
            return dict;
        }
    }
}
