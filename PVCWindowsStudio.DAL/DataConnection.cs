using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PVCWindowsStudio.DAL
{
    public class DataConnection
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["PVCWindwosStudioConnStr"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SqlCommand Command(SqlConnection connection,string cmdText,CommandType commandType)
        {
            SqlCommand command = new SqlCommand(cmdText, connection)
            {
                CommandType = commandType
            };
            return command;
        }

        public static void AddParameter(SqlCommand command, string parameterName, object value)
        {
            SqlParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            if(value!=null)
            {
                if(value is DateTime)
                {
                    if(DateTime.Parse(value.ToString()) <= DateTime.Parse("1/01/1900"))
                    {
                        value = null;
                    }
                }
                if(value is byte[])
                {
                    //konverto foto ne bytearray
                }
            }

            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}
