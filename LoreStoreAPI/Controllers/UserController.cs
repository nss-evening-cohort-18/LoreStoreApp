using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoreStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }


        // GET: api/<UserController>
        [HttpGet]
        public IActionResult  GetAllUsers()
        {
            List<User> users = _userRepo.GetUsers();

            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User user = _userRepo.GetUserById(id);

            if (user == null)
            {
                return NoContent();
            }
            return Ok(user); 
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _userRepo.AddUser(user);

            return Ok();

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,[FromBody] User user)
        {
             _userRepo.UpdateUser(id, user);

            if (user == null)
            {
                return NoContent();
            }

            return Ok();


        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);

            return Ok();
        }
    }
}
