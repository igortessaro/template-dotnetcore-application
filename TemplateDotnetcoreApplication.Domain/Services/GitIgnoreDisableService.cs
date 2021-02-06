using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;

namespace TemplateDotnetcoreApplication.Domain.Services
{
    public sealed class GitIgnoreDisableService : IGitIgnoreService
    {
        private readonly ILogger<GitIgnoreDisableService> _logger;

        public GitIgnoreDisableService(ILogger<GitIgnoreDisableService> logger)
        {
            _logger = logger;
        }

        public Task<GitIgnoreContentDto> GetGitIgnorie(string key)
        {
            _logger.LogInformation("The GitIgnoreService has disabled.");
            _logger.LogInformation("Call {Method} with key {key}", nameof(GetGitIgnorie), key);
            GitIgnoreContentDto result = null;
            return Task.FromResult(result);
        }

        public Task<IList<GitIgnoreDto>> GetGitIgnories()
        {
            _logger.LogInformation("The GitIgnoreService has disabled.");
            _logger.LogInformation("Call {Method}", nameof(GetGitIgnories));
            IList<GitIgnoreDto> result = new List<GitIgnoreDto>();
            return Task.FromResult(result);
        }
    }
}
