using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Permission_APi.AttributeS;
using Permission_Application.Services.Teacher_S;
using Permission_Domen.Enums;
using VehicleManagement_Application.Dto_s;
using VehicleManagementAPI.Extentions;

namespace Permission_APi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IServiceStudent _serviceTransport;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(IWebHostEnvironment webHostEnvironment, IServiceStudent serviceTeacher)
        {
            _webHostEnvironment = webHostEnvironment;
            _serviceTransport = serviceTeacher;
        }

        [FilterAttribute(Permissitions.GetAllStudents)]
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _serviceTransport.GetAllAsync());

        [FilterAttribute(Permissitions.GetStudenttById)]
        [HttpGet]
        public async Task<IActionResult> GetById(int id) => Ok(await _serviceTransport.GetById(id));

        [FilterAttribute(Permissitions.CreateStudent)]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentDto transportDto, IFormFile Imageurl)
        {
            var Extention = new MetodExtention(_webHostEnvironment);
            var picturepath = await Extention.AddPictureAndGetPath(Imageurl);
            var result = await _serviceTransport.CreateAsync(transportDto, picturepath);
            return Ok(result);

        }
        [FilterAttribute(Permissitions.UpdateStudent)]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] StudentDto transportDto, IFormFile Imageurl)
        {
            var Extention = new MetodExtention(_webHostEnvironment);
            var picturepath = await Extention.AddPictureAndGetPath(Imageurl);
            var result = await _serviceTransport.UpdateAsync(id, transportDto, picturepath);
            return Ok(result);
        }

        [FilterAttribute(Permissitions.DeleteStudenent)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => Ok(await _serviceTransport.DeleteAsync(id));
    }
}
