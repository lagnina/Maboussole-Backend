using System.Linq;
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
            var query = _context.Posts.Include(p=>p.Poster.Photos).Include(p=>p.PostTags).Where(p=> p.Type == postParams.Type).AsQueryable();

            return await PagedList<PostDto>.CreateAsync(query.ProjectTo<PostDto>(_mapper
                .ConfigurationProvider).AsNoTracking(), 
                    postParams.PageNumber, postParams.PageSize);
        }
        public async Task<Post> GetPost(int postId){

           return await _context.Posts.Where(p =>p.postId == postId).SingleOrDefaultAsync();
        }
        public async Task<PostDto> GetPostDto(int postId)
        {
            var query = _context.Posts.Where(p => p.postId == postId).AsQueryable();
            return await query.ProjectTo<PostDto>(_mapper
                .ConfigurationProvider).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<Post> GetMyPost(int postId,int PosterId){

           return await _context.Posts.Where(p =>p.PosterId == PosterId && p.postId ==postId).SingleOrDefaultAsync();
        }
        public void DeletePost( Post post)
        {
            _context.Posts.Remove(post);
        }

        public void UpdatePost( Post post)
        {
            _context.Posts.Update(post);

        }


    }
}