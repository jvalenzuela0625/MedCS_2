using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.UserRoles.DeleteUserRole
{
    public class DeleteUserRoleCmdHandler : IRequestHandler<DeleteUserRoleCmd, Response<UserRoleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteUserRoleCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserRoleDto>> Handle(DeleteUserRoleCmd request, CancellationToken cancellationToken)
        {
            var usrRoleEntity = await _unitOfWork.UserRoles.GetByGuidIdAsync(request.UserRoleId);
            if (usrRoleEntity == null)
                return Response<UserRoleDto>.Fail("User role not found", 404);

            var usrRoleDto = _mapper.Map<UserRoleDto>(usrRoleEntity);

            await _unitOfWork.UserRoles.DeleteAsync(usrRoleEntity);
            await _unitOfWork.UserRoles.SaveChangesAsync(cancellationToken);

            return Response<UserRoleDto>.Success(usrRoleDto, "User role deleted successfully", 200);
        }
    }
}
