namespace Mc2it.Agicap.Payments;

/// <summary>
/// Manages the beneficiaries of the entity with the specified identifier.
/// </summary>
/// <param name="client">The Agicap API client.</param>
/// <param name="entityId">The entity identifier.</param>
public class BeneficiaryApi(Client client, int entityId) {
	// TODO

	public void Create(CancellationToken cancellationToken = default) {

	}

	public Task CreateAsync(CancellationToken cancellationToken = default) {
		return Task.CompletedTask;
	}

	public void Delete(CancellationToken cancellationToken = default) {

	}

	public void DeleteAsync(CancellationToken cancellationToken = default) {

	}

	public void DeleteAll(CancellationToken cancellationToken = default) {

	}

	public void DeleteAllAsync(CancellationToken cancellationToken = default) {

	}

	public void Update(CancellationToken cancellationToken = default) {

	}

	public void UpdateAsync(CancellationToken cancellationToken = default) {

	}
}
