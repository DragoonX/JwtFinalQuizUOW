using System;
using System.Collections.Generic;
using JwtSon.Interfaces;
using JwtSon.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtSon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]

        public ActionResult Get()
        {
            return new JsonResult(_unitOfWork.userRepository.List());
        }

        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // POST api/values
        [HttpPost]
        public ActionResult Index([FromBody]List<UserDto> userDtos)
        {
            Console.WriteLine(userDtos);
            foreach (var item in userDtos)
            {
                User user = new User()
                {
                    firstname = item.firstname,
                    lastname = item.lastname,
                    username = item.username
                };
                var result = _unitOfWork.userRepository.FindUsername(user.username);
                if (result == null)
                {
                    _unitOfWork.userRepository.Insert(user);
                }
            }
            _unitOfWork.Complete(); //SaveChanges burada çalışıyor.
            return new JsonResult(_unitOfWork.userRepository.List());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
