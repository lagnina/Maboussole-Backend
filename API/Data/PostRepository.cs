using API.Entities;
using API.Interfaces;
using AutoMapper;

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
    }
}