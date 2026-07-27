namespace Mc2it.Agicap;

using Mc2it.Agicap.Authentication;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Json;

/// <summary>
/// TODO
/// </summary>
/// <param name="credential">The client identifier and secret.</param>
/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
public class Client(NetworkCredential credential, Uri? baseUrl = null) /* TODO IDisposable !!! */ {

	/// <summary>
	/// The assembly version.
	/// </summary>
	private static Version Version => typeof(Client).Assembly.GetName().Version!;

	/// <summary>
	/// The access token.
	/// </summary>
	internal AccessToken AccessToken { get; private set; } = new();

	/// <summary>
	/// The base URL of the remote API endpoint.
	/// </summary>
	public Uri BaseUrl { get; set; } = baseUrl ?? new Uri("https://api.agicap.com/public/");

	/// <summary>
	/// The client identifier and secret.
	/// </summary>
	public NetworkCredential Credential => credential;

	/// <summary>
	/// The user agent string to use when making requests.
	/// </summary>
	public string UserAgent { get; set; } = $".NET/{Environment.Version} | Mc2it.Agicap/{Version.ToString(3)}";

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="credential">The client identifier and secret.</param>
	/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
	public Client(NetworkCredential credential, [StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl):
		this(credential, new Uri(baseUrl, UriKind.Absolute)) { }

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="clientId">The client identifier.</param>
	/// <param name="clientSecret">The client secret.</param>
	/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
	public Client(string clientId, string clientSecret, Uri? baseUrl = null):
		this(new NetworkCredential(clientId, clientSecret), baseUrl) {}

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="clientId">The client identifier.</param>
	/// <param name="clientSecret">The client secret.</param>
	/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
	public Client(string clientId, string clientSecret, [StringSyntax(StringSyntaxAttribute.Uri)] string baseUrl):
		this(new NetworkCredential(clientId, clientSecret), new Uri(baseUrl, UriKind.Absolute)) {}

	/// <summary>
	/// TODO
	/// </summary>
	/// <returns>The generated access token.</param>
	public AccessToken Authenticate(IEnumerable<string>? scopes = null, CancellationToken cancellationToken = default) =>
		AuthenticateAsync(scopes, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// TODO
	/// </summary>
	/// <returns>The generated access token.</param>
	public async Task<AccessToken> AuthenticateAsync(IEnumerable<string>? scopes = null, CancellationToken cancellationToken = default) {
		using var httpClient = GetHttpClient();
		using var httpContent = new FormUrlEncodedContent(new Dictionary<string, string> {
			["client_id"] = Credential.UserName,
			["client_secret"] = Credential.Password,
			["grant_type"] = "client_credentials",
			["scope"] = string.Join(' ', scopes ?? ["agicap:public-api"])
		});

		using var response = await httpClient.PostAsync(new Uri(BaseUrl, "auth/v1/token"), httpContent, cancellationToken);
		response.EnsureSuccessStatusCode();
		return AccessToken = (await response.Content.ReadFromJsonAsync<AccessToken>(cancellationToken))!;
	}

	/// <summary>
	/// TODO
	/// </summary>
	/// <returns>The newly created HTTP client.</returns>
	internal HttpClient GetHttpClient() {
		var httpClient = new HttpClient();
		httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
		return httpClient;
	}
}
