using Data.Model;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Demo6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Ok(userRepository);
        }

        [HttpPost]
        public void Post([FromBody]string name)
        {
            User newUser = new User() { Id = userRepository.Users.Count + 1, Name = name };

            userRepository.Users.Add(newUser);
        }

        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody]string name)
        {
            User currentUser = userRepository.Users.Single(u => u.Id == id);
            currentUser.Name = name;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User currentUser = userRepository.Users.Single(u => u.Id == id);
            userRepository.Users.Remove(currentUser);
        }
    }
}