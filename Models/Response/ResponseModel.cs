using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class ResponseModel
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public string Detail { get; set; }

        public string ExceptionDetail { get; set; }

        public object DataModel { get; set; }
        public object DataModel1 { get; set; }

        public ResponseModel()
        {
            Code = 0;
            Message = "OK";
            Detail = "";
            DataModel = null;
        }

        public ResponseModel(string token)
        {
            Code = 0;
            Message = "OK";
            Detail = "";
            DataModel = null;
        }

        public ResponseModel(int code, string errorMessage, string errorDetail)
        {
            Code = code;
            Message = errorMessage;
            Detail = errorDetail;
            DataModel = null;
        }
    }
}
