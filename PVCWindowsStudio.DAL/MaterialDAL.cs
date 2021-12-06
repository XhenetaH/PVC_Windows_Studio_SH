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
    public class MaterialDAL : IRepository<Materials> , IConvertToObject<Materials>
    {
        public bool Delete(int id)
        {
            try
            {
                using(var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection,"usp_Material_Delete",CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "MaterialID", id);
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

        public bool Delete(Materials model)
        {
            throw new NotImplementedException();
        }

        public Materials Get(int id)
        {
            try
            {
                Materials mat = null;
                using(var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection,"usp_Material_Get",CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "MaterialID", id);
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            mat = new Materials();
                            if (reader.Read())
                                mat = ToObject(reader);                           
                        }
                    }
                }
                return mat;
            }
            catch
            {
                return null;
            }
        }

        public Materials Get(Materials model)
        {
            throw new NotImplementedException();
        }
        public List<Materials> GetExist()
        {
            try
            {
                List<Materials> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Material_GetExist", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Materials>();
                            while (reader.Read())
                                lista.Add(ToObject(reader));
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
        public List<Materials> GetAll()
        {
            try
            {
                List<Materials> lista = null;
                using(var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection,"usp_Material_GetAll",CommandType.StoredProcedure))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Materials>();
                            while (reader.Read())
                                lista.Add(ToObject(reader));
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

        public bool Insert(Materials model)
        {           
            try
            {
               
                using (var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection, "usp_Material_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "Other", model.Other);
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

        public Materials ToObject(SqlDataReader reader)
        {
            Materials mat = new Materials
            {
                MaterialID = int.Parse(reader["MaterialID"].ToString()),
                Name = reader["Name"].ToString(),
                Other = reader["Other"].ToString(),
                Profile = new Profiles()
            };

            return mat;
        }

        public bool Update(Materials model)
        {
            try
            {
                using(var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection,"usp_Material_Update",CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "MaterialID", model.MaterialID);
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "Other", model.Other);
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
