

using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IPostRepository
    {

        void PostCreate(Post post);
        void DeletePost(Post post);

        void UpdatePost(Post post);

        Task<Post> GetPost( int postId);
        Task<PostDto> GetPostDto(int postId);


        Task<Post> GetMyPost( int postId,int PosterId);

        Task<PagedList<PostDto>> GetPosts(PostParams postParams);
    }
}