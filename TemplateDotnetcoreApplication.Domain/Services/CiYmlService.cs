using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;
using TemplateDotnetcoreApplication.Domain.Gateways.GitLab;

namespace TemplateDotnetcoreApplication.Domain.Services
{
    public sealed class CiYmlService : ICiYmlService
    {
        private readonly IGitLabApi _gitLabApi;

        public CiYmlService(IGitLabApi gitLabApi)
        {
            _gitLabApi = gitLabApi;
        }

        public async Task<YmlContentDto> GetCiYml(string key)
        {
            var result = await _gitLabApi.GetCiYml(key);
            return result;
        }

        public async Task<IList<YmlDto>> GetCiYmls()
        {
            var result = await _gitLabApi.GetCiYmls();
            return result;
        }
    }
}
