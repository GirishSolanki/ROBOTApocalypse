using System.ComponentModel.DataAnnotations;

namespace ROBOTApocalypse.Entity
{
    public class Survivors
    {
        [Key]
        public long? Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public bool? Flag { get; set; }
        public decimal? Water { get; set; }
        public string? Food { get; set; }
        public string? Medication { get; set; }
        public int? Ammunition { get; set; }
    }
}
