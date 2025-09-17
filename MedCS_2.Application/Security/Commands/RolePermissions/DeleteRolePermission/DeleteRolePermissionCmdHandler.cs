using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.RolePermissions.DeleteRolePermission
{
    public class DeleteRolePermissionCmdHandler : IRequestHandler<DeleteRolePermissionCmd, Response<RolePermissionDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRolePermissionCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<RolePermissionDto>> Handle(DeleteRolePermissionCmd request, CancellationToken cancellationToken)
        {
            var rolePermissionEntity = await _unitOfWork.RolePermissions.GetByIdAsync(request.RolePermissionId);

            if (rolePermissionEntity is null)
                return Response<RolePermissionDto>.Fail("Role permission not found", 404);

            var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermissionEntity);

            await _unitOfWork.RolePermissions.DeleteAsync(rolePermissionEntity);
            await _unitOfWork.RolePermissions.SaveChangesAsync(cancellationToken);

            return Response<RolePermissionDto>.Success(rolePermissionDto, "Role permission successfully removed");
        }
    }
}
