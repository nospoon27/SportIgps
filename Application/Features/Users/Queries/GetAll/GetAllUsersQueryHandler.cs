using Application.Features.Common;
using Application.Features.DTOs;
using Application.Features.Locations.Queries.GetAll;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler : CommonHandler, IRequestHandler<GetAllUsersQuery, Response<IList<UserDTO>>>
    {
        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<UserDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<User>().GetAllAsync();
            var mapped = _mapper.Map<IList<UserDTO>>(items);
            return new Response<IList<UserDTO>>(mapped);
        }
    }
}
