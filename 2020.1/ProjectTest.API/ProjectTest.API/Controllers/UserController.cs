using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.API.Data;
using ProjectTest.API.Model;

namespace ProjectTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext dataContext;

        public UserController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response> ObterTodos()
        {
            // select * from users
            Response response = new Response();
            response.Model = dataContext.Users.ToList();

            return response;
        }

        [HttpGet("obterUser/{id}")]
        public ActionResult<Response> PesquisarPorId(Guid id)
        {
            Response response = new Response();
            response.Model = dataContext.Users.Where(userTemp => userTemp.Id == id).FirstOrDefault();

            if (response.Model == null)
            {
                response.Model = HttpStatusCode.NotFound;
                response.MessageError = "Usuário não encontrado";
            }

            return response;
        }

        [HttpPost("registro")]
        public ActionResult<User> Cadastrar([FromBody] User user)
        {
            user.Id = Guid.NewGuid();

            dataContext.Users.Add(user);
            dataContext.SaveChanges();

            return user;
        }

        [HttpPut()]
        public ActionResult<Guid> Put([FromBody] User userToEdit)
        {
            User user = dataContext.Users.Where(userTemp => userTemp.Id == userToEdit.Id).FirstOrDefault();

            if (user != null)
            {
                user.Name = userToEdit.Name;
                dataContext.Users.Update(user);
                dataContext.SaveChanges();
            }

            return user.Id;
        }

        [HttpDelete("{id}")] 
        public ActionResult<Guid> Delete(Guid id)
        {
            User user = dataContext.Users.Where(userTemp => userTemp.Id == id).FirstOrDefault();

            if(user != null)
            {
                dataContext.Users.Remove(user);
                dataContext.SaveChanges();
            }

            return id;
        }
    }
}