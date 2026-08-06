namespace Mc2it.Agicap.ChartOfAccounts;

using System.Net.Http.Json;

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
	/// <param name="importId">The identifier to assign to the import.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Metrics about the import of accounting accounts.</returns>
	public ImportResponse Create(IEnumerable<AccountingAccount> accountingAccounts, Guid? importId = null, CancellationToken cancellationToken = default) =>
		CreateAsync(accountingAccounts, importId, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Creates new accounting accounts.
	/// </summary>
	/// <param name="accountingAccounts">The accounting accounts to create.</param>
	/// <param name="importId">The identifier to assign to the import.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Metrics about the import of accounting accounts.</returns>
	public async Task<ImportResponse> CreateAsync(IEnumerable<AccountingAccount> accountingAccounts, Guid? importId = null, CancellationToken cancellationToken = default) {
		importId ??= Guid.CreateVersion7();
		using var response = await client.PostAsync($"{requestUri}/import/{importId}", new { AccountingAccounts = accountingAccounts }, cancellationToken: cancellationToken);
		return (await response.Content.ReadFromJsonAsync<ImportResponse>(cancellationToken))!;
	}

	/// <summary>
	/// Deletes the specified accounting accounts.
	/// </summary>
	/// <param name="accountingAccounts">The numbers of accounting accounts to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Delete(IEnumerable<AccountingAccount> accountingAccounts, CancellationToken cancellationToken = default) =>
		DeleteAsync(accountingAccounts.Select(accountingAccount => accountingAccount.AccountingAccountNumber), cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes the accounting accounts with the specified numbers.
	/// </summary>
	/// <param name="accountingAccountNumbers">The numbers of accounting accounts to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Delete(IEnumerable<string> accountingAccountNumbers, CancellationToken cancellationToken = default) =>
		DeleteAsync(accountingAccountNumbers, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes the specified accounting accounts.
	/// </summary>
	/// <param name="accountingAccounts">The numbers of accounting accounts to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been deleted.</returns>
	public async Task DeleteAsync(IEnumerable<AccountingAccount> accountingAccounts, CancellationToken cancellationToken = default) =>
		await DeleteAsync(accountingAccounts.Select(accountingAccount => accountingAccount.AccountingAccountNumber), cancellationToken);

	/// <summary>
	/// Deletes the accounting accounts with the specified numbers.
	/// </summary>
	/// <param name="accountingAccountNumbers">The numbers of accounting accounts to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been deleted.</returns>
	public async Task DeleteAsync(IEnumerable<string> accountingAccountNumbers, CancellationToken cancellationToken = default) =>
		await client.PostAsync($"{requestUri}/delete", new { AccountingAccountNumbers = accountingAccountNumbers }, cancellationToken: cancellationToken);
}
