namespace MedCS_2.Application.Security.Commands.UserRoles.UpdateUserRole
{
    public class UpdateUserRoleDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedAt { get; set; }
    }
}
