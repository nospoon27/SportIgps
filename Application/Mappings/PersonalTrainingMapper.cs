using Application.Features.DTOs;
using Application.Features.PersonalTrainings.Commands.Create;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class PersonalTrainingMapper : GeneralProfile
    {
        public PersonalTrainingMapper()
        {
            CreateMap<PersonalTraining, PersonalTrainingDTO>();
            CreateMap<CreatePersonalTrainingCommand, PersonalTraining>();
        }
    }
}
