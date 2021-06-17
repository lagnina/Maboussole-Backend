using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    internal class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostRepository(DataContext context, IMapper mapper)
        {
     _mapper = mapper;
            _context = context;
        }

        public void PostCreate(Post post)
        {

            _context.Posts.Add(post);
        }
         public async Task<PagedList<PostDto>> GetPosts(PostParams postParams)
        {
            var query = _context.Posts.AsQueryable();

           
            
            
            return await PagedList<PostDto>.CreateAsync(query.ProjectTo<PostDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), 
                    postParams.PageNumber, postParams.PageSize);
        }
    }
}