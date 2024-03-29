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
        public async Task<ActionResult> AddReply([FromBody]JObject replys)
        {
            var getQuestions = await _dbContext.Questions.Where(x => x.UserId == (int)replys["userId"] && !x.Deleted).ToListAsync();

            Respondents respon = new Respondents();
            respon.RespondentName = (string)replys["replyName"];
            respon.ReplyDate = Convert.ToString(DateTime.Now);
            respon.UserId = (int)replys["userId"];

            _dbContext.Respondents.Add(respon);
            await _dbContext.SaveChangesAsync();

            foreach (var reply in replys)
            {

                foreach (var question in getQuestions)
                {
                    if (question.Question == reply.Key)
                    {
                        Replys userReply = new Replys();
                        userReply.RespondentName = (string)replys["replyName"];
                        userReply.RespondentId = respon.Id;
                        userReply.QuestionId = (int)question.Id;
                        userReply.Question = question.Question;
                        userReply.Subject = question.Subject;
                        userReply.Reply = reply.Value.ToString();

                        _dbContext.Replys.Add(userReply);
                        await _dbContext.SaveChangesAsync();

                    }

                }
            }



            return Ok();


        }

        [Route("get_respondents"), HttpPost]
        public async Task<ActionResult> GetRespondents([FromBody]JObject user)
        {
            var getReplys = await _dbContext.Respondents.Where(x => x.UserId == (int)user["id"]).ToListAsync();

            return Ok(getReplys);

        }


        [Route("get_replys"), HttpPost]
        public async Task<ActionResult> GetReplys([FromBody]JObject user)
        {
            var getReplys = await _dbContext.Replys.Where(x => x.RespondentId == (int)user["id"]).ToListAsync();

            return Ok(getReplys);

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
