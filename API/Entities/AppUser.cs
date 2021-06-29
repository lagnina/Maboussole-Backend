using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string Speciality { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public ICollection<Result> results { get; set; }
        public ICollection<Photo> Photos { get; set; }

        
        public ICollection<PostLike> LikedPosts { get; set; }

        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}