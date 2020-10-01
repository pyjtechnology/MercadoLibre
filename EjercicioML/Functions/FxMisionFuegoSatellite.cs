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
    public static class FxMisionFuegoSatellite
    {
        [FunctionName("FxFuegoSatellite")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get","post", Route = "topsecret_split/{satellite_name}")] HttpRequest req, string satellite_name)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                ModSatelitesname modelojson = JsonConvert.DeserializeObject<ModSatelitesname>(requestBody);
                                           
                string Orvarstring = "este";
                string Orvarstring1 = "es";
                string Orvarstring2 = "un";
                string Orvarstring3 = "mensaje";
                string Orvarstring4 = "secreto";
                int VarContM = 0;
                string Avarstring = modelojson.message[0].ToString();
                string Avarstring1 = modelojson.message[1].ToString();
                string Avarstring2 = modelojson.message[2].ToString();
                string Avarstring3 = modelojson.message[3].ToString();
                string Avarstring4 = modelojson.message[4].ToString();
                

                if (Orvarstring == Avarstring)
                {
                   VarContM = VarContM + 1;
                }
                if (Orvarstring1 == Avarstring1)
                {
                    VarContM = VarContM + 1;
                }
                if (Orvarstring2 == Avarstring2)
                {
                    VarContM = VarContM + 1;
                }
                if (Orvarstring3 == Avarstring3)
                {
                    VarContM = VarContM + 1;
                }
                if (Orvarstring4 == Avarstring4)
                {
                    VarContM = VarContM + 1;
                }

                double var1 = modelojson.distance;
                if (VarContM > 2)

                {
                    Program program = new Program();
                    var provider = program.GetDetail(var1);

                 return Settings.Response(HttpStatusCode.OK, provider.Item1 ) ;
                }
                var message = new { message = $"Mensaje Secreto Errado, Minimo Deben Concidir 3 Partes" };
                return Settings.Response(HttpStatusCode.NotFound, message);
            }
            catch (Exception ex)
            {
                var message = new { message = $"Se ha presentado un error en el algoritmo, por favor contactar a su administrador" };
                return Settings.Response(HttpStatusCode.InternalServerError, message);
            }
        }
    }
}
