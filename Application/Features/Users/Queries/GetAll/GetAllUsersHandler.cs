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

namespace Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PagedResponse<IList<GetAllUsersResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IList<GetAllUsersResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new PagedRequest(request.PageNumber, request.PageSize);
            var users = (await _unitOfWork.GetRepository<User>()
                .GetPagedListAsync(
                selector: s => _mapper.Map<GetAllUsersResponse>(s),
                pageIndex: validFilter.PageNumber,
                pageSize: validFilter.PageSize)).ToPagedResponse();

            return users;
        }
    }
}

