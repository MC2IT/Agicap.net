namespace Mc2it.Agicap;

/// <summary>
/// Tests the features of the <see cref="Client"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class ClientTests(TestContext testContext) {

	[TestMethod]
	public async Task Authenticate() {
		// It should return a new access token.
		var client = Fixtures.CreateClient();
		client.IsAuthenticated.ShouldBeFalse();

		var scopes = new[] { "agicap:public-api", "public-api:manage-payment-beneficiaries", "public-api:manage-suppliers" };
		var accessToken = await client.AuthenticateAsync(scopes, testContext.CancellationToken);
		client.IsAuthenticated.ShouldBeTrue();
		accessToken.HasExpired.ShouldBeFalse();
		accessToken.Scopes.ShouldBe(scopes);
		accessToken.Type.ShouldBe("Bearer");
		accessToken.Value.ShouldMatch(@"^[A-Z\d]{64,}");

		// It should throw an exception when the credentials are invalid.
		client = new Client("FooBar", "BazQux");
		await Should.ThrowAsync<HttpRequestException>(() => client.AuthenticateAsync(cancellationToken: testContext.CancellationToken));
	}
}
