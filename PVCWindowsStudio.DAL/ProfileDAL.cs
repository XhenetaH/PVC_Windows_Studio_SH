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
    public class ProfileDAL : IRepository<Profiles>, IConvertToObject<Profiles>
    {
        public bool Delete(int id)

        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Profile_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProfileID", id);
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
        public bool Delete(Profiles model)
        {
            throw new NotImplementedException();
        } 

        public Profiles Get(Profiles model)
        {
            throw new NotImplementedException();
        }

       
        public bool Insert(Profiles model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Profile_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "Color", model.Color);
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
        public List<Profiles> GetExistProfile()
        {
            try
            {
                List<Profiles> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Pofile_GetExistProd", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Profiles>();
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
        public Profiles ToObject(SqlDataReader reader)
        {
            Profiles profile = new Profiles
            {
                ProfileID = int.Parse(reader["ProfileID"].ToString()),
                Name = reader["Name"].ToString(),
                NameProf = reader["Name"].ToString() + " " + reader["Color"].ToString(),
                Color = reader["Color"].ToString(),
                Other = reader["Other"].ToString()
            };
            return profile;
        }

        

        public bool Update(Profiles model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Profile_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "Name", model.Name);
                        DataConnection.AddParameter(command, "Color", model.Color);
                        DataConnection.AddParameter(command, "Other", model.Other);
                        DataConnection.AddParameter(command, "ProfileID", model.ProfileID);
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

        public Profiles Get(int id)
        {
            try
            {
                Profiles profile = null;
                using(var connection = DataConnection.GetConnection())
                {
                    using(var command = DataConnection.Command(connection, "usp_Profile_GetById",CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "ProfileID", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            profile = new Profiles();
                            if(reader.Read())
                            {
                                profile.ProfileID = int.Parse(reader["ProfileID"].ToString());
                                profile.Name = reader["Name"].ToString();
                                profile.Color = reader["Color"].ToString();
                                profile.NameProf = reader["Name"].ToString() + reader["Color"].ToString();
                            }
                        }
                    }

                }
                return profile;
            }
            catch
            {
                return null;
            }
        }

        public List<String> GetColors()
        {
            try
            {
                List<String> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Profile_GetColor", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<String>();
                            while (reader.Read())
                            {
                                lista.Add(reader["Color"].ToString());
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

        public List<Profiles> Get()
        {
            try
            {
                List<Profiles> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Profile_Get", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Profiles>();
                            while (reader.Read())
                            {
                                Profiles pro = new Profiles();
                                pro.ProfileID = int.Parse(reader["ProfileNr"].ToString());
                                pro.NameProf = reader["Name"].ToString() + reader["Color"].ToString();
                                lista.Add(pro);

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
        public List<Profiles> GetAll()
        {
            try
            {
                List<Profiles> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Profile_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Profiles>();
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
    }

}
