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

namespace MedCS_2.Application.Security.Queries.Permissions.GetAllPermissions
{
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, Response<List<PermissionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPermissionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<PermissionDto>>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var lstPermissions = await _unitOfWork.Permissions.GetAllAsync();
            if (lstPermissions == null || !lstPermissions.Any())
                return Response<List<PermissionDto>>.Fail("No permissions found.", 404);
            var lstPermissionDto = _mapper.Map<List<PermissionDto>>(lstPermissions);
            return Response<List<PermissionDto>>.Success(lstPermissionDto, "Permissions retrieved successfully.");
        }
    }
}
