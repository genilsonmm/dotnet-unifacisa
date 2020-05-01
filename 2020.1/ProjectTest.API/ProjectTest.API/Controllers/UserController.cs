using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.API.Data;
using ProjectTest.API.Model;

namespace ProjectTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> ObterTodos()
        {
            return UserRepository.users;
        }

        [HttpPost("registro")]
        public ActionResult<User> Cadastrar([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            UserRepository.users.Add(user);

            return user;
        }

        [HttpDelete("{id}")] 
        public ActionResult<Guid> Delete(Guid id)
        {
            User usuarioEncontrado = UserRepository.users.Find(u => u.Id == id);

            if (usuarioEncontrado == null)
                return Guid.Empty;
      
            UserRepository.users.Remove(usuarioEncontrado);
            return id;
        }
    }
}