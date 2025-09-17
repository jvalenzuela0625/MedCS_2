using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.UserRoles.CreateUserRole
{
    public class CreateUserRoleCmdHandler : IRequestHandler<CreateUserRoleCmd, Response<UserRoleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserRoleCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserRoleDto>> Handle(CreateUserRoleCmd request, CancellationToken cancellationToken)
        {
            var userRoleEntity = _mapper.Map<MedCS_2.Domain.Security.UserRoles>(request.CreateUsrRoleDto);
            userRoleEntity.AssignedAt = DateTime.UtcNow;

            await _unitOfWork.UserRoles.AddAsync(userRoleEntity);
            await _unitOfWork.UserRoles.SaveChangesAsync(cancellationToken);

            var userRoleDto = _mapper.Map<UserRoleDto>(userRoleEntity);

            return Response<UserRoleDto>.Success(userRoleDto,"User role created successfully");

        }
    }
}
