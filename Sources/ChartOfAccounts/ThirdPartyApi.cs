namespace Mc2it.Agicap.ChartOfAccounts;

using System.Net.Http.Json;

/// <summary>
/// Manages the third-parties of the chart of accounts.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class ThirdPartyApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"chart-of-accounts/v1/entities/{entityId}/third-parties";

	/// <summary>
	/// Creates new third-parties.
	/// </summary>
	/// <param name="thirdParties">The third-parties to create.</param>
	/// <param name="importId">The identifier to assign to the import.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Metrics about the import of third-parties.</returns>
	public ImportResponse Create(IEnumerable<ThirdParty> thirdParties, Guid? importId = null, CancellationToken cancellationToken = default) =>
		CreateAsync(thirdParties, importId, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Creates new third-parties.
	/// </summary>
	/// <param name="thirdParties">The third-parties to create.</param>
	/// <param name="importId">The identifier to assign to the import.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Metrics about the import of third-parties.</returns>
	public async Task<ImportResponse> CreateAsync(IEnumerable<ThirdParty> thirdParties, Guid? importId = null, CancellationToken cancellationToken = default) {
		using var response = await client.PostAsync($"{requestUri}/import/{importId ?? Guid.NewGuid()}", new { ThirdParties = thirdParties }, cancellationToken: cancellationToken);
		return (await response.Content.ReadFromJsonAsync<ImportResponse>(cancellationToken))!;
	}

	/// <summary>
	/// Deletes the third-parties with the specified codes.
	/// </summary>
	/// <param name="thirdPartyCodes">The codes of third-parties to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Delete(IEnumerable<string> thirdPartyCodes, CancellationToken cancellationToken = default) =>
		DeleteAsync(thirdPartyCodes, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes the third-parties with the specified codes.
	/// </summary>
	/// <param name="thirdPartyCodes">The codes of third-parties to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been deleted.</returns>
	public async Task DeleteAsync(IEnumerable<string> thirdPartyCodes, CancellationToken cancellationToken = default) =>
		await client.PostAsync($"{requestUri}/delete", new { ThirdPartyCodes = thirdPartyCodes }, cancellationToken: cancellationToken);
}
