using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities



{
    public class PostLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }

        public Post LikedPost { get; set; }
        public int LikedPostId { get; set; }
    }
}