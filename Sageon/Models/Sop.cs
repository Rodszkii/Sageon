using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sageon.Models
{
    public class Sop
    {

       public int id { get; set; }
        public string Client{ get; set; }
        public string Title { get; set; }
        public string Artifact { get; set; }
        public int Occurance { get; set; }
        public string IOC { get; set; }
        public string SIEM { get; set; }
        public string Comment { get; set; }
        public string Reviewed_By { get; set; }
        public string Added_By { get; set; }
        public string Procedure { get; set; }
    }
}
