using Microsoft.AspNetCore.Mvc;
using EnglishGameServer.Models;
using EnglishGameServer.Data;

namespace EnglishGameServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        // GET: api/questions
        [HttpGet]
        public ActionResult<List<Question>> GetAllQuestions()
        {
            var questions = QuestionsData.GetAllQuestions();
            return Ok(questions);
        }

        // GET: api/questions/1
        [HttpGet("{id}")]
        public ActionResult<Question> GetQuestionById(int id)
        {
            var question = QuestionsData.GetQuestionById(id);
            
            if (question == null)
            {
                return NotFound(new { message = $"Question with id {id} not found" });
            }
            
            return Ok(question);
        }
    }
}
