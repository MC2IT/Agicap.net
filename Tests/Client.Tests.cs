namespace Mc2it.Agicap;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class ClientTests(TestContext testContext) {

	[TestMethod]
	public async Task Authenticate() {
		// It should return a new access token.
		var client = Fixtures.CreateClient();
		IsFalse(client.IsAuthenticated);

		var scopes = new[] { "agicap:public-api", "public-api:manage-payment-beneficiaries", "public-api:manage-suppliers" };
		var accessToken = await client.AuthenticateAsync(scopes, testContext.CancellationToken);
		IsTrue(client.IsAuthenticated);
		IsFalse(accessToken.HasExpired);
		AreSequenceEqual(scopes, accessToken.Scopes);
		AreEqual("Bearer", accessToken.Type);
		MatchesRegex(@"^[A-Z\d]{64,}", accessToken.Value);

		// It should throw an exception when the credentials are invalid.
		client = new Client("FooBar", "BazQux");
		await ThrowsAsync<HttpRequestException>(() => client.AuthenticateAsync(cancellationToken: testContext.CancellationToken));
	}
}
