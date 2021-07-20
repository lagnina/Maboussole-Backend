
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.DTOs;

namespace API.Entities
{
    public class Post
    {
        public int postId { get; set; }
        public string Title { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public int PosterId { get; set; }
        public string Type { get; set; }

        public string speciality { get; set; }
        public int Likes { get; set; }
        public string PhotoUrl { get; set; }


        public Photo Photos { get; set; }

        public AppUser Poster { get; set; }

        public ICollection<PostLike> Postlikes { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        public ICollection<Tag> PostTags { get; set; }




    }
}