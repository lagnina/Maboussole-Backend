
using System;
using System.ComponentModel.DataAnnotations;
namespace API.Entities
{
    public class Post
    {
        public int postId { get; set; }

        [Required]

        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public long PosterId { get; set; }





    }
}