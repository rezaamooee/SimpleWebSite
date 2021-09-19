using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Presentation.Models.Dtos
{
    public class LoginResultDto
    {
        public bool IsReadyToLogin { set; get; }
        public AuthenticationProperties AuthenticationProperties { set; get; }
        public ClaimsPrincipal Principal { set; get; }
    }
}
