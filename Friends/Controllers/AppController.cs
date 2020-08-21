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

        [Route("add_user"), HttpPost]
        public async Task<ActionResult> AddUser([FromBody]JObject user)
        {
            var getUser = await _dbContext.User.Where(x => x.Name == (string)user["user_name"] && x.Password == (string)user["password"]).SingleOrDefaultAsync();

            if (getUser == null)
            {
                User addUser = new User();
                addUser.Name = (string)user["user_name"];
                addUser.Password = (string)user["password"];
                addUser.UserId = 0;


                _dbContext.User.Add(addUser);
                await _dbContext.SaveChangesAsync();

                return Ok(addUser.Id);

            }
            return Ok();

        }


        [Route("add_question"), HttpPost]
        public async Task<ActionResult> AddQuestion([FromBody]JObject question)
        {

            Questions questions = new Questions();

            questions.UserId = (int)question["user_id"];
            questions.Question = (string)question["question"];
            questions.QuestionType = (string)question["question_type"];

            _dbContext.Questions.Add(questions);
            await _dbContext.SaveChangesAsync();

            return Ok();


        }

    }
}
