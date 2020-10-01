using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EjercicioML.Models
{


    public class ModSatelites
    {
       [JsonProperty("satellites", Required = Required.Always)]
        public satellites[] satellites { get; set; }
    }

    public class satellites
    {
        [JsonProperty("name", Required = Required.Always)]
        public string name { get; set; }

        [JsonProperty("distance", Required = Required.Always)]
        public double distance { get; set; }

        [JsonProperty("message", Required = Required.Always)]

        public string[] message { get; set; }

    }

}
