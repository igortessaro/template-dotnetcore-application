using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;

namespace TemplateDotnetcoreApplication.Domain.Gateways.GitLab
{
    public interface IGitLabApi: IHealthCheck
    {
        Task<YmlContentDto> GetCiYml(string key);
        Task<IList<YmlDto>> GetCiYmls();
        Task<GitIgnoreContentDto> GetGitIgnorie(string key);
        Task<IList<GitIgnoreDto>> GetGitIgnories();
    }
}
