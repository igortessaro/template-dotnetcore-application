using System.Collections.Generic;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Dtos;

namespace template_dotnetcore_application.Domain.Services
{
    public interface ICiYmlService : IService
    {
        public Task<IList<YmlDto>> GetCiYmls();
        public Task<YmlContentDto> GetCiYml(string key);
    }
}
