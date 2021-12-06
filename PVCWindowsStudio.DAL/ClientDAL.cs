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
    public class ClientDAL : IRepository<Clients>, IConvertToObject<Clients>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Client_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ClientID", id);

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
                    using (var command = DataConnection.Command(connection, "usp_Client_GetNumberByDate", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["ClientNr"].ToString());
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
                    using (var command = DataConnection.Command(connection, "usp_Client_GetNumber", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nr = int.Parse(reader["ClientNr"].ToString());
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
        public bool Delete(Clients model)
        {
            throw new NotImplementedException();
        }

        public Clients Get(int id)
        {
            try
            {
                Clients client;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Client_GetName", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ClientID", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            client = new Clients();
                            if (reader.Read())
                            {
                               
                                client.ClientID = int.Parse(reader["ClientID"].ToString());
                                client.Name = reader["Name"].ToString();
                                client.LastName = reader["LastName"].ToString();
                                client.Address = reader["Address"].ToString();
                                client.PhoneNumber = reader["PhoneNumber"].ToString();
                                client.Email = reader["Email"].ToString();
                            }
                        }
                    }
                }
                return client;
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
                    using (var command = DataConnection.Command(connection, "usp_Client_GetID", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                id = int.Parse(reader["ClientID"].ToString());
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

        public Clients Get(Clients model)
        {
            throw new NotImplementedException();
        }
        public List<Clients> GetName()
        {
            try
            {
                List<Clients> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Client_GetName", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Clients>();
                            while (reader.Read())
                            {
                                Clients client = new Clients();
                                client.ClientID = int.Parse(reader["ClientID"].ToString());
                                client.Name = reader["Name"].ToString();
                                client.LastName = reader["LastName"].ToString();
                                client.FullName = reader["Name"].ToString() + " " + reader["LastName"].ToString();
                                client.Address = reader["Address"].ToString();
                                client.PhoneNumber = reader["PhoneNumber"].ToString();
                                client.Email = reader["Email"].ToString();
                                lista.Add(client);
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
        public List<Clients> GetAll()
        {
            try
            {
                List<Clients> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Client_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Clients>();
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

        public bool Insert(Clients model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Client_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "LastName", model.LastName);
                        DataConnection.AddParameter(command, "PhoneNumber", model.PhoneNumber);
                        DataConnection.AddParameter(command, "Email", model.Email);
                        DataConnection.AddParameter(command, "Address", model.Address);
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



        public Clients ToObject(SqlDataReader reader)
        {
            Clients client = new Clients
            {
                ClientID = int.Parse(reader["ClientID"].ToString()),
                Name = reader["Name"].ToString(),
                LastName = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Email = reader["Email"].ToString(),
                Address = reader["Address"].ToString()
            };
            return client;
        }

        public bool Update(Clients model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Client_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ClientID", model.ClientID);
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "LastName", model.LastName);
                        DataConnection.AddParameter(command, "PhoneNumber", model.PhoneNumber);
                        DataConnection.AddParameter(command, "Email", model.Email);
                        DataConnection.AddParameter(command, "Address", model.Address);
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
