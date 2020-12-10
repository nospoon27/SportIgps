using Application.DTOs.Users;
using Application.Extensions;
using Application.Features.Common;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.UnitOfWork.Sorting;
using Application.Parameters;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Trainers.Queries.GetAllPaged
{
    public class GetAllPagedTrainersHandler : CommonHandler, IRequestHandler<GetAllPagedTrainersQuery, PagedResponse<IList<GetAllPagedTrainersResponse>>>
    {
        public GetAllPagedTrainersHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PagedResponse<IList<GetAllPagedTrainersResponse>>> Handle(GetAllPagedTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = (await _unitOfWork.GetRepository<Trainer>().GetPagedListWithSieveAsync(
                selector: s => _mapper.Map<GetAllPagedTrainersResponse>(s),
                sieve: request,
                include: s => s.Include(x => x.User))).ToPagedResponse();
            //var trainers = (await _unitOfWork.GetRepository<Trainer>().GetPagedListWithSieveAsync(
            //   selector: s => new GetAllPagedTrainersResponse()
            //   {
            //       Id = s.Id,
            //       User = _mapper.Map<UserDTO>(s.User),
            //       UserId = s.UserId
            //   },
            //   sieve: request,
            //   include: s => s.Include(x => x.User))).ToPagedResponse();
            var test = await _unitOfWork.GetRepository<Trainer>().GetPagedListWithSieveAsync(
                selector: s=> s.User,
                sieve: request,
                include: s => s.Include(x => x.User));
            return trainers;
        }
    }
}
