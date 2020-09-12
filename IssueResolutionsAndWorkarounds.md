# Issue Resolutions and Workarounds


### Issue #1

"The instance of entity type 'UserRegistrationStatus' with the key value '{RegistrationId: Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.UserRegistrationId}' is marked as 'Modified', but the instance of entity type 'Registration' with the key value '{Id: Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.UserRegistrationId}' is marked as 'Added' and both are mapped to the same row."

[Allow optional dependents to be added later when using table splitting](https://github.com/dotnet/efcore/issues/17422)
