using CNPC.SISDUC.DAL;
using CNPC.SISDUC.Model.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.BLL
{
    public class TipoSoportes : IDisposable
    {
        public TipoSoporteResponse GetListTipoSoporte()
        {
            TipoSoporteResponse Result = null;
            using (var r = new Repository<TipoSoporte>())
            {
                Result = r.usp_GetListTipoSoporte();
            }
            return Result;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
