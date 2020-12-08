using Application.Interfaces.UnitOfWork;
using Application.Parameters;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Interfaces.UnitOfWork.Sorting;

namespace Application.Features.Users.Queries.GetAllPaged
{
    public class GetAllPagedUsersHandler : IRequestHandler<GetAllPagedUsersQuery, PagedResponse<IList<GetAllPagedUsersResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllPagedUsersHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IList<GetAllPagedUsersResponse>>> Handle(GetAllPagedUsersQuery request, CancellationToken cancellationToken)
        {
            var users = (await _unitOfWork.GetRepository<User>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedUsersResponse>(s),
                sieve: request)).ToPagedResponse();

            return users;
        }
    }
}

