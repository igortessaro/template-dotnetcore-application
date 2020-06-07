using System.Collections.Generic;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Dtos;
using template_dotnetcore_application.Domain.Gateways.GitLab;

namespace template_dotnetcore_application.Domain.Services
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
