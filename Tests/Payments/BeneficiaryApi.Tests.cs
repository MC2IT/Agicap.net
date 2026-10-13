namespace Mc2it.Agicap.Payments;

using System.Net;

/// <summary>
/// Tests the features of the <see cref="BeneficiaryApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class BeneficiaryApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly BeneficiaryApi api = Fixtures.CreateClient().Payments.Beneficiaries(Fixtures.EntityId);

	[TestMethod]
	public void CreateUpdateDelete() {
		var beneficiary = new Beneficiary {
			Name = "MC2IT Test Runner",
			PostalAddress = new() { City = "Fabrègues", Country = "FR", StreetName = "Rue Gine" }
		};

		// It should create the specified beneficiary.
		beneficiary.Id.ShouldBe(Guid.Empty);
		api.Create(beneficiary, testContext.CancellationToken);
		beneficiary.Id.ShouldNotBe(Guid.Empty);

		// It should throw an exception if the beneficiary already exists.
		var exception = Should.Throw<HttpResponseException>(() => api.Create(beneficiary, testContext.CancellationToken));
		exception.StatusCode.ShouldBe(HttpStatusCode.Conflict);
		exception.ProblemDetails?.Title?.ShouldMatch("beneficiary.*MC2IT.*exists");

		// It should update the specified beneficiary.
		beneficiary.PostalAddress.Number = "29";
		beneficiary.PostalAddress.ZipCode = "34690";
		api.Update(beneficiary, testContext.CancellationToken);

		// It should delete the specified beneficiary.
		api.Delete(beneficiary, testContext.CancellationToken);
	}

	[TestMethod, Ignore("This test requires an Agicap development environment.")]
	public void DeleteAll() => Assert.Inconclusive();

	[TestMethod]
	public void ReadAll() {
		var list = api.ReadAll(cancellationToken: testContext.CancellationToken);
		list.Count.ShouldBeGreaterThan(1);

		var beneficiary = list.Single(item => item.Name.StartsWith("Agicap", StringComparison.InvariantCultureIgnoreCase));
		beneficiary.PostalAddress.ShouldNotBeNull();
		beneficiary.PostalAddress.City.ShouldBe("Lyon", StringCompareShould.IgnoreCase);
		beneficiary.PostalAddress.Country.ShouldBe("FR");
	}
}
