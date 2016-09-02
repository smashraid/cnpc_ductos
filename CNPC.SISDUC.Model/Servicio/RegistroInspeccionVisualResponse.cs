using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model.Servicio
{
    [DataContract]
    public class RegistroInspeccionVisualResponse : Response<RegistroInspeccionVisual>
    {
        [DataMember]
        public RegistroInspeccionVisual registroInspeccionVisual { get; set; }
        [DataMember]
        public TipoSoporteResponse ListTipoSoporte { get; set; }
        [DataMember]
        public Oleoducto oleoducto { get; set; }
        [DataMember]
        public bool Resultado { get; set; } //true-OK, false-Error
        [DataMember]
        public string MensajeError { get; set; }
    }
}