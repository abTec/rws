using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IFileProcessor
    {
        Task<(string content, string customer)> ProcessFileAsync(IFormFile file, string customer);
    }
}
