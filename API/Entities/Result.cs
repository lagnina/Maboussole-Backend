using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Result
    {
       
        public string domaine { get; set; }
        public int note { get; set; }
        public int userId { get; set; }
        public AppUser user { get; set; }
        public int questionnaireId { get; set; }
        public Questionnaire questionnaire { get; set; }


    }
}
