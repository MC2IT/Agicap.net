namespace Mc2it.Agicap.Payments;

/// <summary>
/// Tests the features of the <see cref="OrganizationApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class OrganizationApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly BeneficiaryApi api = Fixtures.CreateClient().Payments.Beneficiaries(Fixtures.EntityId);

	[TestMethod]
	public async Task ReadAll() {
		var list = await api.ReadAllAsync(cancellationToken: testContext.CancellationToken);
		IsGreaterThan(1, list.Count);

		var beneficiary = list.Single(item => item.Name.StartsWith("Agicap", StringComparison.InvariantCultureIgnoreCase));
		IsNotNull(beneficiary.PostalAddress);
		AreEqual("Lyon", beneficiary.PostalAddress.City, ignoreCase: true);
		AreEqual("FR", beneficiary.PostalAddress.Country);
	}
}
