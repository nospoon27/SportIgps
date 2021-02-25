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
using Application.Features.DTOs;

namespace Application.Features.Users.Queries.GetAllPaged
{
    public class GetAllPagedUsersHandler : IRequestHandler<GetAllPagedUsersQuery, PagedResponse<IList<UserDTO>>>
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
        public async Task<PagedResponse<IList<UserDTO>>> Handle(GetAllPagedUsersQuery request, CancellationToken cancellationToken)
        {
            var users = (await _unitOfWork.GetRepository<User>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<UserDTO>(s),
                sieve: request)).ToPagedResponse();

            return users;
        }
    }
}

