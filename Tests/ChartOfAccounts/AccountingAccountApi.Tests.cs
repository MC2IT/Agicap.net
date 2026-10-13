namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Tests the features of the <see cref="AccountingAccountApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public class AccountingAccountApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly AccountingAccountApi api = Fixtures.CreateClient().ChartOfAccounts.AccountingAccounts(Fixtures.EntityId);

	[TestMethod]
	public void CreateUpdateDelete() {
		var accountingAccounts = new List<AccountingAccount> {
			new() {
				AccountingAccountName = $"MC2IT Development Department {Guid.NewGuid()}",
				AccountingAccountNumber = "99999999",
				AccountingAccountType = AccountingAccountType.Other
			}
		};

		// It should create or update the specified accounting account.
		var importResponse = api.Create(accountingAccounts, cancellationToken: testContext.CancellationToken);
		while (importResponse.ImportStatus == ImportStatus.Started) {
			Thread.Sleep(2_500);
			importResponse = api.Create(accountingAccounts, importResponse.ImportId, testContext.CancellationToken);
		}

		importResponse.ImportStatus.ShouldBe(ImportStatus.Done);
		importResponse.ImportSummary?.NotImportedCount.ShouldBe(0);

		// It should delete the specified accounting account.
		api.Delete(accountingAccounts, testContext.CancellationToken);
	}
}
