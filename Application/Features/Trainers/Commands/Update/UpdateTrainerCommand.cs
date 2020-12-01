using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Commands.Update
{
    public class UpdateTrainerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool CanBePersonal { get; set; }
    }
}
