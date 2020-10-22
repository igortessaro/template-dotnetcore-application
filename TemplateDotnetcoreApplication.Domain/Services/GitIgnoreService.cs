using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;
using TemplateDotnetcoreApplication.Domain.Gateways.GitLab;

namespace TemplateDotnetcoreApplication.Domain.Services
{
    public sealed class GitIgnoreService : IGitIgnoreService
    {
        private readonly IGitLabApi _gitLabApi;

        public GitIgnoreService(IGitLabApi gitLabApi)
        {
            _gitLabApi = gitLabApi;
        }

        public async Task<GitIgnoreContentDto> GetGitIgnorie(string key)
        {
            var result = await _gitLabApi.GetGitIgnorie(key);
            return result;
        }

        public async Task<IList<GitIgnoreDto>> GetGitIgnories()
        {
            var result = await _gitLabApi.GetGitIgnories();
            return result;
        }
    }
}
