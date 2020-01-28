using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace CustomAuthen.Data
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		#region Fields
		private readonly ISessionStorageService _sessionStorageService;
		#endregion

		#region Constructors
		public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
		{
			_sessionStorageService = sessionStorageService;
		}
		#endregion

		#region Publics
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			string emailAddress = await _sessionStorageService.GetItemAsync<string>("emailAddress");
			ClaimsIdentity identity;

			if(emailAddress != null)
			{
				identity = new ClaimsIdentity(new[]
				                              {
					                              new Claim(ClaimTypes.Name, emailAddress)
				                              }, "apiauth_type");
			}
			else
			{
				identity = new ClaimsIdentity();
			}

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
			_sessionStorageService.RemoveItemAsync("emailAddress");

			ClaimsIdentity identity = new ClaimsIdentity();

			ClaimsPrincipal user = new ClaimsPrincipal(identity);

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
		}
		#endregion
	}
}