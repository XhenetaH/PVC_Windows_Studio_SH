using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Profiles : AuditColumns
    {
        public int ProfileID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Other { get; set; }
        public string NameProf { get; set; }

    }
}
