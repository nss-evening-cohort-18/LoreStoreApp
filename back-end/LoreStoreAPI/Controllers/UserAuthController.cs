using Microsoft.AspNetCore.Mvc;
using LoreStoreAPI.Models;
using LoreStoreAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using FirebaseAdmin.Auth;

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
        public async Task<IActionResult> EnsureUserExists(string firebaseUserId)
        {
            User user = _userRepo.GetUserByFirebaseId(firebaseUserId);

            var FbUser = await FirebaseAuth.DefaultInstance.GetUserAsync(firebaseUserId);
            if (user == null)
            {
                User newUser = new()
                {
                    FirebaseUserId = firebaseUserId,
                    Email = FbUser.Email,
                    UserTypeId = 1
                };
                _userRepo.AddUser(newUser);
                return Ok(newUser);
            }
            return Ok(user);
        }

       

    }
}
