using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.API.Data;
using ProjectTest.API.Model;
using ProjectTest.Domain;

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
            response.Model = dataContext.Users.Include(tabela => tabela.Posts).ToList();

            return response;
        }

        [HttpGet("obterUser/{id}")]
        public ActionResult<Response> PesquisarPorId(Guid id)
        {
            Response response = new Response();
            response.Model = dataContext.Users.Include(tabela => tabela.Posts).Where(userTemp => userTemp.Id == id).FirstOrDefault();

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

            user.Posts.ForEach(post => post.Date = DateTime.Now);

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
            User user = dataContext.Users.Include(tabela => tabela.Posts).Where(userTemp => userTemp.Id == id).FirstOrDefault();

            if(user != null)
            {
                dataContext.Users.Remove(user);
                dataContext.SaveChanges();
            }

            return id;
        }
    }
}