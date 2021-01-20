using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Queries.GetFileById
{
    public class GetFileByIdRequest : IRequest<Response<GetFileByIdResponse>>
    {
        public int Id { get; set; }
    }
}
