namespace Mc2it.Agicap.Authentication;

using System.Text.Json;

/// <summary>
/// Tests the features of the <see cref="AccessToken"/> class.
/// </summary>
[TestClass]
public sealed class AccessTokenTests {

	[TestMethod]
	public void FromJson() {
		var json = File.ReadAllText(Path.Join(AppContext.BaseDirectory, "../Resources/Authentication/AccessToken.json"));
		var accessToken = JsonSerializer.Deserialize<AccessToken>(json, JsonSerializerOptions.Web)!;
		IsFalse(accessToken.HasExpired);
		AreSequenceEqual(["agicap:public-api", "public-api:import_payment_files", "public-api:manage-payment-beneficiaries"], accessToken.Scopes);
		AreEqual("OAuth", accessToken.Type);
		AreEqual("a1704b4b-7662-432e-a68e-77f414fb836c", accessToken.Value);
	}
}
