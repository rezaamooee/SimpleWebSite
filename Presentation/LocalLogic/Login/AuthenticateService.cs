using Application.Interfaces.Contexts;
using Application.Interfaces.Services.User;
using Common.ViewModel.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Presentation.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.LocalLogic.Login
{
    public class AuthenticateService
    {
        private readonly IUserFacad _userFacad;

        public AuthenticateService( IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }
        public async Task<LoginResultDto> DoLogin(UserLoginVM UserLogin, CancellationToken CT)
        {
            var tryToLogin = await _userFacad.Get<UserAbsVM>(UserLogin, true,CT );
            if (tryToLogin.ResultObject != null &&
                tryToLogin.Messages.First().ServiceStatus == Common.Messages.ServiceStatus.OK)
            {
                var LoginResult = MakeCookie(tryToLogin.ResultObject);
                if (LoginResult.IsReadyToLogin == true)
                    return LoginResult;
            }
            return new LoginResultDto() { IsReadyToLogin = false, AuthenticationProperties = null, Principal = null };
        }
        public LoginResultDto MakeCookie(UserAbsVM UserLogin)
        {
            var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name , UserLogin.Name+ " "+ UserLogin.LastName),
                    new Claim (ClaimTypes.Role  , "rwx"),//User.UserRole.Permision.ToString()),
                    new Claim(ClaimTypes.NameIdentifier , UserLogin.Username),
                    new Claim(ClaimTypes.Authentication  , "true")
                };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(5),
            };
            var Principal = new ClaimsPrincipal(identity);
            return new LoginResultDto
            {
                AuthenticationProperties = authenticationProperties,
                Principal = Principal,
                IsReadyToLogin = true
            };
            //                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, Principal, authenticationProperties);
        }
    }
}
