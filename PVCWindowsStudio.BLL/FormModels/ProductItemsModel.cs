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
        public MaterialBLL MaterialBll;
        public FormulaBLL FormulaBll;
        public Products Product;
        public ProductItems ProductItems;
        public ProductBLL ProductBLL;
        public ProductItemsBLL ProductItemsBll;

        public ProductItemsModel()
        {
            MaterialBll = new MaterialBLL();
            FormulaBll = new FormulaBLL();
            Product = new Products();
            ProductItems = new ProductItems();
            ProductBLL = new ProductBLL();
            ProductItemsBll = new ProductItemsBLL();
        }

    }
}
