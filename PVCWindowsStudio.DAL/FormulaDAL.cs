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
    public class FormulaDAL : IRepository<Formula>, IConvertToObject<Formula>
    {
        public bool Delete(int id)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Formula_Delete", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "FormulaID", id);
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

        public bool Delete(Formula model)
        {
            throw new NotImplementedException();
        }

        public Formula Get(int id)
        {
            throw new NotImplementedException();
        }

        public Formula Get(Formula model)
        {
            throw new NotImplementedException();
        }

        public List<Formula> GetAll()
        {
            try
            {
                List<Formula> lista = null;
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Formula_GetAll", CommandType.StoredProcedure))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            lista = new List<Formula>();
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

        public bool Insert(Formula model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Formula_Insert", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "FormulaType", model.FormulaType);
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

        public Formula ToObject(SqlDataReader reader)
        {
            Formula frm = new Formula
            {
                FormulaID = int.Parse(reader["FormulaID"].ToString()),
                FormulaType = reader["FormulaType"].ToString(),
            };

            return frm;
        }

        public bool Update(Formula model)
        {
            try
            {
                using (var connection = DataConnection.GetConnection())
                {
                    using (var command = DataConnection.Command(connection, "usp_Formula_Update", CommandType.StoredProcedure))
                    {
                        DataConnection.AddParameter(command, "FormulaID", model.FormulaID);
                        DataConnection.AddParameter(command, "FormulaType", model.FormulaType);
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
