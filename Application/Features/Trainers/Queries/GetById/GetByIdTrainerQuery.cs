using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Queries.GetById
{
    public class GetByIdTrainerQuery : IRequest<Response<TrainerDTO>>
    {
        public int Id { get; set; }
    }
}
