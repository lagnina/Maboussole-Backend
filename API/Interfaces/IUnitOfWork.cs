using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository {get; }
        IMessageRepository MessageRepository {get;}
        IPostRepository PostRepository{get;}
        IPostLikeRepository PostLikeRepository{get;}
        IPostCommentRepository PostCommentRepository { get; }
        ITagRepository TagRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}