using Charger_prepaid_API.Models;

namespace Charger_prepaid_API.Models
{
    public class ResponseData
    {
        public class StatusResponse
        {
            public int? Code { get; set; } = null;
            public int StatusCode { get; set; } = 500;
            public string Description { get; set; } = "";
        }

        public StatusResponse Status { get; set; }
        public object Data { get; set; }


        public ResponseData()
        {
        }

        public ResponseData(int code)
        {
            this.Status = GetMessage(code);
            this.Data = null;
        }

        public ResponseData(int code, string message, object data)
        {
            this.Status = new StatusResponse() { Code = code, Description = message };
            this.Data = data;

        }


        public ResponseData(int code, object data)
        {
            this.Status = GetMessage(code);
            this.Data = data;
        }

        private StatusResponse GetMessage(int code)
        {
            StatusResponse statusResponse = new StatusResponse();

            switch (code)
            {
                case 1000:
                    statusResponse.StatusCode = 200;
                    statusResponse.Code = code;
                    statusResponse.Description = "Success";
                    return statusResponse;
                case 1001:
                    statusResponse.StatusCode = 200;
                    statusResponse.Code = code;
                    statusResponse.Description = "Data successfully updated";
                    return statusResponse;
                case 1002:
                    statusResponse.StatusCode = 201;
                    statusResponse.Code = code;
                    statusResponse.Description = "Creation successful";
                    return statusResponse;
                case 1003:
                    statusResponse.StatusCode = 202;
                    statusResponse.Code = code;
                    statusResponse.Description = "The request has been received and presumed to run in the background";
                    return statusResponse;
                case 1004:
                    statusResponse.StatusCode = 202;
                    statusResponse.Code = code;
                    statusResponse.Description = "Data successfully deleted";
                    return statusResponse;
                case 1101:
                    statusResponse.StatusCode = 400;
                    statusResponse.Code = code;
                    statusResponse.Description = "Missing required parameters";
                    return statusResponse;
                case 1102:
                    statusResponse.StatusCode = 400;
                    statusResponse.Code = code;
                    statusResponse.Description = "Invalid parameters entered";
                    return statusResponse;
                case 1103:
                    statusResponse.StatusCode = 400;
                    statusResponse.Code = code;
                    statusResponse.Description = "Empty string input not supported";
                    return statusResponse;
                case 1104:
                    statusResponse.StatusCode = 404;
                    statusResponse.Code = code;
                    statusResponse.Description = "Requested entity record does not exist";
                    return statusResponse;
                case 1105:
                    statusResponse.StatusCode = 400;
                    statusResponse.Code = code;
                    statusResponse.Description = "Unrecognized field name was entered - Please check spelling and/or refer to the API docs for correct name";
                    return statusResponse;
                case 1111:
                    statusResponse.StatusCode = 400;
                    statusResponse.Code = code;
                    statusResponse.Description = "Data entry duplicated with existing";
                    return statusResponse;
                case 4101:
                    statusResponse.StatusCode = 501;
                    statusResponse.Code = code;
                    statusResponse.Description = "Current channel is not supported";
                    return statusResponse;
                case 8101:
                    statusResponse.StatusCode = 500;
                    statusResponse.Code = code;
                    statusResponse.Description = "Invalid response from downstream service";
                    return statusResponse;
                case 8102:
                    statusResponse.StatusCode = 400;
                    statusResponse.Code = code;
                    statusResponse.Description = "Payment API error code";
                    return statusResponse;
                case 8901:
                    statusResponse.StatusCode = 500;
                    statusResponse.Code = code;
                    statusResponse.Description = "Database error";
                    return statusResponse;
                case 8902:
                    statusResponse.StatusCode = 500;
                    statusResponse.Code = code;
                    statusResponse.Description = "Error getting mysql_pool connection";
                    return statusResponse;
                case 9100:
                    statusResponse.StatusCode = 401;
                    statusResponse.Code = code;
                    statusResponse.Description = "Missing required authorization credentials";
                    return statusResponse;
                case 9101:
                    statusResponse.StatusCode = 401;
                    statusResponse.Code = code;
                    statusResponse.Description = "Authorization credentials required";
                    return statusResponse;
                case 9300:
                    statusResponse.StatusCode = 401;
                    statusResponse.Code = code;
                    statusResponse.Description = "Invalid/expired temporary token";
                    return statusResponse;
                case 9500:
                    statusResponse.StatusCode = 401;
                    statusResponse.Code = code;
                    statusResponse.Description = "Invalid authorization credentials";
                    return statusResponse;
                case 9503:
                    statusResponse.StatusCode = 403;
                    statusResponse.Code = code;
                    statusResponse.Description = "Invalid access rights";
                    return statusResponse;
                case 9700:
                    statusResponse.StatusCode = 500;
                    statusResponse.Code = code;
                    statusResponse.Description = "Generic server side error";
                    return statusResponse;
                case 9900:
                    statusResponse.StatusCode = 405;
                    statusResponse.Code = code;
                    statusResponse.Description = "Wrong http method requested on endpoint";
                    return statusResponse;
                case 9901:
                    statusResponse.StatusCode = 415;
                    statusResponse.Code = code;
                    statusResponse.Description = "Unsupported content type defined";
                    return statusResponse;
                case 9902:
                    statusResponse.StatusCode = 500;
                    statusResponse.Code = code;
                    statusResponse.Description = "Threat has been detected";
                    return statusResponse;
                case 9903:
                    statusResponse.StatusCode = 502;
                    statusResponse.Code = code;
                    statusResponse.Description = "Invalid response from upstream server";
                    return statusResponse;
                case 9904:
                    statusResponse.StatusCode = 503;
                    statusResponse.Code = code;
                    statusResponse.Description = "Server is currently unavailable because traffic overload or it is down for maintenance";
                    return statusResponse;
                case 9905:
                    statusResponse.StatusCode = 503;
                    statusResponse.Code = code;
                    statusResponse.Description = "System maintenance in progress. We will be back shortly.";
                    return statusResponse;
                case 9906:
                    statusResponse.StatusCode = 504;
                    statusResponse.Code = code;
                    statusResponse.Description = "API Request Timeout";
                    return statusResponse;
                default:
                    return null;
            }
        }
    }
}
