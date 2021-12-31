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
    public class HandiWorkDAL : IRepository<HandiWork> , IConvertToObject<HandiWork>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_HandiWork_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "HandiWorkID", id);
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

        public bool Delete(HandiWork model)
        {
            throw new NotImplementedException();
        }

        public HandiWork Get(int id)
        {
            throw new NotImplementedException();
        }

        public HandiWork Get(HandiWork model)
        {
            throw new NotImplementedException();
        }

        public decimal GetPrice(decimal width, decimal height)
        {
            try
            {
                decimal price = 0;
                using(var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection, "usp_HandiWork_GetPrice",CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Width", width);
                        DataConnection.AddParameter(command, "Height", height);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                price = Convert.ToDecimal(reader["Price"].ToString());
                            }
                        }
                    }
                }
                return price;
            }
            catch
            {
                return -1;
            }

        }
        public decimal GetPriceByDate(int month, int year)
        {
            try
            {
                decimal price = 0;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_HandiWork_GetPriceByDate", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Month", month);
                        DataConnection.AddParameter(command, "Year", year);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                price = Convert.ToDecimal(reader["Total"].ToString());
                            }
                        }
                    }
                }
                return price;
            }
            catch
            {
                return 0;
            }

        }
        public List<HandiWork> GetAll()
        {
            try
            {
                List<HandiWork> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_HandiWork_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<HandiWork>();
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

        public bool Insert(HandiWork model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_HandiWork_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "MaxWidth", model.MaxWidth);
                        DataConnection.AddParameter(command, "MinWidth", model.MinWidth);
                        DataConnection.AddParameter(command, "MaxHeight", model.MaxHeight);
                        DataConnection.AddParameter(command, "MinHeight", model.MinHeight);
                        DataConnection.AddParameter(command, "Price", model.Price);
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

        public HandiWork ToObject(SqlDataReader reader)
        {
            HandiWork work = new HandiWork
            {
                HandiWorkID = int.Parse(reader["HandiWorkID"].ToString()),
                MaxWidth = int.Parse(reader["MaxWidth"].ToString()),
                MinWidth = int.Parse(reader["MinWidth"].ToString()),
                MaxHeight = int.Parse(reader["MaxHeight"].ToString()),
                MinHeight = int.Parse(reader["MinHeight"].ToString()),
                Price = Convert.ToDecimal(reader["Price"].ToString())
            };
            return work;
        }

        public bool Update(HandiWork model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_HandiWork_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "HandiWorkID", model.HandiWorkID);
                        DataConnection.AddParameter(command, "MaxWidth", model.MaxWidth);
                        DataConnection.AddParameter(command, "MinWidth", model.MinWidth);
                        DataConnection.AddParameter(command, "MaxHeight", model.MaxHeight);
                        DataConnection.AddParameter(command, "MinHeight", model.MinHeight);
                        DataConnection.AddParameter(command, "Price", model.Price);
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
