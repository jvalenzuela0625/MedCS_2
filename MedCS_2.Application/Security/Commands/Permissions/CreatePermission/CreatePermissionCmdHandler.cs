using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.Permissions.CreatePermission
{
    public class CreatePermissionCmdHandler : IRequestHandler<CreatePermissionCmd, Response<PermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePermissionCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<PermissionDto>> Handle(CreatePermissionCmd request, CancellationToken cancellationToken)
        {
            var permission = _mapper.Map<MedCS_2.Domain.Security.Permissions>(request.CreatePermissionDto);
            permission.Id = 0;
            permission.Created = DateTime.UtcNow;

            await _unitOfWork.Permissions.AddAsync(permission);
            await _unitOfWork.Permissions.SaveChangesAsync(cancellationToken);

            var permissionDto = _mapper.Map<PermissionDto>(permission);

            return Response<PermissionDto>.Success(permissionDto, "Permission created successfully.");
        }
    }
}
