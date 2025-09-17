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

namespace MedCS_2.Application.Security.Commands.Users.CreateUser
{
    public class CreateUserCmdHandler : IRequestHandler<CreateUserCmd, Response<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUserCmdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Response<UserDto>> Handle(CreateUserCmd request, CancellationToken cancellationToken)
        {
            //map DTO into entity
            var userEntity = _mapper.Map<MedCS_2.Domain.Security.Users>(request.User);
            userEntity.Id = Guid.NewGuid(); // Ensure a new ID is generated
            userEntity.Created = DateTime.UtcNow;

            await _unitOfWork.Users.AddAsync(userEntity);
            await _unitOfWork.Users.SaveChangesAsync(cancellationToken);

            var userdto = _mapper.Map<UserDto>(userEntity);
            return Response<UserDto>.Success(userdto, "User created successfully.",201);

        }
    }
}
