namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Tests the features of the <see cref="AccountingAccountApi"/> class.
/// </summary>
/// <param name="testContext">The test context.</param>
[TestClass, CICondition(ConditionMode.Exclude)]
public sealed class AccountingAccountApiTests(TestContext testContext) {

	/// <summary>
	/// The client used to query the Agicap API.
	/// </summary>
	private readonly AccountingAccountApi api = Fixtures.CreateClient().ChartOfAccounts.AccountingAccounts(Fixtures.EntityId);

	[TestMethod]
	public async Task CreateUpdateDelete() {
		var accountingAccounts = new List<AccountingAccount> {
			new() {
				AccountingAccountName = $"MC2IT Development Department {Guid.NewGuid()}",
				AccountingAccountNumber = "99999999",
				AccountingAccountType = AccountingAccountType.Other
			}
		};

		// It should create or update the specified accounting account.
		var importResponse = await api.CreateAsync(accountingAccounts, cancellationToken: testContext.CancellationToken);
		while (importResponse.ImportStatus == ImportStatus.Started) {
			await Task.Delay(2_500, testContext.CancellationToken);
			importResponse = await api.CreateAsync(accountingAccounts, importResponse.ImportId, testContext.CancellationToken);
		}

		AreEqual(ImportStatus.Done, importResponse.ImportStatus);
		AreEqual(0, importResponse.ImportSummary?.NotImportedCount);

		// It should delete the specified accounting account.
		await api.DeleteAsync(accountingAccounts, testContext.CancellationToken);
	}
}
