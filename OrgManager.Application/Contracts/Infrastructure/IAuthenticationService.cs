using OrgManager.Core.Domain.Entities;
using System.Threading.Tasks;

namespace OrgManager.Application.Contracts.Infrastructure;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(User user, string password);
}
