using System.Runtime.Serialization;

namespace CNPC.SISDUC.Model
{
    [DataContract]
    public abstract class ObjectRequest<T>
    {
        [DataMember]
        public T Item { get; set; }
        [DataMember]
        public Operacion Operacion { get; set; }
        public string Token { get; set; }
    }
    [DataContract]
    public enum Operacion
    {
        [EnumMember]
        Agregar,
        [EnumMember]
        Actualizar,
        [EnumMember]
        Eliminar,
        [EnumMember]
        BuscarPorId

    }
}
