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

namespace MedCS_2.Application.Security.Commands.Roles.CreateRole
{
    public class CreateRoleCmdHandler : IRequestHandler<CreateRoleCmd, Response<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoleCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<RoleDto>> Handle(CreateRoleCmd request, CancellationToken cancellationToken)
        {
            var roleEntity = _mapper.Map<MedCS_2.Domain.Security.Roles>(request.role);
            roleEntity.Id = 0;
            roleEntity.Created = DateTime.UtcNow;

            await _unitOfWork.Roles.AddAsync(roleEntity);
            await _unitOfWork.Roles.SaveChangesAsync(cancellationToken);

            var roleDto = _mapper.Map<RoleDto>(roleEntity);
            return Response<RoleDto>.Success(roleDto, "Role created successfully.",201);
        }
    }
}
