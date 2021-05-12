using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainings.Commands.Delete
{
    public class DeletePersonalTrainingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
