using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class PostComment
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }

        public Post CommentedPost { get; set; }
        public int CommentedPostId { get; set; }

        public string content { get; set; }
        public DateTime creationDate { get; set; }
    }
}
