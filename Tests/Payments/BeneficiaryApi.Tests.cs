namespace Mc2it.Agicap.Payments;

using System.Net;

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
			Name = "MC2IT Test Runner",
			PostalAddress = new() { City = "Fabrègues", Country = "FR", StreetName = "Rue Gine" }
		};

		// It should create the specified beneficiary.
		AreEqual(Guid.Empty, beneficiary.Id);
		await api.CreateAsync(beneficiary, testContext.CancellationToken);
		AreNotEqual(Guid.Empty, beneficiary.Id);

		// It should throw an exception if the beneficiary already exists.
		try {
			await api.CreateAsync(beneficiary, testContext.CancellationToken);
			Fail("The exception was not thrown as planned.");
		}
		catch (HttpResponseException e) {
			AreEqual(HttpStatusCode.Conflict, e.StatusCode);
			MatchesRegex("beneficiary.*MC2IT.*exists", e.ProblemDetails?.Title);
		}

		// It should update the specified beneficiary.
		beneficiary.PostalAddress.Number = "29";
		beneficiary.PostalAddress.ZipCode = "34690";
		await api.UpdateAsync(beneficiary, testContext.CancellationToken);

		// It should delete the specified beneficiary.
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
