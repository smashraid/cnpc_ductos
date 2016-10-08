using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model.Servicio
{
    [DataContract]
    public class TipoSoporteResponse : Response<TipoSoporte>
    {
        [DataMember]
        public bool Resultado { get; set; } //true-OK, false-Error
        [DataMember]
        public string MensajeError { get; set; }
        [DataMember]
        public IEnumerable<TipoSoporte> ListEnumerable { get; set; }

    }
}