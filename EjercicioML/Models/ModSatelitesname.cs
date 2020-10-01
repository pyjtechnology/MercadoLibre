using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EjercicioML.Models
{


    public class ModSatelitesname
    {


        [JsonProperty("distance", Required = Required.Always)]
        public double distance { get; set; }

        [JsonProperty("message", Required = Required.Always)]
        public string[] message { get; set; }

    }

}
