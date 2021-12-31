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
    public class InvoiceDAL : IRepository<Invoices> , IConvertToObject<Invoices>
    {
        public bool Delete(int id,int orderId)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Invoice_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "InvoiceID", id);
                        DataConnection.AddParameter(command, "OrderID", orderId);
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
                    using (var command = DataConnection.Command(connection, "usp_Invoice_GetNumberByDate", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["InvoiceNr"].ToString());
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
                    using (var command = DataConnection.Command(connection, "usp_Invoice_GetNumber", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["InvoiceNr"].ToString());
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
        public bool Delete(Invoices model)
        {
            throw new NotImplementedException();
        }

        public Invoices Get(int id)
        {
            throw new NotImplementedException();
        }

        public Invoices Get(Invoices model)
        {
            throw new NotImplementedException();
        }

        public List<Invoices> GetAll()
        {
            try
            {
                List<Invoices> list = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Invoice_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            list = new List<Invoices>();
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

        public bool Insert(Invoices model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Invoice_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "OrderID", model.OrderID);
                        DataConnection.AddParameter(command, "Paid", model.Paid);
                        DataConnection.AddParameter(command, "Debt", model.Debt);
                        DataConnection.AddParameter(command, "Date", model.Date);
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

        public Invoices ToObject(SqlDataReader reader)
        {
            Invoices invoice = new Invoices()
            {
                InvoiceID = int.Parse(reader["InvoiceID"].ToString()),
                OrderID = int.Parse(reader["OrderID"].ToString()),
                Date = Convert.ToDateTime(reader["Date"].ToString()),
                Debt = Convert.ToDecimal(reader["Debt"].ToString()),
                Paid = Convert.ToDecimal(reader["Paid"].ToString()),
                Order = new Orders()
                {                    
                    FullDiscount = reader["Discount"].ToString() + " " + reader["DiscountType"].ToString(),
                    TotalPrice = Convert.ToDecimal(reader["TotalPrice"].ToString()),
                    Clients = new Clients()
                    {
                        FullName = reader["Name"].ToString() + " " + reader["LastName"].ToString()
                    }
                }
            };

            return invoice;
        }

        public bool Update(Invoices model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Invoice_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "InvoiceID", model.InvoiceID);
                        DataConnection.AddParameter(command, "Debt", model.Debt);
                        DataConnection.AddParameter(command, "Paid", model.Paid);
                        DataConnection.AddParameter(command, "Date", model.Date);
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
