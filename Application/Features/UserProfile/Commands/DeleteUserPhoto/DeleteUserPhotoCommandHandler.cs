using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserProfile.Commands.DeleteUserPhoto
{
    public class DeleteUserPhotoCommandHandler : IRequestHandler<DeleteUserPhotoCommand, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        public DeleteUserPhotoCommandHandler(
            IUnitOfWork unitOfWork,
            IAuthenticatedUserService authenticatedUserService)
        {
            _unitOfWork = unitOfWork;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<Response<bool>> Handle(DeleteUserPhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.GetRepository<User>().FindAsync(
                _authenticatedUserService.GetRequiredUserId(), cancellationToken);

            user.ChangeUserPhoto(null);
            await _unitOfWork.SaveChangesAsync();

            return new Response<bool>(true);
        }
    }
}
