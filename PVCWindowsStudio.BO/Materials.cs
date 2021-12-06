using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Materials : AuditColumns
    {
        public int MaterialID { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public virtual List<ProductItems> Productitems { get; set; }
        public virtual Profiles Profile { get; set; }
    }
}
