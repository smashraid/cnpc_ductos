using System.Collections.Generic;

namespace CNPC.SISDUC.Model
{
    public class DuctoResponse
    {
        public List<Ducto> List { get; set; }
        public int Page { get; set; }
        public int Records { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}