using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok();
        }
    }
}