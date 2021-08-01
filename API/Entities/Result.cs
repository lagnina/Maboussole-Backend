
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Result
    {
     [Key]

        public string domaine { get; set; }
        public int note { get; set; }
        public int userId { get; set; }
        public AppUser Email { get; set; }
        public int questionnaireId { get; set; }
        public Questionnaire questionnaire { get; set; }


    }
}