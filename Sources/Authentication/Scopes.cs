namespace Mc2it.Agicap.Authentication;

/// <summary>
/// Provides the list of supported OAuth scopes.
/// </summary>
public static class Scopes {

	/// <summary>
	/// Authorize to import payment files.
	/// </summary>
	public const string ImportPaymentFiles = "public-api:import_payment_files";

	/// <summary>
	/// Authorize to import payment files with mandatory signed IBANs.
	/// </summary>
	public const string ImportPaymentFilesWithSignedBeneficiaries = "public-api:import_payment_files_with_signed_beneficiaries";

	/// <summary>
	/// Authorize to manage payment beneficiaries.
	/// </summary>
	public const string ManagePaymentBeneficiaries = "public-api:manage-payment-beneficiaries";

	/// <summary>
	/// Authorize to manage suppliers.
	/// </summary>
	public const string ManageSuppliers = "public-api:manage-suppliers";

	/// <summary>
	/// Authorize calls to Agicap API.
	/// </summary>
	public const string PublicApi = "agicap:public-api";
}
