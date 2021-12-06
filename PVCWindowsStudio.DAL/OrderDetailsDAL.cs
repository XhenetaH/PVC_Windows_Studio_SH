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
    public class OrderDetailsDAL : IRepository<OrderDetails>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderDetailsID", id);

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

        public bool Delete(OrderDetails model)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Get(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Get(OrderDetails model)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAll(int id)
        {
            try
            {
                List<OrderDetails> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_GetAll", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<OrderDetails>();
                            while (reader.Read())
                            {
                                OrderDetails order = new OrderDetails();
                                order.OrderDetailsID = int.Parse(reader["OrderDetailsID"].ToString());
                                order.OrderID = int.Parse(reader["OrderID"].ToString());
                                order.ProductID = int.Parse(reader["ProductID"].ToString());
                                order.Product = new Products();
                                order.Product.Name = reader["ProductName"].ToString();
                                order.Product.Picture = (byte[])reader["Picture"];
                                order.ProfileID = int.Parse(reader["ProfileID"].ToString());
                                order.Profile = new Profiles();
                                order.Profile.Name = reader["ProfileName"].ToString();
                                order.Profile.Color = reader["Color"].ToString();
                                order.BlindID = int.Parse(reader["BlindID"].ToString());
                                order.Blind = new Blinds();
                                order.Blind.Name = reader["BlindName"].ToString();
                                order.WindowPaneID = int.Parse(reader["WindowPaneID"].ToString());
                                order.WindowPane = new WindowPanes();
                                order.WindowPane.Name = reader["WindowPaneName"].ToString();
                                order.Quantity = int.Parse(reader["Quantity"].ToString());
                                order.Width = Convert.ToDecimal(reader["Width"].ToString());
                                order.Height = Convert.ToDecimal(reader["Height"].ToString());
                                order.Price = Convert.ToDecimal(reader["Price"].ToString());
                                order.Total = Convert.ToDecimal(reader["Total"].ToString());

                                lista.Add(order);

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

        public List<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }
        public decimal GetPriceByDate(int month, int year)
        {
            try
            {
                decimal total =0;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_GetPriceByDate", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Month", month);
                        DataConnection.AddParameter(command, "Year", year);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {                            
                            if (reader.Read())
                            {
                                total = Convert.ToDecimal(reader["Total"].ToString());
                            }
                        }
                    }
                }
                return total;
            }
            catch
            {
                return -1;
            }
        }

        public List<DateTime> GetDateChart()
        {
            try
            {
                List<DateTime> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_GetDateChart", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<DateTime>();
                            while (reader.Read())
                            {
                                lista.Add(Convert.ToDateTime(reader["InsertDate"].ToString()));
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


        public List<PriceCalculation> GetPrice(int profileId,int productId)
        {
            try
            {
                List<PriceCalculation> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_GetPrice", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProfileID", profileId);
                        DataConnection.AddParameter(command, "ProductID", productId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<PriceCalculation>();
                            while (reader.Read())
                            {
                                PriceCalculation pr = new PriceCalculation();
                                pr.Formula = reader["FormulaType"].ToString();
                                pr.Price = reader["Price"].ToString();

                                lista.Add(pr);

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

        public bool Insert(OrderDetails model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", model.OrderID);
                        DataConnection.AddParameter(command, "ProductID", model.ProductID);
                        DataConnection.AddParameter(command, "ProfileID", model.ProfileID);
                        DataConnection.AddParameter(command, "BlindID", model.BlindID);
                        DataConnection.AddParameter(command, "WindowPaneID", model.WindowPaneID);
                        DataConnection.AddParameter(command, "Quantity", model.Quantity);
                        DataConnection.AddParameter(command, "Width", model.Width);
                        DataConnection.AddParameter(command, "Height", model.Height);
                        DataConnection.AddParameter(command, "Price", model.Price);
                        DataConnection.AddParameter(command, "Total", model.Total);
                        DataConnection.AddParameter(command, "HandWorkPrice", model.HandWorkPrice);
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

        public bool Update(OrderDetails model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_OrderDetails_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderDetailsID", model.OrderDetailsID);
                        DataConnection.AddParameter(command, "ProductID", model.ProductID);
                        DataConnection.AddParameter(command, "ProfileID", model.ProfileID);
                        DataConnection.AddParameter(command, "BlindID", model.BlindID);
                        DataConnection.AddParameter(command, "WindowPaneID", model.WindowPaneID);
                        DataConnection.AddParameter(command, "Quantity", model.Quantity); 
                        DataConnection.AddParameter(command, "Width", model.Width);
                        DataConnection.AddParameter(command, "Height", model.Height);
                        DataConnection.AddParameter(command, "Price", model.Price);
                        DataConnection.AddParameter(command, "Total", model.Total);
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
