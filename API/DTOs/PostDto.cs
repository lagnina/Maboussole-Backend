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
      public string PhotoUrl { get; set; }

        public int PosterId { get; set; }
        public string PosterPhotoUrl { get; set; }
        public string posterName { get; set; }
        public string Type { get; set; }

        public string speciality { get; set; }

        public int Likes { get; set; }
        public bool isLiked { get; set; }
      public PhotoDto Photos { get; set; }


        public ICollection<PostLike> Postlikes { get; set; }
        public ICollection<Tag> PostTags { get; set; }
public ICollection<string> PostTagsNames { get; set; }

    }
}