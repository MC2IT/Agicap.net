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

		Assert.IsFalse(accessToken.HasExpired);
		Assert.AreSequenceEqual([Scopes.PublicApi, Scopes.ImportPaymentFiles, Scopes.ManagePaymentBeneficiaries], accessToken.Scopes);
		Assert.AreEqual("OAuth", accessToken.Type);
		Assert.AreEqual("a1704b4b-7662-432e-a68e-77f414fb836c", accessToken.Value);
	}
}
