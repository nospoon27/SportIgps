using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Locations.Commands.DeleteLocationById
{
    public class DeleteLocationByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
