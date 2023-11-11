using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIurlshortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostUrl()
        {

            return Ok();
        }

    }
}
