using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class TagController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;

        }
        [HttpPost("AddTag")]
        public async Task<ActionResult> AddTagAsync(string name)
        {
            var tag = new Tag()
            {
                name = name
            };
            var result = await this._unitOfWork.TagRepository.AddTag(tag);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Tag Already Exists");


        }
        [HttpGet("GetAllTags")]
        public async Task<ActionResult<ICollection<Tag>>> GetAllTags()
        {

            var result = await this._unitOfWork.TagRepository.GetAllTags();
            return Ok(result);
        }
    }
}
