namespace Mc2it.Agicap.ChartOfAccounts;

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
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns>
	// public Guid Create(IEnumerable<ThirdParty> thirdParties, CancellationToken cancellationToken = default) =>
	// 	CreateAsync(thirdParties, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Creates new third-parties.
	/// </summary>
	/// <param name="thirdParties">The third-parties to create.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns>
	// public async Task<Guid> CreateAsync(IEnumerable<ThirdParty> thirdParties, CancellationToken cancellationToken = default) {
	// 	using var response = await client.PostAsync(requestUri, thirdParties, cancellationToken: cancellationToken);
	// 	return thirdParties.Id = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
	// }

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
		await client.PostAsync($"{requestUri}/delete", new ThirdPartyList { ThirdPartyCodes = [.. thirdPartyCodes] }, cancellationToken: cancellationToken);
}
