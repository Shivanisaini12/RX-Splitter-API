using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Service_Layer.ICustomServices;
using WebAPI.Exceptions;

namespace WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService _userService;
        public UserDetailController(IUserDetailService userService)
        {
            _userService = userService;
        }
        
        [HttpGet(nameof(GetStudentById))]
        public IActionResult GetStudentById(int Id)
        {
            var obj = _userService.Get(Id);
            if (obj == null)
            {
                return NotFound($"The User Data with this ID {Id} not found in the system.");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        {
            var obj = _userService.GetAll();
            if (obj == null)
            {
                return NotFound($"The User Data not found in the system.");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateStudent))]
        public IActionResult CreateStudent(UserDetail student)
        {
            if (student != null)
            {
                _userService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                throw new BadRequestException($"The User Data given by you is totally empty..");
            }
        }
        [HttpPost(nameof(UpdateStudent))]
        public IActionResult UpdateStudent(UserDetail student)
        {
            if (student != null)
            {
                _userService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                throw new BadRequestException($"The User Data given by you is totally empty..");
            }
        }
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(UserDetail student)
        {
            if (student != null)
            {
                _userService.Delete(student);
                return Ok("Deleted Successfully");
            }
            else
            {
                throw new BadRequestException($"The User Data given by you is totally empty..");
            }
        }
    }
}
