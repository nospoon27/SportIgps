﻿using Application.DTOs.Account;
using Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<AuthenticationResponse>> RefreshToken(string cookieRefreshToken, string ipAddress);
        Task<bool> RevokeToken(string token, string ipAddress);
    }
}
