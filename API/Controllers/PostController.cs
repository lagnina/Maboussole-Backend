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


namespace API.Controllers
{ 
    [Authorize]
    public class PostController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("Create")]

        public async Task<ActionResult<Post>> PostCreate(PostDto postDto)
        {


            Post post = new Post
            {

                Content = postDto.content,
                PosterId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                DateCreated = DateTime.Now
                


            };

            this._unitOfWork.PostRepository.PostCreate(post);

            if (await _unitOfWork.Complete()) return Ok(post);
            return BadRequest("Problem Posting the Post");
        }
    }
}
