using Application.Features.DTOs;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Users.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<Response<UserDTO>>
    {
        public int Id { get; set; }
    }
}
