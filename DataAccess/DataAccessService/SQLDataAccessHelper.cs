using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessService
{
    public class SQLDataAccessHelper : ISQLDataAccessHelper
    {
        private readonly string _connectionString;

        public SQLDataAccessHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ClubDeportivoData"].ConnectionString;
        }

        public async Task<DataSet> ExecuteDataset(string command, System.Data.CommandType commandType, SQLDataAccessParameters parameters)
        {
            string datos = string.Empty;
            DataSet ds = null;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var cmd = new SqlCommand(command, connection))
                    {
                        cmd.CommandTimeout = 120;

                        if (parameters != null)
                        {
                            foreach (SqlParameter param in parameters.ParamerersList)
                            {
                                datos += "Parametro : " + param.ParameterName + " Valor: " + param.SqlValue + " ";
                                cmd.Parameters.Add(param);
                            }
                        }
                        cmd.CommandType = commandType;
                        var adapter = new SqlDataAdapter(cmd);

                        ds = new DataSet();
                        await Task.Run(() =>
                        {
                            adapter.Fill(ds);
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DataAccessHelper.ExecuteDataset Error", ex);
            }
            finally
            {
            }
            return ds;
        }
    }
}
