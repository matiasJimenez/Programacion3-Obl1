using DataAccess;
using DataAccess.DataAccessService;
using DataAccess.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessService
{
    public class SocioService
    {
        private readonly SQLDataAccessHelper _dataAccess = new SQLDataAccessHelper();

        public async Task<IList<Socio>> GetSocios(Filtro filtro)
        {
            List<Socio> socios = new List<Socio>();
            SQLDataAccessParameters parameters = new SQLDataAccessParameters();
            if (filtro.Cedula != null && filtro.Cedula != "")
            {
                parameters.AddStringParameter("Cedula", 50, filtro.Cedula);
            }

            DataSet ds = await _dataAccess.ExecuteDataset("[dbo].[spGetSocios]", CommandType.StoredProcedure, parameters);
            
            try
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        socios.Add(new Socio()
                        {
                            IdSocio = int.Parse(row["IdSocio"].ToString()),
                            NombreCompleto = row["NombreCompleto"].ToString(),
                            Cedula = row["Cedula"].ToString(),
                            FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? DateTime.Parse(row["FechaNacimiento"].ToString()) : DateTime.MinValue,
                            Activo = bool.Parse(row["Activo"].ToString()),
                            FechaAlta = row["FechaAlta"] != DBNull.Value ? DateTime.Parse(row["FechaAlta"].ToString()) : DateTime.MinValue,
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return socios.OrderBy(x => x.NombreCompleto).ThenBy(x => x.Cedula).ToList();
        }

        public async Task<Socio> GetSocio(int? idSocio)
        {
            Socio socio = new Socio();
            SQLDataAccessParameters parameters = new SQLDataAccessParameters();
            parameters.AddIntNullParameter("IdSocio", idSocio);
            DataSet ds = await _dataAccess.ExecuteDataset("[dbo].[spGetSocio]", CommandType.StoredProcedure, parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                {
                    socio.IdSocio = int.Parse(row["IdSocio"].ToString());
                    socio.NombreCompleto = row["NombreCompleto"].ToString();
                    socio.Cedula = row["Cedula"].ToString();
                    socio.FechaNacimiento = row["FechaNacimiento"] != DBNull.Value ? DateTime.Parse(row["FechaNacimiento"].ToString()) : DateTime.MinValue;
                    socio.Activo = bool.Parse(row["Activo"].ToString());
                    socio.FechaAlta = row["FechaAlta"] != DBNull.Value ? DateTime.Parse(row["FechaAlta"].ToString()) : DateTime.MinValue;
                }
            }

            return socio;
        }

        public async Task<Socio> CreateUpdateSocio(Socio socio)
        {
            SQLDataAccessParameters parameters = new SQLDataAccessParameters();
            parameters.AddIntNullParameter("IdSocio", socio.IdSocio);
            parameters.AddStringParameter("NombreCompleto",0 , socio.NombreCompleto);
            parameters.AddStringParameter("Cedula", 0, socio.Cedula);
            parameters.AddNullableDatetimeParameter("FechaNacimiento", socio.FechaNacimiento);
            parameters.AddBitParameter("Activo", socio.Activo);

            DataSet ds = await _dataAccess.ExecuteDataset("[dbo].[spCreateUpdateSocio]", CommandType.StoredProcedure, parameters);

            socio.IdSocio = Int32.Parse(ds.Tables[0].Rows[0]["IdSocio"].ToString());

            return socio;
        }

        public async Task<bool> DeleteSocio(int idSocio)
        {
            SQLDataAccessParameters parameters = new SQLDataAccessParameters();
            parameters.AddIntParameter("IdSocio", idSocio);

            DataSet ds = await _dataAccess.ExecuteDataset("[dbo].[spDeleteClient]", CommandType.StoredProcedure, parameters);
            int id = Int32.Parse(ds.Tables[0].Rows[0]["Id"].ToString());

            return idSocio == id;
        }
    }
}
