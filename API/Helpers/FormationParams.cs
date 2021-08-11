

namespace API.Helpers
{
    public class FormationParams : PaginationParams
    { 
        
        public string Domaine { get; set; }
        public string OrderBy { get; set; } = "Secteur";
        public string Ville { get;  set; }
        public string Secteur { get;  set; }
        public string Etablissement { get;  set; }
    }
}
