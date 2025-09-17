using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Queries.Roles.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, Response<List<RoleDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<RoleDto>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var lstRoles = await _unitOfWork.Roles.GetAllAsync();
            if (lstRoles == null || !lstRoles.Any())
                return Response<List<RoleDto>>.Fail("No roles found.", 404);
            var lstRoleDto = _mapper.Map<List<RoleDto>>(lstRoles);
            return Response<List<RoleDto>>.Success(lstRoleDto, "Roles retrieved successfully.");
        }
    }
}
