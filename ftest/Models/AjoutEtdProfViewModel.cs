namespace ftest.Models
{
    public class AjoutEtdProfViewModel
    {

        public AjoutEtdProfViewModel()
        {
            Etudiants = new List<Etd>();
            Professeurs = new List<Prof>();
        }
        public int? EtdId { get; set; }
        public int? ProfId { get; set; }

        public List<Etd>? Etudiants { get; set; }
        public List<Prof>? Professeurs { get; set; }
    }

}
