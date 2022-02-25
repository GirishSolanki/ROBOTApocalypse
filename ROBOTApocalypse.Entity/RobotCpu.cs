using Newtonsoft.Json;

namespace ROBOTApocalypse.Entity
{
    public class RobotCpu
    {
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }
        [JsonProperty("manufacturedDate")]
        public string ManufacturedDate { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
