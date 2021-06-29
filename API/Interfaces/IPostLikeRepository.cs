using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IPostLikeRepository
    {

        Task<IEnumerable<PostLike>> GetPostLikes (int postId);

        Task<bool> Like(PostLike postLike);


    }
}