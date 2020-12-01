using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Abonements.Commands.DeleteAbonementById
{
    public class DeleteAbonementByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
