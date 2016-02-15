using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;
using StudentManagement.WebAPI.Models;

namespace StudentManagement.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [Route("api/user")]
        [HttpPost]
        public void Create(CreateUserModel user)
        {
            if (!user.Password.Equals(user.ConfirmPassword))
            {
                throw new Exception("Password diffrent with confirm password");
            }
            
            _userLogic.Create(new User {UserName = user.UserName,Password = user.Password });
        }

        [Route("api/user")]
        [HttpPut]
        public void Update(User user)
        {
            _userLogic.Edit(user);
        }

        [Route("api/user/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _userLogic.Delete(id);
        }

        [Route("api/user/{id}")]
        [HttpGet]
        public User GetUserById(int id)
        {
            return _userLogic.Get(id);
        }
        [Route("api/user/login")]
        [HttpPost]
        public HttpResponseMessage Login(string userName, string password)
        {
            string msg;
            bool result = _userLogic.Login(userName, password, out msg);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.StatusCode = HttpStatusCode.OK;
            if (!result)
            {
                response.Content = new StringContent(msg);
            }
            return response;
        }

        [Route("api/user")]
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userLogic.GetAll();
        }

        [Route("api/user/search/")]
        [HttpPost]
        public IEnumerable<User> QueryByName(string userName)
        {
            return _userLogic.QueryByName(userName);
        }

    }
}
