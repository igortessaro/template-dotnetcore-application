using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateDotnetcoreApplication.Domain.Dtos;

namespace TemplateDotnetcoreApplication.Domain.Services
{
    public interface IGitIgnoreService : IService
    {
        public Task<IList<GitIgnoreDto>> GetGitIgnories();
        public Task<GitIgnoreContentDto> GetGitIgnorie(string key);
    }
}
