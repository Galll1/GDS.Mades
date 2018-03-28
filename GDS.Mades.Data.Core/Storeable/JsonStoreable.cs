using GDS.Mades.Data.Interfaces.Store;
using System.Runtime.Serialization;

namespace GDS.Mades.Data.Core.Storeable
{
    [DataContract(Name = nameof(JsonStoreable))]
    public class JsonStoreable : IStoreable
    {
        [DataMember(Name = nameof(StoringId))]
        public object StoringId { get; set; }
        [DataMember(Name = nameof(IndexType))]
        public string IndexType { get; set; }
        [DataMember(Name = nameof(Json))]
        public string Json { get; set; }
    }
}
