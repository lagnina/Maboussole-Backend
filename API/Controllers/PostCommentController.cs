using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PostCommentController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostCommentController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }

        [HttpPost("Comment-post/{postId}")]

        public ActionResult AddComment(int postId,string content)
        {

            var sourceUserId = User.GetUserId();

            var postComment = new PostComment
            {

                SourceUserId = sourceUserId,
                CommentedPostId = postId,
                content = content,
                creationDate = DateTime.Now
            };


            var result = _unitOfWork.PostCommentRepository.Comment(postComment).Result;



            return Ok();
        }

        [HttpGet("Comments")]
        public async Task<ActionResult<IEnumerable<PostComment>>> GetPostComments(int postId)
        {
            var comments = this._unitOfWork.PostCommentRepository.GetPostComments(postId);
            return Ok(comments);
        }




    }
}
