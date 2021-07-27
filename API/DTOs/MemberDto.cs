using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string Speciality { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public PhotoDto Photos { get; set; }
    }
}