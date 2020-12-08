using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Sports.Commands.Create
{
    public class CreateSportCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
