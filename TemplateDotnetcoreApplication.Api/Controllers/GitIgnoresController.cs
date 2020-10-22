using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Services;

namespace TemplateDotnetcoreApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitIgnoresController : ControllerBase
    {
        private readonly IGitIgnoreService _gitIgnoreService;

        public GitIgnoresController(IGitIgnoreService gitIgnoreService)
        {
            _gitIgnoreService = gitIgnoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGitIgnories()
        {
            var result = await _gitIgnoreService.GetGitIgnories();
            return Ok(result);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetGitIgnorie(string key)
        {
            var result = await _gitIgnoreService.GetGitIgnorie(key);
            return Ok(result);
        }
    }
}
