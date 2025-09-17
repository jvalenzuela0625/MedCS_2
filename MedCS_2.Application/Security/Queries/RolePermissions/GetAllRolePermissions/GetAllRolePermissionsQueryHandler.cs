using AutoMapper;
using FluentValidation.Internal;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Queries.RolePermissions.GetAllRolePermissions
{
    public class GetAllRolePermissionsQueryHandler : IRequestHandler<GetAllRolePermissionsQuery, Response<List<RolePermissionDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllRolePermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<RolePermissionDto>>> Handle(GetAllRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Roles.GetAllWithPermissionsAsync(cancellationToken);
            if(role == null || !role.Any())
                return Response<List<RolePermissionDto>>.Fail("No roles with permissions found.", 404);
                        
            var lstRolePermissionsDto = _mapper.Map<List<RolePermissionDto>>(role);

            return Response<List<RolePermissionDto>>.Success(lstRolePermissionsDto, "Role permissions retrieved successfully.");
        }
    }
}
