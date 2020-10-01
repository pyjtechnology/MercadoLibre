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
    public static class FxMisionFuego
    {
        [FunctionName("FxFuego")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function,"post", Route = "topsecret")] HttpRequest req)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                ModSatelites modelojson = JsonConvert.DeserializeObject<ModSatelites>(requestBody);

                
                double[] arreglo = new double[3];
                int i;
                for (i = 0; i <= (modelojson.satellites.Length - 1); i++)
                {
                    arreglo[i] = modelojson.satellites[i].distance;
                }
                double var1 = arreglo[0];
                double var2 = arreglo[1];
                double var3 = arreglo[2];
                Program program = new Program();

                string Orvarstring = "este";
                string Orvarstring1 = "es";
                string Orvarstring2 = "un";
                string Orvarstring3 = "mensaje";
                string Orvarstring4 = "secreto";

                string Avarstring = modelojson.satellites[0].message[0].ToString();
                string Avarstring1 = modelojson.satellites[0].message[1].ToString();
                string Avarstring2 = modelojson.satellites[0].message[2].ToString();
                string Avarstring3 = modelojson.satellites[0].message[3].ToString();
                string Avarstring4 = modelojson.satellites[0].message[4].ToString();

                string Bvarstring = modelojson.satellites[1].message[0].ToString();
                string Bvarstring1 = modelojson.satellites[1].message[1].ToString();
                string Bvarstring2 = modelojson.satellites[1].message[2].ToString();
                string Bvarstring3 = modelojson.satellites[1].message[3].ToString();
                string Bvarstring4 = modelojson.satellites[1].message[4].ToString();

                string Cvarstring = modelojson.satellites[2].message[0].ToString();
                string Cvarstring1 = modelojson.satellites[2].message[1].ToString();
                string Cvarstring2 = modelojson.satellites[2].message[2].ToString();
                string Cvarstring3 = modelojson.satellites[2].message[3].ToString();
                string Cvarstring4 = modelojson.satellites[2].message[4].ToString();

                int VarContM = 0;
                int VarContM1 = 0;
                int VarContM2 = 0;

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

                if (Orvarstring == Bvarstring)
                {
                    VarContM1 = VarContM1 + 1;
                }
                if (Orvarstring1 == Bvarstring1)
                {
                    VarContM1 = VarContM1 + 1;
                }
                if (Orvarstring2 == Bvarstring2)
                {
                    VarContM1 = VarContM1 + 1;
                }
                if (Orvarstring3 == Bvarstring3)
                {
                    VarContM1 = VarContM1 + 1;
                }
                if (Orvarstring4 == Bvarstring4)
                {
                    VarContM1 = VarContM1 + 1;
                }

                if (Orvarstring == Cvarstring)
                {
                    VarContM2 = VarContM2 + 1;
                }
                if (Orvarstring1 == Cvarstring1)
                {
                    VarContM2 = VarContM2 + 1;
                }
                if (Orvarstring2 == Cvarstring2)
                {
                    VarContM2 = VarContM2 + 1;
                }
                if (Orvarstring3 == Cvarstring3)
                {
                    VarContM2 = VarContM2 + 1;
                }
                if (Orvarstring4 == Cvarstring4)
                {
                    VarContM2 = VarContM2 + 1;
                }

                if (VarContM2>2 && VarContM1 > 2 && VarContM > 2)

                { 
                 var provider = program.Get(var1, var2, var3);

                 return Settings.Response(HttpStatusCode.OK, provider.Item1 ) ;
                }
                var message = new { message = $"Mensaje Secreto Errado, Minimo Deben Concidir 3 Partes" };
                return Settings.Response(HttpStatusCode.NotFound, message);
            }
            catch (Exception ex)
            {
                var message = new { message = $"Se ha presentado un error en el algoritmo, por favor contactar a su administrador." };
                return Settings.Response(HttpStatusCode.InternalServerError, message);
            }
        }
    }
}
