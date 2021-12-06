using PVCWindowsStudio.BO;
using PVCWindowsStudio.BO.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.DAL
{
    public class ProductItemsDAL : IRepository<ProductItems>, IConvertToObject<ProductItems>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_ProductItems_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProductItemsID", id);
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(ProductItems model)
        {
            throw new NotImplementedException();
        }

        public ProductItems Get(int id)
        {
            throw new NotImplementedException();
        }


        public ProductItems Get(ProductItems model)
        {
            throw new NotImplementedException();
        }

        public List<int> GetFormula()
        {
            try
            {
                List<int> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_ProductItems_GetFormula", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<int>();
                            while (reader.Read())
                            {
                                int nr = int.Parse(reader["FormulaID"].ToString());
                                lista.Add(nr);
                            }
                        }
                    }
                }
                return lista;
            }
            catch
            {
                return null;
            }
        }

        public List<ProductItems> GetAll(int id)
        {
            try
            {
                List<ProductItems> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_ProductItems_GetAll", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProductID", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<ProductItems>();
                            while (reader.Read())
                            {                                
                                lista.Add(ToObject(reader));
                            }
                        }
                    }
                }
                return lista;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(ProductItems model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_ProductItems_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProductID", model.ProductID);
                        DataConnection.AddParameter(command, "MaterialID", model.MaterialID);
                        DataConnection.AddParameter(command, "FormulaID", model.FormulaID);             
                        DataConnection.AddParameter(command, "InsertBy", model.InsertBy);
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

       

        public bool Update(ProductItems model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_ProductItems_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProductItemsID", model.ProductItemsID);
                        DataConnection.AddParameter(command, "MaterialID", model.MaterialID);
                        DataConnection.AddParameter(command, "ProductID", model.ProductID);
                        DataConnection.AddParameter(command, "FormulaID", model.FormulaID);
                        DataConnection.AddParameter(command, "LUB", model.LUB);
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public ProductItems ToObject(SqlDataReader reader)
        {
            ProductItems productItem = new ProductItems
            {
                ProductItemsID = int.Parse(reader["ProductItemsID"].ToString()),
                Materials = new Materials()
                {
                    Name = reader["Material Name"].ToString(),
                    MaterialID = int.Parse(reader["MaterialID"].ToString())
                },
                Products = new Products()
                {
                    Name = reader["Product Name"].ToString(),
                    Picture = (byte[])reader["Picture"],
                    ProductID = int.Parse(reader["ProductID"].ToString())                   
                },
                Formula = new Formula()
                {
                    FormulaID = int.Parse(reader["FormulaID"].ToString()),
                    FormulaType = reader["Formula"].ToString()
                }
            };
           
            return productItem;
        }

        public List<ProductItems> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
