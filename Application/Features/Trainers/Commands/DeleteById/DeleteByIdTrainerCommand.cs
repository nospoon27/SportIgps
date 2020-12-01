using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Commands.DeleteById
{
    public class DeleteByIdTrainerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
