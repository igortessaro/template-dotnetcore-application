using System.Collections.Generic;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Dtos;
using template_dotnetcore_application.Domain.Gateways.GitLab;

namespace template_dotnetcore_application.Domain.Services
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
