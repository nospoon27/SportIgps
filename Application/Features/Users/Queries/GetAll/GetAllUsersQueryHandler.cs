using Application.Features.Common;
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
    public class GetAllUsersQueryHandler : CommonHandler, IRequestHandler<GetAllUsersQuery, Response<IList<GetAllUsersResponse>>>
    {
        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<Response<IList<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var items = await _unitOfWork.GetRepository<User>().GetAllAsync();
            var mapped = _mapper.Map<IList<GetAllUsersResponse>>(items);
            return new Response<IList<GetAllUsersResponse>>(mapped);
        }
    }
}
