using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CNPC.SISDUC.Presentacion.Models
{
    public class Context:DbContext
    {
        public DbSet<Ducto> Ductos{get; set;}
    }
}