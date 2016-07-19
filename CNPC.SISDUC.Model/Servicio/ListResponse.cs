using CNPC.SISDUC.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model.Servicio
{
    [DataContract]
    public abstract class ListResponse<T> : Response<T>
    {
        [DataMember]
        public IEnumerable<T> Lista { get; set; }

    }
}
