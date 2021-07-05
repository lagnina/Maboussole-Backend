using API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PostDto
    {

        public int postId { get; set; }
        public string Title { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public long PosterId { get; set; }
        public string Type { get; set; }

        public string speciality { get; set; }

        public int Likes { get; set; }
        public bool isLiked { get; set; }

        public ICollection<PostLike> Postlikes;


    }
}