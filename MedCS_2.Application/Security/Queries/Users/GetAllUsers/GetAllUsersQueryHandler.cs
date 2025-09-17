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

namespace MedCS_2.Application.Security.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<List<ListUserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<ListUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var lstUsers = await _unitOfWork.Users.GetAllAsync();
            if (lstUsers is null || !lstUsers.Any())
                return Response<List<ListUserDto>>.Fail("No users found.", 404);

            var lstUsersDto = _mapper.Map<List<ListUserDto>>(lstUsers);

            return Response<List<ListUserDto>>.Success(lstUsersDto, "Users retrieved successfully.");
        }
    }
}
