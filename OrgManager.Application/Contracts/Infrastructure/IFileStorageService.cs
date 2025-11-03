using System.IO;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Infrastructure;

public interface IFileStorageService
{
    Task<string> UploadAsync(Stream fileStream, string fileName);
}
