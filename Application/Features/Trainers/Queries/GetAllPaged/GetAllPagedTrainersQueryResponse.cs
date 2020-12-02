﻿using Application.DTOs.Users;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Trainers.Queries.GetAllPaged
{
    public class GetAllPagedTrainersQueryResponse : BaseEntity
    {
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public bool CanBePersonal { get; set; }
    }
}