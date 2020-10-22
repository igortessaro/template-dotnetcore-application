using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;
using TemplateDotnetcoreApplication.Domain.Gateways.GitLab;
using TemplateDotnetcoreApplication.Infrastructure.Gateways.Core;

namespace TemplateDotnetcoreApplication.Infrastructure.Gateways.GitLab
{
    public sealed class GitLabApi : GatewayService, IGitLabApi
    {
        public GitLabApi(HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var gitlabVersion = await this.GetVersion();
                Dictionary<string, object> result = new Dictionary<string, object>();
                result.Add(nameof(gitlabVersion.Version), gitlabVersion.Version);
                result.Add(nameof(gitlabVersion.Revision), gitlabVersion.Revision);
                return HealthCheckResult.Healthy($"{nameof(GitLabApi)} healthy.", result.ToImmutableDictionary());
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy($"{nameof(GitLabApi)} unhealthy.");
            }
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

        public async Task<GitLabVersionDto> GetVersion()
        {
            var result = await this.GetAsync<GitLabVersionDto>("version");
            return result;
        }
    }
}
