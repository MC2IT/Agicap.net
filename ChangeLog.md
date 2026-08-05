# Changelog

## Version [0.6.0](https://github.com/MC2IT/Agicap.net/compare/v0.5.0...v0.6.0)
- Added the `Payments.SynchronizedBeneficiary.BankAccount` property.
- Removed the `NestedList` class.
- Removed the `IEquatable` implementation from the `BankAccount`, `Beneficiary` and `PostalAddress` classes of the `Payments` namespace.

## Version [0.5.0](https://github.com/MC2IT/Agicap.net/compare/v0.4.0...v0.5.0)
- Added the `NestedList` class.
- **Payments:** added the beneficiary synchronization API.

## Version [0.4.0](https://github.com/MC2IT/Agicap.net/compare/v0.3.0...v0.4.0)
- Added the `HttpResponseException` class.
- Added support for returning a `ProblemDetails` instance when an API call fails. 

## Version [0.3.0](https://github.com/MC2IT/Agicap.net/compare/v0.2.0...v0.3.0)
- Added the `Client.DefaultScopes` property.
- Renamed the `GetAll` methods to `ReadAll`.
- **Payments:** added the beneficiary API, with the exception of `sync` endpoints.

## Version [0.2.0](https://github.com/MC2IT/Agicap.net/compare/v0.1.0...v0.2.0)
- Added the `Authentication.Scopes.All` property.
- Added the `Payments.Beneficiary.CompanyLegalIdentifier` property.

## Version 0.1.0
- Initial release.
