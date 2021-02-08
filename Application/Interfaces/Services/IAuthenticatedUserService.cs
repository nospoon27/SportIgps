using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Services
{
    public interface IAuthenticatedUserService
    {
        int? UserId { get; }
        string RemoteIp { get; }

        int GetRequiredUserId();
    }
}
