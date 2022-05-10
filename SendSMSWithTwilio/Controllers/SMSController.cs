using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendSMSWithTwilio.Services;

namespace SendSMSWithTwilio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public SMSController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("send")]
        public IActionResult send(SendSMS sendSMS)
        {
            var result = _smsService.sendSms(sendSMS.MobileNumber, sendSMS.Message);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }
    }
}
