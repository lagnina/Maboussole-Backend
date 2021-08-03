using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Formation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ville { get; set; }
        public string Site { get; set; }
        public string Secteur { get; set; }
        public string Etablissement { get; set; }
        public string Adresse { get; set; }
        public string Domaine { get; set; }
    }
}
