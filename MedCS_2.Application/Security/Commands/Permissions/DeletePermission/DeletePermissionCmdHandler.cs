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

namespace MedCS_2.Application.Security.Commands.Permissions.DeletePermission
{
    public class DeletePermissionCmdHandler : IRequestHandler<DeletePermissionCmd, Response<PermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeletePermissionCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<PermissionDto>> Handle(DeletePermissionCmd request, CancellationToken cancellationToken)
        {
            var permission = await _unitOfWork.Permissions.GetByIdAsync(request.PermissionId);
            if (permission is null)
                return Response<PermissionDto>.Fail("Permission not found.", 404);

            //map the entity before deleting it in case EF detaches it after deletion
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            await _unitOfWork.Permissions.DeleteAsync(permission);
            await _unitOfWork.Permissions.SaveChangesAsync(cancellationToken);

            return Response<PermissionDto>.Success(permissionDto, "Permission deleted successfully.", 200);

        }
    }
}
