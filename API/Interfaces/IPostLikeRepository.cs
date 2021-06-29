using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IPostLikeRepository
    {

        Task<IEnumerable<PostLike>> GetPostLikes (int postId);

        bool Like(PostLike postLike);


    }
}