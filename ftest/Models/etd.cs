using System.ComponentModel.DataAnnotations;

namespace ftest.Models
{
    public class Etd
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Nom { get; set; }
        [Required]
        public string? Prenom { get; set; }
        [Required]
        public string? Filiere { get; set; }
        [Required]
        public string? Niv { get; set; }

        public List<EtdProf>? EtdProfs { get; set; }
    }
}
