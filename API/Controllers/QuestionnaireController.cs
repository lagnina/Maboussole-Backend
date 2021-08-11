using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    public class QuestionnaireController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public QuestionnaireController(DataContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        
        [Authorize]
        [HttpPost("Quiz")]
        public async Task<ActionResult> PostQuestionnairesResult([FromBody]MyPayload[] results)
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                foreach (MyPayload result in results)
                {
                    var existingRsult = this._context.Results.Where(r => r.domaine == result.name && r.userId == userId && r.isMain).FirstOrDefault();
                    if (existingRsult != null)
                    {
                        existingRsult.isMain = false;
                        this._context.Results.Update(existingRsult);
                    }
                    var newResult = new Result()
                    {
                        domaine = result.name,
                        note = result.note,
                        userId = userId,
                        User = await this._unitOfWork.UserRepository.GetUserByIdAsync(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))),
                        creationDate = DateTime.Now,
                        isMain = true
                    };

                    this._context.Results.Add(newResult);
                    await this._context.SaveChangesAsync();

                }

                return Ok();
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
           
        }

        [Authorize]
        [HttpGet("Result")]
        public async Task<ActionResult<IEnumerable<Result>>> GetQuestionnaireResult()
        {
            try
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
               var results = await  this._context.Results.Where(r => r.userId == userId && r.isMain == true).ToListAsync();

                return results;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Questionnaire>> GetQuestionnaire(int id)
        {
            return await _context.Questionnaires.FindAsync(id);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionnaireQuestions(int id)
        {
            IEnumerable<Question> questions = _context.Questions.Where(p => p.questionnaireId == id);
            return  Ok(questions);
        }
        [Authorize]
        [HttpGet("{id}/{userId}")]
        public async Task<ActionResult<IEnumerable<Result>>> GetUser(int id, int userId)
        {
            
            return Ok();
        }

    }
}
public class MyPayload
{
    public string name { get; set; }
    public float ratingSum { get; set; }

    public float note { get; set; }
}