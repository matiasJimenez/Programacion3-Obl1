using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SQLDataAccessParameters
    {
        public List<SqlParameter> ParamerersList { get; set; }
        public SQLDataAccessParameters()
        {
            ParamerersList = new List<SqlParameter>();
        }

        public void AddIntParameter(string name, int value)
        {
            SqlParameter paramInteger = new SqlParameter(name, SqlDbType.Int)
            {
                Value = value
            };
            ParamerersList.Add(paramInteger);
        }

        public void AddIntNullParameter(string name, int? value)
        {
            SqlParameter paramInteger = new SqlParameter(name, SqlDbType.Int)
            {
                IsNullable = true
            };
            if (value.HasValue)
            {
                paramInteger.Value = value;
            }
            else
            {
                paramInteger.Value = DBNull.Value;
            }

            ParamerersList.Add(paramInteger);
        }

        public void AddDecimalParameter(string name, decimal value, byte precision, byte scale)
        {
            SqlParameter paramInteger = new SqlParameter(name, SqlDbType.Decimal)
            {
                Value = value
            };
            if (scale != 0)
                paramInteger.Scale = scale;
            if (precision != 0)
                paramInteger.Precision = precision;
            ParamerersList.Add(paramInteger);
        }

        public void AddStringParameter(string name, int size, string value)
        {
            string comillas = "\"\"";

            if (value != null && value.IndexOf("'") >= 0)
            {
                //si lo que se ha introducido en el filtro es ' lo cambia por " para que no tire error en la BBDD
                value = value.Replace("'", string.Empty).Trim() == string.Empty ? comillas : value;
                //reemplaza las ' por vacio para evitar injection attack y error en la búsqueda
                value = value != null ? value.Replace("'", string.Empty) : value;
            }

            if (value != null && value.IndexOf("%") >= 0)
            {
                //si lo que se ha introducido en el filtro es ' lo cambia por " para que no tire error en la BBDD
                value = value.Replace("%", string.Empty).Trim() == string.Empty ? comillas : value;
                value = value != null ? value.Replace("%", string.Empty) : value;
            }
            //si es el value es uno o mas espacios se envia null
            value = value != null && value.Trim() == "" && value.Trim() != value ? null : value;

            SqlParameter paramString = new SqlParameter(name, SqlDbType.NVarChar, size)
            {
                Value = value
            };
            ParamerersList.Add(paramString);
        }

        public void AddBitParameter(string name, bool value)
        {
            SqlParameter paramBit = new SqlParameter(name, SqlDbType.Bit)
            {
                Value = (value == true ? 1 : 0)
            };
            ParamerersList.Add(paramBit);
        }

        public void AddNullableDatetimeParameter(string name, DateTime? value)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            SqlParameter paramDatetime;

            if (value == null)
            {
                paramDatetime = new SqlParameter(name, DBNull.Value)
                {
                    Value = DBNull.Value
                };
            }
            else
            {
                paramDatetime = new SqlParameter(name, SqlDbType.DateTime)
                {
                    Value = value
                };
            }
            ParamerersList.Add(paramDatetime);
        }
    }
}
