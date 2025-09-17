using MedCS_2.Domain.Common;


namespace MedCS_2.Domain.Security
{
    public class Permissions : BaseEntity<int>
    {
        public string Endpoint { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string OperationType { get; set; } = string.Empty;


        public ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();

    }
}
