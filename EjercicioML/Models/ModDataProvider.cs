using Newtonsoft.Json;
namespace EjercicioML.Models

{
    public class ModDataProvider
    {
        public Position position { get; set; }
        public string message { get; set; }
    }
    public class Position
    {
        public double x { get; set; }
        public double y { get; set; }
    }




}
