
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Result
    {
     

        public string domaine { get; set; }
        public float note { get; set; }
        public int userId { get; set; }
        public  virtual AppUser User { get; set; }
        public DateTime creationDate { get; set; }
        public bool isMain { get; set; }


    }
}