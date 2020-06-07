using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Services;

namespace template_dotnetcore_application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiYmlsController : ControllerBase
    {
        private readonly ICiYmlService _ciYmlService;

        public CiYmlsController(ICiYmlService ciYmlService)
        {
            _ciYmlService = ciYmlService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCiYmls()
        {
            var result = await _ciYmlService.GetCiYmls();
            return Ok(result);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetCiYml(string key)
        {
            var result = await _ciYmlService.GetCiYml(key);

            return Ok(result);
        }
    }
}
