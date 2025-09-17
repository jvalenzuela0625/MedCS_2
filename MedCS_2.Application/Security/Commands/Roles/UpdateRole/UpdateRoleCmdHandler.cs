using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.Roles.UpdateRole
{
    public class UpdateRoleCmdHandler : IRequestHandler<UpdateRoleCmd, Response<RoleDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateRoleCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<RoleDto>> Handle(UpdateRoleCmd request, CancellationToken cancellationToken)
        {
            var role =  await _unitOfWork.Roles.GetByIdAsync(request.UpdateRoleDto.Id);
            if (role == null)
                return Response<RoleDto>.Fail("Role not found", 404);

            _mapper.Map(request.UpdateRoleDto, role);

            await _unitOfWork.Roles.UpdateAsync(role);
            await _unitOfWork.SaveChangesAsync();

            var roleDto = _mapper.Map<RoleDto>(role);
            return Response<RoleDto>.Success(roleDto,"Role updated successfully", 404);
        }
    }
}
