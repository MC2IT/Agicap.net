namespace Mc2it.Agicap;

using Mc2it.Agicap.Authentication;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class ClientTests(TestContext testContext) {

	[TestMethod]
	public async Task Authenticate() {
		// It should return a new access token.
		var client = new Client(Environment.GetEnvironmentVariable("AGICAP_CLIENT_ID")!, Environment.GetEnvironmentVariable("AGICAP_CLIENT_SECRET")!);
		IsFalse(client.IsAuthenticated);

		var accessToken = await client.AuthenticateAsync(Scopes.All, testContext.CancellationToken);
		IsTrue(client.IsAuthenticated);
		IsFalse(accessToken.HasExpired);
		AreSequenceEqual(Scopes.All, accessToken.Scopes);
		AreEqual("Bearer", accessToken.Type);
		MatchesRegex(@"^[A-Z\d]{64,}", accessToken.Value);

		// It should throw an exception when the credentials are invalid.
		client = new Client("FooBar", "BazQux");
		await ThrowsAsync<HttpRequestException>(() => client.AuthenticateAsync(cancellationToken: testContext.CancellationToken));
	}
}
