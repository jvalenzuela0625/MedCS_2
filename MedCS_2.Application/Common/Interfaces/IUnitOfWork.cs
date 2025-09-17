using MedCS_2.Presistence.Repositories.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Presistence.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        IRolesRepository Roles { get; }
        IPermissionsRepository Permissions { get; }
        IUserRolesRepository UserRoles { get; }
        IRolePermissionsRepository RolePermissions { get; }

        Task<int> SaveChangesAsync();

    }
}
