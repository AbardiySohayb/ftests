using System.ComponentModel.DataAnnotations;

namespace ftest.Models
{
    public class Dem
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? EtdNom { get; set; }
        [Required]
        public string? ProfNom { get; set; }
        

        
        public byte[]? ImageData { get; set; }
    }
}
