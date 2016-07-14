using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.Model
{
    public enum EEstadoRowState
    {
        None = 0x0,
        A,   //ADDED
        U,//UNCHANGED
        M, //MODIFIED
        D // DELETED
    }
}
