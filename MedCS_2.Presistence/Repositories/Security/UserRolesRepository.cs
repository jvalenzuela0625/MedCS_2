using MedCS_2.Domain.Security;
using MedCS_2.Presistence.DbContext;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Presistence.Repositories.Security.Interfaces;

namespace MedCS_2.Presistence.Repositories.Security
{
    public class UserRolesRepository :GenericRepository<UserRoles>, IUserRolesRepository
    {
        public UserRolesRepository(MedCSAppDbContext context) : base(context)
        {

        }
    }
}
