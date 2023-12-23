namespace ftest.VM
{
    public class EtdVM
    {

        public string? Nom { get; set; }
        
        public string? Prenom { get; set; }
       
        public string? Filiere { get; set; }
       
        public string? Niv { get; set; }
        public List<int>? ProfIds { get; set; }
    }

    public class ProfEtdVM
    {
        public string? Nom { get; set; }
       
        public string? Prenom { get; set; }
      
        public string? Filiere { get; set; }
        
        public string? Niv { get; set; }

        public List<string>? ProfNames { get; set; }
    }
}
