using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ISQLDataAccessHelper
    {
        Task<DataSet> ExecuteDataset(string command, System.Data.CommandType commandType, SQLDataAccessParameters parameters);
    }
}
