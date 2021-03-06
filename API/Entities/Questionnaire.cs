using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public ICollection<Question> questions { get; set; }
        public ICollection<Result> results { get; set; }
    }
}