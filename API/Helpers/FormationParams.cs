

namespace API.Helpers
{
    public class FormationParams : PaginationParams
    { 
        
        public string Domaine { get; set; }
        public string OrderBy { get; set; } = "Secteur";


    }
}
