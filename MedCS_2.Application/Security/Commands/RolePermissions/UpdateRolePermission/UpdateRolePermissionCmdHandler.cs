using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.RolePermissions.UpdateRolePermission
{
    public class UpdateRolePermissionCmdHandler : IRequestHandler<UpdateRolePermissionCmd, Response<RolePermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRolePermissionCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<RolePermissionDto>> Handle(UpdateRolePermissionCmd request, CancellationToken cancellationToken)
        {
            var rolePermission = await _unitOfWork.RolePermissions.GetByIdAsync(request.RolePermissionDto.Id);
            if(rolePermission is null)
                return Response<RolePermissionDto>.Fail("Role Permission not found.", 404);

            _mapper.Map(request.RolePermissionDto, rolePermission);

            await _unitOfWork.RolePermissions.UpdateAsync(rolePermission);
            await _unitOfWork.RolePermissions.SaveChangesAsync(cancellationToken);

            var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermission);

            return Response<RolePermissionDto>.Success(rolePermissionDto, "Role Permission updated successfully.");
        }
    }
}
