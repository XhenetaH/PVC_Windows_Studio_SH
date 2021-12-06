using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Products : AuditColumns
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public byte[] Picture { get; set; }

        public string Color { get; set; }

    }
}
