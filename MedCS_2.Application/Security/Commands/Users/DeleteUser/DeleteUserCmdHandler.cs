using AutoMapper;
using MedCS_2.Application.Security.Dtos;
using MedCS_2.Presistence.Repositories.Common;
using MedCS_2.Shared.Responses;
using MediatR;

namespace MedCS_2.Application.Security.Commands.Users.DeleteUser
{
    public class DeleteUserCmdHandler : IRequestHandler<DeleteUserCmd, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteUserCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<UserDto>> Handle(DeleteUserCmd request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByGuidIdAsync(request.userId);
            if (user is null)            
                return Response<UserDto>.Fail("User not found.", 404);

            // map the entity before deleting it in case EF detaches it after deletion
            var userDto = _mapper.Map<UserDto>(user);

            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.Users.SaveChangesAsync(cancellationToken);
            
            return Response<UserDto>.Success(userDto, "User deleted successfully.",200);
        }
    }
}
