namespace Mc2it.Agicap.Payments;

/// <summary>
/// Manages the payments.
/// </summary>
/// <param name="client">The Agicap API client.</param>
public class PaymentApi(Client client) {

	/// <summary>
	/// Gets a new API client for the beneficiaries of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the beneficiaries of the specified entity.</returns>
	public BeneficiaryApi Beneficiaries(int entityId) => new(client, entityId);

	/// <summary>
	/// Gets a new API client for the payment files of the entity with the specified identifier.
	/// </summary>
	/// <param name="entityId">The entity identifier.</param>
	/// <returns>The API client for the payment files of the specified entity.</returns>
	/// <exception cref="NotImplementedException">This API is not implemented.</exception>
	public object PaymentFiles(int entityId) => throw new NotImplementedException("TODO");
}
