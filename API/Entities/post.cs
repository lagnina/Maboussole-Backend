
using System;
using System.ComponentModel.DataAnnotations;
namespace API.Entities
{
    public class post
    {
        public int postId { get; set; }

        [Required]
        public string Titre { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
    
    
    
    
    
    }
}