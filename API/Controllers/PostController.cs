using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Helpers;
using API.Extensions;
using Newtonsoft.Json;

namespace API.Controllers
{ 
    [Authorize]
    public class PostController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
         private readonly IPhotoService _photoService;
        public PostController(IUnitOfWork unitOfWork, IMapper mapper,
            IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _mapper = mapper;
        }

        [HttpPost("Create")]

        public async Task<ActionResult<int>> PostCreate()
        {
            try
            {
                var postDto = JsonConvert.DeserializeObject<PostDto>(Request.Form["PostForm"]);
                var photo = Request.Form.Files.Count > 0 ? Request.Form.Files.First() : null;
                if (photo != null)
                {
                    var result = await _photoService.AddPhotoAsync(photo);
                    var pic = new Photo
                    {
                        Url = result.SecureUrl.AbsoluteUri,
                        PublicId = result.PublicId,
                    };
                   



                    Post post = new Post
                    {

                        Content = postDto.Content,
                        PosterId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                        DateCreated = DateTime.Now,
                        speciality = postDto.speciality,
                        Type = postDto.Type,
                        Title = postDto.Title,
                        Photos = pic,
                        PhotoUrl = pic.Url,
                        Poster = await this._unitOfWork.UserRepository.GetUserByIdAsync(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                    };
                    post.PostTags = new List<Tag>();
                    foreach (Tag tag in postDto.PostTags)
                    {
                        post.PostTags.Add(new Tag
                        {
                            Id = tag.Id,
                            name = tag.name
                        });
                    }


                    this._unitOfWork.PostRepository.PostCreate(post);

                    if (await _unitOfWork.Complete()) return Ok(post.postId);
                }
                return BadRequest("Problem Posting the Post");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
          
        }

         [HttpGet("Posts")]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetPosts([FromQuery] PostParams postParams)
        {
            var posts = await _unitOfWork.PostRepository.GetPosts(postParams);
           foreach(PostDto post in posts)
            {
                if(post.Postlikes != null)
                {
                    if (post.Postlikes.Where(p => p.SourceUserId == long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))).Count() > 0)
                    {
                        post.isLiked = true;
                    }
                    else
                    {
                        post.isLiked = false;
                    }
                   
                }
                else
                {
                    post.isLiked = false;
                }
               
            }

            Response.AddPaginationHeader(posts.CurrentPage, posts.PageSize,
                posts.TotalCount, posts.TotalPages);

            return Ok(posts);
        }

        [HttpGet("Posts/{postId}")]
        public async Task<ActionResult<PostDto>> GetPost(int postId)
        {
            var post = await _unitOfWork.PostRepository.GetPostDto(postId);

            if (post.Postlikes != null)
            {
                if (post.Postlikes.Where(p => p.SourceUserId == long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))).Count() > 0)
                {
                    post.isLiked = true;
                }
                else
                {
                    post.isLiked = false;
                }

            }
            return Ok(post);
        }

        [HttpDelete("delete-post/{postId}")]

    public async Task<ActionResult<IEnumerable<PostDto>>> DeletePost(int postId)


    {
        var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

        var post = await _unitOfWork.PostRepository.GetMyPost(postId,user.Id);
        
        if (post == null) return NotFound();
        _unitOfWork.PostRepository.DeletePost(post);
        if (await _unitOfWork.Complete()) return Ok();
            return BadRequest("Problem deleting the post");

    }

    public async Task<ActionResult<IEnumerable<Post>>> UpdatePost(int postId)

    {
         var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

        var post = await _unitOfWork.PostRepository.GetMyPost(postId,user.Id);
        
      //  _mapper.Map(post);

        if (post == null) return NotFound();
        _unitOfWork.PostRepository.UpdatePost(post);
        if (await _unitOfWork.Complete()) return NoContent();
            return BadRequest("Problem Updating the post");
    }
    }
}
