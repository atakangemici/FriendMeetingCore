using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Friends.Models;

namespace Friends.Controllers
{
    [Route("api/app")]
    public class AppController : ControllerBase
    {

        private readonly FriendsContext _dbContext;

        public AppController(FriendsContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "home page" };

        }

        [Route("register"), HttpPost]
        public async Task<ActionResult> Register([FromBody]JObject user)
        {
            var getUser = await _dbContext.User.Where(x => x.Name == (string)user["user_name"] && x.Password == (string)user["password"]).SingleOrDefaultAsync();

            if (getUser == null)
            {
                User addUser = new User();
                addUser.NameSurename = (string)user["name_surename"];
                addUser.Name = (string)user["user_name"];
                addUser.Password = (string)user["password"];
                addUser.UserId = 0;


                _dbContext.User.Add(addUser);
                await _dbContext.SaveChangesAsync();

                return Ok(addUser.Id);

            }

            return Ok(false);

        }

        [Route("login"), HttpPost]
        public async Task<ActionResult> Login([FromBody]JObject user)
        {
            var getUser = await _dbContext.User.Where(x => x.Name == (string)user["user_name"] && x.Password == (string)user["password"]).SingleOrDefaultAsync();

            if (getUser != null)
                return Ok(getUser.Id);

            return Ok(false);

        }


        [Route("add_question"), HttpPost]
        public async Task<ActionResult> AddQuestion([FromBody]JObject question)
        {

            Questions questions = new Questions();

            questions.UserId = (int)question["user_id"];
            questions.Question = (string)question["question"];
            questions.Subject = (string)question["subject"];
            questions.QuestionType = (string)question["question_type"];

            _dbContext.Questions.Add(questions);
            await _dbContext.SaveChangesAsync();

            return Ok();


        }


        [Route("add_reply"), HttpPost]
        public async Task<ActionResult> AddReply([FromBody]JObject reply)
        {

            //Questions questions = new Questions();

            //questions.UserId = (int)question["user_id"];
            //questions.Question = (string)question["question"];
            //questions.Subject = (string)question["subject"];
            //questions.QuestionType = (string)question["question_type"];

            //_dbContext.Questions.Add(questions);
            //await _dbContext.SaveChangesAsync();

            return Ok();


        }

        [Route("delete_questions/{id:int}"), HttpGet]
        public async Task<ActionResult> DeleteQuestions(int id)
        {
            var getQuestions = await _dbContext.Questions.Where(x => x.UserId == id).ToListAsync();

            foreach (var question in getQuestions)
            {
                question.Deleted = true;

                await _dbContext.SaveChangesAsync();

            }

            return Ok(true);

        }

        [Route("get_questions/{id:int}"), HttpGet]
        public async Task<ActionResult> GetQuestions(int id)
        {
            var getQuestions = await _dbContext.Questions.Where(x => !x.Deleted && x.UserId == id).ToListAsync();

            return Ok(getQuestions);

        }

    }
}
