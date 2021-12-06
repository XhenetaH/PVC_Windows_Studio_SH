using PVCWindowsStudio.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BLL.FormModels
{
    public class ProductItemsModel
    {
        public MaterialBLL MaterialBll { get; set; }
        public FormulaBLL FormulaBll { get; set; }
        public Products Product { get; set; }
        public ProductItems ProductItems { get; set; }
        public ProductBLL ProductBLL { get; set; }
        public ProductItemsBLL ProductItemsBll { get; set; }

    }
}
