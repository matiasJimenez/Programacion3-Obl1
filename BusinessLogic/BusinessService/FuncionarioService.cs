using DataAccess;
using DataAccess.DataAccessService;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessService
{
    public class FuncionarioService
    {
        private readonly SQLDataAccessHelper _dataAccess = new SQLDataAccessHelper();

        public async Task<Funcionario> GetFuncionario(string mail, string contraseña)
        {
            Funcionario funcionario = new Funcionario();
            SQLDataAccessParameters parameters = new SQLDataAccessParameters();
            parameters.AddStringParameter("Mail", 0, mail);
            parameters.AddStringParameter("Contraseña", 0, contraseña);
            DataSet ds = await _dataAccess.ExecuteDataset("[dbo].[spGetFuncionario]", CommandType.StoredProcedure, parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                {
                    funcionario.IdFuncionario = int.Parse(row["IdFuncionario"].ToString());
                    funcionario.Mail = row["Mail"].ToString();
                    funcionario.Contraseña = row["Contraseña"].ToString();
                }
            }

            return funcionario;
        }

        public async Task<Funcionario> CreateFuncionario(Funcionario funcionario)
        {
            SQLDataAccessParameters parameters = new SQLDataAccessParameters();
            parameters.AddStringParameter("Mail", 0, funcionario.Mail);
            parameters.AddStringParameter("Contraseña", 0, funcionario.Contraseña);

            DataSet ds = await _dataAccess.ExecuteDataset("[dbo].[spCreateFuncionario]", CommandType.StoredProcedure, parameters);

            funcionario.IdFuncionario = Int32.Parse(ds.Tables[0].Rows[0]["IdFuncionario"].ToString());

            return funcionario;
        }

    }
}
