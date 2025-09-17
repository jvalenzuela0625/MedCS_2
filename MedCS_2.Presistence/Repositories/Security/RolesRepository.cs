using MedCS_2.Domain.Security;
using MedCS_2.Presistence.DbContext;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Presistence.Repositories.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCS_2.Presistence.Repositories.Security
{
    public class RolesRepository : GenericRepository<Roles>, IRolesRepository
    {
        private readonly MedCSAppDbContext _context;
        public RolesRepository(MedCSAppDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves a role by its ID, including its associated permissions.
        // - Uses Entity Framework's Include and ThenInclude to eagerly load related entities:
        //   - Includes RolePermissions navigation property from Roles.
        //   - Then includes the Permission navigation property from RolePermissions.
        // - Returns the first role that matches the given roleId, or null if not found.
        // - Supports cancellation via the provided CancellationToken.
        public async Task<Roles?> GetByIdWithPermissionsAsync(int roleId, CancellationToken cancellationToken = default)
        {
            return await _context.Roles
                .Include(r => r.RolePermissions) // Load RolePermissions for the role
                .ThenInclude(rp => rp.Permission) // For each RolePermission, load its Permission
                .FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken); // Find the role by ID
        }

        // Retrieves all roles from the database, including their associated permissions.
        // - Uses Entity Framework's Include and ThenInclude to eagerly load related entities:
        //   - Includes the RolePermissions navigation property from Roles.
        //   - Then includes the Permission navigation property from each RolePermission.
        // - Returns a list of all roles, each with its permissions loaded.
        // - Supports cancellation via the provided CancellationToken.
        public async Task<List<Roles>> GetAllWithPermissionsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Roles
                .Include(r => r.RolePermissions) // Load RolePermissions for each role
                .ThenInclude(rp => rp.Permission) // For each RolePermission, load its Permission
                .ToListAsync(cancellationToken); // Return all roles as a list
        }
    }
}
