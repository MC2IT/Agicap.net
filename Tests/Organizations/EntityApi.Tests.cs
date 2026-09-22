namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Tests the features of the <see cref="EntityApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class EntityApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly EntityApi api = Fixtures.CreateClient().Organizations.Entities(Fixtures.OrganizationId);

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(cancellationToken: testContext.CancellationToken);
		Assert.IsGreaterThanOrEqualTo(1, list.Items.Count);
		Assert.AreEqual(list.Items.Count, list.Pagination.TotalItemsCount);

		var entity = list.Items.Single(item => item.Id == Fixtures.EntityId);
		Assert.AreEqual("FR", entity.Country);
		Assert.AreEqual("MC2IT", entity.Name);
	}
}
