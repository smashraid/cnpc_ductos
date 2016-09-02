using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.Model
{
    public partial class Oleoducto
    {
        public decimal LongitudTotal { get; set; }
    }
    public partial class RegistroInspeccionVisual
    {
        public decimal EspesorNominal { get; set; }
        public decimal EspesorMinimoRealRemanente { get; set; }
        public string ObservacionesDeLaInspeccionVisual { get; set; }
        public string CondicionDelTramo { get; set; }
    }
}
