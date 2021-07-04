using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PostLikeRepository : IPostLikeRepository
    {
         private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PostLikeRepository(DataContext context, IMapper mapper)
        {
     _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<PostLike>> GetPostLikes(int postId)
        {
            return await _context.PostLikes.Where(Pl => Pl.LikedPostId == postId ).ToArrayAsync();
        }

        public async Task<bool> Like(PostLike postLike)
        {
           var existingPostLike = await _context.PostLikes.Where(pl => pl.LikedPostId == postLike.LikedPostId && pl.SourceUserId == postLike.SourceUserId).FirstOrDefaultAsync();
            if(existingPostLike == null){
                _context.PostLikes.Add(postLike);
                _context.SaveChanges();
                return true;
            }
            _context.PostLikes.Remove(existingPostLike);
            _context.SaveChanges();
            return false;
        }
    }
}