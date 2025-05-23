using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarWars.Core.Services;

public static class ObservableCollectionExtensions
{
    public static void ReplaceWith<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
    {
        collection.Clear();
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }
}