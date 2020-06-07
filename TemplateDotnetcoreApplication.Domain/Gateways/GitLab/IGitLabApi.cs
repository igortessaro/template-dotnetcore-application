using System.Collections.Generic;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Dtos;

namespace template_dotnetcore_application.Domain.Gateways.GitLab
{
    public interface IGitLabApi
    {
        Task<YmlContentDto> GetCiYml(string key);
        Task<IList<YmlDto>> GetCiYmls();
        Task<GitIgnoreContentDto> GetGitIgnorie(string key);
        Task<IList<GitIgnoreDto>> GetGitIgnories();
    }
}
