namespace Mc2it.Agicap.Payments;

/// <summary>
/// Tests the features of the <see cref="BeneficiaryApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class BeneficiaryApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly BeneficiaryApi api = Fixtures.CreateClient().Payments.Beneficiaries(Fixtures.EntityId);

	[TestMethod]
	public async Task CreateUpdateDelete() {
		var beneficiary = new Beneficiary {
			Name = "MC2IT Service Développement",
			PostalAddress = new() { City = "Fabrègues", Country = "FR", StreetName = "Rue Gine" }
		};

		AreEqual(Guid.Empty, beneficiary.Id);
		await api.CreateAsync(beneficiary, testContext.CancellationToken);
		AreNotEqual(Guid.Empty, beneficiary.Id);

		beneficiary.PostalAddress.Number = "29";
		beneficiary.PostalAddress.ZipCode = "34690";
		await api.UpdateAsync(beneficiary, testContext.CancellationToken);
		await api.DeleteAsync(beneficiary, testContext.CancellationToken);
	}

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
