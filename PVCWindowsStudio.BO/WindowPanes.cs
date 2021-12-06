using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class WindowPanes : AuditColumns
    {
        public int WindowPaneID { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public decimal Price { get; set; }
    }
}
