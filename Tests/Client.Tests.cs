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
		Assert.IsFalse(client.IsAuthenticated);

		var scopes = new[] { "agicap:public-api", "public-api:manage-payment-beneficiaries", "public-api:manage-suppliers" };
		var accessToken = await client.AuthenticateAsync(scopes, testContext.CancellationToken);
		Assert.IsTrue(client.IsAuthenticated);
		Assert.IsFalse(accessToken.HasExpired);
		Assert.AreSequenceEqual(scopes, accessToken.Scopes);
		Assert.AreEqual("Bearer", accessToken.Type);
		Assert.MatchesRegex(@"^[A-Z\d]{64,}", accessToken.Value);

		// It should throw an exception when the credentials are invalid.
		client = new Client("FooBar", "BazQux");
		await Assert.ThrowsAsync<HttpRequestException>(() => client.AuthenticateAsync(cancellationToken: testContext.CancellationToken));
	}
}
