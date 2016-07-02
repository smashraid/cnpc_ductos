using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.Model
{
    public class RegistroInspeccionVisualResponse : Response<RegistroInspeccionVisual>
    {
        public Oleoducto oleoducto { get; set; }
    }
}
