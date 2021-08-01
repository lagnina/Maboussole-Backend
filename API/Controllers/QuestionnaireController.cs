using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    public class QuestionnaireController : BaseApiController
    {
        private readonly DataContext _context;
        public QuestionnaireController(DataContext context)
        {
            _context = context;
        }
        
        [Authorize]
        [HttpPost("Quiz")]
        public async Task<ActionResult<IEnumerable<Questionnaire>>> GetQuestionnairesResult([FromBody]MyPayload[] results)
        {
            var data = Request.Body;
            return await _context.Questionnaires.ToListAsync();
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
            var results = _context.Results.Where(p => p.questionnaireId == id && p.userId == userId);
            return Ok(results);
        }

    }
}
public class MyPayload
{
    public string name { get; set; }
    public float ratingSum { get; set; }

    public float note { get; set; }
}