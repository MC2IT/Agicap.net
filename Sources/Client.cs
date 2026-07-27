namespace Mc2it.Agicap;

using System.Diagnostics.CodeAnalysis;
using System.Net;

/// <summary>
/// TODO
/// </summary>
/// <param name="credential">The client identifier and secret.</param>
/// <param name="baseUrl">The base URL of the remote API endpoint.</param>
public class Client(NetworkCredential credential, Uri? baseUrl = null) {

	/// <summary>
	/// The assembly version.
	/// </summary>
	private static Version Version => typeof(Client).Assembly.GetName().Version!;

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
}
