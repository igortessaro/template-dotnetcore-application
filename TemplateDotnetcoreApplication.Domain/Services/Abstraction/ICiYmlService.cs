using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;

namespace TemplateDotnetcoreApplication.Domain.Services
{
    public interface ICiYmlService : IService
    {
        public Task<IList<YmlDto>> GetCiYmls();
        public Task<YmlContentDto> GetCiYml(string key);
    }
}
