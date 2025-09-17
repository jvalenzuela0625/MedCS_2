using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.RolePermissions.CreateRolePermission
{
    public class CreateRolePermissionCmdHandler : IRequestHandler<CreateRolePermissionCmd, Response<RolePermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRolePermissionCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<RolePermissionDto>> Handle(CreateRolePermissionCmd request, CancellationToken cancellationToken)
        {
            var rolePermissionEntity = _mapper.Map<MedCS_2.Domain.Security.RolePermissions>(request.CreateRolePermissionDTO);

            rolePermissionEntity.Id = 0;
            rolePermissionEntity.Created = DateTime.UtcNow;

            await _unitOfWork.RolePermissions.AddAsync(rolePermissionEntity);
            await _unitOfWork.RolePermissions.SaveChangesAsync(cancellationToken);

            var rolePermissionDto = _mapper.Map<RolePermissionDto>(rolePermissionEntity);

            return Response<RolePermissionDto>.Success(rolePermissionDto," Role Permission created successfully.");

        }
    }
}
