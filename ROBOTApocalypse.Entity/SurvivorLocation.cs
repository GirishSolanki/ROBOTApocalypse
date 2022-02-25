using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ROBOTApocalypse.Entity
{
    public class SurvivorLocation
    {
        [Key]
        public long? Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long? SurvivorId { get; set; }
    }
}
