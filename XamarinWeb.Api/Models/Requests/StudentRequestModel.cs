using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinWeb.Api.Models.Requests
{
    public class StudentRequestModel
    {
        [JsonProperty("userName")]
        public string UserName { get;set; }

        [JsonProperty("password")]
        public string Password { get;set; }

        [JsonProperty("contactNo")]
        public string ContactNo { get;set; }
    }

    public class Response
    {
        [JsonProperty("data")]
        public List<StudentRequestModel> Data { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
