using System.Collections.Generic;
using System.Threading.Tasks;
using template_dotnetcore_application.Domain.Dtos;

namespace template_dotnetcore_application.Domain.Services
{
    public interface IGitIgnoreService : IService
    {
        public Task<IList<GitIgnoreDto>> GetGitIgnories();
        public Task<GitIgnoreContentDto> GetGitIgnorie(string key);
    }
}
