namespace Mc2it.Agicap.Payments;

using System.Net.Http.Json;

/// <summary>
/// Manages the beneficiaries of the entity with the specified identifier.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class BeneficiaryApi(Client client, int entityId) {

	/// <summary>
	/// The relative URI of the API endpoint.
	/// </summary>
	private readonly string requestUri = $"payments/v2/entities/{entityId}/Beneficiaries";

	/// <summary>
	/// The API client for the beneficiary synchronization.
	/// </summary>
	public BeneficiarySynchronizationApi Synchronization => new(client, entityId);

	/// <summary>
	/// Creates a new beneficiary.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to create.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns
	public Guid Create(Beneficiary beneficiary, CancellationToken cancellationToken = default) =>
		CreateAsync(beneficiary, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Creates a new beneficiary.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to create.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The identifier of the newly created beneficiary.</returns
	public async Task<Guid> CreateAsync(Beneficiary beneficiary, CancellationToken cancellationToken = default) {
		using var response = await client.PostAsync(requestUri, beneficiary, cancellationToken: cancellationToken);
		return beneficiary.Id = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
	}

	/// <summary>
	/// Deletes the beneficiary with the specified identifier.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Delete(Beneficiary beneficiary, CancellationToken cancellationToken = default) =>
		DeleteAsync(beneficiary.Id, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes the beneficiary with the specified identifier.
	/// </summary>
	/// <param name="beneficiaryId">The beneficiary identifier.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Delete(Guid beneficiaryId, CancellationToken cancellationToken = default) =>
		DeleteAsync(beneficiaryId, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes the beneficiary with the specified identifier.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to delete.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been deleted.</returns>
	public async Task DeleteAsync(Beneficiary beneficiary, CancellationToken cancellationToken = default) =>
		await DeleteAsync(beneficiary.Id, cancellationToken);

	/// <summary>
	/// Deletes the beneficiary with the specified identifier.
	/// </summary>
	/// <param name="beneficiaryId">The beneficiary identifier.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been deleted.</returns>
	public async Task DeleteAsync(Guid beneficiaryId, CancellationToken cancellationToken = default) =>
		await client.DeleteAsync($"{requestUri}/{beneficiaryId}", cancellationToken: cancellationToken);

	/// <summary>
	/// Deletes all beneficiaries.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void DeleteAll(CancellationToken cancellationToken = default) =>
		DeleteAllAsync(cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Deletes all beneficiaries.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiaries have been deleted.</returns>
	public async Task DeleteAllAsync(CancellationToken cancellationToken = default) =>
		await client.DeleteAsync(requestUri, cancellationToken: cancellationToken);

	/// <summary>
	/// Fetches all beneficiaries.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The beneficiary list.</returns>
	public IList<Beneficiary> ReadAll(CancellationToken cancellationToken = default) =>
		ReadAllAsync(cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches all beneficiaries.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The beneficiary list.</returns>
	public async Task<IList<Beneficiary>> ReadAllAsync(CancellationToken cancellationToken = default) =>
		await client.GetAsync<IList<Beneficiary>>(requestUri, cancellationToken: cancellationToken);

	/// <summary>
	/// Updates the specified beneficiary.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to update.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Update(Beneficiary beneficiary, CancellationToken cancellationToken = default) =>
		UpdateAsync(beneficiary, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Updates the specified beneficiary.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to update.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>Completes when the beneficiary has been updated.</returns>
	public async Task UpdateAsync(Beneficiary beneficiary, CancellationToken cancellationToken = default) =>
		await client.PutAsync($"{requestUri}/{beneficiary.Id}", beneficiary, cancellationToken: cancellationToken);
}
