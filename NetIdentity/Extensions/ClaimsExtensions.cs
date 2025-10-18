using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using NetIdentity.Models;
using System.Security.Claims;

namespace NetIdentity.Extensions
{
    public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, 
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            
            // Agregar claim de género
            identity.AddClaim(new Claim("genero", user.genero ?? "O"));
            
            // Agregar claim de fecha de nacimiento
            identity.AddClaim(new Claim("FechaNacimiento", user.FechaNacimiento.ToString("yyyy-MM-dd")));
            
            return identity;
        }
    }
}