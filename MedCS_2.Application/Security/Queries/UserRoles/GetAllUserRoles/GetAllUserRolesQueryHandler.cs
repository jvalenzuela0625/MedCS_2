using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Queries.UserRoles.GetAllUserRoles
{
    public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, Response<List<UserRoleDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<UserRoleDto>>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
        {
            var userRoles = await _unitOfWork.UserRoles.GetAllAsync();
            if(userRoles is null || userRoles.Any())
                return Response<List<UserRoleDto>>.Fail("No user roles found", 404);
            var lstUsrRoleDto = _mapper.Map<List<UserRoleDto>>(userRoles);
            return Response<List<UserRoleDto>>.Success(lstUsrRoleDto, "User roles retrieved successfully");
        }
    }
}