using System.Threading.Tasks;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostLikeController :BaseApiController
    {
         private readonly IUnitOfWork _unitOfWork;

         public PostLikeController(IUnitOfWork unitOfWork){

             _unitOfWork = unitOfWork;
             
         }

         [HttpPost("like-post/{postId}")]

         public  ActionResult AddLike(int postId)
{

        var sourceUserId = User.GetUserId();
        
        var postLike = new PostLike{

            SourceUserId = sourceUserId,
            LikedPostId = postId
        };


          var result  =   _unitOfWork.PostLikeRepository.Like(postLike).Result;

         

          return Ok();  
          }        
         
         

        
    }
}