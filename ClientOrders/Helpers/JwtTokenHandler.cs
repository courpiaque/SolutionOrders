using System.Net.Http.Headers;

namespace ClientOrders.Helpers;

// Simple handler used for adding bearer token to each http request
public class JwtTokenHandler : DelegatingHandler
{
	private readonly string _token;

	public JwtTokenHandler(string token)
	{
		_token = token;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		// Add the JWT token to the Authorization header
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

		// Call the inner handler
		return await base.SendAsync(request, cancellationToken);
	}
}
