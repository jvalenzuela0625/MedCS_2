using MedCS_2.Domain.Security;
using MedCS_2.Application.Common.Interfaces;

namespace MedCS_2.Presistence.Repositories.Security.Interfaces
{
    public interface IRolesRepository:IGenericRepository<Roles>
    {
        Task<Roles?> GetByIdWithPermissionsAsync(int roleId, CancellationToken cancellationToken = default);
        Task<List<Roles>> GetAllWithPermissionsAsync(CancellationToken cancellationToken = default);
    }
}
