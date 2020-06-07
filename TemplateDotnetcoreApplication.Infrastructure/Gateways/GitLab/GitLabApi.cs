using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Dtos;
using template_dotnetcore_application.Domain.Gateways.GitLab;
using template_dotnetcore_application.Infrastructure.Gateways.Core;

namespace template_dotnetcore_application.Infrastructure.Gateways.GitLab
{
    public sealed class GitLabApi : GatewayService, IGitLabApi
    {
        public GitLabApi(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<YmlContentDto> GetCiYml(string key)
        {
            var result = await GetAsync<YmlContentDto>($"templates/gitlab_ci_ymls/{key}");
            return result;
        }

        public async Task<IList<YmlDto>> GetCiYmls()
        {
            var result = await this.GetAsync<IList<YmlDto>>("templates/gitlab_ci_ymls");
            return result;
        }

        public async Task<GitIgnoreContentDto> GetGitIgnorie(string key)
        {
            var result = await this.GetAsync<GitIgnoreContentDto>($"templates/gitlab_ci_ymls/{key}");
            return result;
        }

        public async Task<IList<GitIgnoreDto>> GetGitIgnories()
        {
            var result = await this.GetAsync<IList<GitIgnoreDto>>("templates/gitignores");
            return result;
        }
    }
}
