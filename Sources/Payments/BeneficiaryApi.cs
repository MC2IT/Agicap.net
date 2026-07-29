namespace Mc2it.Agicap.Payments;

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
	/// Creates a new beneficiary.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to update.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	public void Create(Beneficiary beneficiary, CancellationToken cancellationToken = default) =>
		CreateAsync(beneficiary, cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Creates a new beneficiary.
	/// </summary>
	/// <param name="beneficiary">The beneficiary to update.</param>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns></returns>
	public Task CreateAsync(Beneficiary beneficiary, CancellationToken cancellationToken = default) {
		return Task.CompletedTask;
	}

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
	public IList<Beneficiary> GetAll(CancellationToken cancellationToken = default) =>
		GetAllAsync(cancellationToken).GetAwaiter().GetResult();

	/// <summary>
	/// Fetches all beneficiaries.
	/// </summary>
	/// <param name="cancellationToken">The token to cancel the operation.</param>
	/// <returns>The beneficiary list.</returns>
	public async Task<IList<Beneficiary>> GetAllAsync(CancellationToken cancellationToken = default) =>
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
	public Task UpdateAsync(Beneficiary beneficiary, CancellationToken cancellationToken = default) {
		return Task.CompletedTask;
	}
}
