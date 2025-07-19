using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetSecret()
        {
            return Ok("You are authorized! Here's your protected data.");
        }
    }
}
