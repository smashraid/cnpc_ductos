using System;
using System.Data.Entity;

namespace CNPC.SISDUC.Model
{
    public partial class CNPC_DuctosEntities : DbContext
    {
        public CNPC_DuctosEntities(String connectionString)
        : base(connectionString)
        {

        }
    }
}
