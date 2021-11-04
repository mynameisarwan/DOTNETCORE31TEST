using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace KlinikAPI.Errors
{
    public class ApiError
    {
        public ApiError(int errorCode, string errorMessage, string errorDetails = null, String errorgettypename = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
            ErrorGetTypeName = errorgettypename;
        }

        public int ErrorCode { get; set; }
        public String ErrorMessage { get; set; }
        public String ErrorDetails { get; set; }
        public String ErrorGetTypeName { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
