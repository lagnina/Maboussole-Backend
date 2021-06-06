using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string content { get; set; }
        public string domaine { get; set; }
        public int questionnaireId { get; set; }
        public Questionnaire questionnaire { get; set; }
    }
}