namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Tests the features of the <see cref="Api"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class ApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly Api client =
		new Client(Environment.GetEnvironmentVariable("AGICAP_CLIENT_ID")!, Environment.GetEnvironmentVariable("AGICAP_CLIENT_SECRET")!).Organizations;

	[TestMethod]
	public async Task GetEntities() {
		var entityId = int.Parse(Environment.GetEnvironmentVariable("AGICAP_ENTITY")!);
		var organizationId = Guid.Parse(Environment.GetEnvironmentVariable("AGICAP_ORGANIZATION")!);

		var list = await client.GetEntitiesAsync(organizationId, cancellationToken: testContext.CancellationToken);
		IsGreaterThanOrEqualTo(1, list.Items.Count);
		AreEqual(list.Items.Count, list.Pagination.TotalItemsCount);

		var entity = list.Items.Single(item => item.Id == entityId);
		AreEqual("FR", entity.Country);
		AreEqual("MC2IT", entity.Name);
	}

	[TestMethod]
	public async Task GetOrganizations() {
		var organizationId = Guid.Parse(Environment.GetEnvironmentVariable("AGICAP_ORGANIZATION")!);

		var list = await client.GetOrganizationsAsync(cancellationToken: testContext.CancellationToken);
		HasCount(1, list.Items);
		AreEqual(list.Items.Count, list.Pagination.TotalItemsCount);

		var organization = list.Items.Single();
		AreEqual(organizationId, organization.Id);
		AreEqual("MC2IT", organization.Name);
	}
}
