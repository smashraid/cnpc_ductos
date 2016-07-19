using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model
{
    [DataContract]
    public class Response<T>
    {
        [DataMember]
        public List<T> List { get; set; }
        [DataMember]
        public T Item { get; set; }
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int Records { get; set; }
        [DataMember]
        public int TotalRecords { get; set; }
        [DataMember]
        public int TotalPages { get; set; }
    }
}
