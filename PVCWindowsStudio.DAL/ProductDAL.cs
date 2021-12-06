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
    public class ProductDAL : IRepository<Products>, IConvertToObject<Products>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProductID", id);
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
        public int GetNumberByDate()
        {
            try
            {
                int nr = 0;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_GetNumberByDate", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["ProductNr"].ToString());
                            }
                        }
                    }
                }
                return nr;
            }
            catch
            {
                return -1;
            }
        }
        public int GetNumber()
        {
            try
            {
                int nr = 0;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_GetNumber", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["ProductNr"].ToString());
                            }
                        }
                    }
                }
                return nr;
            }
            catch
            {
                return -1;
            }
        }
        public bool Delete(Products model)
        {
            throw new NotImplementedException();
        }

        public Products Get(int id)
        {
            throw new NotImplementedException();
        }

       
        public Products Get(Products model)
        {
            throw new NotImplementedException();
        }
        public List<Products> GetExistProd()
        {
            try
            {
                List<Products> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_GetExistProd", CommandType.StoredProcedure))
                    {                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Products>();                           
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
        public List<Products> GetExistProdByColor(string color)
        {
            try
            {
                List<Products> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_GetExistProdByColor", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Color", color);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Products>();
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
        public List<Products> GetAll()
        {
            try
            {
                List<Products> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Products>();
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

        public bool Insert(Products model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "Other", model.Other);
                        DataConnection.AddParameter(command, "Picture", model.Picture);
                        DataConnection.AddParameter(command, "Color", model.Color);
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

        public Products ToObject(SqlDataReader reader)
        {
            Products product = new Products
            {
                ProductID = int.Parse(reader["ProductID"].ToString()),
                Name = reader["Name"].ToString(),
                Other = reader["Other"].ToString(),
                Picture = (byte[])reader["Picture"],
            };
            return product;
        }

        public bool Update(Products model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Product_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProductID", model.ProductID);
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "Other", model.Other);
                        DataConnection.AddParameter(command, "Picture", model.Picture);
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
    }

}
