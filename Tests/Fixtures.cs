namespace Mc2it.Agicap;

using Mc2it.Agicap.Authentication;

/// <summary>
/// Provides common objects for the API tests.
/// </summary>
public static class Fixtures {

	/// <summary>
	/// The identifier of the test entity.
	/// </summary>
	public static readonly int EntityId = int.Parse(Environment.GetEnvironmentVariable("AGICAP_ENTITY") ?? "000000");

	/// <summary>
	/// The identifier of the test organization.
	/// </summary>
	public static readonly Guid OrganizationId = Guid.Parse(Environment.GetEnvironmentVariable("AGICAP_ORGANIZATION") ?? "00000000-0000-0000-0000-000000000000");

	/// <summary>
	/// Creates a new API client for testing.
	/// </summary>
	/// <returns>The newly </returns>
	public static Client CreateClient() => new(
		Environment.GetEnvironmentVariable("AGICAP_CLIENT_ID") ?? "FooBar",
		Environment.GetEnvironmentVariable("AGICAP_CLIENT_SECRET") ?? "BazQux"
	) { DefaultScopes = Scopes.All };
}
