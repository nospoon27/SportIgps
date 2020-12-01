using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Abonements.Commands.UpdateAbonement
{
    public class UpdateAbonementCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public bool IsChild { get; set; }
        public int AbonementLimitId { get; set; }
        public double Price { get; set; }
        public int WorkoutId { get; set; }
    }
}
