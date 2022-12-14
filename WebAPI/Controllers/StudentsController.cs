using DomainLayer.Data;
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
    [ApiVersion("2.0")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICustomService<Student> _customService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IStringLocalizer<StudentsController> _stringLocalizer;
        public StudentsController(ICustomService<Student> customService, ApplicationDbContext applicationDbContext, IStringLocalizer<StudentsController> stringLocalizer)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
            _stringLocalizer = stringLocalizer;
        }
        //IOf you want to map each action to a specific version, you can use the attribute [MapToApiVersion] to control it.
        [MapToApiVersion("1.0")]
        [HttpGet]
        public string Get() => ".Net Core Web API Version 1";
        [HttpGet(nameof(GetStudentById))]
        public IActionResult GetStudentById(int Id)
        {
            var obj = _customService.Get(Id);
            if (obj == null)
            {
                return NotFound($"The Student Data with this ID {Id} not found in the system.");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound($"The Students Data not found in the system.");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateStudent))]
        public IActionResult CreateStudent(Student student)
        {
            if (student != null)
            {
                _customService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                throw new BadRequestException($"The Student Data given by you is totally empty..");
            }
        }
        [HttpPost(nameof(UpdateStudent))]
        public IActionResult UpdateStudent(Student student)
        {
            if (student != null)
            {
                _customService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                throw new BadRequestException($"The Student Data given by you is totally empty..");
            }
        }
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(Student student)
        {
            if (student != null)
            {
                _customService.Delete(student);
                return Ok("Deleted Successfully");
            }
            else
            {
                throw new BadRequestException($"The Student Data given by you is totally empty..");
            }
        }
    }
}
