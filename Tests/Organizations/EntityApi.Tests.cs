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
	private readonly EntityApi client =
		new Client(Environment.GetEnvironmentVariable("AGICAP_CLIENT_ID")!, Environment.GetEnvironmentVariable("AGICAP_CLIENT_SECRET")!)
			.Organizations.Entities(Guid.Parse(Environment.GetEnvironmentVariable("AGICAP_ORGANIZATION")!));

	[TestMethod]
	public async Task GetAll() {
		var entityId = int.Parse(Environment.GetEnvironmentVariable("AGICAP_ENTITY")!);

		var list = await client.GetAllAsync(cancellationToken: testContext.CancellationToken);
		IsGreaterThanOrEqualTo(1, list.Items.Count);
		AreEqual(list.Items.Count, list.Pagination.TotalItemsCount);

		var entity = list.Items.Single(item => item.Id == entityId);
		AreEqual("FR", entity.Country);
		AreEqual("MC2IT", entity.Name);
	}
}
