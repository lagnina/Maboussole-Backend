using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Post> PostTags { get; set; }
    }
}
