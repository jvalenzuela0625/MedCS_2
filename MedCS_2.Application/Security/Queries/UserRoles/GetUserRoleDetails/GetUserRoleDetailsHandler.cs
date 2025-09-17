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

namespace MedCS_2.Application.Security.Queries.UserRoles.GetUserRoleDetails
{
    public class GetUserRoleDetailsHandler : IRequestHandler<GetUserRoleDetailsQuery, Response<RolePermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserRoleDetailsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<RolePermissionDto>> Handle(GetUserRoleDetailsQuery request, CancellationToken cancellationToken)
        {
            var rolePermission = await _unitOfWork.RolePermissions.GetByIdAsync(request.UserRoleId);
            if(rolePermission is null)
                return Response<RolePermissionDto>.Fail("RolePermission not found", 404);

            var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermission);
            return Response<RolePermissionDto>.Success(rolePermissionDto, "Role permission retrieved successfully.");
        }
    }
}
