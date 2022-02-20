using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace FifthTask.Serialization
{
    [DataContract(Name = "GroupedByTransmissionType")]
    public class GroupSerializationModel<TKey, TElement>
    {
        [DataMember]
        public TKey Key { get; private set; }

        [DataMember]
        public List<TElement> Elements { get; private set; }

        private GroupSerializationModel() { }

        public GroupSerializationModel(IGrouping<TKey, TElement> group)
        {
            Key = group.Key;
            Elements = group.ToList();
        }
    }
}
