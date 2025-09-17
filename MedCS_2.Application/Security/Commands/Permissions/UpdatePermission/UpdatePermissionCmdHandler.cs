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

namespace MedCS_2.Application.Security.Commands.Permissions.UpdatePermission
{
    public class UpdatePermissionCmdHandler:IRequestHandler<UpdatePermissionCmd, Response<PermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdatePermissionCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<PermissionDto>> Handle(UpdatePermissionCmd request, CancellationToken cancellationToken)
        {
            var permission = await _unitOfWork.Permissions.GetByIdAsync(request.UpdatePermissionDto.Id);
            if (permission is null)
                return Response<PermissionDto>.Fail("Permission not found.", 404);
            //map the updated fields from the dto to the entity
            _mapper.Map(request.UpdatePermissionDto, permission);
            await _unitOfWork.Permissions.UpdateAsync(permission);
            await _unitOfWork.Permissions.SaveChangesAsync(cancellationToken);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return Response<PermissionDto>.Success(permissionDto, "Permission updated successfully.", 200);
        }
    }
}
