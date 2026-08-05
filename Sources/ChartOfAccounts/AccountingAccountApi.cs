namespace Mc2it.Agicap.ChartOfAccounts;

/// <summary>
/// Manages the accounting accounts of the chart of accounts.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class AccountingAccountApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"chart-of-accounts/v1/entities/{entityId}/accounting-accounts";

	/// <summary>
	/// Creates new accounting accounts.
	/// </summary>
	/// <param name="accountingAccounts">The accounting accounts to create.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns>
	// public Guid Create(IEnumerable<AccountingAccount> accountingAccounts, CancellationToken cancellationToken = default) =>
	// 	CreateAsync(accountingAccounts, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Creates new accounting accounts.
	/// </summary>
	/// <param name="accountingAccounts">The accounting accounts to create.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns>
	// public async Task<Guid> CreateAsync(IEnumerable<AccountingAccount> accountingAccounts, CancellationToken cancellationToken = default) {
	// 	using var response = await client.PostAsync(requestUri, accountingAccounts, cancellationToken: cancellationToken);
	// 	return accountingAccounts.Id = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
	// }

	/// <summary>
	/// Deletes the accounting accounts with the specified numbers.
	/// </summary>
	/// <param name="accountingAccountNumbers">The numbers of accounting accounts to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Delete(IEnumerable<string> accountingAccountNumbers, CancellationToken cancellationToken = default) =>
		DeleteAsync(accountingAccountNumbers, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes the accounting accounts with the specified numbers.
	/// </summary>
	/// <param name="accountingAccountNumbers">The numbers of accounting accounts to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been deleted.</returns>
	public async Task DeleteAsync(IEnumerable<string> accountingAccountNumbers, CancellationToken cancellationToken = default) =>
		await client.PostAsync($"{requestUri}/delete", new AccountingAccountList { AccountingAccountNumbers = [.. accountingAccountNumbers] }, cancellationToken: cancellationToken);
}
