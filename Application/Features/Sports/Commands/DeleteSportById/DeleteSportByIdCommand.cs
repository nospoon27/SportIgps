using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Commands.DeleteSportById
{
    public class DeleteSportByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
