using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using EjercicioML.Models;
using MathNet.Numerics;

namespace EjercicioML
{
    public static class FxMisionFuegoDistance
    {
        [FunctionName("FxFuegoDistance")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getlocation/{distance}")] HttpRequest req, double distance)
        {
            try
            {
               string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

               ModSatelitesname modelojson = JsonConvert.DeserializeObject<ModSatelitesname>(requestBody);
                              
               Program program = new Program();
               var provider = program.GetDistance(distance);

               return Settings.Response(HttpStatusCode.OK, provider.Item1) ;

            }
            catch (Exception ex)
            {
                var message = new { message = $"Se ha presentado un error en el algoritmo, por favor contactar a su administrador" };
                return Settings.Response(HttpStatusCode.InternalServerError, message);
            }
        }
    }
}
