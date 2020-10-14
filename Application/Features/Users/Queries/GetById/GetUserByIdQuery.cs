using Application.Wrappers;
using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
    }
}
