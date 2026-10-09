namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Tests the features of the <see cref="OrganizationApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class OrganizationApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly OrganizationApi api = Fixtures.CreateClient().Organizations;

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(cancellationToken: testContext.CancellationToken);
		list.Items.Count.ShouldBe(1);
		list.Pagination.TotalItemsCount.ShouldBe(list.Items.Count);

		var organization = list.Items.Single();
		organization.Id.ShouldBe(Fixtures.OrganizationId);
		organization.Name.ShouldBe("MC2IT");
	}
}
