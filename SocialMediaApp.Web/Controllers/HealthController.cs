using Microsoft.AspNetCore.Mvc;
namespace SocialMediaApp.Web.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealthStatus() => Ok(
            new
            {
                status = "Healthy",
                timestamp = DateTime.UtcNow
            });
    }
}
