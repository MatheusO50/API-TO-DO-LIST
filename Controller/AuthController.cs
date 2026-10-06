using Microsoft.AspNetCore.Mvc;
using To_Do_List.DTO;
using To_Do_List.Models;
using To_Do_List.Service;

namespace To_Do_List.Controller
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userservice;
        private readonly AuthService _authService;
        public AuthController(UserService userService , AuthService authService) 
        {
            _userservice = userService;
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            var response = _authService.LoginRequest(user);
            if(response == null) return Unauthorized("Invalid username or password");
            return Ok(response);
        }
        [HttpPost]
        public ActionResult<UserDto> PostUser(User new_user)
        {
            var user = _userservice.AddItem(new_user);
            return CreatedAtAction(nameof(GetUser),new{Id=user.Id},user);
        }
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(long id)
        {
            UserDto user = _userservice.GetItem(id);
            return Ok(user);
        }
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUser() => Ok(_userservice.GetAll());
        [HttpPut]
        public ActionResult PutUser(UserDto user) 
        {
            if(user is null) return BadRequest();
            _userservice.UpdateItem(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DelUser(long id) 
        {
            _userservice.RemoveItem(id);
            return NoContent();
        }
    }
}