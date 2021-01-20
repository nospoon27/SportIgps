﻿using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Queries.GetAllFiles
{
    public class GetAllFilesRequest : IRequest<Response<IList<GetAllFilesResponse>>>
    {
        public bool WithDeleted { get; set; }
    }
}
