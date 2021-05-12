using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PersonalTrainings.Commands.Update
{
    public class UpdatePersonalTrainingCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int ClientId { get; set; }
        public int SportId { get; set; }
    }
}
