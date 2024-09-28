using System.Linq;
using FifthTask.Serialization;

namespace FifthTask.Extensions
{
    public static class Groupings
    {
        public static GroupSerializationModel<TKey,TElement> ToSerializationModel<TKey, TElement>(this IGrouping<TKey, TElement> group) =>
            new GroupSerializationModel<TKey, TElement>(group);
    }
}
