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
    public class PriceListDAL : IRepository<PriceList>, IConvertToObject<PriceList>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_PriceList_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "PriceListID", id);
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

        public bool Delete(PriceList model)
        {
            throw new NotImplementedException();
        }

        public PriceList Get(int id)
        {
            throw new NotImplementedException();
        }

        public PriceList Get(PriceList model)
        {
            throw new NotImplementedException();
        }
        public List<PriceList> GetAll()
        {
            try
            {
                List<PriceList> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_PriceList_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<PriceList>();
                            while (reader.Read())
                            {
                                var pricelist = ToObject(reader);
                                pricelist.Materials = new Materials();
                                pricelist.Materials.Name = reader["Name"].ToString();
                                pricelist.Profiles = new Profiles();
                                pricelist.Profiles.NameProf = reader["ProfileName"].ToString() + " " + reader["Color"].ToString();


                                lista.Add(pricelist);

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

        public bool Insert(PriceList model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_PriceList_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "MaterialID", model.MaterialID);
                        DataConnection.AddParameter(command, "ProfileID", model.ProfileID);
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

       

        public bool Update(PriceList model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_PriceList_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "PriceListID", model.PriceListID);
                        DataConnection.AddParameter(command, "MaterialID", model.MaterialID);
                        DataConnection.AddParameter(command, "ProfileID", model.ProfileID);
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

        public PriceList ToObject(SqlDataReader reader)
        {
            PriceList pricelist = new PriceList
            {
                PriceListID = int.Parse(reader["PriceListID"].ToString()),
                MaterialID = int.Parse(reader["MaterialID"].ToString()),
                ProfileID = int.Parse(reader["ProfileID"].ToString()),
                Price = Convert.ToDecimal(reader["Price"].ToString())
            };
            return pricelist;
        }
    }
}
