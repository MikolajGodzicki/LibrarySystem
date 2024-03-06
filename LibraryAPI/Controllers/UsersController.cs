using LibraryAPI.Entities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }


        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            User? user = _userService.GetUser(id);

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
