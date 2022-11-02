using Microsoft.AspNetCore.Mvc;
using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace LoreStoreAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {

        private readonly IUserRepository _userRepo;

        public UserAuthController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUserByFirebaseId(string firebaseUserId)
        {
            User user = _userRepo.GetUserByFirebaseId(firebaseUserId);

            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

       

    }
}
