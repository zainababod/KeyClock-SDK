# VoxgigKeycloakSdk C# SDK



The C# SDK for the VoxgigKeycloakSdk API — an entity-oriented client following idiomatic C# conventions.

The SDK exposes the API as capitalised, semantic **Entities** — for example `client.AccessToken()` — each
carrying a small, uniform set of operations (`list`, `load`, `create`, `update`, `remove`) instead of raw URL
paths and query strings. You work with named resources and verbs, which
keeps the cognitive load low.

> Other languages, the CLI, and MCP server live alongside this one — see
> the [top-level README](../README.md).


## Install
This package is not yet published to NuGet. Install it from the GitHub
release tag (`csharp/vX.Y.Z`, see [Tags](https://github.com/voxgig-sdk/voxgig-keycloak-sdk/tags)) or
from a source checkout — build the library and add a project reference:

```bash
cd csharp && dotnet build VoxgigKeycloakSdkSDK.csproj
```


## Tutorial: your first API call

This tutorial walks through creating a client, listing entities, and
loading a specific record.

### 1. Create a client

```csharp
using VoxgigKeycloakSdkSdk;

var client = new VoxgigKeycloakSdkSDK(new Dictionary<string, object?>
{
    ["apikey"] = Environment.GetEnvironmentVariable("VOXGIG_KEYCLOAK_SDK_APIKEY"),
});
```

### 2. List accesstoken records

`List(null)` returns a list of entities, one per record (as `object?`), and
raises on error.

```csharp
try
{
    var accessTokenList = client.AccessToken().List(null);
    Console.WriteLine(accessTokenList);
}
catch (Exception err)
{
    Console.WriteLine($"list failed: {err.Message}");
}
```

### 3. Load an attackdetection

AttackDetection is nested under realm, so provide the `realm`.
`Load()` returns the entity (as `object?`) and raises on error; an entity's
`Data()` reads its record.

```csharp
try
{
    var attackDetection = client.AttackDetection().Load(new Dictionary<string, object?> { ["realm"] = "example_realm", ["user_id"] = "example_user_id" });
    Console.WriteLine(attackDetection);
}
catch (Exception err)
{
    Console.WriteLine($"load failed: {err.Message}");
}
```


## Error handling

Entity operations reject on failure, so wrap them in `try` / `catch`:

```ts
try {
  const certificate = await client.Certificate().load({ client_id: "example", id: "example_id", realm: "example" })
  console.log(certificate)
} catch (err) {
  console.error('load failed:', err)
}
```

The low-level `direct()` method does **not** throw — it returns the
result envelope. Branch on `ok`; on failure `status` holds the HTTP status
(for error responses) and `err` holds the error:

```ts
const result = await client.direct({
  path: '/api/resource/{id}',
  method: 'GET',
  params: { id: 'example_id' },
})

if (!result.ok) {
  console.error('request failed:', result.status, result.err)
}
```


## How-to guides

### Make a direct HTTP request

For endpoints not covered by entity methods:

```csharp
var result = client.Direct(new Dictionary<string, object?>
{
    ["path"] = "/api/resource/{id}",
    ["method"] = "GET",
    ["params"] = new Dictionary<string, object?> { ["id"] = "example" },
});

if (Equals(result["ok"], true))
{
    Console.WriteLine(result["status"]);  // 200
    Console.WriteLine(result["data"]);    // response body
}
else
{
    // A non-2xx response carries status + data (the error body); a
    // transport-level failure carries err instead. Only one is present, so
    // read both with TryGetValue rather than indexing a key that may be absent.
    result.TryGetValue("status", out var status);
    result.TryGetValue("err", out var err);
    Console.WriteLine($"{status} {err}");
}
```

### Prepare a request without sending it

```csharp
// Prepare() returns the fetch definition and raises on error.
var fetchdef = client.Prepare(new Dictionary<string, object?>
{
    ["path"] = "/api/resource/{id}",
    ["method"] = "DELETE",
    ["params"] = new Dictionary<string, object?> { ["id"] = "example" },
});

Console.WriteLine(fetchdef["url"]);
Console.WriteLine(fetchdef["method"]);
Console.WriteLine(fetchdef["headers"]);
```

### Use test mode

Create a mock client for unit testing — no server required:

```csharp
var client = VoxgigKeycloakSdkSDK.TestSDK(null, null);

// Entity ops return the entity, and List one per record; they raise on error.
var certificate = client.Certificate().Load(new Dictionary<string, object?> { ["id"] = "test01" });
// Data() on an entity reads its mock response record
Console.WriteLine(certificate);
```

### Use a custom fetch function

Replace the HTTP transport with your own delegate:

```csharp
Func<string, Dictionary<string, object?>, Dictionary<string, object?>> mockFetch =
    (url, init) => new Dictionary<string, object?>
    {
        ["status"] = 200,
        ["statusText"] = "OK",
        ["headers"] = new Dictionary<string, object?>(),
        ["json"] = (Func<object?>)(() => new Dictionary<string, object?> { ["id"] = "mock01" }),
    };

var client = new VoxgigKeycloakSdkSDK(new Dictionary<string, object?>
{
    ["base"] = "http://localhost:8080",
    ["system"] = new Dictionary<string, object?>
    {
        ["fetch"] = mockFetch,
    },
});
```

### Run live tests

Create a `.env.local` file at the project root:

```
VOXGIG_KEYCLOAK_SDK_TEST_LIVE=TRUE
VOXGIG_KEYCLOAK_SDK_APIKEY=<your-key>
```

Then run:

```bash
cd csharp && dotnet test
```


## Reference

### VoxgigKeycloakSdkSDK

```csharp
using VoxgigKeycloakSdkSdk;

var client = new VoxgigKeycloakSdkSDK(options);
```

Creates a new SDK client. `options` is a `Dictionary<string, object?>`.

| Option | Type | Description |
| --- | --- | --- |
| `apikey` | `string` | API key for authentication. |
| `base` | `string` | Base URL of the API server. |
| `prefix` | `string` | URL path prefix prepended to all requests. |
| `suffix` | `string` | URL path suffix appended to all requests. |
| `feature` | `Dictionary` | Feature activation flags. |
| `extend` | `List` | Additional Feature instances to load. |
| `system` | `Dictionary` | System overrides (e.g. custom `fetch` delegate). |

### TestSDK

```csharp
var client = VoxgigKeycloakSdkSDK.TestSDK(testopts, sdkopts);
```

Creates a test-mode client with mock transport. Both arguments may be `null`.

### VoxgigKeycloakSdkSDK methods

| Method | Signature | Description |
| --- | --- | --- |
| `OptionsMap` | `() -> Dictionary` | Deep copy of current SDK options. |
| `GetUtility` | `() -> Utility` | Copy of the SDK utility object. |
| `Prepare` | `(fetchargs) -> Dictionary` | Build an HTTP request definition without sending. Raises on error. |
| `Direct` | `(fetchargs) -> Dictionary` | Build and send an HTTP request. Returns a result dictionary (branch on `ok`). |
| `AccessToken` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AccessToken entity instance. |
| `AdminEvent` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AdminEvent entity instance. |
| `AttackDetection` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AttackDetection entity instance. |
| `AuthenticationFlowRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AuthenticationFlowRepresentation entity instance. |
| `AuthenticationManagement` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AuthenticationManagement entity instance. |
| `AuthenticatorConfigInfoRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AuthenticatorConfigInfoRepresentation entity instance. |
| `AuthenticatorConfigRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an AuthenticatorConfigRepresentation entity instance. |
| `Available` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an Available entity instance. |
| `Certificate` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Certificate entity instance. |
| `CertificateRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a CertificateRepresentation entity instance. |
| `Client` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Client entity instance. |
| `ClientInitialAccess` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientInitialAccess entity instance. |
| `ClientInitialAccessPresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientInitialAccessPresentation entity instance. |
| `ClientPolicyRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientPolicyRepresentation entity instance. |
| `ClientProfilesRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientProfilesRepresentation entity instance. |
| `ClientRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientRepresentation entity instance. |
| `ClientScope` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientScope entity instance. |
| `ClientScopeRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ClientScopeRepresentation entity instance. |
| `Component` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Component entity instance. |
| `ComponentTypeRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ComponentTypeRepresentation entity instance. |
| `Composite` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Composite entity instance. |
| `Credential` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Credential entity instance. |
| `CredentialRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a CredentialRepresentation entity instance. |
| `DeleteByRealm` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a DeleteByRealm entity instance. |
| `Event` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an Event entity instance. |
| `FederatedIdentity` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a FederatedIdentity entity instance. |
| `Flow` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Flow entity instance. |
| `Get` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Get entity instance. |
| `GetByRealm` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a GetByRealm entity instance. |
| `GlobalRequestResult` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a GlobalRequestResult entity instance. |
| `Granted` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Granted entity instance. |
| `Group` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Group entity instance. |
| `GroupRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a GroupRepresentation entity instance. |
| `IdToken` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an IdToken entity instance. |
| `IdentityProvider` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an IdentityProvider entity instance. |
| `IdentityProviderMapperRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an IdentityProviderMapperRepresentation entity instance. |
| `IdentityProviderRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an IdentityProviderRepresentation entity instance. |
| `Key` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Key entity instance. |
| `ManagementPermissionReference` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ManagementPermissionReference entity instance. |
| `MappingsRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a MappingsRepresentation entity instance. |
| `NotGranted` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a NotGranted entity instance. |
| `Post` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Post entity instance. |
| `Protocol` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Protocol entity instance. |
| `ProtocolMapper` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ProtocolMapper entity instance. |
| `ProtocolMapperRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ProtocolMapperRepresentation entity instance. |
| `PutByRealm` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a PutByRealm entity instance. |
| `Realm` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Realm entity instance. |
| `RealmEventsConfigRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a RealmEventsConfigRepresentation entity instance. |
| `RealmsAdmin` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a RealmsAdmin entity instance. |
| `RequiredAction` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a RequiredAction entity instance. |
| `Role` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a Role entity instance. |
| `RoleMapper` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a RoleMapper entity instance. |
| `RolesById` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a RolesById entity instance. |
| `ScopeMapping` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create a ScopeMapping entity instance. |
| `UpConfig` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an UpConfig entity instance. |
| `User` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an User entity instance. |
| `UserRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an UserRepresentation entity instance. |
| `UserSession` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an UserSession entity instance. |
| `UserSessionRepresentation` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an UserSessionRepresentation entity instance. |
| `UsersManagementPermission` | `(entopts) -> VoxgigKeycloakSdkEntityBase` | Create an UsersManagementPermission entity instance. |

### Entity interface

All entities share the same interface.

| Method | Signature | Description |
| --- | --- | --- |
| `Load` | `(reqmatch, ctrl) -> object?` | Load a single entity by match criteria, and return it. Raises on error. |
| `List` | `(reqmatch, ctrl) -> object?` | List entities matching the criteria, one per record. Raises on error. |
| `Create` | `(reqdata, ctrl) -> object?` | Create a new entity, and return it. Raises on error. |
| `Update` | `(reqdata, ctrl) -> object?` | Update an existing entity, and return it. Raises on error. |
| `Remove` | `(reqmatch, ctrl) -> object?` | Remove an entity, and return it marked as deleted. Raises on error. |
| `Data` | `(newdata) -> object?` | Get or set entity data. |
| `Match` | `(newmatch) -> object?` | Get or set entity match criteria. |
| `Make` | `() -> IEntity` | Create a new instance with the same options. |
| `GetName` | `() -> string` | Return the entity name. |

### Result shape

Entity operations return the entity, and `List` a list of entities, one per
record, as `object?`; an entity is an `IEntity`, whose `Data()` reads its
record. They raise on error, so wrap calls in `try`/`catch` to handle
failures.

The `Direct()` escape hatch never raises — it returns a result
`Dictionary<string, object?>` you branch on via `result["ok"]`:

| Key | Type | Description |
| --- | --- | --- |
| `ok` | `bool` | `true` if the HTTP status is 2xx. |
| `status` | `int` | HTTP status code. |
| `headers` | `Dictionary` | Response headers. |
| `data` | `object?` | Parsed JSON response body. |

On error, `ok` is `false` and `err` contains the error value.

### Entities

#### AccessToken

| Field | Description |
| --- | --- |
| `acr` |  |
| `address` |  |
| `allowedorigins` |  |
| `at_hash` |  |
| `authTime` |  |
| `auth_time` |  |
| `authorization` |  |
| `azp` |  |
| `birthdate` |  |
| `c_hash` |  |
| `claims_locales` |  |
| `cnf` |  |
| `email` |  |
| `email_verified` |  |
| `exp` |  |
| `family_name` |  |
| `gender` |  |
| `given_name` |  |
| `iat` |  |
| `iss` |  |
| `jti` |  |
| `locale` |  |
| `middle_name` |  |
| `name` |  |
| `nbf` |  |
| `nickname` |  |
| `nonce` |  |
| `otherClaims` |  |
| `phone_number` |  |
| `phone_number_verified` |  |
| `picture` |  |
| `preferred_username` |  |
| `profile` |  |
| `realm_access` |  |
| `resource_access` |  |
| `s_hash` |  |
| `scope` |  |
| `session_state` |  |
| `sid` |  |
| `sub` |  |
| `trustedcerts` |  |
| `typ` |  |
| `updated_at` |  |
| `website` |  |
| `zoneinfo` |  |

Operations: List.

API path: `/{realm}/clients/{id}/evaluate-scopes/generate-example-access-token`

#### AdminEvent

| Field | Description |
| --- | --- |
| `authDetails` |  |
| `error` |  |
| `operationType` |  |
| `realmId` |  |
| `representation` |  |
| `resourcePath` |  |
| `resourceType` |  |
| `time` |  |

Operations: List.

API path: `/{realm}/admin-events`

#### AttackDetection

| Field | Description |
| --- | --- |

Operations: Load, Remove.

API path: `/{realm}/attack-detection/brute-force/users/{userId}`

#### AuthenticationFlowRepresentation

| Field | Description |
| --- | --- |
| `alias` |  |
| `authenticationExecutions` |  |
| `builtIn` |  |
| `description` |  |
| `id` |  |
| `providerId` |  |
| `topLevel` |  |

Operations: List, Load.

API path: `/{realm}/authentication/flows`

#### AuthenticationManagement

| Field | Description |
| --- | --- |
| `alias` |  |
| `authenticationConfig` |  |
| `authenticationExecutions` |  |
| `authenticationFlow` |  |
| `authenticator` |  |
| `authenticatorConfig` |  |
| `authenticatorFlow` |  |
| `autheticatorFlow` |  |
| `builtIn` |  |
| `config` |  |
| `configurable` |  |
| `defaultAction` |  |
| `defaultValue` |  |
| `description` |  |
| `displayName` |  |
| `enabled` |  |
| `flowId` |  |
| `helpText` |  |
| `id` |  |
| `index` |  |
| `label` |  |
| `level` |  |
| `name` |  |
| `options` |  |
| `parentFlow` |  |
| `priority` |  |
| `providerId` |  |
| `readOnly` |  |
| `required` |  |
| `requirement` |  |
| `requirementChoices` |  |
| `secret` |  |
| `topLevel` |  |
| `type` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/authentication/executions/{executionId}/config`

#### AuthenticatorConfigInfoRepresentation

| Field | Description |
| --- | --- |
| `helpText` |  |
| `name` |  |
| `properties` |  |
| `providerId` |  |

Operations: Load.

API path: `/{realm}/authentication/config-description/{providerId}`

#### AuthenticatorConfigRepresentation

| Field | Description |
| --- | --- |
| `alias` |  |
| `config` |  |
| `id` |  |

Operations: Load.

API path: `/{realm}/authentication/executions/{executionId}/config/{id}`

#### Available

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: List.

API path: `/{realm}/clients/{id}/scope-mappings/clients/{client}/available`

#### Certificate

| Field | Description |
| --- | --- |
| `certificate` |  |
| `id` |  |
| `kid` |  |
| `privateKey` |  |
| `publicKey` |  |

Operations: Create, Load.

API path: `/{realm}/clients/{id}/certificates/{attr}/download`

#### CertificateRepresentation

| Field | Description |
| --- | --- |
| `certificate` |  |
| `kid` |  |
| `privateKey` |  |
| `publicKey` |  |

Operations: Create.

API path: `/{realm}/clients/{id}/certificates/{attr}/generate`

#### Client

| Field | Description |
| --- | --- |
| `access` |  |
| `adminUrl` |  |
| `alwaysDisplayInConsole` |  |
| `attributes` |  |
| `authenticationFlowBindingOverrides` |  |
| `authorizationServicesEnabled` |  |
| `authorizationSettings` |  |
| `baseUrl` |  |
| `bearerOnly` |  |
| `clientAuthenticatorType` |  |
| `clientId` |  |
| `clientRole` |  |
| `clientTemplate` |  |
| `composite` |  |
| `composites` |  |
| `consentRequired` |  |
| `containerId` |  |
| `defaultClientScopes` |  |
| `defaultRoles` |  |
| `description` |  |
| `directAccessGrantsEnabled` |  |
| `directGrantsOnly` |  |
| `enabled` |  |
| `frontchannelLogout` |  |
| `fullScopeAllowed` |  |
| `id` |  |
| `implicitFlowEnabled` |  |
| `name` |  |
| `nodeReRegistrationTimeout` |  |
| `notBefore` |  |
| `oauth2DeviceAuthorizationGrantEnabled` |  |
| `optionalClientScopes` |  |
| `origin` |  |
| `protocol` |  |
| `protocolMappers` |  |
| `publicClient` |  |
| `redirectUris` |  |
| `registeredNodes` |  |
| `registrationAccessToken` |  |
| `rootUrl` |  |
| `scopeParamRequired` |  |
| `secret` |  |
| `serviceAccountsEnabled` |  |
| `standardFlowEnabled` |  |
| `surrogateAuthRequired` |  |
| `useTemplateConfig` |  |
| `useTemplateMappers` |  |
| `useTemplateScope` |  |
| `webOrigins` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/groups/{id}/role-mappings/clients/{client}`

#### ClientInitialAccess

| Field | Description |
| --- | --- |
| `id` |  |

Operations: Remove.

API path: `/{realm}/clients-initial-access/{id}`

#### ClientInitialAccessPresentation

| Field | Description |
| --- | --- |
| `count` |  |
| `expiration` |  |
| `id` |  |
| `remainingCount` |  |
| `timestamp` |  |
| `token` |  |

Operations: Create, List.

API path: `/{realm}/clients-initial-access`

#### ClientPolicyRepresentation

| Field | Description |
| --- | --- |
| `conditions` |  |
| `description` |  |
| `enabled` |  |
| `name` |  |
| `profiles` |  |

Operations: List.

API path: `/{realm}/client-policies/policies`

#### ClientProfilesRepresentation

| Field | Description |
| --- | --- |
| `globalProfiles` |  |
| `profiles` |  |

Operations: List.

API path: `/{realm}/client-policies/profiles`

#### ClientRepresentation

| Field | Description |
| --- | --- |
| `access` |  |
| `adminUrl` |  |
| `alwaysDisplayInConsole` |  |
| `attributes` |  |
| `authenticationFlowBindingOverrides` |  |
| `authorizationServicesEnabled` |  |
| `authorizationSettings` |  |
| `baseUrl` |  |
| `bearerOnly` |  |
| `clientAuthenticatorType` |  |
| `clientId` |  |
| `clientTemplate` |  |
| `consentRequired` |  |
| `defaultClientScopes` |  |
| `defaultRoles` |  |
| `description` |  |
| `directAccessGrantsEnabled` |  |
| `directGrantsOnly` |  |
| `enabled` |  |
| `frontchannelLogout` |  |
| `fullScopeAllowed` |  |
| `id` |  |
| `implicitFlowEnabled` |  |
| `name` |  |
| `nodeReRegistrationTimeout` |  |
| `notBefore` |  |
| `oauth2DeviceAuthorizationGrantEnabled` |  |
| `optionalClientScopes` |  |
| `origin` |  |
| `protocol` |  |
| `protocolMappers` |  |
| `publicClient` |  |
| `redirectUris` |  |
| `registeredNodes` |  |
| `registrationAccessToken` |  |
| `rootUrl` |  |
| `secret` |  |
| `serviceAccountsEnabled` |  |
| `standardFlowEnabled` |  |
| `surrogateAuthRequired` |  |
| `useTemplateConfig` |  |
| `useTemplateMappers` |  |
| `useTemplateScope` |  |
| `webOrigins` |  |

Operations: Create.

API path: `/{realm}/clients/{id}/registration-access-token`

#### ClientScope

| Field | Description |
| --- | --- |
| `attributes` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `protocol` |  |
| `protocolMappers` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/client-scopes`

#### ClientScopeRepresentation

| Field | Description |
| --- | --- |
| `attributes` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `protocol` |  |
| `protocolMappers` |  |

Operations: List, Load.

API path: `/{realm}/clients/{id}/default-client-scopes`

#### Component

| Field | Description |
| --- | --- |
| `config` |  |
| `id` |  |
| `name` |  |
| `parentId` |  |
| `providerId` |  |
| `providerType` |  |
| `subType` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/components`

#### ComponentTypeRepresentation

| Field | Description |
| --- | --- |
| `helpText` |  |
| `id` |  |
| `metadata` |  |
| `properties` |  |

Operations: List.

API path: `/{realm}/components/{id}/sub-component-types`

#### Composite

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: List.

API path: `/{realm}/clients/{id}/scope-mappings/clients/{client}/composite`

#### Credential

| Field | Description |
| --- | --- |
| `algorithm` |  |
| `config` |  |
| `counter` |  |
| `createdDate` |  |
| `credentialData` |  |
| `device` |  |
| `digits` |  |
| `hashIterations` |  |
| `hashedSaltedValue` |  |
| `id` |  |
| `period` |  |
| `priority` |  |
| `salt` |  |
| `secretData` |  |
| `temporary` |  |
| `type` |  |
| `userLabel` |  |
| `value` |  |

Operations: List.

API path: `/{realm}/users/{id}/credentials`

#### CredentialRepresentation

| Field | Description |
| --- | --- |
| `algorithm` |  |
| `config` |  |
| `counter` |  |
| `createdDate` |  |
| `credentialData` |  |
| `device` |  |
| `digits` |  |
| `hashIterations` |  |
| `hashedSaltedValue` |  |
| `id` |  |
| `period` |  |
| `priority` |  |
| `salt` |  |
| `secretData` |  |
| `temporary` |  |
| `type` |  |
| `userLabel` |  |
| `value` |  |

Operations: Create, Load.

API path: `/{realm}/clients/{id}/client-secret`

#### DeleteByRealm

| Field | Description |
| --- | --- |
| `id` |  |

Operations: Remove.

API path: `/{realm}`

#### Event

| Field | Description |
| --- | --- |
| `clientId` |  |
| `details` |  |
| `error` |  |
| `ipAddress` |  |
| `realmId` |  |
| `sessionId` |  |
| `time` |  |
| `type` |  |
| `userId` |  |

Operations: List.

API path: `/{realm}/events`

#### FederatedIdentity

| Field | Description |
| --- | --- |
| `identityProvider` |  |
| `userId` |  |
| `userName` |  |

Operations: List.

API path: `/{realm}/users/{id}/federated-identity`

#### Flow

| Field | Description |
| --- | --- |

Operations: Create.

API path: `/{realm}/authentication/flows/{flowAlias}/copy`

#### Get

| Field | Description |
| --- | --- |
| `accessCodeLifespan` |  |
| `accessCodeLifespanLogin` |  |
| `accessCodeLifespanUserAction` |  |
| `accessTokenLifespan` |  |
| `accessTokenLifespanForImplicitFlow` |  |
| `accountTheme` |  |
| `actionTokenGeneratedByAdminLifespan` |  |
| `actionTokenGeneratedByUserLifespan` |  |
| `adminEventsDetailsEnabled` |  |
| `adminEventsEnabled` |  |
| `adminTheme` |  |
| `applicationScopeMappings` |  |
| `applications` |  |
| `attributes` |  |
| `authenticationFlows` |  |
| `authenticatorConfig` |  |
| `browserFlow` |  |
| `browserSecurityHeaders` |  |
| `bruteForceProtected` |  |
| `certificate` |  |
| `clientAuthenticationFlow` |  |
| `clientOfflineSessionIdleTimeout` |  |
| `clientOfflineSessionMaxLifespan` |  |
| `clientPolicies` |  |
| `clientProfiles` |  |
| `clientScopeMappings` |  |
| `clientScopes` |  |
| `clientSessionIdleTimeout` |  |
| `clientSessionMaxLifespan` |  |
| `clientTemplates` |  |
| `clients` |  |
| `codeSecret` |  |
| `components` |  |
| `defaultDefaultClientScopes` |  |
| `defaultGroups` |  |
| `defaultLocale` |  |
| `defaultOptionalClientScopes` |  |
| `defaultRole` |  |
| `defaultRoles` |  |
| `defaultSignatureAlgorithm` |  |
| `directGrantFlow` |  |
| `displayName` |  |
| `displayNameHtml` |  |
| `dockerAuthenticationFlow` |  |
| `duplicateEmailsAllowed` |  |
| `editUsernameAllowed` |  |
| `emailTheme` |  |
| `enabled` |  |
| `enabledEventTypes` |  |
| `eventsEnabled` |  |
| `eventsExpiration` |  |
| `eventsListeners` |  |
| `failureFactor` |  |
| `federatedUsers` |  |
| `groups` |  |
| `id` |  |
| `identityProviderMappers` |  |
| `identityProviders` |  |
| `internationalizationEnabled` |  |
| `keycloakVersion` |  |
| `localizationTexts` |  |
| `loginTheme` |  |
| `loginWithEmailAllowed` |  |
| `maxDeltaTimeSeconds` |  |
| `maxFailureWaitSeconds` |  |
| `minimumQuickLoginWaitSeconds` |  |
| `notBefore` |  |
| `oAuth2DeviceCodeLifespan` |  |
| `oAuth2DevicePollingInterval` |  |
| `oauth2DeviceCodeLifespan` |  |
| `oauth2DevicePollingInterval` |  |
| `oauthClients` |  |
| `offlineSessionIdleTimeout` |  |
| `offlineSessionMaxLifespan` |  |
| `offlineSessionMaxLifespanEnabled` |  |
| `otpPolicyAlgorithm` |  |
| `otpPolicyCodeReusable` |  |
| `otpPolicyDigits` |  |
| `otpPolicyInitialCounter` |  |
| `otpPolicyLookAheadWindow` |  |
| `otpPolicyPeriod` |  |
| `otpPolicyType` |  |
| `otpSupportedApplications` |  |
| `passwordCredentialGrantAllowed` |  |
| `passwordPolicy` |  |
| `permanentLockout` |  |
| `privateKey` |  |
| `protocolMappers` |  |
| `publicKey` |  |
| `quickLoginCheckMilliSeconds` |  |
| `realm` |  |
| `realmCacheEnabled` |  |
| `refreshTokenMaxReuse` |  |
| `registrationAllowed` |  |
| `registrationEmailAsUsername` |  |
| `registrationFlow` |  |
| `rememberMe` |  |
| `requiredActions` |  |
| `requiredCredentials` |  |
| `resetCredentialsFlow` |  |
| `resetPasswordAllowed` |  |
| `revokeRefreshToken` |  |
| `roles` |  |
| `scopeMappings` |  |
| `smtpServer` |  |
| `social` |  |
| `socialProviders` |  |
| `sslRequired` |  |
| `ssoSessionIdleTimeout` |  |
| `ssoSessionIdleTimeoutRememberMe` |  |
| `ssoSessionMaxLifespan` |  |
| `ssoSessionMaxLifespanRememberMe` |  |
| `supportedLocales` |  |
| `updateProfileOnInitialSocialLogin` |  |
| `userCacheEnabled` |  |
| `userFederationMappers` |  |
| `userFederationProviders` |  |
| `userManagedAccessAllowed` |  |
| `users` |  |
| `verifyEmail` |  |
| `waitIncrementSeconds` |  |
| `webAuthnPolicyAcceptableAaguids` |  |
| `webAuthnPolicyAttestationConveyancePreference` |  |
| `webAuthnPolicyAuthenticatorAttachment` |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` |  |
| `webAuthnPolicyCreateTimeout` |  |
| `webAuthnPolicyExtraOrigins` |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` |  |
| `webAuthnPolicyPasswordlessCreateTimeout` |  |
| `webAuthnPolicyPasswordlessExtraOrigins` |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` |  |
| `webAuthnPolicyPasswordlessRpEntityName` |  |
| `webAuthnPolicyPasswordlessRpId` |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` |  |
| `webAuthnPolicyRequireResidentKey` |  |
| `webAuthnPolicyRpEntityName` |  |
| `webAuthnPolicyRpId` |  |
| `webAuthnPolicySignatureAlgorithms` |  |
| `webAuthnPolicyUserVerificationRequirement` |  |

Operations: List.

API path: `/`

#### GetByRealm

| Field | Description |
| --- | --- |
| `accessCodeLifespan` |  |
| `accessCodeLifespanLogin` |  |
| `accessCodeLifespanUserAction` |  |
| `accessTokenLifespan` |  |
| `accessTokenLifespanForImplicitFlow` |  |
| `accountTheme` |  |
| `actionTokenGeneratedByAdminLifespan` |  |
| `actionTokenGeneratedByUserLifespan` |  |
| `adminEventsDetailsEnabled` |  |
| `adminEventsEnabled` |  |
| `adminTheme` |  |
| `applicationScopeMappings` |  |
| `applications` |  |
| `attributes` |  |
| `authenticationFlows` |  |
| `authenticatorConfig` |  |
| `browserFlow` |  |
| `browserSecurityHeaders` |  |
| `bruteForceProtected` |  |
| `certificate` |  |
| `clientAuthenticationFlow` |  |
| `clientOfflineSessionIdleTimeout` |  |
| `clientOfflineSessionMaxLifespan` |  |
| `clientPolicies` |  |
| `clientProfiles` |  |
| `clientScopeMappings` |  |
| `clientScopes` |  |
| `clientSessionIdleTimeout` |  |
| `clientSessionMaxLifespan` |  |
| `clientTemplates` |  |
| `clients` |  |
| `codeSecret` |  |
| `components` |  |
| `defaultDefaultClientScopes` |  |
| `defaultGroups` |  |
| `defaultLocale` |  |
| `defaultOptionalClientScopes` |  |
| `defaultRole` |  |
| `defaultRoles` |  |
| `defaultSignatureAlgorithm` |  |
| `directGrantFlow` |  |
| `displayName` |  |
| `displayNameHtml` |  |
| `dockerAuthenticationFlow` |  |
| `duplicateEmailsAllowed` |  |
| `editUsernameAllowed` |  |
| `emailTheme` |  |
| `enabled` |  |
| `enabledEventTypes` |  |
| `eventsEnabled` |  |
| `eventsExpiration` |  |
| `eventsListeners` |  |
| `failureFactor` |  |
| `federatedUsers` |  |
| `groups` |  |
| `id` |  |
| `identityProviderMappers` |  |
| `identityProviders` |  |
| `internationalizationEnabled` |  |
| `keycloakVersion` |  |
| `localizationTexts` |  |
| `loginTheme` |  |
| `loginWithEmailAllowed` |  |
| `maxDeltaTimeSeconds` |  |
| `maxFailureWaitSeconds` |  |
| `minimumQuickLoginWaitSeconds` |  |
| `notBefore` |  |
| `oAuth2DeviceCodeLifespan` |  |
| `oAuth2DevicePollingInterval` |  |
| `oauth2DeviceCodeLifespan` |  |
| `oauth2DevicePollingInterval` |  |
| `oauthClients` |  |
| `offlineSessionIdleTimeout` |  |
| `offlineSessionMaxLifespan` |  |
| `offlineSessionMaxLifespanEnabled` |  |
| `otpPolicyAlgorithm` |  |
| `otpPolicyCodeReusable` |  |
| `otpPolicyDigits` |  |
| `otpPolicyInitialCounter` |  |
| `otpPolicyLookAheadWindow` |  |
| `otpPolicyPeriod` |  |
| `otpPolicyType` |  |
| `otpSupportedApplications` |  |
| `passwordCredentialGrantAllowed` |  |
| `passwordPolicy` |  |
| `permanentLockout` |  |
| `privateKey` |  |
| `protocolMappers` |  |
| `publicKey` |  |
| `quickLoginCheckMilliSeconds` |  |
| `realm` |  |
| `realmCacheEnabled` |  |
| `refreshTokenMaxReuse` |  |
| `registrationAllowed` |  |
| `registrationEmailAsUsername` |  |
| `registrationFlow` |  |
| `rememberMe` |  |
| `requiredActions` |  |
| `requiredCredentials` |  |
| `resetCredentialsFlow` |  |
| `resetPasswordAllowed` |  |
| `revokeRefreshToken` |  |
| `roles` |  |
| `scopeMappings` |  |
| `smtpServer` |  |
| `social` |  |
| `socialProviders` |  |
| `sslRequired` |  |
| `ssoSessionIdleTimeout` |  |
| `ssoSessionIdleTimeoutRememberMe` |  |
| `ssoSessionMaxLifespan` |  |
| `ssoSessionMaxLifespanRememberMe` |  |
| `supportedLocales` |  |
| `updateProfileOnInitialSocialLogin` |  |
| `userCacheEnabled` |  |
| `userFederationMappers` |  |
| `userFederationProviders` |  |
| `userManagedAccessAllowed` |  |
| `users` |  |
| `verifyEmail` |  |
| `waitIncrementSeconds` |  |
| `webAuthnPolicyAcceptableAaguids` |  |
| `webAuthnPolicyAttestationConveyancePreference` |  |
| `webAuthnPolicyAuthenticatorAttachment` |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` |  |
| `webAuthnPolicyCreateTimeout` |  |
| `webAuthnPolicyExtraOrigins` |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` |  |
| `webAuthnPolicyPasswordlessCreateTimeout` |  |
| `webAuthnPolicyPasswordlessExtraOrigins` |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` |  |
| `webAuthnPolicyPasswordlessRpEntityName` |  |
| `webAuthnPolicyPasswordlessRpId` |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` |  |
| `webAuthnPolicyRequireResidentKey` |  |
| `webAuthnPolicyRpEntityName` |  |
| `webAuthnPolicyRpId` |  |
| `webAuthnPolicySignatureAlgorithms` |  |
| `webAuthnPolicyUserVerificationRequirement` |  |

Operations: List.

API path: `/{realm}`

#### GlobalRequestResult

| Field | Description |
| --- | --- |
| `failedRequests` |  |
| `successRequests` |  |

Operations: Create, List.

API path: `/{realm}/clients/{id}/push-revocation`

#### Granted

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: List.

API path: `/{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/granted`

#### Group

| Field | Description |
| --- | --- |
| `access` |  |
| `attributes` |  |
| `clientRoles` |  |
| `id` |  |
| `name` |  |
| `parentId` |  |
| `path` |  |
| `realmRoles` |  |
| `subGroupCount` |  |
| `subGroups` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/groups/{id}/children`

#### GroupRepresentation

| Field | Description |
| --- | --- |
| `access` |  |
| `attributes` |  |
| `clientRoles` |  |
| `id` |  |
| `name` |  |
| `parentId` |  |
| `path` |  |
| `realmRoles` |  |
| `subGroupCount` |  |
| `subGroups` |  |

Operations: List, Load.

API path: `/{realm}/groups/{id}/children`

#### IdToken

| Field | Description |
| --- | --- |
| `acr` |  |
| `address` |  |
| `at_hash` |  |
| `authTime` |  |
| `auth_time` |  |
| `azp` |  |
| `birthdate` |  |
| `c_hash` |  |
| `claims_locales` |  |
| `email` |  |
| `email_verified` |  |
| `exp` |  |
| `family_name` |  |
| `gender` |  |
| `given_name` |  |
| `iat` |  |
| `iss` |  |
| `jti` |  |
| `locale` |  |
| `middle_name` |  |
| `name` |  |
| `nbf` |  |
| `nickname` |  |
| `nonce` |  |
| `otherClaims` |  |
| `phone_number` |  |
| `phone_number_verified` |  |
| `picture` |  |
| `preferred_username` |  |
| `profile` |  |
| `s_hash` |  |
| `session_state` |  |
| `sid` |  |
| `sub` |  |
| `typ` |  |
| `updated_at` |  |
| `website` |  |
| `zoneinfo` |  |

Operations: Load.

API path: `/{realm}/clients/{id}/evaluate-scopes/generate-example-id-token`

#### IdentityProvider

| Field | Description |
| --- | --- |
| `addReadTokenRoleOnCreate` |  |
| `alias` |  |
| `authenticateByDefault` |  |
| `config` |  |
| `displayName` |  |
| `enabled` |  |
| `firstBrokerLoginFlowAlias` |  |
| `id` |  |
| `identityProviderAlias` |  |
| `identityProviderMapper` |  |
| `internalId` |  |
| `linkOnly` |  |
| `name` |  |
| `postBrokerLoginFlowAlias` |  |
| `providerId` |  |
| `storeToken` |  |
| `trustEmail` |  |
| `updateProfileFirstLogin` |  |
| `updateProfileFirstLoginMode` |  |

Operations: Create, Load, Remove, Update.

API path: `/{realm}/identity-provider/instances/{alias}/mappers`

#### IdentityProviderMapperRepresentation

| Field | Description |
| --- | --- |
| `config` |  |
| `id` |  |
| `identityProviderAlias` |  |
| `identityProviderMapper` |  |
| `name` |  |

Operations: List, Load.

API path: `/{realm}/identity-provider/instances/{alias}/mappers`

#### IdentityProviderRepresentation

| Field | Description |
| --- | --- |
| `addReadTokenRoleOnCreate` |  |
| `alias` |  |
| `authenticateByDefault` |  |
| `config` |  |
| `displayName` |  |
| `enabled` |  |
| `firstBrokerLoginFlowAlias` |  |
| `internalId` |  |
| `linkOnly` |  |
| `postBrokerLoginFlowAlias` |  |
| `providerId` |  |
| `storeToken` |  |
| `trustEmail` |  |
| `updateProfileFirstLogin` |  |
| `updateProfileFirstLoginMode` |  |

Operations: List, Load.

API path: `/{realm}/identity-provider/instances`

#### Key

| Field | Description |
| --- | --- |
| `algorithm` |  |
| `certificate` |  |
| `kid` |  |
| `providerId` |  |
| `providerPriority` |  |
| `publicKey` |  |
| `status` |  |
| `type` |  |
| `use` |  |
| `validTo` |  |

Operations: List.

API path: `/{realm}/keys`

#### ManagementPermissionReference

| Field | Description |
| --- | --- |
| `enabled` |  |
| `resource` |  |
| `scopePermissions` |  |

Operations: Load, Update.

API path: `/{realm}/clients/{id}/roles/{role-name}/management/permissions`

#### MappingsRepresentation

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: List.

API path: `/{realm}/clients/{id}/scope-mappings`

#### NotGranted

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: List.

API path: `/{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted`

#### Post

| Field | Description |
| --- | --- |

Operations: Create.

API path: `/`

#### Protocol

| Field | Description |
| --- | --- |
| `config` |  |
| `consentRequired` |  |
| `consentText` |  |
| `id` |  |
| `name` |  |
| `protocol` |  |
| `protocolMapper` |  |

Operations: Load.

API path: `/{realm}/clients/{id}/protocol-mappers/protocol/{protocol}`

#### ProtocolMapper

| Field | Description |
| --- | --- |
| `config` |  |
| `consentRequired` |  |
| `consentText` |  |
| `containerId` |  |
| `containerName` |  |
| `containerType` |  |
| `id` |  |
| `mapperId` |  |
| `mapperName` |  |
| `name` |  |
| `protocol` |  |
| `protocolMapper` |  |

Operations: Create, List, Remove, Update.

API path: `/{realm}/clients/{id}/protocol-mappers/add-models`

#### ProtocolMapperRepresentation

| Field | Description |
| --- | --- |
| `config` |  |
| `consentRequired` |  |
| `consentText` |  |
| `id` |  |
| `name` |  |
| `protocol` |  |
| `protocolMapper` |  |

Operations: List, Load.

API path: `/{realm}/clients/{id}/protocol-mappers/models`

#### PutByRealm

| Field | Description |
| --- | --- |
| `accessCodeLifespan` |  |
| `accessCodeLifespanLogin` |  |
| `accessCodeLifespanUserAction` |  |
| `accessTokenLifespan` |  |
| `accessTokenLifespanForImplicitFlow` |  |
| `accountTheme` |  |
| `actionTokenGeneratedByAdminLifespan` |  |
| `actionTokenGeneratedByUserLifespan` |  |
| `adminEventsDetailsEnabled` |  |
| `adminEventsEnabled` |  |
| `adminTheme` |  |
| `applicationScopeMappings` |  |
| `applications` |  |
| `attributes` |  |
| `authenticationFlows` |  |
| `authenticatorConfig` |  |
| `browserFlow` |  |
| `browserSecurityHeaders` |  |
| `bruteForceProtected` |  |
| `certificate` |  |
| `clientAuthenticationFlow` |  |
| `clientOfflineSessionIdleTimeout` |  |
| `clientOfflineSessionMaxLifespan` |  |
| `clientPolicies` |  |
| `clientProfiles` |  |
| `clientScopeMappings` |  |
| `clientScopes` |  |
| `clientSessionIdleTimeout` |  |
| `clientSessionMaxLifespan` |  |
| `clientTemplates` |  |
| `clients` |  |
| `codeSecret` |  |
| `components` |  |
| `defaultDefaultClientScopes` |  |
| `defaultGroups` |  |
| `defaultLocale` |  |
| `defaultOptionalClientScopes` |  |
| `defaultRole` |  |
| `defaultRoles` |  |
| `defaultSignatureAlgorithm` |  |
| `directGrantFlow` |  |
| `displayName` |  |
| `displayNameHtml` |  |
| `dockerAuthenticationFlow` |  |
| `duplicateEmailsAllowed` |  |
| `editUsernameAllowed` |  |
| `emailTheme` |  |
| `enabled` |  |
| `enabledEventTypes` |  |
| `eventsEnabled` |  |
| `eventsExpiration` |  |
| `eventsListeners` |  |
| `failureFactor` |  |
| `federatedUsers` |  |
| `groups` |  |
| `id` |  |
| `identityProviderMappers` |  |
| `identityProviders` |  |
| `internationalizationEnabled` |  |
| `keycloakVersion` |  |
| `localizationTexts` |  |
| `loginTheme` |  |
| `loginWithEmailAllowed` |  |
| `maxDeltaTimeSeconds` |  |
| `maxFailureWaitSeconds` |  |
| `minimumQuickLoginWaitSeconds` |  |
| `notBefore` |  |
| `oAuth2DeviceCodeLifespan` |  |
| `oAuth2DevicePollingInterval` |  |
| `oauth2DeviceCodeLifespan` |  |
| `oauth2DevicePollingInterval` |  |
| `oauthClients` |  |
| `offlineSessionIdleTimeout` |  |
| `offlineSessionMaxLifespan` |  |
| `offlineSessionMaxLifespanEnabled` |  |
| `otpPolicyAlgorithm` |  |
| `otpPolicyCodeReusable` |  |
| `otpPolicyDigits` |  |
| `otpPolicyInitialCounter` |  |
| `otpPolicyLookAheadWindow` |  |
| `otpPolicyPeriod` |  |
| `otpPolicyType` |  |
| `otpSupportedApplications` |  |
| `passwordCredentialGrantAllowed` |  |
| `passwordPolicy` |  |
| `permanentLockout` |  |
| `privateKey` |  |
| `protocolMappers` |  |
| `publicKey` |  |
| `quickLoginCheckMilliSeconds` |  |
| `realm` |  |
| `realmCacheEnabled` |  |
| `refreshTokenMaxReuse` |  |
| `registrationAllowed` |  |
| `registrationEmailAsUsername` |  |
| `registrationFlow` |  |
| `rememberMe` |  |
| `requiredActions` |  |
| `requiredCredentials` |  |
| `resetCredentialsFlow` |  |
| `resetPasswordAllowed` |  |
| `revokeRefreshToken` |  |
| `roles` |  |
| `scopeMappings` |  |
| `smtpServer` |  |
| `social` |  |
| `socialProviders` |  |
| `sslRequired` |  |
| `ssoSessionIdleTimeout` |  |
| `ssoSessionIdleTimeoutRememberMe` |  |
| `ssoSessionMaxLifespan` |  |
| `ssoSessionMaxLifespanRememberMe` |  |
| `supportedLocales` |  |
| `updateProfileOnInitialSocialLogin` |  |
| `userCacheEnabled` |  |
| `userFederationMappers` |  |
| `userFederationProviders` |  |
| `userManagedAccessAllowed` |  |
| `users` |  |
| `verifyEmail` |  |
| `waitIncrementSeconds` |  |
| `webAuthnPolicyAcceptableAaguids` |  |
| `webAuthnPolicyAttestationConveyancePreference` |  |
| `webAuthnPolicyAuthenticatorAttachment` |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` |  |
| `webAuthnPolicyCreateTimeout` |  |
| `webAuthnPolicyExtraOrigins` |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` |  |
| `webAuthnPolicyPasswordlessCreateTimeout` |  |
| `webAuthnPolicyPasswordlessExtraOrigins` |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` |  |
| `webAuthnPolicyPasswordlessRpEntityName` |  |
| `webAuthnPolicyPasswordlessRpId` |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` |  |
| `webAuthnPolicyRequireResidentKey` |  |
| `webAuthnPolicyRpEntityName` |  |
| `webAuthnPolicyRpId` |  |
| `webAuthnPolicySignatureAlgorithms` |  |
| `webAuthnPolicyUserVerificationRequirement` |  |

Operations: Update.

API path: `/{realm}`

#### Realm

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: List.

API path: `/{realm}/clients/{id}/roles/{role-name}/composites/realm`

#### RealmEventsConfigRepresentation

| Field | Description |
| --- | --- |
| `adminEventsDetailsEnabled` |  |
| `adminEventsEnabled` |  |
| `enabledEventTypes` |  |
| `eventsEnabled` |  |
| `eventsExpiration` |  |
| `eventsListeners` |  |

Operations: List.

API path: `/{realm}/events/config`

#### RealmsAdmin

| Field | Description |
| --- | --- |
| `adminEventsDetailsEnabled` |  |
| `adminEventsEnabled` |  |
| `enabledEventTypes` |  |
| `eventsEnabled` |  |
| `eventsExpiration` |  |
| `eventsListeners` |  |
| `globalProfiles` |  |
| `id` |  |
| `policies` |  |
| `profiles` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/localization/{locale}`

#### RequiredAction

| Field | Description |
| --- | --- |
| `alias` |  |
| `config` |  |
| `defaultAction` |  |
| `enabled` |  |
| `id` |  |
| `name` |  |
| `priority` |  |
| `providerId` |  |

Operations: Create, List, Load.

API path: `/{realm}/authentication/required-actions/{alias}/lower-priority`

#### Role

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/clients/{id}/roles/{role-name}/composites`

#### RoleMapper

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: Create, Remove.

API path: `/{realm}/groups/{id}/role-mappings/realm`

#### RolesById

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: Create, Load, Remove, Update.

API path: `/{realm}/roles-by-id/{role-id}/composites`

#### ScopeMapping

| Field | Description |
| --- | --- |
| `attributes` |  |
| `clientRole` |  |
| `composite` |  |
| `composites` |  |
| `containerId` |  |
| `description` |  |
| `id` |  |
| `name` |  |
| `scopeParamRequired` |  |

Operations: Create, Remove.

API path: `/{realm}/clients/{id}/scope-mappings/clients/{client}`

#### UpConfig

| Field | Description |
| --- | --- |
| `attributes` |  |
| `groups` |  |

Operations: List, Update.

API path: `/{realm}/users/profile`

#### User

| Field | Description |
| --- | --- |
| `access` |  |
| `applicationRoles` |  |
| `attributes` |  |
| `clientConsents` |  |
| `clientRoles` |  |
| `createdTimestamp` |  |
| `credentials` |  |
| `disableableCredentialTypes` |  |
| `email` |  |
| `emailVerified` |  |
| `enabled` |  |
| `federatedIdentities` |  |
| `federationLink` |  |
| `firstName` |  |
| `groups` |  |
| `id` |  |
| `lastName` |  |
| `notBefore` |  |
| `origin` |  |
| `realmRoles` |  |
| `requiredActions` |  |
| `self` |  |
| `serviceAccountClientId` |  |
| `socialLinks` |  |
| `totp` |  |
| `userProfileMetadata` |  |
| `username` |  |

Operations: Create, List, Load, Remove, Update.

API path: `/{realm}/users/{id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}`

#### UserRepresentation

| Field | Description |
| --- | --- |
| `access` |  |
| `applicationRoles` |  |
| `attributes` |  |
| `clientConsents` |  |
| `clientRoles` |  |
| `createdTimestamp` |  |
| `credentials` |  |
| `disableableCredentialTypes` |  |
| `email` |  |
| `emailVerified` |  |
| `enabled` |  |
| `federatedIdentities` |  |
| `federationLink` |  |
| `firstName` |  |
| `groups` |  |
| `id` |  |
| `lastName` |  |
| `notBefore` |  |
| `origin` |  |
| `realmRoles` |  |
| `requiredActions` |  |
| `self` |  |
| `serviceAccountClientId` |  |
| `socialLinks` |  |
| `totp` |  |
| `userProfileMetadata` |  |
| `username` |  |

Operations: List.

API path: `/{realm}/clients/{id}/service-account-user`

#### UserSession

| Field | Description |
| --- | --- |
| `clients` |  |
| `id` |  |
| `ipAddress` |  |
| `lastAccess` |  |
| `rememberMe` |  |
| `start` |  |
| `userId` |  |
| `username` |  |

Operations: List.

API path: `/{realm}/clients/{id}/user-sessions`

#### UserSessionRepresentation

| Field | Description |
| --- | --- |
| `clients` |  |
| `id` |  |
| `ipAddress` |  |
| `lastAccess` |  |
| `rememberMe` |  |
| `start` |  |
| `userId` |  |
| `username` |  |

Operations: List, Load.

API path: `/{realm}/clients/{id}/offline-sessions`

#### UsersManagementPermission

| Field | Description |
| --- | --- |
| `enabled` |  |
| `resource` |  |
| `scopePermissions` |  |

Operations: Load, Update.

API path: `/{realm}/users-management-permissions`



## Entities


### AccessToken

Create an instance: `var accessToken = client.AccessToken();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `acr` | `string` |  |
| `address` | `Dictionary<string, object?>` |  |
| `allowedorigins` | `List<object?>` |  |
| `at_hash` | `string` |  |
| `authTime` | `long` |  |
| `auth_time` | `long` |  |
| `authorization` | `Dictionary<string, object?>` |  |
| `azp` | `string` |  |
| `birthdate` | `string` |  |
| `c_hash` | `string` |  |
| `claims_locales` | `string` |  |
| `cnf` | `Dictionary<string, object?>` |  |
| `email` | `string` |  |
| `email_verified` | `bool` |  |
| `exp` | `long` |  |
| `family_name` | `string` |  |
| `gender` | `string` |  |
| `given_name` | `string` |  |
| `iat` | `long` |  |
| `iss` | `string` |  |
| `jti` | `string` |  |
| `locale` | `string` |  |
| `middle_name` | `string` |  |
| `name` | `string` |  |
| `nbf` | `long` |  |
| `nickname` | `string` |  |
| `nonce` | `string` |  |
| `otherClaims` | `Dictionary<string, object?>` |  |
| `phone_number` | `string` |  |
| `phone_number_verified` | `bool` |  |
| `picture` | `string` |  |
| `preferred_username` | `string` |  |
| `profile` | `string` |  |
| `realm_access` | `Dictionary<string, object?>` |  |
| `resource_access` | `Dictionary<string, object?>` |  |
| `s_hash` | `string` |  |
| `scope` | `string` |  |
| `session_state` | `string` |  |
| `sid` | `string` |  |
| `sub` | `string` |  |
| `trustedcerts` | `List<object?>` |  |
| `typ` | `string` |  |
| `updated_at` | `long` |  |
| `website` | `string` |  |
| `zoneinfo` | `string` |  |

#### Example: List

```csharp
var accessTokenList = client.AccessToken().List(null);
```


### AdminEvent

Create an instance: `var adminEvent = client.AdminEvent();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `authDetails` | `Dictionary<string, object?>` |  |
| `error` | `string` |  |
| `operationType` | `string` |  |
| `realmId` | `string` |  |
| `representation` | `string` |  |
| `resourcePath` | `string` |  |
| `resourceType` | `string` |  |
| `time` | `long` |  |

#### Example: List

```csharp
var adminEventList = client.AdminEvent().List(null);
```


### AttackDetection

Create an instance: `var attackDetection = client.AttackDetection();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |

#### Example: Load

```csharp
var attackDetection = client.AttackDetection().Load(new Dictionary<string, object?> { ["realm"] = "realm", ["user_id"] = "user_id" });
```


### AuthenticationFlowRepresentation

Create an instance: `var authenticationFlowRepresentation = client.AuthenticationFlowRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `alias` | `string` |  |
| `authenticationExecutions` | `List<object?>` |  |
| `builtIn` | `bool` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `providerId` | `string` |  |
| `topLevel` | `bool` |  |

#### Example: Load

```csharp
var authenticationFlowRepresentation = client.AuthenticationFlowRepresentation().Load(new Dictionary<string, object?> { ["id"] = "authentication_flow_representation_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var authenticationFlowRepresentationList = client.AuthenticationFlowRepresentation().List(null);
```


### AuthenticationManagement

Create an instance: `var authenticationManagement = client.AuthenticationManagement();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `alias` | `string` |  |
| `authenticationConfig` | `string` |  |
| `authenticationExecutions` | `List<object?>` |  |
| `authenticationFlow` | `bool` |  |
| `authenticator` | `string` |  |
| `authenticatorConfig` | `string` |  |
| `authenticatorFlow` | `bool` |  |
| `autheticatorFlow` | `bool` |  |
| `builtIn` | `bool` |  |
| `config` | `Dictionary<string, object?>` |  |
| `configurable` | `bool` |  |
| `defaultAction` | `bool` |  |
| `defaultValue` | `object?` |  |
| `description` | `string` |  |
| `displayName` | `string` |  |
| `enabled` | `bool` |  |
| `flowId` | `string` |  |
| `helpText` | `string` |  |
| `id` | `string` |  |
| `index` | `long` |  |
| `label` | `string` |  |
| `level` | `long` |  |
| `name` | `string` |  |
| `options` | `List<object?>` |  |
| `parentFlow` | `string` |  |
| `priority` | `long` |  |
| `providerId` | `string` |  |
| `readOnly` | `bool` |  |
| `required` | `bool` |  |
| `requirement` | `string` |  |
| `requirementChoices` | `List<object?>` |  |
| `secret` | `bool` |  |
| `topLevel` | `bool` |  |
| `type` | `string` |  |

#### Example: Load

```csharp
var authenticationManagement = client.AuthenticationManagement().Load(new Dictionary<string, object?> { ["realm"] = "realm" });
```

#### Example: List

```csharp
var authenticationManagementList = client.AuthenticationManagement().List(null);
```

#### Example: Create

```csharp
var authenticationManagement = client.AuthenticationManagement().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### AuthenticatorConfigInfoRepresentation

Create an instance: `var authenticatorConfigInfoRepresentation = client.AuthenticatorConfigInfoRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `helpText` | `string` |  |
| `name` | `string` |  |
| `properties` | `List<object?>` |  |
| `providerId` | `string` |  |

#### Example: Load

```csharp
var authenticatorConfigInfoRepresentation = client.AuthenticatorConfigInfoRepresentation().Load(new Dictionary<string, object?> { ["provider_id"] = "provider_id", ["realm"] = "realm" });
```


### AuthenticatorConfigRepresentation

Create an instance: `var authenticatorConfigRepresentation = client.AuthenticatorConfigRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `alias` | `string` |  |
| `config` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |

#### Example: Load

```csharp
var authenticatorConfigRepresentation = client.AuthenticatorConfigRepresentation().Load(new Dictionary<string, object?> { ["id"] = "authenticator_config_representation_id", ["realm"] = "realm" });
```


### Available

Create an instance: `var available = client.Available();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: List

```csharp
var availableList = client.Available().List(null);
```


### Certificate

Create an instance: `var certificate = client.Certificate();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `certificate` | `string` |  |
| `id` | `string` |  |
| `kid` | `string` |  |
| `privateKey` | `string` |  |
| `publicKey` | `string` |  |

#### Example: Load

```csharp
var certificate = client.Certificate().Load(new Dictionary<string, object?> { ["id"] = "certificate_id", ["client_id"] = "client_id", ["realm"] = "realm" });
```


### CertificateRepresentation

Create an instance: `var certificateRepresentation = client.CertificateRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `certificate` | `string` |  |
| `kid` | `string` |  |
| `privateKey` | `string` |  |
| `publicKey` | `string` |  |

#### Example: Create

```csharp
var certificateRepresentation = client.CertificateRepresentation().Create(new Dictionary<string, object?>
{
    ["attr"] = "example_attr",  // string
    ["client_id"] = "example_client_id",  // string
    ["realm"] = "example_realm",  // string
});
```


### Client

Create an instance: `var client = client.Client();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `access` | `Dictionary<string, object?>` |  |
| `adminUrl` | `string` |  |
| `alwaysDisplayInConsole` | `bool` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `authenticationFlowBindingOverrides` | `Dictionary<string, object?>` |  |
| `authorizationServicesEnabled` | `bool` |  |
| `authorizationSettings` | `Dictionary<string, object?>` |  |
| `baseUrl` | `string` |  |
| `bearerOnly` | `bool` |  |
| `clientAuthenticatorType` | `string` |  |
| `clientId` | `string` |  |
| `clientRole` | `bool` |  |
| `clientTemplate` | `string` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `consentRequired` | `bool` |  |
| `containerId` | `string` |  |
| `defaultClientScopes` | `List<object?>` |  |
| `defaultRoles` | `List<object?>` |  |
| `description` | `string` |  |
| `directAccessGrantsEnabled` | `bool` |  |
| `directGrantsOnly` | `bool` |  |
| `enabled` | `bool` |  |
| `frontchannelLogout` | `bool` |  |
| `fullScopeAllowed` | `bool` |  |
| `id` | `string` |  |
| `implicitFlowEnabled` | `bool` |  |
| `name` | `string` |  |
| `nodeReRegistrationTimeout` | `long` |  |
| `notBefore` | `long` |  |
| `oauth2DeviceAuthorizationGrantEnabled` | `bool` |  |
| `optionalClientScopes` | `List<object?>` |  |
| `origin` | `string` |  |
| `protocol` | `string` |  |
| `protocolMappers` | `List<object?>` |  |
| `publicClient` | `bool` |  |
| `redirectUris` | `List<object?>` |  |
| `registeredNodes` | `Dictionary<string, object?>` |  |
| `registrationAccessToken` | `string` |  |
| `rootUrl` | `string` |  |
| `scopeParamRequired` | `bool` |  |
| `secret` | `string` |  |
| `serviceAccountsEnabled` | `bool` |  |
| `standardFlowEnabled` | `bool` |  |
| `surrogateAuthRequired` | `bool` |  |
| `useTemplateConfig` | `bool` |  |
| `useTemplateMappers` | `bool` |  |
| `useTemplateScope` | `bool` |  |
| `webOrigins` | `List<object?>` |  |

#### Example: Load

```csharp
var client = client.Client().Load(new Dictionary<string, object?> { ["id"] = "client_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var clientList = client.Client().List(null);
```

#### Example: Create

```csharp
var client = client.Client().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### ClientInitialAccess

Create an instance: `var clientInitialAccess = client.ClientInitialAccess();`

#### Operations

| Method | Description |
| --- | --- |
| `Remove(match)` | Remove the matching entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `id` | `string` |  |


### ClientInitialAccessPresentation

Create an instance: `var clientInitialAccessPresentation = client.ClientInitialAccessPresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `count` | `long` |  |
| `expiration` | `long` |  |
| `id` | `string` |  |
| `remainingCount` | `long` |  |
| `timestamp` | `long` |  |
| `token` | `string` |  |

#### Example: List

```csharp
var clientInitialAccessPresentationList = client.ClientInitialAccessPresentation().List(null);
```

#### Example: Create

```csharp
var clientInitialAccessPresentation = client.ClientInitialAccessPresentation().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### ClientPolicyRepresentation

Create an instance: `var clientPolicyRepresentation = client.ClientPolicyRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `conditions` | `List<object?>` |  |
| `description` | `string` |  |
| `enabled` | `bool` |  |
| `name` | `string` |  |
| `profiles` | `List<object?>` |  |

#### Example: List

```csharp
var clientPolicyRepresentationList = client.ClientPolicyRepresentation().List(null);
```


### ClientProfilesRepresentation

Create an instance: `var clientProfilesRepresentation = client.ClientProfilesRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `globalProfiles` | `List<object?>` |  |
| `profiles` | `List<object?>` |  |

#### Example: List

```csharp
var clientProfilesRepresentationList = client.ClientProfilesRepresentation().List(null);
```


### ClientRepresentation

Create an instance: `var clientRepresentation = client.ClientRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `access` | `Dictionary<string, object?>` |  |
| `adminUrl` | `string` |  |
| `alwaysDisplayInConsole` | `bool` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `authenticationFlowBindingOverrides` | `Dictionary<string, object?>` |  |
| `authorizationServicesEnabled` | `bool` |  |
| `authorizationSettings` | `Dictionary<string, object?>` |  |
| `baseUrl` | `string` |  |
| `bearerOnly` | `bool` |  |
| `clientAuthenticatorType` | `string` |  |
| `clientId` | `string` |  |
| `clientTemplate` | `string` |  |
| `consentRequired` | `bool` |  |
| `defaultClientScopes` | `List<object?>` |  |
| `defaultRoles` | `List<object?>` |  |
| `description` | `string` |  |
| `directAccessGrantsEnabled` | `bool` |  |
| `directGrantsOnly` | `bool` |  |
| `enabled` | `bool` |  |
| `frontchannelLogout` | `bool` |  |
| `fullScopeAllowed` | `bool` |  |
| `id` | `string` |  |
| `implicitFlowEnabled` | `bool` |  |
| `name` | `string` |  |
| `nodeReRegistrationTimeout` | `long` |  |
| `notBefore` | `long` |  |
| `oauth2DeviceAuthorizationGrantEnabled` | `bool` |  |
| `optionalClientScopes` | `List<object?>` |  |
| `origin` | `string` |  |
| `protocol` | `string` |  |
| `protocolMappers` | `List<object?>` |  |
| `publicClient` | `bool` |  |
| `redirectUris` | `List<object?>` |  |
| `registeredNodes` | `Dictionary<string, object?>` |  |
| `registrationAccessToken` | `string` |  |
| `rootUrl` | `string` |  |
| `secret` | `string` |  |
| `serviceAccountsEnabled` | `bool` |  |
| `standardFlowEnabled` | `bool` |  |
| `surrogateAuthRequired` | `bool` |  |
| `useTemplateConfig` | `bool` |  |
| `useTemplateMappers` | `bool` |  |
| `useTemplateScope` | `bool` |  |
| `webOrigins` | `List<object?>` |  |

#### Example: Create

```csharp
var clientRepresentation = client.ClientRepresentation().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### ClientScope

Create an instance: `var clientScope = client.ClientScope();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `protocol` | `string` |  |
| `protocolMappers` | `List<object?>` |  |

#### Example: Load

```csharp
var clientScope = client.ClientScope().Load(new Dictionary<string, object?> { ["id"] = "client_scope_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var clientScopeList = client.ClientScope().List(null);
```

#### Example: Create

```csharp
var clientScope = client.ClientScope().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### ClientScopeRepresentation

Create an instance: `var clientScopeRepresentation = client.ClientScopeRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `protocol` | `string` |  |
| `protocolMappers` | `List<object?>` |  |

#### Example: Load

```csharp
var clientScopeRepresentation = client.ClientScopeRepresentation().Load(new Dictionary<string, object?> { ["id"] = "client_scope_representation_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var clientScopeRepresentationList = client.ClientScopeRepresentation().List(null);
```


### Component

Create an instance: `var component = client.Component();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `config` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `parentId` | `string` |  |
| `providerId` | `string` |  |
| `providerType` | `string` |  |
| `subType` | `string` |  |

#### Example: Load

```csharp
var component = client.Component().Load(new Dictionary<string, object?> { ["id"] = "component_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var componentList = client.Component().List(null);
```

#### Example: Create

```csharp
var component = client.Component().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### ComponentTypeRepresentation

Create an instance: `var componentTypeRepresentation = client.ComponentTypeRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `helpText` | `string` |  |
| `id` | `string` |  |
| `metadata` | `Dictionary<string, object?>` |  |
| `properties` | `List<object?>` |  |

#### Example: List

```csharp
var componentTypeRepresentationList = client.ComponentTypeRepresentation().List(null);
```


### Composite

Create an instance: `var composite = client.Composite();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: List

```csharp
var compositeList = client.Composite().List(null);
```


### Credential

Create an instance: `var credential = client.Credential();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `algorithm` | `string` |  |
| `config` | `Dictionary<string, object?>` |  |
| `counter` | `long` |  |
| `createdDate` | `long` |  |
| `credentialData` | `string` |  |
| `device` | `string` |  |
| `digits` | `long` |  |
| `hashIterations` | `long` |  |
| `hashedSaltedValue` | `string` |  |
| `id` | `string` |  |
| `period` | `long` |  |
| `priority` | `long` |  |
| `salt` | `string` |  |
| `secretData` | `string` |  |
| `temporary` | `bool` |  |
| `type` | `string` |  |
| `userLabel` | `string` |  |
| `value` | `string` |  |

#### Example: List

```csharp
var credentialList = client.Credential().List(null);
```


### CredentialRepresentation

Create an instance: `var credentialRepresentation = client.CredentialRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `algorithm` | `string` |  |
| `config` | `Dictionary<string, object?>` |  |
| `counter` | `long` |  |
| `createdDate` | `long` |  |
| `credentialData` | `string` |  |
| `device` | `string` |  |
| `digits` | `long` |  |
| `hashIterations` | `long` |  |
| `hashedSaltedValue` | `string` |  |
| `id` | `string` |  |
| `period` | `long` |  |
| `priority` | `long` |  |
| `salt` | `string` |  |
| `secretData` | `string` |  |
| `temporary` | `bool` |  |
| `type` | `string` |  |
| `userLabel` | `string` |  |
| `value` | `string` |  |

#### Example: Load

```csharp
var credentialRepresentation = client.CredentialRepresentation().Load(new Dictionary<string, object?> { ["client_id"] = "client_id", ["realm"] = "realm" });
```

#### Example: Create

```csharp
var credentialRepresentation = client.CredentialRepresentation().Create(new Dictionary<string, object?>
{
    ["client_id"] = "example_client_id",  // string
    ["realm"] = "example_realm",  // string
});
```


### DeleteByRealm

Create an instance: `var deleteByRealm = client.DeleteByRealm();`

#### Operations

| Method | Description |
| --- | --- |
| `Remove(match)` | Remove the matching entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `id` | `string` |  |


### Event

Create an instance: `var event_ = client.Event();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `clientId` | `string` |  |
| `details` | `Dictionary<string, object?>` |  |
| `error` | `string` |  |
| `ipAddress` | `string` |  |
| `realmId` | `string` |  |
| `sessionId` | `string` |  |
| `time` | `long` |  |
| `type` | `string` |  |
| `userId` | `string` |  |

#### Example: List

```csharp
var event_List = client.Event().List(null);
```


### FederatedIdentity

Create an instance: `var federatedIdentity = client.FederatedIdentity();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `identityProvider` | `string` |  |
| `userId` | `string` |  |
| `userName` | `string` |  |

#### Example: List

```csharp
var federatedIdentityList = client.FederatedIdentity().List(null);
```


### Flow

Create an instance: `var flow = client.Flow();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |

#### Example: Create

```csharp
var flow = client.Flow().Create(new Dictionary<string, object?>
{
    ["flow_alia"] = "example_flow_alia",  // string
    ["realm"] = "example_realm",  // string
});
```


### Get

Create an instance: `var get = client.Get();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `accessCodeLifespan` | `long` |  |
| `accessCodeLifespanLogin` | `long` |  |
| `accessCodeLifespanUserAction` | `long` |  |
| `accessTokenLifespan` | `long` |  |
| `accessTokenLifespanForImplicitFlow` | `long` |  |
| `accountTheme` | `string` |  |
| `actionTokenGeneratedByAdminLifespan` | `long` |  |
| `actionTokenGeneratedByUserLifespan` | `long` |  |
| `adminEventsDetailsEnabled` | `bool` |  |
| `adminEventsEnabled` | `bool` |  |
| `adminTheme` | `string` |  |
| `applicationScopeMappings` | `Dictionary<string, object?>` |  |
| `applications` | `List<object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `authenticationFlows` | `List<object?>` |  |
| `authenticatorConfig` | `List<object?>` |  |
| `browserFlow` | `string` |  |
| `browserSecurityHeaders` | `Dictionary<string, object?>` |  |
| `bruteForceProtected` | `bool` |  |
| `certificate` | `string` |  |
| `clientAuthenticationFlow` | `string` |  |
| `clientOfflineSessionIdleTimeout` | `long` |  |
| `clientOfflineSessionMaxLifespan` | `long` |  |
| `clientPolicies` | `Dictionary<string, object?>` |  |
| `clientProfiles` | `Dictionary<string, object?>` |  |
| `clientScopeMappings` | `Dictionary<string, object?>` |  |
| `clientScopes` | `List<object?>` |  |
| `clientSessionIdleTimeout` | `long` |  |
| `clientSessionMaxLifespan` | `long` |  |
| `clientTemplates` | `List<object?>` |  |
| `clients` | `List<object?>` |  |
| `codeSecret` | `string` |  |
| `components` | `Dictionary<string, object?>` |  |
| `defaultDefaultClientScopes` | `List<object?>` |  |
| `defaultGroups` | `List<object?>` |  |
| `defaultLocale` | `string` |  |
| `defaultOptionalClientScopes` | `List<object?>` |  |
| `defaultRole` | `Dictionary<string, object?>` |  |
| `defaultRoles` | `List<object?>` |  |
| `defaultSignatureAlgorithm` | `string` |  |
| `directGrantFlow` | `string` |  |
| `displayName` | `string` |  |
| `displayNameHtml` | `string` |  |
| `dockerAuthenticationFlow` | `string` |  |
| `duplicateEmailsAllowed` | `bool` |  |
| `editUsernameAllowed` | `bool` |  |
| `emailTheme` | `string` |  |
| `enabled` | `bool` |  |
| `enabledEventTypes` | `List<object?>` |  |
| `eventsEnabled` | `bool` |  |
| `eventsExpiration` | `long` |  |
| `eventsListeners` | `List<object?>` |  |
| `failureFactor` | `long` |  |
| `federatedUsers` | `List<object?>` |  |
| `groups` | `List<object?>` |  |
| `id` | `string` |  |
| `identityProviderMappers` | `List<object?>` |  |
| `identityProviders` | `List<object?>` |  |
| `internationalizationEnabled` | `bool` |  |
| `keycloakVersion` | `string` |  |
| `localizationTexts` | `Dictionary<string, object?>` |  |
| `loginTheme` | `string` |  |
| `loginWithEmailAllowed` | `bool` |  |
| `maxDeltaTimeSeconds` | `long` |  |
| `maxFailureWaitSeconds` | `long` |  |
| `minimumQuickLoginWaitSeconds` | `long` |  |
| `notBefore` | `long` |  |
| `oAuth2DeviceCodeLifespan` | `long` |  |
| `oAuth2DevicePollingInterval` | `long` |  |
| `oauth2DeviceCodeLifespan` | `long` |  |
| `oauth2DevicePollingInterval` | `long` |  |
| `oauthClients` | `List<object?>` |  |
| `offlineSessionIdleTimeout` | `long` |  |
| `offlineSessionMaxLifespan` | `long` |  |
| `offlineSessionMaxLifespanEnabled` | `bool` |  |
| `otpPolicyAlgorithm` | `string` |  |
| `otpPolicyCodeReusable` | `bool` |  |
| `otpPolicyDigits` | `long` |  |
| `otpPolicyInitialCounter` | `long` |  |
| `otpPolicyLookAheadWindow` | `long` |  |
| `otpPolicyPeriod` | `long` |  |
| `otpPolicyType` | `string` |  |
| `otpSupportedApplications` | `List<object?>` |  |
| `passwordCredentialGrantAllowed` | `bool` |  |
| `passwordPolicy` | `string` |  |
| `permanentLockout` | `bool` |  |
| `privateKey` | `string` |  |
| `protocolMappers` | `List<object?>` |  |
| `publicKey` | `string` |  |
| `quickLoginCheckMilliSeconds` | `long` |  |
| `realm` | `string` |  |
| `realmCacheEnabled` | `bool` |  |
| `refreshTokenMaxReuse` | `long` |  |
| `registrationAllowed` | `bool` |  |
| `registrationEmailAsUsername` | `bool` |  |
| `registrationFlow` | `string` |  |
| `rememberMe` | `bool` |  |
| `requiredActions` | `List<object?>` |  |
| `requiredCredentials` | `List<object?>` |  |
| `resetCredentialsFlow` | `string` |  |
| `resetPasswordAllowed` | `bool` |  |
| `revokeRefreshToken` | `bool` |  |
| `roles` | `Dictionary<string, object?>` |  |
| `scopeMappings` | `List<object?>` |  |
| `smtpServer` | `Dictionary<string, object?>` |  |
| `social` | `bool` |  |
| `socialProviders` | `Dictionary<string, object?>` |  |
| `sslRequired` | `string` |  |
| `ssoSessionIdleTimeout` | `long` |  |
| `ssoSessionIdleTimeoutRememberMe` | `long` |  |
| `ssoSessionMaxLifespan` | `long` |  |
| `ssoSessionMaxLifespanRememberMe` | `long` |  |
| `supportedLocales` | `List<object?>` |  |
| `updateProfileOnInitialSocialLogin` | `bool` |  |
| `userCacheEnabled` | `bool` |  |
| `userFederationMappers` | `List<object?>` |  |
| `userFederationProviders` | `List<object?>` |  |
| `userManagedAccessAllowed` | `bool` |  |
| `users` | `List<object?>` |  |
| `verifyEmail` | `bool` |  |
| `waitIncrementSeconds` | `long` |  |
| `webAuthnPolicyAcceptableAaguids` | `List<object?>` |  |
| `webAuthnPolicyAttestationConveyancePreference` | `string` |  |
| `webAuthnPolicyAuthenticatorAttachment` | `string` |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` | `bool` |  |
| `webAuthnPolicyCreateTimeout` | `long` |  |
| `webAuthnPolicyExtraOrigins` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` | `string` |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` | `string` |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` | `bool` |  |
| `webAuthnPolicyPasswordlessCreateTimeout` | `long` |  |
| `webAuthnPolicyPasswordlessExtraOrigins` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` | `string` |  |
| `webAuthnPolicyPasswordlessRpEntityName` | `string` |  |
| `webAuthnPolicyPasswordlessRpId` | `string` |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` | `string` |  |
| `webAuthnPolicyRequireResidentKey` | `string` |  |
| `webAuthnPolicyRpEntityName` | `string` |  |
| `webAuthnPolicyRpId` | `string` |  |
| `webAuthnPolicySignatureAlgorithms` | `List<object?>` |  |
| `webAuthnPolicyUserVerificationRequirement` | `string` |  |

#### Example: List

```csharp
var getList = client.Get().List(null);
```


### GetByRealm

Create an instance: `var getByRealm = client.GetByRealm();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `accessCodeLifespan` | `long` |  |
| `accessCodeLifespanLogin` | `long` |  |
| `accessCodeLifespanUserAction` | `long` |  |
| `accessTokenLifespan` | `long` |  |
| `accessTokenLifespanForImplicitFlow` | `long` |  |
| `accountTheme` | `string` |  |
| `actionTokenGeneratedByAdminLifespan` | `long` |  |
| `actionTokenGeneratedByUserLifespan` | `long` |  |
| `adminEventsDetailsEnabled` | `bool` |  |
| `adminEventsEnabled` | `bool` |  |
| `adminTheme` | `string` |  |
| `applicationScopeMappings` | `Dictionary<string, object?>` |  |
| `applications` | `List<object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `authenticationFlows` | `List<object?>` |  |
| `authenticatorConfig` | `List<object?>` |  |
| `browserFlow` | `string` |  |
| `browserSecurityHeaders` | `Dictionary<string, object?>` |  |
| `bruteForceProtected` | `bool` |  |
| `certificate` | `string` |  |
| `clientAuthenticationFlow` | `string` |  |
| `clientOfflineSessionIdleTimeout` | `long` |  |
| `clientOfflineSessionMaxLifespan` | `long` |  |
| `clientPolicies` | `Dictionary<string, object?>` |  |
| `clientProfiles` | `Dictionary<string, object?>` |  |
| `clientScopeMappings` | `Dictionary<string, object?>` |  |
| `clientScopes` | `List<object?>` |  |
| `clientSessionIdleTimeout` | `long` |  |
| `clientSessionMaxLifespan` | `long` |  |
| `clientTemplates` | `List<object?>` |  |
| `clients` | `List<object?>` |  |
| `codeSecret` | `string` |  |
| `components` | `Dictionary<string, object?>` |  |
| `defaultDefaultClientScopes` | `List<object?>` |  |
| `defaultGroups` | `List<object?>` |  |
| `defaultLocale` | `string` |  |
| `defaultOptionalClientScopes` | `List<object?>` |  |
| `defaultRole` | `Dictionary<string, object?>` |  |
| `defaultRoles` | `List<object?>` |  |
| `defaultSignatureAlgorithm` | `string` |  |
| `directGrantFlow` | `string` |  |
| `displayName` | `string` |  |
| `displayNameHtml` | `string` |  |
| `dockerAuthenticationFlow` | `string` |  |
| `duplicateEmailsAllowed` | `bool` |  |
| `editUsernameAllowed` | `bool` |  |
| `emailTheme` | `string` |  |
| `enabled` | `bool` |  |
| `enabledEventTypes` | `List<object?>` |  |
| `eventsEnabled` | `bool` |  |
| `eventsExpiration` | `long` |  |
| `eventsListeners` | `List<object?>` |  |
| `failureFactor` | `long` |  |
| `federatedUsers` | `List<object?>` |  |
| `groups` | `List<object?>` |  |
| `id` | `string` |  |
| `identityProviderMappers` | `List<object?>` |  |
| `identityProviders` | `List<object?>` |  |
| `internationalizationEnabled` | `bool` |  |
| `keycloakVersion` | `string` |  |
| `localizationTexts` | `Dictionary<string, object?>` |  |
| `loginTheme` | `string` |  |
| `loginWithEmailAllowed` | `bool` |  |
| `maxDeltaTimeSeconds` | `long` |  |
| `maxFailureWaitSeconds` | `long` |  |
| `minimumQuickLoginWaitSeconds` | `long` |  |
| `notBefore` | `long` |  |
| `oAuth2DeviceCodeLifespan` | `long` |  |
| `oAuth2DevicePollingInterval` | `long` |  |
| `oauth2DeviceCodeLifespan` | `long` |  |
| `oauth2DevicePollingInterval` | `long` |  |
| `oauthClients` | `List<object?>` |  |
| `offlineSessionIdleTimeout` | `long` |  |
| `offlineSessionMaxLifespan` | `long` |  |
| `offlineSessionMaxLifespanEnabled` | `bool` |  |
| `otpPolicyAlgorithm` | `string` |  |
| `otpPolicyCodeReusable` | `bool` |  |
| `otpPolicyDigits` | `long` |  |
| `otpPolicyInitialCounter` | `long` |  |
| `otpPolicyLookAheadWindow` | `long` |  |
| `otpPolicyPeriod` | `long` |  |
| `otpPolicyType` | `string` |  |
| `otpSupportedApplications` | `List<object?>` |  |
| `passwordCredentialGrantAllowed` | `bool` |  |
| `passwordPolicy` | `string` |  |
| `permanentLockout` | `bool` |  |
| `privateKey` | `string` |  |
| `protocolMappers` | `List<object?>` |  |
| `publicKey` | `string` |  |
| `quickLoginCheckMilliSeconds` | `long` |  |
| `realm` | `string` |  |
| `realmCacheEnabled` | `bool` |  |
| `refreshTokenMaxReuse` | `long` |  |
| `registrationAllowed` | `bool` |  |
| `registrationEmailAsUsername` | `bool` |  |
| `registrationFlow` | `string` |  |
| `rememberMe` | `bool` |  |
| `requiredActions` | `List<object?>` |  |
| `requiredCredentials` | `List<object?>` |  |
| `resetCredentialsFlow` | `string` |  |
| `resetPasswordAllowed` | `bool` |  |
| `revokeRefreshToken` | `bool` |  |
| `roles` | `Dictionary<string, object?>` |  |
| `scopeMappings` | `List<object?>` |  |
| `smtpServer` | `Dictionary<string, object?>` |  |
| `social` | `bool` |  |
| `socialProviders` | `Dictionary<string, object?>` |  |
| `sslRequired` | `string` |  |
| `ssoSessionIdleTimeout` | `long` |  |
| `ssoSessionIdleTimeoutRememberMe` | `long` |  |
| `ssoSessionMaxLifespan` | `long` |  |
| `ssoSessionMaxLifespanRememberMe` | `long` |  |
| `supportedLocales` | `List<object?>` |  |
| `updateProfileOnInitialSocialLogin` | `bool` |  |
| `userCacheEnabled` | `bool` |  |
| `userFederationMappers` | `List<object?>` |  |
| `userFederationProviders` | `List<object?>` |  |
| `userManagedAccessAllowed` | `bool` |  |
| `users` | `List<object?>` |  |
| `verifyEmail` | `bool` |  |
| `waitIncrementSeconds` | `long` |  |
| `webAuthnPolicyAcceptableAaguids` | `List<object?>` |  |
| `webAuthnPolicyAttestationConveyancePreference` | `string` |  |
| `webAuthnPolicyAuthenticatorAttachment` | `string` |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` | `bool` |  |
| `webAuthnPolicyCreateTimeout` | `long` |  |
| `webAuthnPolicyExtraOrigins` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` | `string` |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` | `string` |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` | `bool` |  |
| `webAuthnPolicyPasswordlessCreateTimeout` | `long` |  |
| `webAuthnPolicyPasswordlessExtraOrigins` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` | `string` |  |
| `webAuthnPolicyPasswordlessRpEntityName` | `string` |  |
| `webAuthnPolicyPasswordlessRpId` | `string` |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` | `string` |  |
| `webAuthnPolicyRequireResidentKey` | `string` |  |
| `webAuthnPolicyRpEntityName` | `string` |  |
| `webAuthnPolicyRpId` | `string` |  |
| `webAuthnPolicySignatureAlgorithms` | `List<object?>` |  |
| `webAuthnPolicyUserVerificationRequirement` | `string` |  |

#### Example: List

```csharp
var getByRealmList = client.GetByRealm().List(null);
```


### GlobalRequestResult

Create an instance: `var globalRequestResult = client.GlobalRequestResult();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `failedRequests` | `List<object?>` |  |
| `successRequests` | `List<object?>` |  |

#### Example: List

```csharp
var globalRequestResultList = client.GlobalRequestResult().List(null);
```

#### Example: Create

```csharp
var globalRequestResult = client.GlobalRequestResult().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### Granted

Create an instance: `var granted = client.Granted();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: List

```csharp
var grantedList = client.Granted().List(null);
```


### Group

Create an instance: `var group = client.Group();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `access` | `Dictionary<string, object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRoles` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `parentId` | `string` |  |
| `path` | `string` |  |
| `realmRoles` | `List<object?>` |  |
| `subGroupCount` | `long` |  |
| `subGroups` | `List<object?>` |  |

#### Example: Load

```csharp
var group = client.Group().Load(new Dictionary<string, object?> { ["id"] = "group_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var groupList = client.Group().List(null);
```

#### Example: Create

```csharp
var group = client.Group().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### GroupRepresentation

Create an instance: `var groupRepresentation = client.GroupRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `access` | `Dictionary<string, object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRoles` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `parentId` | `string` |  |
| `path` | `string` |  |
| `realmRoles` | `List<object?>` |  |
| `subGroupCount` | `long` |  |
| `subGroups` | `List<object?>` |  |

#### Example: Load

```csharp
var groupRepresentation = client.GroupRepresentation().Load(new Dictionary<string, object?> { ["path"] = "path", ["realm"] = "realm" });
```

#### Example: List

```csharp
var groupRepresentationList = client.GroupRepresentation().List(null);
```


### IdToken

Create an instance: `var idToken = client.IdToken();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `acr` | `string` |  |
| `address` | `Dictionary<string, object?>` |  |
| `at_hash` | `string` |  |
| `authTime` | `long` |  |
| `auth_time` | `long` |  |
| `azp` | `string` |  |
| `birthdate` | `string` |  |
| `c_hash` | `string` |  |
| `claims_locales` | `string` |  |
| `email` | `string` |  |
| `email_verified` | `bool` |  |
| `exp` | `long` |  |
| `family_name` | `string` |  |
| `gender` | `string` |  |
| `given_name` | `string` |  |
| `iat` | `long` |  |
| `iss` | `string` |  |
| `jti` | `string` |  |
| `locale` | `string` |  |
| `middle_name` | `string` |  |
| `name` | `string` |  |
| `nbf` | `long` |  |
| `nickname` | `string` |  |
| `nonce` | `string` |  |
| `otherClaims` | `Dictionary<string, object?>` |  |
| `phone_number` | `string` |  |
| `phone_number_verified` | `bool` |  |
| `picture` | `string` |  |
| `preferred_username` | `string` |  |
| `profile` | `string` |  |
| `s_hash` | `string` |  |
| `session_state` | `string` |  |
| `sid` | `string` |  |
| `sub` | `string` |  |
| `typ` | `string` |  |
| `updated_at` | `long` |  |
| `website` | `string` |  |
| `zoneinfo` | `string` |  |

#### Example: Load

```csharp
var idToken = client.IdToken().Load(new Dictionary<string, object?> { ["client_id"] = "client_id", ["realm"] = "realm" });
```


### IdentityProvider

Create an instance: `var identityProvider = client.IdentityProvider();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `addReadTokenRoleOnCreate` | `bool` |  |
| `alias` | `string` |  |
| `authenticateByDefault` | `bool` |  |
| `config` | `Dictionary<string, object?>` |  |
| `displayName` | `string` |  |
| `enabled` | `bool` |  |
| `firstBrokerLoginFlowAlias` | `string` |  |
| `id` | `string` |  |
| `identityProviderAlias` | `string` |  |
| `identityProviderMapper` | `string` |  |
| `internalId` | `string` |  |
| `linkOnly` | `bool` |  |
| `name` | `string` |  |
| `postBrokerLoginFlowAlias` | `string` |  |
| `providerId` | `string` |  |
| `storeToken` | `bool` |  |
| `trustEmail` | `bool` |  |
| `updateProfileFirstLogin` | `bool` |  |
| `updateProfileFirstLoginMode` | `string` |  |

#### Example: Load

```csharp
var identityProvider = client.IdentityProvider().Load(new Dictionary<string, object?> { ["id"] = "identity_provider_id", ["realm"] = "realm" });
```

#### Example: Create

```csharp
var identityProvider = client.IdentityProvider().Create(new Dictionary<string, object?>
{
    ["alia"] = "example_alia",  // string
    ["realm"] = "example_realm",  // string
});
```


### IdentityProviderMapperRepresentation

Create an instance: `var identityProviderMapperRepresentation = client.IdentityProviderMapperRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `config` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |
| `identityProviderAlias` | `string` |  |
| `identityProviderMapper` | `string` |  |
| `name` | `string` |  |

#### Example: Load

```csharp
var identityProviderMapperRepresentation = client.IdentityProviderMapperRepresentation().Load(new Dictionary<string, object?> { ["id"] = "identity_provider_mapper_representation_id", ["alia"] = "alia", ["realm"] = "realm" });
```

#### Example: List

```csharp
var identityProviderMapperRepresentationList = client.IdentityProviderMapperRepresentation().List(null);
```


### IdentityProviderRepresentation

Create an instance: `var identityProviderRepresentation = client.IdentityProviderRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `addReadTokenRoleOnCreate` | `bool` |  |
| `alias` | `string` |  |
| `authenticateByDefault` | `bool` |  |
| `config` | `Dictionary<string, object?>` |  |
| `displayName` | `string` |  |
| `enabled` | `bool` |  |
| `firstBrokerLoginFlowAlias` | `string` |  |
| `internalId` | `string` |  |
| `linkOnly` | `bool` |  |
| `postBrokerLoginFlowAlias` | `string` |  |
| `providerId` | `string` |  |
| `storeToken` | `bool` |  |
| `trustEmail` | `bool` |  |
| `updateProfileFirstLogin` | `bool` |  |
| `updateProfileFirstLoginMode` | `string` |  |

#### Example: Load

```csharp
var identityProviderRepresentation = client.IdentityProviderRepresentation().Load(new Dictionary<string, object?> { ["alia"] = "alia", ["realm"] = "realm" });
```

#### Example: List

```csharp
var identityProviderRepresentationList = client.IdentityProviderRepresentation().List(null);
```


### Key

Create an instance: `var key = client.Key();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `algorithm` | `string` |  |
| `certificate` | `string` |  |
| `kid` | `string` |  |
| `providerId` | `string` |  |
| `providerPriority` | `long` |  |
| `publicKey` | `string` |  |
| `status` | `string` |  |
| `type` | `string` |  |
| `use` | `Dictionary<string, object?>` |  |
| `validTo` | `long` |  |

#### Example: List

```csharp
var keyList = client.Key().List(null);
```


### ManagementPermissionReference

Create an instance: `var managementPermissionReference = client.ManagementPermissionReference();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `enabled` | `bool` |  |
| `resource` | `string` |  |
| `scopePermissions` | `Dictionary<string, object?>` |  |

#### Example: Load

```csharp
var managementPermissionReference = client.ManagementPermissionReference().Load(new Dictionary<string, object?> { ["realm"] = "realm" });
```


### MappingsRepresentation

Create an instance: `var mappingsRepresentation = client.MappingsRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: List

```csharp
var mappingsRepresentationList = client.MappingsRepresentation().List(null);
```


### NotGranted

Create an instance: `var notGranted = client.NotGranted();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: List

```csharp
var notGrantedList = client.NotGranted().List(null);
```


### Post

Create an instance: `var post = client.Post();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |

#### Example: Create

```csharp
var post = client.Post().Create(new Dictionary<string, object?>
{
});
```


### Protocol

Create an instance: `var protocol = client.Protocol();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `config` | `Dictionary<string, object?>` |  |
| `consentRequired` | `bool` |  |
| `consentText` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `protocol` | `string` |  |
| `protocolMapper` | `string` |  |

#### Example: Load

```csharp
var protocol = client.Protocol().Load(new Dictionary<string, object?> { ["id"] = "protocol_id", ["realm"] = "realm" });
```


### ProtocolMapper

Create an instance: `var protocolMapper = client.ProtocolMapper();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `config` | `Dictionary<string, object?>` |  |
| `consentRequired` | `bool` |  |
| `consentText` | `string` |  |
| `containerId` | `string` |  |
| `containerName` | `string` |  |
| `containerType` | `string` |  |
| `id` | `string` |  |
| `mapperId` | `string` |  |
| `mapperName` | `string` |  |
| `name` | `string` |  |
| `protocol` | `string` |  |
| `protocolMapper` | `string` |  |

#### Example: List

```csharp
var protocolMapperList = client.ProtocolMapper().List(null);
```


### ProtocolMapperRepresentation

Create an instance: `var protocolMapperRepresentation = client.ProtocolMapperRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `config` | `Dictionary<string, object?>` |  |
| `consentRequired` | `bool` |  |
| `consentText` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `protocol` | `string` |  |
| `protocolMapper` | `string` |  |

#### Example: Load

```csharp
var protocolMapperRepresentation = client.ProtocolMapperRepresentation().Load(new Dictionary<string, object?> { ["id2"] = "id2", ["realm"] = "realm" });
```

#### Example: List

```csharp
var protocolMapperRepresentationList = client.ProtocolMapperRepresentation().List(null);
```


### PutByRealm

Create an instance: `var putByRealm = client.PutByRealm();`

#### Operations

| Method | Description |
| --- | --- |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `accessCodeLifespan` | `long` |  |
| `accessCodeLifespanLogin` | `long` |  |
| `accessCodeLifespanUserAction` | `long` |  |
| `accessTokenLifespan` | `long` |  |
| `accessTokenLifespanForImplicitFlow` | `long` |  |
| `accountTheme` | `string` |  |
| `actionTokenGeneratedByAdminLifespan` | `long` |  |
| `actionTokenGeneratedByUserLifespan` | `long` |  |
| `adminEventsDetailsEnabled` | `bool` |  |
| `adminEventsEnabled` | `bool` |  |
| `adminTheme` | `string` |  |
| `applicationScopeMappings` | `Dictionary<string, object?>` |  |
| `applications` | `List<object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `authenticationFlows` | `List<object?>` |  |
| `authenticatorConfig` | `List<object?>` |  |
| `browserFlow` | `string` |  |
| `browserSecurityHeaders` | `Dictionary<string, object?>` |  |
| `bruteForceProtected` | `bool` |  |
| `certificate` | `string` |  |
| `clientAuthenticationFlow` | `string` |  |
| `clientOfflineSessionIdleTimeout` | `long` |  |
| `clientOfflineSessionMaxLifespan` | `long` |  |
| `clientPolicies` | `Dictionary<string, object?>` |  |
| `clientProfiles` | `Dictionary<string, object?>` |  |
| `clientScopeMappings` | `Dictionary<string, object?>` |  |
| `clientScopes` | `List<object?>` |  |
| `clientSessionIdleTimeout` | `long` |  |
| `clientSessionMaxLifespan` | `long` |  |
| `clientTemplates` | `List<object?>` |  |
| `clients` | `List<object?>` |  |
| `codeSecret` | `string` |  |
| `components` | `Dictionary<string, object?>` |  |
| `defaultDefaultClientScopes` | `List<object?>` |  |
| `defaultGroups` | `List<object?>` |  |
| `defaultLocale` | `string` |  |
| `defaultOptionalClientScopes` | `List<object?>` |  |
| `defaultRole` | `Dictionary<string, object?>` |  |
| `defaultRoles` | `List<object?>` |  |
| `defaultSignatureAlgorithm` | `string` |  |
| `directGrantFlow` | `string` |  |
| `displayName` | `string` |  |
| `displayNameHtml` | `string` |  |
| `dockerAuthenticationFlow` | `string` |  |
| `duplicateEmailsAllowed` | `bool` |  |
| `editUsernameAllowed` | `bool` |  |
| `emailTheme` | `string` |  |
| `enabled` | `bool` |  |
| `enabledEventTypes` | `List<object?>` |  |
| `eventsEnabled` | `bool` |  |
| `eventsExpiration` | `long` |  |
| `eventsListeners` | `List<object?>` |  |
| `failureFactor` | `long` |  |
| `federatedUsers` | `List<object?>` |  |
| `groups` | `List<object?>` |  |
| `id` | `string` |  |
| `identityProviderMappers` | `List<object?>` |  |
| `identityProviders` | `List<object?>` |  |
| `internationalizationEnabled` | `bool` |  |
| `keycloakVersion` | `string` |  |
| `localizationTexts` | `Dictionary<string, object?>` |  |
| `loginTheme` | `string` |  |
| `loginWithEmailAllowed` | `bool` |  |
| `maxDeltaTimeSeconds` | `long` |  |
| `maxFailureWaitSeconds` | `long` |  |
| `minimumQuickLoginWaitSeconds` | `long` |  |
| `notBefore` | `long` |  |
| `oAuth2DeviceCodeLifespan` | `long` |  |
| `oAuth2DevicePollingInterval` | `long` |  |
| `oauth2DeviceCodeLifespan` | `long` |  |
| `oauth2DevicePollingInterval` | `long` |  |
| `oauthClients` | `List<object?>` |  |
| `offlineSessionIdleTimeout` | `long` |  |
| `offlineSessionMaxLifespan` | `long` |  |
| `offlineSessionMaxLifespanEnabled` | `bool` |  |
| `otpPolicyAlgorithm` | `string` |  |
| `otpPolicyCodeReusable` | `bool` |  |
| `otpPolicyDigits` | `long` |  |
| `otpPolicyInitialCounter` | `long` |  |
| `otpPolicyLookAheadWindow` | `long` |  |
| `otpPolicyPeriod` | `long` |  |
| `otpPolicyType` | `string` |  |
| `otpSupportedApplications` | `List<object?>` |  |
| `passwordCredentialGrantAllowed` | `bool` |  |
| `passwordPolicy` | `string` |  |
| `permanentLockout` | `bool` |  |
| `privateKey` | `string` |  |
| `protocolMappers` | `List<object?>` |  |
| `publicKey` | `string` |  |
| `quickLoginCheckMilliSeconds` | `long` |  |
| `realm` | `string` |  |
| `realmCacheEnabled` | `bool` |  |
| `refreshTokenMaxReuse` | `long` |  |
| `registrationAllowed` | `bool` |  |
| `registrationEmailAsUsername` | `bool` |  |
| `registrationFlow` | `string` |  |
| `rememberMe` | `bool` |  |
| `requiredActions` | `List<object?>` |  |
| `requiredCredentials` | `List<object?>` |  |
| `resetCredentialsFlow` | `string` |  |
| `resetPasswordAllowed` | `bool` |  |
| `revokeRefreshToken` | `bool` |  |
| `roles` | `Dictionary<string, object?>` |  |
| `scopeMappings` | `List<object?>` |  |
| `smtpServer` | `Dictionary<string, object?>` |  |
| `social` | `bool` |  |
| `socialProviders` | `Dictionary<string, object?>` |  |
| `sslRequired` | `string` |  |
| `ssoSessionIdleTimeout` | `long` |  |
| `ssoSessionIdleTimeoutRememberMe` | `long` |  |
| `ssoSessionMaxLifespan` | `long` |  |
| `ssoSessionMaxLifespanRememberMe` | `long` |  |
| `supportedLocales` | `List<object?>` |  |
| `updateProfileOnInitialSocialLogin` | `bool` |  |
| `userCacheEnabled` | `bool` |  |
| `userFederationMappers` | `List<object?>` |  |
| `userFederationProviders` | `List<object?>` |  |
| `userManagedAccessAllowed` | `bool` |  |
| `users` | `List<object?>` |  |
| `verifyEmail` | `bool` |  |
| `waitIncrementSeconds` | `long` |  |
| `webAuthnPolicyAcceptableAaguids` | `List<object?>` |  |
| `webAuthnPolicyAttestationConveyancePreference` | `string` |  |
| `webAuthnPolicyAuthenticatorAttachment` | `string` |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` | `bool` |  |
| `webAuthnPolicyCreateTimeout` | `long` |  |
| `webAuthnPolicyExtraOrigins` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` | `string` |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` | `string` |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` | `bool` |  |
| `webAuthnPolicyPasswordlessCreateTimeout` | `long` |  |
| `webAuthnPolicyPasswordlessExtraOrigins` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` | `string` |  |
| `webAuthnPolicyPasswordlessRpEntityName` | `string` |  |
| `webAuthnPolicyPasswordlessRpId` | `string` |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` | `List<object?>` |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` | `string` |  |
| `webAuthnPolicyRequireResidentKey` | `string` |  |
| `webAuthnPolicyRpEntityName` | `string` |  |
| `webAuthnPolicyRpId` | `string` |  |
| `webAuthnPolicySignatureAlgorithms` | `List<object?>` |  |
| `webAuthnPolicyUserVerificationRequirement` | `string` |  |


### Realm

Create an instance: `var realm = client.Realm();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: List

```csharp
var realmList = client.Realm().List(null);
```


### RealmEventsConfigRepresentation

Create an instance: `var realmEventsConfigRepresentation = client.RealmEventsConfigRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `adminEventsDetailsEnabled` | `bool` |  |
| `adminEventsEnabled` | `bool` |  |
| `enabledEventTypes` | `List<object?>` |  |
| `eventsEnabled` | `bool` |  |
| `eventsExpiration` | `long` |  |
| `eventsListeners` | `List<object?>` |  |

#### Example: List

```csharp
var realmEventsConfigRepresentationList = client.RealmEventsConfigRepresentation().List(null);
```


### RealmsAdmin

Create an instance: `var realmsAdmin = client.RealmsAdmin();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `adminEventsDetailsEnabled` | `bool` |  |
| `adminEventsEnabled` | `bool` |  |
| `enabledEventTypes` | `List<object?>` |  |
| `eventsEnabled` | `bool` |  |
| `eventsExpiration` | `long` |  |
| `eventsListeners` | `List<object?>` |  |
| `globalProfiles` | `List<object?>` |  |
| `id` | `string` |  |
| `policies` | `List<object?>` |  |
| `profiles` | `List<object?>` |  |

#### Example: Load

```csharp
var realmsAdmin = client.RealmsAdmin().Load(new Dictionary<string, object?> { ["locale"] = "locale", ["realm"] = "realm" });
```

#### Example: List

```csharp
var realmsAdminList = client.RealmsAdmin().List(null);
```

#### Example: Create

```csharp
var realmsAdmin = client.RealmsAdmin().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### RequiredAction

Create an instance: `var requiredAction = client.RequiredAction();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `alias` | `string` |  |
| `config` | `Dictionary<string, object?>` |  |
| `defaultAction` | `bool` |  |
| `enabled` | `bool` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `priority` | `long` |  |
| `providerId` | `string` |  |

#### Example: Load

```csharp
var requiredAction = client.RequiredAction().Load(new Dictionary<string, object?> { ["id"] = "required_action_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var requiredActionList = client.RequiredAction().List(null);
```


### Role

Create an instance: `var role = client.Role();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: Load

```csharp
var role = client.Role().Load(new Dictionary<string, object?> { ["id"] = "role_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var roleList = client.Role().List(null);
```

#### Example: Create

```csharp
var role = client.Role().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### RoleMapper

Create an instance: `var roleMapper = client.RoleMapper();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `Remove(match)` | Remove the matching entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: Create

```csharp
var roleMapper = client.RoleMapper().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### RolesById

Create an instance: `var rolesById = client.RolesById();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: Load

```csharp
var rolesById = client.RolesById().Load(new Dictionary<string, object?> { ["id"] = "roles_by_id_id", ["realm"] = "realm" });
```

#### Example: Create

```csharp
var rolesById = client.RolesById().Create(new Dictionary<string, object?>
{
    ["id"] = "example_id",  // string
    ["realm"] = "example_realm",  // string
});
```


### ScopeMapping

Create an instance: `var scopeMapping = client.ScopeMapping();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `Remove(match)` | Remove the matching entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientRole` | `bool` |  |
| `composite` | `bool` |  |
| `composites` | `Dictionary<string, object?>` |  |
| `containerId` | `string` |  |
| `description` | `string` |  |
| `id` | `string` |  |
| `name` | `string` |  |
| `scopeParamRequired` | `bool` |  |

#### Example: Create

```csharp
var scopeMapping = client.ScopeMapping().Create(new Dictionary<string, object?>
{
    ["client"] = "example_client",  // string
    ["realm"] = "example_realm",  // string
});
```


### UpConfig

Create an instance: `var upConfig = client.UpConfig();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `attributes` | `List<object?>` |  |
| `groups` | `List<object?>` |  |

#### Example: List

```csharp
var upConfigList = client.UpConfig().List(null);
```


### User

Create an instance: `var user = client.User();`

#### Operations

| Method | Description |
| --- | --- |
| `Create(data)` | Create a new entity with the given data. |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |
| `Remove(match)` | Remove the matching entity. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `access` | `Dictionary<string, object?>` |  |
| `applicationRoles` | `Dictionary<string, object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientConsents` | `List<object?>` |  |
| `clientRoles` | `Dictionary<string, object?>` |  |
| `createdTimestamp` | `long` |  |
| `credentials` | `List<object?>` |  |
| `disableableCredentialTypes` | `List<object?>` |  |
| `email` | `string` |  |
| `emailVerified` | `bool` |  |
| `enabled` | `bool` |  |
| `federatedIdentities` | `List<object?>` |  |
| `federationLink` | `string` |  |
| `firstName` | `string` |  |
| `groups` | `List<object?>` |  |
| `id` | `string` |  |
| `lastName` | `string` |  |
| `notBefore` | `long` |  |
| `origin` | `string` |  |
| `realmRoles` | `List<object?>` |  |
| `requiredActions` | `List<object?>` |  |
| `self` | `string` |  |
| `serviceAccountClientId` | `string` |  |
| `socialLinks` | `List<object?>` |  |
| `totp` | `bool` |  |
| `userProfileMetadata` | `Dictionary<string, object?>` |  |
| `username` | `string` |  |

#### Example: Load

```csharp
var user = client.User().Load(new Dictionary<string, object?> { ["id"] = "user_id", ["realm"] = "realm" });
```

#### Example: List

```csharp
var userList = client.User().List(null);
```

#### Example: Create

```csharp
var user = client.User().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```


### UserRepresentation

Create an instance: `var userRepresentation = client.UserRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `access` | `Dictionary<string, object?>` |  |
| `applicationRoles` | `Dictionary<string, object?>` |  |
| `attributes` | `Dictionary<string, object?>` |  |
| `clientConsents` | `List<object?>` |  |
| `clientRoles` | `Dictionary<string, object?>` |  |
| `createdTimestamp` | `long` |  |
| `credentials` | `List<object?>` |  |
| `disableableCredentialTypes` | `List<object?>` |  |
| `email` | `string` |  |
| `emailVerified` | `bool` |  |
| `enabled` | `bool` |  |
| `federatedIdentities` | `List<object?>` |  |
| `federationLink` | `string` |  |
| `firstName` | `string` |  |
| `groups` | `List<object?>` |  |
| `id` | `string` |  |
| `lastName` | `string` |  |
| `notBefore` | `long` |  |
| `origin` | `string` |  |
| `realmRoles` | `List<object?>` |  |
| `requiredActions` | `List<object?>` |  |
| `self` | `string` |  |
| `serviceAccountClientId` | `string` |  |
| `socialLinks` | `List<object?>` |  |
| `totp` | `bool` |  |
| `userProfileMetadata` | `Dictionary<string, object?>` |  |
| `username` | `string` |  |

#### Example: List

```csharp
var userRepresentationList = client.UserRepresentation().List(null);
```


### UserSession

Create an instance: `var userSession = client.UserSession();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `clients` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |
| `ipAddress` | `string` |  |
| `lastAccess` | `long` |  |
| `rememberMe` | `bool` |  |
| `start` | `long` |  |
| `userId` | `string` |  |
| `username` | `string` |  |

#### Example: List

```csharp
var userSessionList = client.UserSession().List(null);
```


### UserSessionRepresentation

Create an instance: `var userSessionRepresentation = client.UserSessionRepresentation();`

#### Operations

| Method | Description |
| --- | --- |
| `List(null)` | List entities, optionally matching the given criteria. |
| `Load(match)` | Load a single entity by match criteria. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `clients` | `Dictionary<string, object?>` |  |
| `id` | `string` |  |
| `ipAddress` | `string` |  |
| `lastAccess` | `long` |  |
| `rememberMe` | `bool` |  |
| `start` | `long` |  |
| `userId` | `string` |  |
| `username` | `string` |  |

#### Example: Load

```csharp
var userSessionRepresentation = client.UserSessionRepresentation().Load(new Dictionary<string, object?> { ["client_uuid"] = "client_uuid", ["realm"] = "realm", ["user_id"] = "user_id" });
```

#### Example: List

```csharp
var userSessionRepresentationList = client.UserSessionRepresentation().List(null);
```


### UsersManagementPermission

Create an instance: `var usersManagementPermission = client.UsersManagementPermission();`

#### Operations

| Method | Description |
| --- | --- |
| `Load(match)` | Load a single entity by match criteria. |
| `Update(data)` | Update an existing entity. |

#### Fields

| Field | Type | Description |
| --- | --- | --- |
| `enabled` | `bool` |  |
| `resource` | `string` |  |
| `scopePermissions` | `Dictionary<string, object?>` |  |

#### Example: Load

```csharp
var usersManagementPermission = client.UsersManagementPermission().Load(new Dictionary<string, object?> { ["realm"] = "realm" });
```

## Features

This SDK ships 1 optional features. Each is **inactive until you
switch it on**, so an SDK you have not configured behaves exactly as if none of
them existed — no retries, no cache, no logging, no measurable overhead.

Activate a feature by name in the client options, alongside the options shown
above:

| Feature | What it does |
|---|---|
| [`test`](#test) | Test transport |

### test

Test transport.

| Option | Default |
|---|---|
| `active` | `false` |

Set `feature.test.active` to enable it, then override any of the options above.


## Advanced

> The sections above cover everyday use. The material below explains the
> SDK's internals — useful when extending it with custom features, but not
> needed for normal use.

### The operation pipeline

Every entity operation follows a six-stage pipeline. Each stage fires a
feature hook before executing:

```
PrePoint → PreSpec → PreRequest → PreResponse → PreResult → PreDone
```

- **PrePoint**: Resolves which API endpoint to call based on the
  operation name and entity configuration.
- **PreSpec**: Builds the HTTP spec — URL, method, headers, body —
  from the resolved point and the caller's parameters.
- **PreRequest**: Sends the HTTP request. Features can intercept here
  to replace the transport (as TestFeature does with mocks).
- **PreResponse**: Parses the raw HTTP response.
- **PreResult**: Extracts the business data from the parsed response.
- **PreDone**: Final stage before returning to the caller. Entity
  state (match, data) is updated here.

If any stage errors, the pipeline short-circuits and the error surfaces
to the caller — see [Error handling](#error-handling) for how that looks
in this language.

### Features and hooks

Features are the extension mechanism. A feature is an object with a
`hooks` map. Each hook key is a pipeline stage name, and the value is
a function that receives the context.

The SDK ships with built-in features:

- **TestFeature**: Test transport

Features are initialized in order. Hooks fire in the order features
were added, so later features can override earlier ones.

### Data as dictionaries

The C# SDK uses a loose object model — `Dictionary<string, object?>`
throughout — rather than a bespoke typed class per endpoint. This mirrors
the dynamic nature of the API and keeps the SDK flexible: no regeneration is
needed when the API schema changes.

Use `Helpers.ToMapAny(value)` to safely coerce a value to a
`Dictionary<string, object?>`. A `VoxgigKeycloakSdkTypes.cs` module of
reference `record` types is also generated for editor documentation.

### Project structure

```
csharp/
├── VoxgigKeycloakSdkSDK.csproj    -- Library project (compiles everything except test/)
├── core/                       -- Main SDK client, config, entity base, error type
├── entity/                     -- Entity implementations
├── feature/                    -- Built-in features (Base, Test, Log, ...)
├── utility/                    -- Utility functions and the vendored struct library
└── test/                       -- xUnit test suites
```

The main client class (`VoxgigKeycloakSdkSDK`, namespace
`VoxgigKeycloakSdkSdk`) exposes the entity accessors. Reference entity or
utility types directly only when needed.

### Entity state

Entity instances are stateful. After a successful `load`, the entity
stores the returned data and match criteria internally. Subsequent
calls on the same instance can rely on this state.

```ts
const certificate = client.Certificate()
await certificate.load({ client_id: "example", id: "example_id", realm: "example" })

// certificate.data() now returns the certificate data from the last `load`
// certificate.match() returns { id: "example_id" }
```

Call `make()` to create a fresh instance with the same configuration
but no stored state.

### Direct vs entity access

The entity interface handles URL construction, parameter placement,
and response parsing automatically. Use it for standard CRUD operations.

The `direct` method gives full control over the HTTP request. Use it
for non-standard endpoints, bulk operations, or any path not modelled
as an entity. The `prepare` method is useful for debugging — it
shows exactly what `direct` would send.


## Full Reference

See [REFERENCE.md](REFERENCE.md) for complete API reference
documentation including all method signatures, entity field schemas,
and detailed usage examples.
