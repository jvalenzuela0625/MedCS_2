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

namespace MedCS_2.Application.Security.Commands.Users.UpdateUser
{
    public class UpdateUserCmdHandler : IRequestHandler<UpdateUserCmd, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> Handle(UpdateUserCmd request, CancellationToken cancellationToken)
        {
            var userEntity = await _unitOfWork.Users.GetByGuidIdAsync(request.updateUserDto.Id);
            if (userEntity is null)
                return Response<UserDto>.Fail("User not found", 404);

            //use automapper to update the entity
            _mapper.Map(request.updateUserDto, userEntity);

            await _unitOfWork.Users.UpdateAsync(userEntity);
            await _unitOfWork.Users.SaveChangesAsync(cancellationToken);

            var updatedUser = _mapper.Map<UserDto>(userEntity);
            return Response<UserDto>.Success(updatedUser,"User updated successfully");
        }
    }
}
