

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
        Task<PagedList<PostDto>> GetPosts(PostParams postParams);
    }
}