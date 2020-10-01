using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace EjercicioML
{
    class Settings
    {
        public static HttpResponseMessage Response(HttpStatusCode httpStatusCode, object response)
        {
            return new HttpResponseMessage(httpStatusCode)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
            };
        }




    }
}
