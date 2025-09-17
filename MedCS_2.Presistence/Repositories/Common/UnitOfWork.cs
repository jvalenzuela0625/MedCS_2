using MedCS_2.Domain.Security;
using MedCS_2.Presistence.DbContext;
using MedCS_2.Presistence.Repositories.Security;
using MedCS_2.Presistence.Repositories.Security.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MedCS_2.Presistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedCSAppDbContext _context;

        public UnitOfWork(MedCSAppDbContext context)
        {
            _context = context;           
        }

        public IUsersRepository Users => new UsersRepository(_context);
        public IRolesRepository Roles  => new RolesRepository(_context);
        public IPermissionsRepository Permissions => new PermissionsRepository(_context);
        public IUserRolesRepository UserRoles => new UserRolesRepository(_context);
        public IRolePermissionsRepository RolePermissions => new RolePermissionsRepository(_context);

        public async Task<int> SaveChangesAsync() { return await _context.SaveChangesAsync(); }
        public void Dispose() 
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
