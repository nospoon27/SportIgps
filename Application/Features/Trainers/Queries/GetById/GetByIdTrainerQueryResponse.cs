using Application.DTOs.Users;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Queries.GetById
{
    public class GetByIdTrainerQueryResponse : BaseEntity
    {
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public bool CanBePersonal { get; set; }
        public string FullName { get => $"{User.LastName} {User.FirstName} {User.MiddleName}"; }
    }
}
