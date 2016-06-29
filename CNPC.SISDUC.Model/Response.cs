using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPC.SISDUC.Model
{
    public class Response<T>
    {
        public List<T> List { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}
