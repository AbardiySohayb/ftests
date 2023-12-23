using System.ComponentModel.DataAnnotations;
namespace ftest.Models
{
    public class EtdProf
    {
        
        public int? Id { get; set; }
        public int? EtdId { get; set; }
        public Etd? Etd { get; set; }

        public int? ProfId { get; set; }
        public Prof? Prof { get; set; }

    }
}
