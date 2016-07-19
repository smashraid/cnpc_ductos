using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model.Servicio
{
    [DataContract]
    public abstract class ListRequest<T>
    {
        [DataMember]
        public IEnumerable<T> Lista { get; set; }
        [DataMember]
        public Operacion Operacion { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}
