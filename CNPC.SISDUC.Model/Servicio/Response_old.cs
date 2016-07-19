using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model.Servicio
{
    [DataContract]
    public abstract class Response
    {
        [DataMember]
        public bool Resultado { get; set; } //true-OK, false-Error
        [DataMember]
        public string MensajeError { get; set; }
    }
}
