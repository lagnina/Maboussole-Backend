using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{

    public interface IPostCommentRepository
    {
        IEnumerable<PostComment> GetPostComments(int postId);

        Task<bool> Comment(PostComment postComment);
    }
}