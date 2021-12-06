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
    public class OrderDAL : IRepository<Orders>, IConvertToObject<Orders>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", id);

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
        public bool DeleteAll(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_DeleteAll", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", id);

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
        public bool Delete(Orders model)
        {
            throw new NotImplementedException();
        }

        public Orders Get(int id)
        {
            throw new NotImplementedException();
        }

        public Orders Get(Orders model)
        {
            throw new NotImplementedException();
        }

        public int GetNumberByDate()
        {
            try
            {
                int nr = 0;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_GetNumberByDate", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["OrderNr"].ToString());
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
                    using (var command = DataConnection.Command(connection, "usp_Order_GetNumber", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["OrderNr"].ToString());
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
        public List<Orders> GetAll()
        {
            try
            {
                List<Orders> list = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            list = new List<Orders>();
                            while (reader.Read())
                            {                               
                                list.Add(ToObject(reader));
                            }
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public List<Orders> GetAllExist()
        {
            try
            {
                List<Orders> list = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_GetAllExist", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            list = new List<Orders>();
                            while (reader.Read())
                            {
                                list.Add(ToObject(reader));
                            }
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
        public int GetID()
        {
            try
            {
                int id = -1;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_GetID", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                id = int.Parse(reader["OrderID"].ToString());
                            }
                        }
                    }
                }
                return id;
            }
            catch
            {
                return -1;
            }

        }
        public bool Insert(Orders model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ClientID", model.ClientID);
                        DataConnection.AddParameter(command, "Date", model.Date);
                        DataConnection.AddParameter(command, "Comment", model.Comment);
                        DataConnection.AddParameter(command, "Discount", model.Discount);
                        DataConnection.AddParameter(command, "DiscountType", model.DiscountType);
                        DataConnection.AddParameter(command, "TotalPrice", model.TotalPrice);
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

        public Orders ToObject(SqlDataReader reader)
        {
            Orders ord = new Orders
            {
                OrderID = int.Parse(reader["OrderID"].ToString()),
                ClientID = int.Parse(reader["ClientID"].ToString()),
                Discount = Convert.ToDecimal(reader["Discount"].ToString()),
                DiscountType = reader["DiscountType"].ToString(),
                FullDiscount = reader["Discount"].ToString() + " " + reader["DiscountType"].ToString(),
                Comment = reader["Comment"].ToString(),
                TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString()),
                Date = Convert.ToDateTime(reader["Date"].ToString()),
                Clients = new Clients()
                {
                    FullName = reader["Name"].ToString() + " " + reader["LastName"].ToString()
                }

            };

            return ord;
        }
        public bool UpdatePrice(Orders model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_PriceUpdate", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", model.OrderID);
                        DataConnection.AddParameter(command, "TotalPrice", model.TotalPrice);
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
        public bool Update(Orders model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Order_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", model.OrderID);
                        DataConnection.AddParameter(command, "ClientID", model.ClientID);
                        DataConnection.AddParameter(command, "Date", model.Date);
                        DataConnection.AddParameter(command, "Discount", model.Discount);
                        DataConnection.AddParameter(command, "DiscountType", model.DiscountType);
                        DataConnection.AddParameter(command, "Comment", model.Comment);
                        DataConnection.AddParameter(command, "TotalPrice", model.TotalPrice);
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
