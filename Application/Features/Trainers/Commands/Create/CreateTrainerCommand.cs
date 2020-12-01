using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Commands.Create
{
    public class CreateTrainerCommand : IRequest<Response<int>>
    {
        public int UserId { get; set; }
        public bool CanBePersonal { get; set; }
    }
}
