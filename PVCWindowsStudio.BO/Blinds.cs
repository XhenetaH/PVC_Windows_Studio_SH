using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Blinds : AuditColumns
    {
        public int BlindID { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
    }
}
