using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);


        public IPostRepository PostRepository => new PostRepository(_context,_mapper);

        public IPostLikeRepository PostLikeRepository => new PostLikeRepository(_context,_mapper);

        public IPostCommentRepository PostCommentRepository => new PostCommentRepository(_context, _mapper);

        // public IFormationRepository FormationRepository => new FormationRepository(_context,_mapper);

        public ITagRepository TagRepository => new TagRepository(_context, _mapper);

        public IFormationRepository FormationRepository => throw new System.NotImplementedException();

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddPhoto(Photo photo)
        {
             _context.Photos.Add(photo);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}