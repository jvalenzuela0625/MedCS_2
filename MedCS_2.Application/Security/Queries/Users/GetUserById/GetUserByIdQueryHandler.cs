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

namespace MedCS_2.Application.Security.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler :IRequestHandler<GetUserByIdQuery, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userEntity = await _unitOfWork.Users.GetByGuidIdAsync(request.UserId);
            if (userEntity is null)
                return Response<UserDto>.Fail("User not found", 404);

            var userDto = _mapper.Map<UserDto>(userEntity);
            return Response<UserDto>.Success(userDto, "User retrieved successfully.");
        }
    }
}
