namespace Mc2it.Agicap.Organizations;

/// <summary>
/// Tests the features of the <see cref="EntityApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class EntityApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly EntityApi api = Fixtures.CreateClient().Organizations.Entities(Fixtures.OrganizationId);

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(cancellationToken: testContext.CancellationToken);
		list.Items.Count.ShouldBeGreaterThanOrEqualTo(1);
		list.Pagination.TotalItemsCount.ShouldBe(list.Items.Count);

		var entity = list.Items.Single(item => item.Id == Fixtures.EntityId);
		entity.Country.ShouldBe("FR");
		entity.Name.ShouldBe("MC2IT");
	}
}
