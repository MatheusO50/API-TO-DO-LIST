using Microsoft.AspNetCore.Mvc;
using To_Do_List.DTO;
using To_Do_List.Models;
using To_Do_List.Service;

namespace To_Do_List.Controller
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userservice;
        public UserController(UserService userService) {_userservice = userService;}
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