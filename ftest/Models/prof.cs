using System.ComponentModel.DataAnnotations;

namespace ftest.Models
{
    public class Prof
    {
        
            [Key]
            public int? Id { get; set; }
            [Required]
            public string? Nom { get; set; }
            [Required]
            public string? Prenom { get; set; }
            [Required]
            public string? Matiere { get; set; }

        public List<EtdProf>? EtdProfs { get; set; }




    }
}
