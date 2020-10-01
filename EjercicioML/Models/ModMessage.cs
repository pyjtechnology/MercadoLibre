using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioML.Models
{
    class ModMessage
    {

        [JsonProperty("message", Required = Required.Always)]
        public string[] message { get; set; }

    }
}
