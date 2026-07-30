namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Tests the features of the <see cref="OrganizationApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class OrganizationApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly OrganizationApi api = Fixtures.CreateClient().Organizations;

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(cancellationToken: testContext.CancellationToken);
		HasCount(1, list.Items);
		AreEqual(list.Items.Count, list.Pagination.TotalItemsCount);

		var organization = list.Items.Single();
		AreEqual(Fixtures.OrganizationId, organization.Id);
		AreEqual("MC2IT", organization.Name);
	}
}
