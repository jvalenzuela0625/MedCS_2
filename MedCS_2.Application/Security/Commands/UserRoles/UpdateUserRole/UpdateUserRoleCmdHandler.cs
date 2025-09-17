using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.UserRoles.UpdateUserRole
{
    public class UpdateUserRoleCmdHandler : IRequestHandler<UpdateUserRoleCmd, Response<UserRoleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserRoleCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserRoleDto>> Handle(UpdateUserRoleCmd request, CancellationToken cancellationToken)
        {
            var usrRoleEntity = await _unitOfWork.UserRoles.GetByGuidIdAsync(request.UserRoleDto.Id);
            if (usrRoleEntity == null)
                return Response<UserRoleDto>.Fail("User role not found", 404);

            _mapper.Map(request.UserRoleDto, usrRoleEntity);

            await _unitOfWork.UserRoles.UpdateAsync(usrRoleEntity);
            await _unitOfWork.UserRoles.SaveChangesAsync(cancellationToken);

            var usrRoleDto = _mapper.Map<UserRoleDto>(usrRoleEntity);

            return Response<UserRoleDto>.Success(usrRoleDto, "User role updated successfully");
        }
    }
}
