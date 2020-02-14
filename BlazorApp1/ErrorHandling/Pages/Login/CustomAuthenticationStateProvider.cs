using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ErrorHandling
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		#region Publics
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{

			ClaimsIdentity identity = new ClaimsIdentity();

			ClaimsPrincipal user = new ClaimsPrincipal(identity);

			return await Task.FromResult(new AuthenticationState(user));
		}

		public void MarkUserAsAuthenticated(string emailAddress)
		{
			ClaimsIdentity identity = new ClaimsIdentity(new[]
			                                             {
				                                             new Claim(ClaimTypes.Name, emailAddress)
			                                             }, "apiauth_type");

			ClaimsPrincipal user = new ClaimsPrincipal(identity);

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		}

		public void MarkUserAsLoggedOut()
		{
			ClaimsIdentity identity = new ClaimsIdentity();

			ClaimsPrincipal user = new ClaimsPrincipal(identity);

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		}
		#endregion
	}
}