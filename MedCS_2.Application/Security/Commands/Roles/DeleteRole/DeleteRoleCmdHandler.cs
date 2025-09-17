using AutoMapper;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCS_2.Application.Security.Commands.Roles.DeleteRole
{
    public class DeleteRoleCmdHandler : IRequestHandler<DeleteRoleCmd, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteRoleCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(DeleteRoleCmd request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(request.RoleId);
            if (role == null)
            {
                return Response<bool>.Fail("Role not found.", 404);
            }
            await _unitOfWork.Roles.DeleteAsync(role);
            await _unitOfWork.Roles.SaveChangesAsync(cancellationToken);
            return Response<bool>.Success(true, "Role deleted successfully.");
        }
    }
}
