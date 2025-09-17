using MedCS_2.Domain.Security;
using MedCS_2.Presistence.DbContext;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Presistence.Repositories.Security.Interfaces;

namespace MedCS_2.Presistence.Repositories.Security
{
    public class RolePermissionsRepository : GenericRepository<RolePermissions>, IRolePermissionsRepository
    {
        public RolePermissionsRepository(MedCSAppDbContext context) : base(context)
        {
            
        }
    }
}
