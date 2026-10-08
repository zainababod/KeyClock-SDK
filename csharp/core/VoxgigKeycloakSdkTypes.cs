// Typed reference models for the VoxgigKeycloakSdk SDK.
//
// GENERATED from the API model: main.kit.entity.<e>.fields{} and per-op
// params (op.<name>.points[].g.params[]). Field/param types come from the
// canonical type sentinels (source of truth: @voxgig/apidef VALID_CANON). Do
// not edit by hand.
//
// These records are documentation/DX reference shapes ONLY. The SDK ops take
// and return the loose object model (Dictionary<string, object?> / object?) at
// runtime, so these types are not wired into the op signatures — use them to
// describe a payload before converting it to a dictionary. Optional (req:false)
// keys are modelled as nullable properties.

namespace VoxgigKeycloakSdkSdk.Types;

public record AccessToken
{
    public string? acr { get; init; }
    public Dictionary<string, object?>? address { get; init; }
    public List<object?>? allowedorigins { get; init; }
    public string? at_hash { get; init; }
    public long? authTime { get; init; }
    public long? auth_time { get; init; }
    public Dictionary<string, object?>? authorization { get; init; }
    public string? azp { get; init; }
    public string? birthdate { get; init; }
    public string? c_hash { get; init; }
    public string? claims_locales { get; init; }
    public Dictionary<string, object?>? cnf { get; init; }
    public string? email { get; init; }
    public bool? email_verified { get; init; }
    public long? exp { get; init; }
    public string? family_name { get; init; }
    public string? gender { get; init; }
    public string? given_name { get; init; }
    public long? iat { get; init; }
    public string? iss { get; init; }
    public string? jti { get; init; }
    public string? locale { get; init; }
    public string? middle_name { get; init; }
    public string? name { get; init; }
    public long? nbf { get; init; }
    public string? nickname { get; init; }
    public string? nonce { get; init; }
    public Dictionary<string, object?>? otherClaims { get; init; }
    public string? phone_number { get; init; }
    public bool? phone_number_verified { get; init; }
    public string? picture { get; init; }
    public string? preferred_username { get; init; }
    public string? profile { get; init; }
    public Dictionary<string, object?>? realm_access { get; init; }
    public Dictionary<string, object?>? resource_access { get; init; }
    public string? s_hash { get; init; }
    public string? scope { get; init; }
    public string? session_state { get; init; }
    public string? sid { get; init; }
    public string? sub { get; init; }
    public List<object?>? trustedcerts { get; init; }
    public string? typ { get; init; }
    public long? updated_at { get; init; }
    public string? website { get; init; }
    public string? zoneinfo { get; init; }
}

public record AccessTokenListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? scope { get; init; }
    public string? user_id { get; init; }
}

public record AdminEvent
{
    public Dictionary<string, object?>? authDetails { get; init; }
    public string? error { get; init; }
    public string? operationType { get; init; }
    public string? realmId { get; init; }
    public string? representation { get; init; }
    public string? resourcePath { get; init; }
    public string? resourceType { get; init; }
    public long? time { get; init; }
}

public record AdminEventListMatch
{
    public string realm { get; init; }
    public string? auth_client { get; init; }
    public string? auth_ip_address { get; init; }
    public string? auth_realm { get; init; }
    public string? auth_user { get; init; }
    public string? date_from { get; init; }
    public string? date_to { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? operation_type { get; init; }
    public string? resource_path { get; init; }
    public string? resource_type { get; init; }
}

public record AttackDetection();

public record AttackDetectionLoadMatch
{
    public string realm { get; init; }
    public string user_id { get; init; }
}

public record AttackDetectionRemoveMatch
{
    public string realm { get; init; }
    public string? user_id { get; init; }
}

public record AuthenticationFlowRepresentation
{
    public string? alias { get; init; }
    public List<object?>? authenticationExecutions { get; init; }
    public bool? builtIn { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? providerId { get; init; }
    public bool? topLevel { get; init; }
}

public record AuthenticationFlowRepresentationLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record AuthenticationFlowRepresentationListMatch
{
    public string realm { get; init; }
}

public record AuthenticationManagement
{
    public string? alias { get; init; }
    public string? authenticationConfig { get; init; }
    public List<object?>? authenticationExecutions { get; init; }
    public bool? authenticationFlow { get; init; }
    public string? authenticator { get; init; }
    public string? authenticatorConfig { get; init; }
    public bool? authenticatorFlow { get; init; }
    public bool? autheticatorFlow { get; init; }
    public bool? builtIn { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? configurable { get; init; }
    public bool? defaultAction { get; init; }
    public object? defaultValue { get; init; }
    public string? description { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? flowId { get; init; }
    public string? helpText { get; init; }
    public string? id { get; init; }
    public long? index { get; init; }
    public string? label { get; init; }
    public long? level { get; init; }
    public string? name { get; init; }
    public List<object?>? options { get; init; }
    public string? parentFlow { get; init; }
    public long? priority { get; init; }
    public string? providerId { get; init; }
    public bool? readOnly { get; init; }
    public bool? required { get; init; }
    public string? requirement { get; init; }
    public List<object?>? requirementChoices { get; init; }
    public bool? secret { get; init; }
    public bool? topLevel { get; init; }
    public string? type { get; init; }
}

public record AuthenticationManagementLoadMatch
{
    public string? execution_id { get; init; }
    public string realm { get; init; }
    public string? flow_alia { get; init; }
}

public record AuthenticationManagementListMatch
{
    public string realm { get; init; }
}

public record AuthenticationManagementCreateData
{
    public string? execution_id { get; init; }
    public string realm { get; init; }
    public string? flow_alia { get; init; }
    public string? alias { get; init; }
    public string? authenticationConfig { get; init; }
    public List<object?>? authenticationExecutions { get; init; }
    public bool? authenticationFlow { get; init; }
    public string? authenticator { get; init; }
    public string? authenticatorConfig { get; init; }
    public bool? authenticatorFlow { get; init; }
    public bool? autheticatorFlow { get; init; }
    public bool? builtIn { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? configurable { get; init; }
    public bool? defaultAction { get; init; }
    public object? defaultValue { get; init; }
    public string? description { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? flowId { get; init; }
    public string? helpText { get; init; }
    public string? id { get; init; }
    public long? index { get; init; }
    public string? label { get; init; }
    public long? level { get; init; }
    public string? name { get; init; }
    public List<object?>? options { get; init; }
    public string? parentFlow { get; init; }
    public long? priority { get; init; }
    public string? providerId { get; init; }
    public bool? readOnly { get; init; }
    public bool? required { get; init; }
    public string? requirement { get; init; }
    public List<object?>? requirementChoices { get; init; }
    public bool? secret { get; init; }
    public bool? topLevel { get; init; }
    public string? type { get; init; }
}

public record AuthenticationManagementUpdateData
{
    public string? alia { get; init; }
    public string realm { get; init; }
    public string? flow_alia { get; init; }
    public string? id { get; init; }
    public string? alias { get; init; }
    public string? authenticationConfig { get; init; }
    public List<object?>? authenticationExecutions { get; init; }
    public bool? authenticationFlow { get; init; }
    public string? authenticator { get; init; }
    public string? authenticatorConfig { get; init; }
    public bool? authenticatorFlow { get; init; }
    public bool? autheticatorFlow { get; init; }
    public bool? builtIn { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? configurable { get; init; }
    public bool? defaultAction { get; init; }
    public object? defaultValue { get; init; }
    public string? description { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? flowId { get; init; }
    public string? helpText { get; init; }
    public long? index { get; init; }
    public string? label { get; init; }
    public long? level { get; init; }
    public string? name { get; init; }
    public List<object?>? options { get; init; }
    public string? parentFlow { get; init; }
    public long? priority { get; init; }
    public string? providerId { get; init; }
    public bool? readOnly { get; init; }
    public bool? required { get; init; }
    public string? requirement { get; init; }
    public List<object?>? requirementChoices { get; init; }
    public bool? secret { get; init; }
    public bool? topLevel { get; init; }
    public string? type { get; init; }
}

public record AuthenticationManagementRemoveMatch
{
    public string? alia { get; init; }
    public string realm { get; init; }
    public string? execution_id { get; init; }
    public string? id { get; init; }
}

public record AuthenticatorConfigInfoRepresentation
{
    public string? helpText { get; init; }
    public string? name { get; init; }
    public List<object?>? properties { get; init; }
    public string? providerId { get; init; }
}

public record AuthenticatorConfigInfoRepresentationLoadMatch
{
    public string provider_id { get; init; }
    public string realm { get; init; }
}

public record AuthenticatorConfigRepresentation
{
    public string? alias { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? id { get; init; }
}

public record AuthenticatorConfigRepresentationLoadMatch
{
    public string? execution_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
}

public record Available
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record AvailableListMatch
{
    public string? client { get; init; }
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public string? group_id { get; init; }
    public string? user_id { get; init; }
}

public record Certificate
{
    public string? certificate { get; init; }
    public string? id { get; init; }
    public string? kid { get; init; }
    public string? privateKey { get; init; }
    public string? publicKey { get; init; }
}

public record CertificateLoadMatch
{
    public string client_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
}

public record CertificateCreateData
{
    public string attr { get; init; }
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? certificate { get; init; }
    public string? id { get; init; }
    public string? kid { get; init; }
    public string? privateKey { get; init; }
    public string? publicKey { get; init; }
}

public record CertificateRepresentation
{
    public string? certificate { get; init; }
    public string? kid { get; init; }
    public string? privateKey { get; init; }
    public string? publicKey { get; init; }
}

public record CertificateRepresentationCreateData
{
    public string attr { get; init; }
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? certificate { get; init; }
    public string? kid { get; init; }
    public string? privateKey { get; init; }
    public string? publicKey { get; init; }
}

public record Client
{
    public Dictionary<string, object?>? access { get; init; }
    public string? adminUrl { get; init; }
    public bool? alwaysDisplayInConsole { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? authenticationFlowBindingOverrides { get; init; }
    public bool? authorizationServicesEnabled { get; init; }
    public Dictionary<string, object?>? authorizationSettings { get; init; }
    public string? baseUrl { get; init; }
    public bool? bearerOnly { get; init; }
    public string? clientAuthenticatorType { get; init; }
    public string? clientId { get; init; }
    public bool? clientRole { get; init; }
    public string? clientTemplate { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public bool? consentRequired { get; init; }
    public string? containerId { get; init; }
    public List<object?>? defaultClientScopes { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? description { get; init; }
    public bool? directAccessGrantsEnabled { get; init; }
    public bool? directGrantsOnly { get; init; }
    public bool? enabled { get; init; }
    public bool? frontchannelLogout { get; init; }
    public bool? fullScopeAllowed { get; init; }
    public string? id { get; init; }
    public bool? implicitFlowEnabled { get; init; }
    public string? name { get; init; }
    public long? nodeReRegistrationTimeout { get; init; }
    public long? notBefore { get; init; }
    public bool? oauth2DeviceAuthorizationGrantEnabled { get; init; }
    public List<object?>? optionalClientScopes { get; init; }
    public string? origin { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public bool? publicClient { get; init; }
    public List<object?>? redirectUris { get; init; }
    public Dictionary<string, object?>? registeredNodes { get; init; }
    public string? registrationAccessToken { get; init; }
    public string? rootUrl { get; init; }
    public bool? scopeParamRequired { get; init; }
    public string? secret { get; init; }
    public bool? serviceAccountsEnabled { get; init; }
    public bool? standardFlowEnabled { get; init; }
    public bool? surrogateAuthRequired { get; init; }
    public bool? useTemplateConfig { get; init; }
    public bool? useTemplateMappers { get; init; }
    public bool? useTemplateScope { get; init; }
    public List<object?>? webOrigins { get; init; }
}

public record ClientLoadMatch
{
    public string? client_uuid { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public string? role_name { get; init; }
    public string? client { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public string? group_id { get; init; }
    public string? provider_id { get; init; }
    public string? roles_by_id_id { get; init; }
    public string? user_id { get; init; }
}

public record ClientListMatch
{
    public string realm { get; init; }
    public string? client_id { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? q { get; init; }
    public string? search { get; init; }
    public string? viewable_only { get; init; }
}

public record ClientCreateData
{
    public string? group_id { get; init; }
    public string? id { get; init; }
    public string realm { get; init; }
    public string? user_id { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public string? adminUrl { get; init; }
    public bool? alwaysDisplayInConsole { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? authenticationFlowBindingOverrides { get; init; }
    public bool? authorizationServicesEnabled { get; init; }
    public Dictionary<string, object?>? authorizationSettings { get; init; }
    public string? baseUrl { get; init; }
    public bool? bearerOnly { get; init; }
    public string? clientAuthenticatorType { get; init; }
    public string? clientId { get; init; }
    public bool? clientRole { get; init; }
    public string? clientTemplate { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public bool? consentRequired { get; init; }
    public string? containerId { get; init; }
    public List<object?>? defaultClientScopes { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? description { get; init; }
    public bool? directAccessGrantsEnabled { get; init; }
    public bool? directGrantsOnly { get; init; }
    public bool? enabled { get; init; }
    public bool? frontchannelLogout { get; init; }
    public bool? fullScopeAllowed { get; init; }
    public bool? implicitFlowEnabled { get; init; }
    public string? name { get; init; }
    public long? nodeReRegistrationTimeout { get; init; }
    public long? notBefore { get; init; }
    public bool? oauth2DeviceAuthorizationGrantEnabled { get; init; }
    public List<object?>? optionalClientScopes { get; init; }
    public string? origin { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public bool? publicClient { get; init; }
    public List<object?>? redirectUris { get; init; }
    public Dictionary<string, object?>? registeredNodes { get; init; }
    public string? registrationAccessToken { get; init; }
    public string? rootUrl { get; init; }
    public bool? scopeParamRequired { get; init; }
    public string? secret { get; init; }
    public bool? serviceAccountsEnabled { get; init; }
    public bool? standardFlowEnabled { get; init; }
    public bool? surrogateAuthRequired { get; init; }
    public bool? useTemplateConfig { get; init; }
    public bool? useTemplateMappers { get; init; }
    public bool? useTemplateScope { get; init; }
    public List<object?>? webOrigins { get; init; }
}

public record ClientUpdateData
{
    public string? client_scope_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public string? adminUrl { get; init; }
    public bool? alwaysDisplayInConsole { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? authenticationFlowBindingOverrides { get; init; }
    public bool? authorizationServicesEnabled { get; init; }
    public Dictionary<string, object?>? authorizationSettings { get; init; }
    public string? baseUrl { get; init; }
    public bool? bearerOnly { get; init; }
    public string? clientAuthenticatorType { get; init; }
    public string? clientId { get; init; }
    public bool? clientRole { get; init; }
    public string? clientTemplate { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public bool? consentRequired { get; init; }
    public string? containerId { get; init; }
    public List<object?>? defaultClientScopes { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? description { get; init; }
    public bool? directAccessGrantsEnabled { get; init; }
    public bool? directGrantsOnly { get; init; }
    public bool? enabled { get; init; }
    public bool? frontchannelLogout { get; init; }
    public bool? fullScopeAllowed { get; init; }
    public bool? implicitFlowEnabled { get; init; }
    public string? name { get; init; }
    public long? nodeReRegistrationTimeout { get; init; }
    public long? notBefore { get; init; }
    public bool? oauth2DeviceAuthorizationGrantEnabled { get; init; }
    public List<object?>? optionalClientScopes { get; init; }
    public string? origin { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public bool? publicClient { get; init; }
    public List<object?>? redirectUris { get; init; }
    public Dictionary<string, object?>? registeredNodes { get; init; }
    public string? registrationAccessToken { get; init; }
    public string? rootUrl { get; init; }
    public bool? scopeParamRequired { get; init; }
    public string? secret { get; init; }
    public bool? serviceAccountsEnabled { get; init; }
    public bool? standardFlowEnabled { get; init; }
    public bool? surrogateAuthRequired { get; init; }
    public bool? useTemplateConfig { get; init; }
    public bool? useTemplateMappers { get; init; }
    public bool? useTemplateScope { get; init; }
    public List<object?>? webOrigins { get; init; }
}

public record ClientRemoveMatch
{
    public string? client_scope_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public string? group_id { get; init; }
    public string? node { get; init; }
    public string? user_id { get; init; }
}

public record ClientInitialAccess
{
    public string? id { get; init; }
}

public record ClientInitialAccessRemoveMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ClientInitialAccessPresentation
{
    public long? count { get; init; }
    public long? expiration { get; init; }
    public string? id { get; init; }
    public long? remainingCount { get; init; }
    public long? timestamp { get; init; }
    public string? token { get; init; }
}

public record ClientInitialAccessPresentationListMatch
{
    public string realm { get; init; }
}

public record ClientInitialAccessPresentationCreateData
{
    public string realm { get; init; }
    public long? count { get; init; }
    public long? expiration { get; init; }
    public string? id { get; init; }
    public long? remainingCount { get; init; }
    public long? timestamp { get; init; }
    public string? token { get; init; }
}

public record ClientPolicyRepresentation
{
    public List<object?>? conditions { get; init; }
    public string? description { get; init; }
    public bool? enabled { get; init; }
    public string? name { get; init; }
    public List<object?>? profiles { get; init; }
}

public record ClientPolicyRepresentationListMatch
{
    public string realm { get; init; }
}

public record ClientProfilesRepresentation
{
    public List<object?>? globalProfiles { get; init; }
    public List<object?>? profiles { get; init; }
}

public record ClientProfilesRepresentationListMatch
{
    public string realm { get; init; }
    public string? include_global_profile { get; init; }
}

public record ClientRepresentation
{
    public Dictionary<string, object?>? access { get; init; }
    public string? adminUrl { get; init; }
    public bool? alwaysDisplayInConsole { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? authenticationFlowBindingOverrides { get; init; }
    public bool? authorizationServicesEnabled { get; init; }
    public Dictionary<string, object?>? authorizationSettings { get; init; }
    public string? baseUrl { get; init; }
    public bool? bearerOnly { get; init; }
    public string? clientAuthenticatorType { get; init; }
    public string? clientId { get; init; }
    public string? clientTemplate { get; init; }
    public bool? consentRequired { get; init; }
    public List<object?>? defaultClientScopes { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? description { get; init; }
    public bool? directAccessGrantsEnabled { get; init; }
    public bool? directGrantsOnly { get; init; }
    public bool? enabled { get; init; }
    public bool? frontchannelLogout { get; init; }
    public bool? fullScopeAllowed { get; init; }
    public string? id { get; init; }
    public bool? implicitFlowEnabled { get; init; }
    public string? name { get; init; }
    public long? nodeReRegistrationTimeout { get; init; }
    public long? notBefore { get; init; }
    public bool? oauth2DeviceAuthorizationGrantEnabled { get; init; }
    public List<object?>? optionalClientScopes { get; init; }
    public string? origin { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public bool? publicClient { get; init; }
    public List<object?>? redirectUris { get; init; }
    public Dictionary<string, object?>? registeredNodes { get; init; }
    public string? registrationAccessToken { get; init; }
    public string? rootUrl { get; init; }
    public string? secret { get; init; }
    public bool? serviceAccountsEnabled { get; init; }
    public bool? standardFlowEnabled { get; init; }
    public bool? surrogateAuthRequired { get; init; }
    public bool? useTemplateConfig { get; init; }
    public bool? useTemplateMappers { get; init; }
    public bool? useTemplateScope { get; init; }
    public List<object?>? webOrigins { get; init; }
}

public record ClientRepresentationCreateData
{
    public string realm { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public string? adminUrl { get; init; }
    public bool? alwaysDisplayInConsole { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? authenticationFlowBindingOverrides { get; init; }
    public bool? authorizationServicesEnabled { get; init; }
    public Dictionary<string, object?>? authorizationSettings { get; init; }
    public string? baseUrl { get; init; }
    public bool? bearerOnly { get; init; }
    public string? clientAuthenticatorType { get; init; }
    public string? clientId { get; init; }
    public string? clientTemplate { get; init; }
    public bool? consentRequired { get; init; }
    public List<object?>? defaultClientScopes { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? description { get; init; }
    public bool? directAccessGrantsEnabled { get; init; }
    public bool? directGrantsOnly { get; init; }
    public bool? enabled { get; init; }
    public bool? frontchannelLogout { get; init; }
    public bool? fullScopeAllowed { get; init; }
    public string? id { get; init; }
    public bool? implicitFlowEnabled { get; init; }
    public string? name { get; init; }
    public long? nodeReRegistrationTimeout { get; init; }
    public long? notBefore { get; init; }
    public bool? oauth2DeviceAuthorizationGrantEnabled { get; init; }
    public List<object?>? optionalClientScopes { get; init; }
    public string? origin { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public bool? publicClient { get; init; }
    public List<object?>? redirectUris { get; init; }
    public Dictionary<string, object?>? registeredNodes { get; init; }
    public string? registrationAccessToken { get; init; }
    public string? rootUrl { get; init; }
    public string? secret { get; init; }
    public bool? serviceAccountsEnabled { get; init; }
    public bool? standardFlowEnabled { get; init; }
    public bool? surrogateAuthRequired { get; init; }
    public bool? useTemplateConfig { get; init; }
    public bool? useTemplateMappers { get; init; }
    public bool? useTemplateScope { get; init; }
    public List<object?>? webOrigins { get; init; }
}

public record ClientScope
{
    public Dictionary<string, object?>? attributes { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
}

public record ClientScopeLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ClientScopeListMatch
{
    public string realm { get; init; }
}

public record ClientScopeCreateData
{
    public string realm { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
}

public record ClientScopeUpdateData
{
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public string? description { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
}

public record ClientScopeRemoveMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ClientScopeRepresentation
{
    public Dictionary<string, object?>? attributes { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public List<object?>? protocolMappers { get; init; }
}

public record ClientScopeRepresentationLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ClientScopeRepresentationListMatch
{
    public string realm { get; init; }
}

public record Component
{
    public Dictionary<string, object?>? config { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? providerId { get; init; }
    public string? providerType { get; init; }
    public string? subType { get; init; }
}

public record ComponentLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ComponentListMatch
{
    public string realm { get; init; }
    public string? name { get; init; }
    public string? parent { get; init; }
    public string? type { get; init; }
}

public record ComponentCreateData
{
    public string realm { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? providerId { get; init; }
    public string? providerType { get; init; }
    public string? subType { get; init; }
}

public record ComponentUpdateData
{
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? providerId { get; init; }
    public string? providerType { get; init; }
    public string? subType { get; init; }
}

public record ComponentRemoveMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ComponentTypeRepresentation
{
    public string? helpText { get; init; }
    public string? id { get; init; }
    public Dictionary<string, object?>? metadata { get; init; }
    public List<object?>? properties { get; init; }
}

public record ComponentTypeRepresentationListMatch
{
    public string realm { get; init; }
}

public record Composite
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record CompositeListMatch
{
    public string? client { get; init; }
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? brief_representation { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public string? group_id { get; init; }
    public string? role_name { get; init; }
    public string? user_id { get; init; }
    public string? roles_by_id_id { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? search { get; init; }
}

public record Credential
{
    public string? algorithm { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public long? counter { get; init; }
    public long? createdDate { get; init; }
    public string? credentialData { get; init; }
    public string? device { get; init; }
    public long? digits { get; init; }
    public long? hashIterations { get; init; }
    public string? hashedSaltedValue { get; init; }
    public string? id { get; init; }
    public long? period { get; init; }
    public long? priority { get; init; }
    public string? salt { get; init; }
    public string? secretData { get; init; }
    public bool? temporary { get; init; }
    public string? type { get; init; }
    public string? userLabel { get; init; }
    public string? value { get; init; }
}

public record CredentialListMatch
{
    public string realm { get; init; }
    public string user_id { get; init; }
}

public record CredentialRepresentation
{
    public string? algorithm { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public long? counter { get; init; }
    public long? createdDate { get; init; }
    public string? credentialData { get; init; }
    public string? device { get; init; }
    public long? digits { get; init; }
    public long? hashIterations { get; init; }
    public string? hashedSaltedValue { get; init; }
    public string? id { get; init; }
    public long? period { get; init; }
    public long? priority { get; init; }
    public string? salt { get; init; }
    public string? secretData { get; init; }
    public bool? temporary { get; init; }
    public string? type { get; init; }
    public string? userLabel { get; init; }
    public string? value { get; init; }
}

public record CredentialRepresentationLoadMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
}

public record CredentialRepresentationCreateData
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? algorithm { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public long? counter { get; init; }
    public long? createdDate { get; init; }
    public string? credentialData { get; init; }
    public string? device { get; init; }
    public long? digits { get; init; }
    public long? hashIterations { get; init; }
    public string? hashedSaltedValue { get; init; }
    public string? id { get; init; }
    public long? period { get; init; }
    public long? priority { get; init; }
    public string? salt { get; init; }
    public string? secretData { get; init; }
    public bool? temporary { get; init; }
    public string? type { get; init; }
    public string? userLabel { get; init; }
    public string? value { get; init; }
}

public record DeleteByRealm
{
    public string? id { get; init; }
}

public record DeleteByRealmRemoveMatch
{
    public string id { get; init; }
}

public record Event
{
    public string? clientId { get; init; }
    public Dictionary<string, object?>? details { get; init; }
    public string? error { get; init; }
    public string? ipAddress { get; init; }
    public string? realmId { get; init; }
    public string? sessionId { get; init; }
    public long? time { get; init; }
    public string? type { get; init; }
    public string? userId { get; init; }
}

public record EventListMatch
{
    public string realm { get; init; }
    public string? client { get; init; }
    public string? date_from { get; init; }
    public string? date_to { get; init; }
    public string? first { get; init; }
    public string? ip_address { get; init; }
    public string? max { get; init; }
    public string? type { get; init; }
    public string? user { get; init; }
}

public record FederatedIdentity
{
    public string? identityProvider { get; init; }
    public string? userId { get; init; }
    public string? userName { get; init; }
}

public record FederatedIdentityListMatch
{
    public string realm { get; init; }
    public string user_id { get; init; }
}

public record Flow();

public record FlowCreateData
{
    public string flow_alia { get; init; }
    public string realm { get; init; }
}

public record Get
{
    public long? accessCodeLifespan { get; init; }
    public long? accessCodeLifespanLogin { get; init; }
    public long? accessCodeLifespanUserAction { get; init; }
    public long? accessTokenLifespan { get; init; }
    public long? accessTokenLifespanForImplicitFlow { get; init; }
    public string? accountTheme { get; init; }
    public long? actionTokenGeneratedByAdminLifespan { get; init; }
    public long? actionTokenGeneratedByUserLifespan { get; init; }
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public string? adminTheme { get; init; }
    public Dictionary<string, object?>? applicationScopeMappings { get; init; }
    public List<object?>? applications { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? authenticationFlows { get; init; }
    public List<object?>? authenticatorConfig { get; init; }
    public string? browserFlow { get; init; }
    public Dictionary<string, object?>? browserSecurityHeaders { get; init; }
    public bool? bruteForceProtected { get; init; }
    public string? certificate { get; init; }
    public string? clientAuthenticationFlow { get; init; }
    public long? clientOfflineSessionIdleTimeout { get; init; }
    public long? clientOfflineSessionMaxLifespan { get; init; }
    public Dictionary<string, object?>? clientPolicies { get; init; }
    public Dictionary<string, object?>? clientProfiles { get; init; }
    public Dictionary<string, object?>? clientScopeMappings { get; init; }
    public List<object?>? clientScopes { get; init; }
    public long? clientSessionIdleTimeout { get; init; }
    public long? clientSessionMaxLifespan { get; init; }
    public List<object?>? clientTemplates { get; init; }
    public List<object?>? clients { get; init; }
    public string? codeSecret { get; init; }
    public Dictionary<string, object?>? components { get; init; }
    public List<object?>? defaultDefaultClientScopes { get; init; }
    public List<object?>? defaultGroups { get; init; }
    public string? defaultLocale { get; init; }
    public List<object?>? defaultOptionalClientScopes { get; init; }
    public Dictionary<string, object?>? defaultRole { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? defaultSignatureAlgorithm { get; init; }
    public string? directGrantFlow { get; init; }
    public string? displayName { get; init; }
    public string? displayNameHtml { get; init; }
    public string? dockerAuthenticationFlow { get; init; }
    public bool? duplicateEmailsAllowed { get; init; }
    public bool? editUsernameAllowed { get; init; }
    public string? emailTheme { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public long? failureFactor { get; init; }
    public List<object?>? federatedUsers { get; init; }
    public List<object?>? groups { get; init; }
    public string? id { get; init; }
    public List<object?>? identityProviderMappers { get; init; }
    public List<object?>? identityProviders { get; init; }
    public bool? internationalizationEnabled { get; init; }
    public string? keycloakVersion { get; init; }
    public Dictionary<string, object?>? localizationTexts { get; init; }
    public string? loginTheme { get; init; }
    public bool? loginWithEmailAllowed { get; init; }
    public long? maxDeltaTimeSeconds { get; init; }
    public long? maxFailureWaitSeconds { get; init; }
    public long? minimumQuickLoginWaitSeconds { get; init; }
    public long? notBefore { get; init; }
    public long? oAuth2DeviceCodeLifespan { get; init; }
    public long? oAuth2DevicePollingInterval { get; init; }
    public long? oauth2DeviceCodeLifespan { get; init; }
    public long? oauth2DevicePollingInterval { get; init; }
    public List<object?>? oauthClients { get; init; }
    public long? offlineSessionIdleTimeout { get; init; }
    public long? offlineSessionMaxLifespan { get; init; }
    public bool? offlineSessionMaxLifespanEnabled { get; init; }
    public string? otpPolicyAlgorithm { get; init; }
    public bool? otpPolicyCodeReusable { get; init; }
    public long? otpPolicyDigits { get; init; }
    public long? otpPolicyInitialCounter { get; init; }
    public long? otpPolicyLookAheadWindow { get; init; }
    public long? otpPolicyPeriod { get; init; }
    public string? otpPolicyType { get; init; }
    public List<object?>? otpSupportedApplications { get; init; }
    public bool? passwordCredentialGrantAllowed { get; init; }
    public string? passwordPolicy { get; init; }
    public bool? permanentLockout { get; init; }
    public string? privateKey { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public string? publicKey { get; init; }
    public long? quickLoginCheckMilliSeconds { get; init; }
    public string? realm { get; init; }
    public bool? realmCacheEnabled { get; init; }
    public long? refreshTokenMaxReuse { get; init; }
    public bool? registrationAllowed { get; init; }
    public bool? registrationEmailAsUsername { get; init; }
    public string? registrationFlow { get; init; }
    public bool? rememberMe { get; init; }
    public List<object?>? requiredActions { get; init; }
    public List<object?>? requiredCredentials { get; init; }
    public string? resetCredentialsFlow { get; init; }
    public bool? resetPasswordAllowed { get; init; }
    public bool? revokeRefreshToken { get; init; }
    public Dictionary<string, object?>? roles { get; init; }
    public List<object?>? scopeMappings { get; init; }
    public Dictionary<string, object?>? smtpServer { get; init; }
    public bool? social { get; init; }
    public Dictionary<string, object?>? socialProviders { get; init; }
    public string? sslRequired { get; init; }
    public long? ssoSessionIdleTimeout { get; init; }
    public long? ssoSessionIdleTimeoutRememberMe { get; init; }
    public long? ssoSessionMaxLifespan { get; init; }
    public long? ssoSessionMaxLifespanRememberMe { get; init; }
    public List<object?>? supportedLocales { get; init; }
    public bool? updateProfileOnInitialSocialLogin { get; init; }
    public bool? userCacheEnabled { get; init; }
    public List<object?>? userFederationMappers { get; init; }
    public List<object?>? userFederationProviders { get; init; }
    public bool? userManagedAccessAllowed { get; init; }
    public List<object?>? users { get; init; }
    public bool? verifyEmail { get; init; }
    public long? waitIncrementSeconds { get; init; }
    public List<object?>? webAuthnPolicyAcceptableAaguids { get; init; }
    public string? webAuthnPolicyAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyExtraOrigins { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessAcceptableAaguids { get; init; }
    public string? webAuthnPolicyPasswordlessAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyPasswordlessAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyPasswordlessCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessExtraOrigins { get; init; }
    public string? webAuthnPolicyPasswordlessRequireResidentKey { get; init; }
    public string? webAuthnPolicyPasswordlessRpEntityName { get; init; }
    public string? webAuthnPolicyPasswordlessRpId { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessSignatureAlgorithms { get; init; }
    public string? webAuthnPolicyPasswordlessUserVerificationRequirement { get; init; }
    public string? webAuthnPolicyRequireResidentKey { get; init; }
    public string? webAuthnPolicyRpEntityName { get; init; }
    public string? webAuthnPolicyRpId { get; init; }
    public List<object?>? webAuthnPolicySignatureAlgorithms { get; init; }
    public string? webAuthnPolicyUserVerificationRequirement { get; init; }
}

public record GetListMatch
{
    public string? brief_representation { get; init; }
}

public record GetByRealm
{
    public long? accessCodeLifespan { get; init; }
    public long? accessCodeLifespanLogin { get; init; }
    public long? accessCodeLifespanUserAction { get; init; }
    public long? accessTokenLifespan { get; init; }
    public long? accessTokenLifespanForImplicitFlow { get; init; }
    public string? accountTheme { get; init; }
    public long? actionTokenGeneratedByAdminLifespan { get; init; }
    public long? actionTokenGeneratedByUserLifespan { get; init; }
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public string? adminTheme { get; init; }
    public Dictionary<string, object?>? applicationScopeMappings { get; init; }
    public List<object?>? applications { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? authenticationFlows { get; init; }
    public List<object?>? authenticatorConfig { get; init; }
    public string? browserFlow { get; init; }
    public Dictionary<string, object?>? browserSecurityHeaders { get; init; }
    public bool? bruteForceProtected { get; init; }
    public string? certificate { get; init; }
    public string? clientAuthenticationFlow { get; init; }
    public long? clientOfflineSessionIdleTimeout { get; init; }
    public long? clientOfflineSessionMaxLifespan { get; init; }
    public Dictionary<string, object?>? clientPolicies { get; init; }
    public Dictionary<string, object?>? clientProfiles { get; init; }
    public Dictionary<string, object?>? clientScopeMappings { get; init; }
    public List<object?>? clientScopes { get; init; }
    public long? clientSessionIdleTimeout { get; init; }
    public long? clientSessionMaxLifespan { get; init; }
    public List<object?>? clientTemplates { get; init; }
    public List<object?>? clients { get; init; }
    public string? codeSecret { get; init; }
    public Dictionary<string, object?>? components { get; init; }
    public List<object?>? defaultDefaultClientScopes { get; init; }
    public List<object?>? defaultGroups { get; init; }
    public string? defaultLocale { get; init; }
    public List<object?>? defaultOptionalClientScopes { get; init; }
    public Dictionary<string, object?>? defaultRole { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? defaultSignatureAlgorithm { get; init; }
    public string? directGrantFlow { get; init; }
    public string? displayName { get; init; }
    public string? displayNameHtml { get; init; }
    public string? dockerAuthenticationFlow { get; init; }
    public bool? duplicateEmailsAllowed { get; init; }
    public bool? editUsernameAllowed { get; init; }
    public string? emailTheme { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public long? failureFactor { get; init; }
    public List<object?>? federatedUsers { get; init; }
    public List<object?>? groups { get; init; }
    public string? id { get; init; }
    public List<object?>? identityProviderMappers { get; init; }
    public List<object?>? identityProviders { get; init; }
    public bool? internationalizationEnabled { get; init; }
    public string? keycloakVersion { get; init; }
    public Dictionary<string, object?>? localizationTexts { get; init; }
    public string? loginTheme { get; init; }
    public bool? loginWithEmailAllowed { get; init; }
    public long? maxDeltaTimeSeconds { get; init; }
    public long? maxFailureWaitSeconds { get; init; }
    public long? minimumQuickLoginWaitSeconds { get; init; }
    public long? notBefore { get; init; }
    public long? oAuth2DeviceCodeLifespan { get; init; }
    public long? oAuth2DevicePollingInterval { get; init; }
    public long? oauth2DeviceCodeLifespan { get; init; }
    public long? oauth2DevicePollingInterval { get; init; }
    public List<object?>? oauthClients { get; init; }
    public long? offlineSessionIdleTimeout { get; init; }
    public long? offlineSessionMaxLifespan { get; init; }
    public bool? offlineSessionMaxLifespanEnabled { get; init; }
    public string? otpPolicyAlgorithm { get; init; }
    public bool? otpPolicyCodeReusable { get; init; }
    public long? otpPolicyDigits { get; init; }
    public long? otpPolicyInitialCounter { get; init; }
    public long? otpPolicyLookAheadWindow { get; init; }
    public long? otpPolicyPeriod { get; init; }
    public string? otpPolicyType { get; init; }
    public List<object?>? otpSupportedApplications { get; init; }
    public bool? passwordCredentialGrantAllowed { get; init; }
    public string? passwordPolicy { get; init; }
    public bool? permanentLockout { get; init; }
    public string? privateKey { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public string? publicKey { get; init; }
    public long? quickLoginCheckMilliSeconds { get; init; }
    public string? realm { get; init; }
    public bool? realmCacheEnabled { get; init; }
    public long? refreshTokenMaxReuse { get; init; }
    public bool? registrationAllowed { get; init; }
    public bool? registrationEmailAsUsername { get; init; }
    public string? registrationFlow { get; init; }
    public bool? rememberMe { get; init; }
    public List<object?>? requiredActions { get; init; }
    public List<object?>? requiredCredentials { get; init; }
    public string? resetCredentialsFlow { get; init; }
    public bool? resetPasswordAllowed { get; init; }
    public bool? revokeRefreshToken { get; init; }
    public Dictionary<string, object?>? roles { get; init; }
    public List<object?>? scopeMappings { get; init; }
    public Dictionary<string, object?>? smtpServer { get; init; }
    public bool? social { get; init; }
    public Dictionary<string, object?>? socialProviders { get; init; }
    public string? sslRequired { get; init; }
    public long? ssoSessionIdleTimeout { get; init; }
    public long? ssoSessionIdleTimeoutRememberMe { get; init; }
    public long? ssoSessionMaxLifespan { get; init; }
    public long? ssoSessionMaxLifespanRememberMe { get; init; }
    public List<object?>? supportedLocales { get; init; }
    public bool? updateProfileOnInitialSocialLogin { get; init; }
    public bool? userCacheEnabled { get; init; }
    public List<object?>? userFederationMappers { get; init; }
    public List<object?>? userFederationProviders { get; init; }
    public bool? userManagedAccessAllowed { get; init; }
    public List<object?>? users { get; init; }
    public bool? verifyEmail { get; init; }
    public long? waitIncrementSeconds { get; init; }
    public List<object?>? webAuthnPolicyAcceptableAaguids { get; init; }
    public string? webAuthnPolicyAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyExtraOrigins { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessAcceptableAaguids { get; init; }
    public string? webAuthnPolicyPasswordlessAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyPasswordlessAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyPasswordlessCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessExtraOrigins { get; init; }
    public string? webAuthnPolicyPasswordlessRequireResidentKey { get; init; }
    public string? webAuthnPolicyPasswordlessRpEntityName { get; init; }
    public string? webAuthnPolicyPasswordlessRpId { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessSignatureAlgorithms { get; init; }
    public string? webAuthnPolicyPasswordlessUserVerificationRequirement { get; init; }
    public string? webAuthnPolicyRequireResidentKey { get; init; }
    public string? webAuthnPolicyRpEntityName { get; init; }
    public string? webAuthnPolicyRpId { get; init; }
    public List<object?>? webAuthnPolicySignatureAlgorithms { get; init; }
    public string? webAuthnPolicyUserVerificationRequirement { get; init; }
}

public record GetByRealmListMatch
{
    public string id { get; init; }
}

public record GlobalRequestResult
{
    public List<object?>? failedRequests { get; init; }
    public List<object?>? successRequests { get; init; }
}

public record GlobalRequestResultListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
}

public record GlobalRequestResultCreateData
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public List<object?>? failedRequests { get; init; }
    public List<object?>? successRequests { get; init; }
}

public record Granted
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record GrantedListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string scope_mapping_id { get; init; }
    public string? scope { get; init; }
}

public record Group
{
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? path { get; init; }
    public List<object?>? realmRoles { get; init; }
    public long? subGroupCount { get; init; }
    public List<object?>? subGroups { get; init; }
}

public record GroupLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record GroupListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? role_name { get; init; }
    public string? brief_representation { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? user_id { get; init; }
    public string? search { get; init; }
    public string? exact { get; init; }
    public string? populate_hierarchy { get; init; }
    public string? q { get; init; }
}

public record GroupCreateData
{
    public string realm { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? path { get; init; }
    public List<object?>? realmRoles { get; init; }
    public long? subGroupCount { get; init; }
    public List<object?>? subGroups { get; init; }
}

public record GroupUpdateData
{
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? path { get; init; }
    public List<object?>? realmRoles { get; init; }
    public long? subGroupCount { get; init; }
    public List<object?>? subGroups { get; init; }
}

public record GroupRemoveMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record GroupRepresentation
{
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? parentId { get; init; }
    public string? path { get; init; }
    public List<object?>? realmRoles { get; init; }
    public long? subGroupCount { get; init; }
    public List<object?>? subGroups { get; init; }
}

public record GroupRepresentationLoadMatch
{
    public string path { get; init; }
    public string realm { get; init; }
}

public record GroupRepresentationListMatch
{
    public string realm { get; init; }
}

public record IdToken
{
    public string? acr { get; init; }
    public Dictionary<string, object?>? address { get; init; }
    public string? at_hash { get; init; }
    public long? authTime { get; init; }
    public long? auth_time { get; init; }
    public string? azp { get; init; }
    public string? birthdate { get; init; }
    public string? c_hash { get; init; }
    public string? claims_locales { get; init; }
    public string? email { get; init; }
    public bool? email_verified { get; init; }
    public long? exp { get; init; }
    public string? family_name { get; init; }
    public string? gender { get; init; }
    public string? given_name { get; init; }
    public long? iat { get; init; }
    public string? iss { get; init; }
    public string? jti { get; init; }
    public string? locale { get; init; }
    public string? middle_name { get; init; }
    public string? name { get; init; }
    public long? nbf { get; init; }
    public string? nickname { get; init; }
    public string? nonce { get; init; }
    public Dictionary<string, object?>? otherClaims { get; init; }
    public string? phone_number { get; init; }
    public bool? phone_number_verified { get; init; }
    public string? picture { get; init; }
    public string? preferred_username { get; init; }
    public string? profile { get; init; }
    public string? s_hash { get; init; }
    public string? session_state { get; init; }
    public string? sid { get; init; }
    public string? sub { get; init; }
    public string? typ { get; init; }
    public long? updated_at { get; init; }
    public string? website { get; init; }
    public string? zoneinfo { get; init; }
}

public record IdTokenLoadMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? scope { get; init; }
    public string? user_id { get; init; }
}

public record IdentityProvider
{
    public bool? addReadTokenRoleOnCreate { get; init; }
    public string? alias { get; init; }
    public bool? authenticateByDefault { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? firstBrokerLoginFlowAlias { get; init; }
    public string? id { get; init; }
    public string? identityProviderAlias { get; init; }
    public string? identityProviderMapper { get; init; }
    public string? internalId { get; init; }
    public bool? linkOnly { get; init; }
    public string? name { get; init; }
    public string? postBrokerLoginFlowAlias { get; init; }
    public string? providerId { get; init; }
    public bool? storeToken { get; init; }
    public bool? trustEmail { get; init; }
    public bool? updateProfileFirstLogin { get; init; }
    public string? updateProfileFirstLoginMode { get; init; }
}

public record IdentityProviderLoadMatch
{
    public string? alia { get; init; }
    public string realm { get; init; }
    public string? format { get; init; }
    public string? id { get; init; }
}

public record IdentityProviderCreateData
{
    public string alia { get; init; }
    public string realm { get; init; }
    public bool? addReadTokenRoleOnCreate { get; init; }
    public string? alias { get; init; }
    public bool? authenticateByDefault { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? firstBrokerLoginFlowAlias { get; init; }
    public string? id { get; init; }
    public string? identityProviderAlias { get; init; }
    public string? identityProviderMapper { get; init; }
    public string? internalId { get; init; }
    public bool? linkOnly { get; init; }
    public string? name { get; init; }
    public string? postBrokerLoginFlowAlias { get; init; }
    public string? providerId { get; init; }
    public bool? storeToken { get; init; }
    public bool? trustEmail { get; init; }
    public bool? updateProfileFirstLogin { get; init; }
    public string? updateProfileFirstLoginMode { get; init; }
}

public record IdentityProviderUpdateData
{
    public string alia { get; init; }
    public string? id { get; init; }
    public string realm { get; init; }
    public bool? addReadTokenRoleOnCreate { get; init; }
    public string? alias { get; init; }
    public bool? authenticateByDefault { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? firstBrokerLoginFlowAlias { get; init; }
    public string? identityProviderAlias { get; init; }
    public string? identityProviderMapper { get; init; }
    public string? internalId { get; init; }
    public bool? linkOnly { get; init; }
    public string? name { get; init; }
    public string? postBrokerLoginFlowAlias { get; init; }
    public string? providerId { get; init; }
    public bool? storeToken { get; init; }
    public bool? trustEmail { get; init; }
    public bool? updateProfileFirstLogin { get; init; }
    public string? updateProfileFirstLoginMode { get; init; }
}

public record IdentityProviderRemoveMatch
{
    public string alia { get; init; }
    public string? id { get; init; }
    public string realm { get; init; }
}

public record IdentityProviderMapperRepresentation
{
    public Dictionary<string, object?>? config { get; init; }
    public string? id { get; init; }
    public string? identityProviderAlias { get; init; }
    public string? identityProviderMapper { get; init; }
    public string? name { get; init; }
}

public record IdentityProviderMapperRepresentationLoadMatch
{
    public string alia { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
}

public record IdentityProviderMapperRepresentationListMatch
{
    public string alia { get; init; }
    public string realm { get; init; }
}

public record IdentityProviderRepresentation
{
    public bool? addReadTokenRoleOnCreate { get; init; }
    public string? alias { get; init; }
    public bool? authenticateByDefault { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public string? displayName { get; init; }
    public bool? enabled { get; init; }
    public string? firstBrokerLoginFlowAlias { get; init; }
    public string? internalId { get; init; }
    public bool? linkOnly { get; init; }
    public string? postBrokerLoginFlowAlias { get; init; }
    public string? providerId { get; init; }
    public bool? storeToken { get; init; }
    public bool? trustEmail { get; init; }
    public bool? updateProfileFirstLogin { get; init; }
    public string? updateProfileFirstLoginMode { get; init; }
}

public record IdentityProviderRepresentationLoadMatch
{
    public string alia { get; init; }
    public string realm { get; init; }
}

public record IdentityProviderRepresentationListMatch
{
    public string realm { get; init; }
    public string? brief_representation { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? search { get; init; }
}

public record Key
{
    public string? algorithm { get; init; }
    public string? certificate { get; init; }
    public string? kid { get; init; }
    public string? providerId { get; init; }
    public long? providerPriority { get; init; }
    public string? publicKey { get; init; }
    public string? status { get; init; }
    public string? type { get; init; }
    public Dictionary<string, object?>? use { get; init; }
    public long? validTo { get; init; }
}

public record KeyListMatch
{
    public string realm { get; init; }
}

public record ManagementPermissionReference
{
    public bool? enabled { get; init; }
    public string? resource { get; init; }
    public Dictionary<string, object?>? scopePermissions { get; init; }
}

public record ManagementPermissionReferenceLoadMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? role_name { get; init; }
    public string? group_id { get; init; }
    public string? instance_id { get; init; }
    public string? roles_by_id_id { get; init; }
}

public record ManagementPermissionReferenceUpdateData
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? role_name { get; init; }
    public string? group_id { get; init; }
    public string? instance_id { get; init; }
    public string? roles_by_id_id { get; init; }
    public bool? enabled { get; init; }
    public string? resource { get; init; }
    public Dictionary<string, object?>? scopePermissions { get; init; }
}

public record MappingsRepresentation
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record MappingsRepresentationListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public string? group_id { get; init; }
    public string? user_id { get; init; }
}

public record NotGranted
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record NotGrantedListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string scope_mapping_id { get; init; }
    public string? scope { get; init; }
}

public record Post();

public record PostCreateData();

public record Protocol
{
    public Dictionary<string, object?>? config { get; init; }
    public bool? consentRequired { get; init; }
    public string? consentText { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public string? protocolMapper { get; init; }
}

public record ProtocolLoadMatch
{
    public string? client_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
}

public record ProtocolMapper
{
    public Dictionary<string, object?>? config { get; init; }
    public bool? consentRequired { get; init; }
    public string? consentText { get; init; }
    public string? containerId { get; init; }
    public string? containerName { get; init; }
    public string? containerType { get; init; }
    public string? id { get; init; }
    public string? mapperId { get; init; }
    public string? mapperName { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public string? protocolMapper { get; init; }
}

public record ProtocolMapperListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? scope { get; init; }
}

public record ProtocolMapperCreateData
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? consentRequired { get; init; }
    public string? consentText { get; init; }
    public string? containerId { get; init; }
    public string? containerName { get; init; }
    public string? containerType { get; init; }
    public string? id { get; init; }
    public string? mapperId { get; init; }
    public string? mapperName { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public string? protocolMapper { get; init; }
}

public record ProtocolMapperUpdateData
{
    public string? client_id { get; init; }
    public string id2 { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? consentRequired { get; init; }
    public string? consentText { get; init; }
    public string? containerId { get; init; }
    public string? containerName { get; init; }
    public string? containerType { get; init; }
    public string? id { get; init; }
    public string? mapperId { get; init; }
    public string? mapperName { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public string? protocolMapper { get; init; }
}

public record ProtocolMapperRemoveMatch
{
    public string? client_id { get; init; }
    public string id2 { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
}

public record ProtocolMapperRepresentation
{
    public Dictionary<string, object?>? config { get; init; }
    public bool? consentRequired { get; init; }
    public string? consentText { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public string? protocol { get; init; }
    public string? protocolMapper { get; init; }
}

public record ProtocolMapperRepresentationLoadMatch
{
    public string? client_id { get; init; }
    public string id2 { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
}

public record ProtocolMapperRepresentationListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
}

public record PutByRealm
{
    public long? accessCodeLifespan { get; init; }
    public long? accessCodeLifespanLogin { get; init; }
    public long? accessCodeLifespanUserAction { get; init; }
    public long? accessTokenLifespan { get; init; }
    public long? accessTokenLifespanForImplicitFlow { get; init; }
    public string? accountTheme { get; init; }
    public long? actionTokenGeneratedByAdminLifespan { get; init; }
    public long? actionTokenGeneratedByUserLifespan { get; init; }
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public string? adminTheme { get; init; }
    public Dictionary<string, object?>? applicationScopeMappings { get; init; }
    public List<object?>? applications { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? authenticationFlows { get; init; }
    public List<object?>? authenticatorConfig { get; init; }
    public string? browserFlow { get; init; }
    public Dictionary<string, object?>? browserSecurityHeaders { get; init; }
    public bool? bruteForceProtected { get; init; }
    public string? certificate { get; init; }
    public string? clientAuthenticationFlow { get; init; }
    public long? clientOfflineSessionIdleTimeout { get; init; }
    public long? clientOfflineSessionMaxLifespan { get; init; }
    public Dictionary<string, object?>? clientPolicies { get; init; }
    public Dictionary<string, object?>? clientProfiles { get; init; }
    public Dictionary<string, object?>? clientScopeMappings { get; init; }
    public List<object?>? clientScopes { get; init; }
    public long? clientSessionIdleTimeout { get; init; }
    public long? clientSessionMaxLifespan { get; init; }
    public List<object?>? clientTemplates { get; init; }
    public List<object?>? clients { get; init; }
    public string? codeSecret { get; init; }
    public Dictionary<string, object?>? components { get; init; }
    public List<object?>? defaultDefaultClientScopes { get; init; }
    public List<object?>? defaultGroups { get; init; }
    public string? defaultLocale { get; init; }
    public List<object?>? defaultOptionalClientScopes { get; init; }
    public Dictionary<string, object?>? defaultRole { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? defaultSignatureAlgorithm { get; init; }
    public string? directGrantFlow { get; init; }
    public string? displayName { get; init; }
    public string? displayNameHtml { get; init; }
    public string? dockerAuthenticationFlow { get; init; }
    public bool? duplicateEmailsAllowed { get; init; }
    public bool? editUsernameAllowed { get; init; }
    public string? emailTheme { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public long? failureFactor { get; init; }
    public List<object?>? federatedUsers { get; init; }
    public List<object?>? groups { get; init; }
    public string? id { get; init; }
    public List<object?>? identityProviderMappers { get; init; }
    public List<object?>? identityProviders { get; init; }
    public bool? internationalizationEnabled { get; init; }
    public string? keycloakVersion { get; init; }
    public Dictionary<string, object?>? localizationTexts { get; init; }
    public string? loginTheme { get; init; }
    public bool? loginWithEmailAllowed { get; init; }
    public long? maxDeltaTimeSeconds { get; init; }
    public long? maxFailureWaitSeconds { get; init; }
    public long? minimumQuickLoginWaitSeconds { get; init; }
    public long? notBefore { get; init; }
    public long? oAuth2DeviceCodeLifespan { get; init; }
    public long? oAuth2DevicePollingInterval { get; init; }
    public long? oauth2DeviceCodeLifespan { get; init; }
    public long? oauth2DevicePollingInterval { get; init; }
    public List<object?>? oauthClients { get; init; }
    public long? offlineSessionIdleTimeout { get; init; }
    public long? offlineSessionMaxLifespan { get; init; }
    public bool? offlineSessionMaxLifespanEnabled { get; init; }
    public string? otpPolicyAlgorithm { get; init; }
    public bool? otpPolicyCodeReusable { get; init; }
    public long? otpPolicyDigits { get; init; }
    public long? otpPolicyInitialCounter { get; init; }
    public long? otpPolicyLookAheadWindow { get; init; }
    public long? otpPolicyPeriod { get; init; }
    public string? otpPolicyType { get; init; }
    public List<object?>? otpSupportedApplications { get; init; }
    public bool? passwordCredentialGrantAllowed { get; init; }
    public string? passwordPolicy { get; init; }
    public bool? permanentLockout { get; init; }
    public string? privateKey { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public string? publicKey { get; init; }
    public long? quickLoginCheckMilliSeconds { get; init; }
    public string? realm { get; init; }
    public bool? realmCacheEnabled { get; init; }
    public long? refreshTokenMaxReuse { get; init; }
    public bool? registrationAllowed { get; init; }
    public bool? registrationEmailAsUsername { get; init; }
    public string? registrationFlow { get; init; }
    public bool? rememberMe { get; init; }
    public List<object?>? requiredActions { get; init; }
    public List<object?>? requiredCredentials { get; init; }
    public string? resetCredentialsFlow { get; init; }
    public bool? resetPasswordAllowed { get; init; }
    public bool? revokeRefreshToken { get; init; }
    public Dictionary<string, object?>? roles { get; init; }
    public List<object?>? scopeMappings { get; init; }
    public Dictionary<string, object?>? smtpServer { get; init; }
    public bool? social { get; init; }
    public Dictionary<string, object?>? socialProviders { get; init; }
    public string? sslRequired { get; init; }
    public long? ssoSessionIdleTimeout { get; init; }
    public long? ssoSessionIdleTimeoutRememberMe { get; init; }
    public long? ssoSessionMaxLifespan { get; init; }
    public long? ssoSessionMaxLifespanRememberMe { get; init; }
    public List<object?>? supportedLocales { get; init; }
    public bool? updateProfileOnInitialSocialLogin { get; init; }
    public bool? userCacheEnabled { get; init; }
    public List<object?>? userFederationMappers { get; init; }
    public List<object?>? userFederationProviders { get; init; }
    public bool? userManagedAccessAllowed { get; init; }
    public List<object?>? users { get; init; }
    public bool? verifyEmail { get; init; }
    public long? waitIncrementSeconds { get; init; }
    public List<object?>? webAuthnPolicyAcceptableAaguids { get; init; }
    public string? webAuthnPolicyAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyExtraOrigins { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessAcceptableAaguids { get; init; }
    public string? webAuthnPolicyPasswordlessAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyPasswordlessAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyPasswordlessCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessExtraOrigins { get; init; }
    public string? webAuthnPolicyPasswordlessRequireResidentKey { get; init; }
    public string? webAuthnPolicyPasswordlessRpEntityName { get; init; }
    public string? webAuthnPolicyPasswordlessRpId { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessSignatureAlgorithms { get; init; }
    public string? webAuthnPolicyPasswordlessUserVerificationRequirement { get; init; }
    public string? webAuthnPolicyRequireResidentKey { get; init; }
    public string? webAuthnPolicyRpEntityName { get; init; }
    public string? webAuthnPolicyRpId { get; init; }
    public List<object?>? webAuthnPolicySignatureAlgorithms { get; init; }
    public string? webAuthnPolicyUserVerificationRequirement { get; init; }
}

public record PutByRealmUpdateData
{
    public string id { get; init; }
    public long? accessCodeLifespan { get; init; }
    public long? accessCodeLifespanLogin { get; init; }
    public long? accessCodeLifespanUserAction { get; init; }
    public long? accessTokenLifespan { get; init; }
    public long? accessTokenLifespanForImplicitFlow { get; init; }
    public string? accountTheme { get; init; }
    public long? actionTokenGeneratedByAdminLifespan { get; init; }
    public long? actionTokenGeneratedByUserLifespan { get; init; }
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public string? adminTheme { get; init; }
    public Dictionary<string, object?>? applicationScopeMappings { get; init; }
    public List<object?>? applications { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? authenticationFlows { get; init; }
    public List<object?>? authenticatorConfig { get; init; }
    public string? browserFlow { get; init; }
    public Dictionary<string, object?>? browserSecurityHeaders { get; init; }
    public bool? bruteForceProtected { get; init; }
    public string? certificate { get; init; }
    public string? clientAuthenticationFlow { get; init; }
    public long? clientOfflineSessionIdleTimeout { get; init; }
    public long? clientOfflineSessionMaxLifespan { get; init; }
    public Dictionary<string, object?>? clientPolicies { get; init; }
    public Dictionary<string, object?>? clientProfiles { get; init; }
    public Dictionary<string, object?>? clientScopeMappings { get; init; }
    public List<object?>? clientScopes { get; init; }
    public long? clientSessionIdleTimeout { get; init; }
    public long? clientSessionMaxLifespan { get; init; }
    public List<object?>? clientTemplates { get; init; }
    public List<object?>? clients { get; init; }
    public string? codeSecret { get; init; }
    public Dictionary<string, object?>? components { get; init; }
    public List<object?>? defaultDefaultClientScopes { get; init; }
    public List<object?>? defaultGroups { get; init; }
    public string? defaultLocale { get; init; }
    public List<object?>? defaultOptionalClientScopes { get; init; }
    public Dictionary<string, object?>? defaultRole { get; init; }
    public List<object?>? defaultRoles { get; init; }
    public string? defaultSignatureAlgorithm { get; init; }
    public string? directGrantFlow { get; init; }
    public string? displayName { get; init; }
    public string? displayNameHtml { get; init; }
    public string? dockerAuthenticationFlow { get; init; }
    public bool? duplicateEmailsAllowed { get; init; }
    public bool? editUsernameAllowed { get; init; }
    public string? emailTheme { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public long? failureFactor { get; init; }
    public List<object?>? federatedUsers { get; init; }
    public List<object?>? groups { get; init; }
    public List<object?>? identityProviderMappers { get; init; }
    public List<object?>? identityProviders { get; init; }
    public bool? internationalizationEnabled { get; init; }
    public string? keycloakVersion { get; init; }
    public Dictionary<string, object?>? localizationTexts { get; init; }
    public string? loginTheme { get; init; }
    public bool? loginWithEmailAllowed { get; init; }
    public long? maxDeltaTimeSeconds { get; init; }
    public long? maxFailureWaitSeconds { get; init; }
    public long? minimumQuickLoginWaitSeconds { get; init; }
    public long? notBefore { get; init; }
    public long? oAuth2DeviceCodeLifespan { get; init; }
    public long? oAuth2DevicePollingInterval { get; init; }
    public long? oauth2DeviceCodeLifespan { get; init; }
    public long? oauth2DevicePollingInterval { get; init; }
    public List<object?>? oauthClients { get; init; }
    public long? offlineSessionIdleTimeout { get; init; }
    public long? offlineSessionMaxLifespan { get; init; }
    public bool? offlineSessionMaxLifespanEnabled { get; init; }
    public string? otpPolicyAlgorithm { get; init; }
    public bool? otpPolicyCodeReusable { get; init; }
    public long? otpPolicyDigits { get; init; }
    public long? otpPolicyInitialCounter { get; init; }
    public long? otpPolicyLookAheadWindow { get; init; }
    public long? otpPolicyPeriod { get; init; }
    public string? otpPolicyType { get; init; }
    public List<object?>? otpSupportedApplications { get; init; }
    public bool? passwordCredentialGrantAllowed { get; init; }
    public string? passwordPolicy { get; init; }
    public bool? permanentLockout { get; init; }
    public string? privateKey { get; init; }
    public List<object?>? protocolMappers { get; init; }
    public string? publicKey { get; init; }
    public long? quickLoginCheckMilliSeconds { get; init; }
    public string? realm { get; init; }
    public bool? realmCacheEnabled { get; init; }
    public long? refreshTokenMaxReuse { get; init; }
    public bool? registrationAllowed { get; init; }
    public bool? registrationEmailAsUsername { get; init; }
    public string? registrationFlow { get; init; }
    public bool? rememberMe { get; init; }
    public List<object?>? requiredActions { get; init; }
    public List<object?>? requiredCredentials { get; init; }
    public string? resetCredentialsFlow { get; init; }
    public bool? resetPasswordAllowed { get; init; }
    public bool? revokeRefreshToken { get; init; }
    public Dictionary<string, object?>? roles { get; init; }
    public List<object?>? scopeMappings { get; init; }
    public Dictionary<string, object?>? smtpServer { get; init; }
    public bool? social { get; init; }
    public Dictionary<string, object?>? socialProviders { get; init; }
    public string? sslRequired { get; init; }
    public long? ssoSessionIdleTimeout { get; init; }
    public long? ssoSessionIdleTimeoutRememberMe { get; init; }
    public long? ssoSessionMaxLifespan { get; init; }
    public long? ssoSessionMaxLifespanRememberMe { get; init; }
    public List<object?>? supportedLocales { get; init; }
    public bool? updateProfileOnInitialSocialLogin { get; init; }
    public bool? userCacheEnabled { get; init; }
    public List<object?>? userFederationMappers { get; init; }
    public List<object?>? userFederationProviders { get; init; }
    public bool? userManagedAccessAllowed { get; init; }
    public List<object?>? users { get; init; }
    public bool? verifyEmail { get; init; }
    public long? waitIncrementSeconds { get; init; }
    public List<object?>? webAuthnPolicyAcceptableAaguids { get; init; }
    public string? webAuthnPolicyAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyExtraOrigins { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessAcceptableAaguids { get; init; }
    public string? webAuthnPolicyPasswordlessAttestationConveyancePreference { get; init; }
    public string? webAuthnPolicyPasswordlessAuthenticatorAttachment { get; init; }
    public bool? webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; init; }
    public long? webAuthnPolicyPasswordlessCreateTimeout { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessExtraOrigins { get; init; }
    public string? webAuthnPolicyPasswordlessRequireResidentKey { get; init; }
    public string? webAuthnPolicyPasswordlessRpEntityName { get; init; }
    public string? webAuthnPolicyPasswordlessRpId { get; init; }
    public List<object?>? webAuthnPolicyPasswordlessSignatureAlgorithms { get; init; }
    public string? webAuthnPolicyPasswordlessUserVerificationRequirement { get; init; }
    public string? webAuthnPolicyRequireResidentKey { get; init; }
    public string? webAuthnPolicyRpEntityName { get; init; }
    public string? webAuthnPolicyRpId { get; init; }
    public List<object?>? webAuthnPolicySignatureAlgorithms { get; init; }
    public string? webAuthnPolicyUserVerificationRequirement { get; init; }
}

public record Realm
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RealmListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? role_name { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public string? group_id { get; init; }
    public string? roles_by_id_id { get; init; }
    public string? user_id { get; init; }
}

public record RealmEventsConfigRepresentation
{
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
}

public record RealmEventsConfigRepresentationListMatch
{
    public string realm { get; init; }
}

public record RealmsAdmin
{
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public List<object?>? globalProfiles { get; init; }
    public string? id { get; init; }
    public List<object?>? policies { get; init; }
    public List<object?>? profiles { get; init; }
}

public record RealmsAdminLoadMatch
{
    public string? key { get; init; }
    public string locale { get; init; }
    public string realm { get; init; }
    public string? use_realm_default_locale_fallback { get; init; }
}

public record RealmsAdminListMatch
{
    public string realm { get; init; }
}

public record RealmsAdminCreateData
{
    public string? locale { get; init; }
    public string realm { get; init; }
    public string? export_client { get; init; }
    public string? export_groups_and_role { get; init; }
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public List<object?>? globalProfiles { get; init; }
    public string? id { get; init; }
    public List<object?>? policies { get; init; }
    public List<object?>? profiles { get; init; }
}

public record RealmsAdminUpdateData
{
    public string? key { get; init; }
    public string? locale { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? group_id { get; init; }
    public bool? adminEventsDetailsEnabled { get; init; }
    public bool? adminEventsEnabled { get; init; }
    public List<object?>? enabledEventTypes { get; init; }
    public bool? eventsEnabled { get; init; }
    public long? eventsExpiration { get; init; }
    public List<object?>? eventsListeners { get; init; }
    public List<object?>? globalProfiles { get; init; }
    public string? id { get; init; }
    public List<object?>? policies { get; init; }
    public List<object?>? profiles { get; init; }
}

public record RealmsAdminRemoveMatch
{
    public string? key { get; init; }
    public string? locale { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? group_id { get; init; }
    public string? session { get; init; }
}

public record RequiredAction
{
    public string? alias { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? defaultAction { get; init; }
    public bool? enabled { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public long? priority { get; init; }
    public string? providerId { get; init; }
}

public record RequiredActionLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record RequiredActionListMatch
{
    public string realm { get; init; }
}

public record RequiredActionCreateData
{
    public string alia { get; init; }
    public string realm { get; init; }
    public string? alias { get; init; }
    public Dictionary<string, object?>? config { get; init; }
    public bool? defaultAction { get; init; }
    public bool? enabled { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public long? priority { get; init; }
    public string? providerId { get; init; }
}

public record Role
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RoleLoadMatch
{
    public string? client_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
}

public record RoleListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? brief_representation { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? search { get; init; }
}

public record RoleCreateData
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RoleUpdateData
{
    public string? client_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RoleRemoveMatch
{
    public string? client_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
}

public record RoleMapper
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RoleMapperCreateData
{
    public string? group_id { get; init; }
    public string realm { get; init; }
    public string? user_id { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RoleMapperRemoveMatch
{
    public string? group_id { get; init; }
    public string realm { get; init; }
    public string? user_id { get; init; }
}

public record RolesById
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RolesByIdLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record RolesByIdCreateData
{
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RolesByIdUpdateData
{
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record RolesByIdRemoveMatch
{
    public string id { get; init; }
    public string realm { get; init; }
}

public record ScopeMapping
{
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record ScopeMappingCreateData
{
    public string client { get; init; }
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public bool? clientRole { get; init; }
    public bool? composite { get; init; }
    public Dictionary<string, object?>? composites { get; init; }
    public string? containerId { get; init; }
    public string? description { get; init; }
    public string? id { get; init; }
    public string? name { get; init; }
    public bool? scopeParamRequired { get; init; }
}

public record ScopeMappingRemoveMatch
{
    public string client { get; init; }
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? client_scope_id { get; init; }
    public string? client_template_id { get; init; }
}

public record UpConfig
{
    public List<object?>? attributes { get; init; }
    public List<object?>? groups { get; init; }
}

public record UpConfigListMatch
{
    public string realm { get; init; }
}

public record UpConfigUpdateData
{
    public string realm { get; init; }
    public List<object?>? attributes { get; init; }
    public List<object?>? groups { get; init; }
}

public record User
{
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? applicationRoles { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? clientConsents { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public long? createdTimestamp { get; init; }
    public List<object?>? credentials { get; init; }
    public List<object?>? disableableCredentialTypes { get; init; }
    public string? email { get; init; }
    public bool? emailVerified { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? federatedIdentities { get; init; }
    public string? federationLink { get; init; }
    public string? firstName { get; init; }
    public List<object?>? groups { get; init; }
    public string? id { get; init; }
    public string? lastName { get; init; }
    public long? notBefore { get; init; }
    public string? origin { get; init; }
    public List<object?>? realmRoles { get; init; }
    public List<object?>? requiredActions { get; init; }
    public string? self { get; init; }
    public string? serviceAccountClientId { get; init; }
    public List<object?>? socialLinks { get; init; }
    public bool? totp { get; init; }
    public Dictionary<string, object?>? userProfileMetadata { get; init; }
    public string? username { get; init; }
}

public record UserLoadMatch
{
    public string id { get; init; }
    public string realm { get; init; }
    public string? user_profile_metadata { get; init; }
}

public record UserListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? role_name { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
    public string? brief_representation { get; init; }
    public string? email { get; init; }
    public string? email_verified { get; init; }
    public bool? enabled { get; init; }
    public string? exact { get; init; }
    public string? first_name { get; init; }
    public string? idp_alia { get; init; }
    public string? idp_user_id { get; init; }
    public string? last_name { get; init; }
    public string? q { get; init; }
    public string? search { get; init; }
    public string? username { get; init; }
}

public record UserCreateData
{
    public string? credential_id { get; init; }
    public string? id { get; init; }
    public string? new_previous_credential_id { get; init; }
    public string realm { get; init; }
    public string? provider { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? applicationRoles { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? clientConsents { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public long? createdTimestamp { get; init; }
    public List<object?>? credentials { get; init; }
    public List<object?>? disableableCredentialTypes { get; init; }
    public string? email { get; init; }
    public bool? emailVerified { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? federatedIdentities { get; init; }
    public string? federationLink { get; init; }
    public string? firstName { get; init; }
    public List<object?>? groups { get; init; }
    public string? lastName { get; init; }
    public long? notBefore { get; init; }
    public string? origin { get; init; }
    public List<object?>? realmRoles { get; init; }
    public List<object?>? requiredActions { get; init; }
    public string? self { get; init; }
    public string? serviceAccountClientId { get; init; }
    public List<object?>? socialLinks { get; init; }
    public bool? totp { get; init; }
    public Dictionary<string, object?>? userProfileMetadata { get; init; }
    public string? username { get; init; }
}

public record UserUpdateData
{
    public string? group_id { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? applicationRoles { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? clientConsents { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public long? createdTimestamp { get; init; }
    public List<object?>? credentials { get; init; }
    public List<object?>? disableableCredentialTypes { get; init; }
    public string? email { get; init; }
    public bool? emailVerified { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? federatedIdentities { get; init; }
    public string? federationLink { get; init; }
    public string? firstName { get; init; }
    public List<object?>? groups { get; init; }
    public string? lastName { get; init; }
    public long? notBefore { get; init; }
    public string? origin { get; init; }
    public List<object?>? realmRoles { get; init; }
    public List<object?>? requiredActions { get; init; }
    public string? self { get; init; }
    public string? serviceAccountClientId { get; init; }
    public List<object?>? socialLinks { get; init; }
    public bool? totp { get; init; }
    public Dictionary<string, object?>? userProfileMetadata { get; init; }
    public string? username { get; init; }
}

public record UserRemoveMatch
{
    public string? client { get; init; }
    public string id { get; init; }
    public string realm { get; init; }
    public string? credential_id { get; init; }
    public string? group_id { get; init; }
    public string? provider { get; init; }
}

public record UserRepresentation
{
    public Dictionary<string, object?>? access { get; init; }
    public Dictionary<string, object?>? applicationRoles { get; init; }
    public Dictionary<string, object?>? attributes { get; init; }
    public List<object?>? clientConsents { get; init; }
    public Dictionary<string, object?>? clientRoles { get; init; }
    public long? createdTimestamp { get; init; }
    public List<object?>? credentials { get; init; }
    public List<object?>? disableableCredentialTypes { get; init; }
    public string? email { get; init; }
    public bool? emailVerified { get; init; }
    public bool? enabled { get; init; }
    public List<object?>? federatedIdentities { get; init; }
    public string? federationLink { get; init; }
    public string? firstName { get; init; }
    public List<object?>? groups { get; init; }
    public string? id { get; init; }
    public string? lastName { get; init; }
    public long? notBefore { get; init; }
    public string? origin { get; init; }
    public List<object?>? realmRoles { get; init; }
    public List<object?>? requiredActions { get; init; }
    public string? self { get; init; }
    public string? serviceAccountClientId { get; init; }
    public List<object?>? socialLinks { get; init; }
    public bool? totp { get; init; }
    public Dictionary<string, object?>? userProfileMetadata { get; init; }
    public string? username { get; init; }
}

public record UserRepresentationListMatch
{
    public string? client_id { get; init; }
    public string realm { get; init; }
    public string? group_id { get; init; }
    public string? brief_representation { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
}

public record UserSession
{
    public Dictionary<string, object?>? clients { get; init; }
    public string? id { get; init; }
    public string? ipAddress { get; init; }
    public long? lastAccess { get; init; }
    public bool? rememberMe { get; init; }
    public long? start { get; init; }
    public string? userId { get; init; }
    public string? username { get; init; }
}

public record UserSessionListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
}

public record UserSessionRepresentation
{
    public Dictionary<string, object?>? clients { get; init; }
    public string? id { get; init; }
    public string? ipAddress { get; init; }
    public long? lastAccess { get; init; }
    public bool? rememberMe { get; init; }
    public long? start { get; init; }
    public string? userId { get; init; }
    public string? username { get; init; }
}

public record UserSessionRepresentationLoadMatch
{
    public string client_uuid { get; init; }
    public string realm { get; init; }
    public string user_id { get; init; }
}

public record UserSessionRepresentationListMatch
{
    public string client_id { get; init; }
    public string realm { get; init; }
    public string? first { get; init; }
    public string? max { get; init; }
}

public record UsersManagementPermission
{
    public bool? enabled { get; init; }
    public string? resource { get; init; }
    public Dictionary<string, object?>? scopePermissions { get; init; }
}

public record UsersManagementPermissionLoadMatch
{
    public string realm { get; init; }
}

public record UsersManagementPermissionUpdateData
{
    public string realm { get; init; }
    public bool? enabled { get; init; }
    public string? resource { get; init; }
    public Dictionary<string, object?>? scopePermissions { get; init; }
}

