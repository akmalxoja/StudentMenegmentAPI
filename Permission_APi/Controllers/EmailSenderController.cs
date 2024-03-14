using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement_Application.Services.EmailSender;
using VehicleManagement_Domen.Entityes;

namespace VehicleManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IForgetEmail _forgetEmail;

        public EmailSenderController(IForgetEmail forgetEmail)
        {
            _forgetEmail = forgetEmail;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm]string model)
        {

            await _forgetEmail.SendEmailAsync(model);

            return Ok("Emailingizga Kod Jonatildi");
        }



    }
}
