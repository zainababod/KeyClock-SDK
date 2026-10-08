# VoxgigKeycloakSdk C# SDK Reference

Complete API reference for the VoxgigKeycloakSdk C# SDK.


## VoxgigKeycloakSdkSDK

### Constructor

```csharp
using VoxgigKeycloakSdkSdk;

var client = new VoxgigKeycloakSdkSDK(options);
```

Create a new SDK client instance. `options` is a
`Dictionary<string, object?>`.

**Parameters:**

| Name | Type | Description |
| --- | --- | --- |
| `options` | `Dictionary` | SDK configuration options. |
| `options["apikey"]` | `string` | API key for authentication. |
| `options["base"]` | `string` | Base URL for API requests. |
| `options["prefix"]` | `string` | URL prefix appended after base. |
| `options["suffix"]` | `string` | URL suffix appended after path. |
| `options["headers"]` | `Dictionary` | Custom headers for all requests. |
| `options["feature"]` | `Dictionary` | Feature configuration. |
| `options["system"]` | `Dictionary` | System overrides (e.g. custom fetch). |


### Static Methods

#### `VoxgigKeycloakSdkSDK.TestSDK(testopts = null, sdkopts = null)`

Create a test client with mock features active. Both arguments may be `null`.

```csharp
var client = VoxgigKeycloakSdkSDK.TestSDK(null, null);
```


### Instance Methods

#### `AccessToken(entopts = null)`

Create a new `AccessToken` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `AdminEvent(entopts = null)`

Create a new `AdminEvent` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `AttackDetection(entopts = null)`

Create a new `AttackDetection` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `AuthenticationFlowRepresentation(entopts = null)`

Create a new `AuthenticationFlowRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `AuthenticationManagement(entopts = null)`

Create a new `AuthenticationManagement` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `AuthenticatorConfigInfoRepresentation(entopts = null)`

Create a new `AuthenticatorConfigInfoRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `AuthenticatorConfigRepresentation(entopts = null)`

Create a new `AuthenticatorConfigRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Available(entopts = null)`

Create a new `Available` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Certificate(entopts = null)`

Create a new `Certificate` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `CertificateRepresentation(entopts = null)`

Create a new `CertificateRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Client(entopts = null)`

Create a new `Client` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientInitialAccess(entopts = null)`

Create a new `ClientInitialAccess` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientInitialAccessPresentation(entopts = null)`

Create a new `ClientInitialAccessPresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientPolicyRepresentation(entopts = null)`

Create a new `ClientPolicyRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientProfilesRepresentation(entopts = null)`

Create a new `ClientProfilesRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientRepresentation(entopts = null)`

Create a new `ClientRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientScope(entopts = null)`

Create a new `ClientScope` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ClientScopeRepresentation(entopts = null)`

Create a new `ClientScopeRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Component(entopts = null)`

Create a new `Component` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ComponentTypeRepresentation(entopts = null)`

Create a new `ComponentTypeRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Composite(entopts = null)`

Create a new `Composite` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Credential(entopts = null)`

Create a new `Credential` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `CredentialRepresentation(entopts = null)`

Create a new `CredentialRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `DeleteByRealm(entopts = null)`

Create a new `DeleteByRealm` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Event(entopts = null)`

Create a new `Event` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `FederatedIdentity(entopts = null)`

Create a new `FederatedIdentity` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Flow(entopts = null)`

Create a new `Flow` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Get(entopts = null)`

Create a new `Get` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `GetByRealm(entopts = null)`

Create a new `GetByRealm` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `GlobalRequestResult(entopts = null)`

Create a new `GlobalRequestResult` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Granted(entopts = null)`

Create a new `Granted` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Group(entopts = null)`

Create a new `Group` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `GroupRepresentation(entopts = null)`

Create a new `GroupRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `IdToken(entopts = null)`

Create a new `IdToken` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `IdentityProvider(entopts = null)`

Create a new `IdentityProvider` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `IdentityProviderMapperRepresentation(entopts = null)`

Create a new `IdentityProviderMapperRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `IdentityProviderRepresentation(entopts = null)`

Create a new `IdentityProviderRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Key(entopts = null)`

Create a new `Key` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ManagementPermissionReference(entopts = null)`

Create a new `ManagementPermissionReference` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `MappingsRepresentation(entopts = null)`

Create a new `MappingsRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `NotGranted(entopts = null)`

Create a new `NotGranted` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Post(entopts = null)`

Create a new `Post` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Protocol(entopts = null)`

Create a new `Protocol` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ProtocolMapper(entopts = null)`

Create a new `ProtocolMapper` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ProtocolMapperRepresentation(entopts = null)`

Create a new `ProtocolMapperRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `PutByRealm(entopts = null)`

Create a new `PutByRealm` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Realm(entopts = null)`

Create a new `Realm` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `RealmEventsConfigRepresentation(entopts = null)`

Create a new `RealmEventsConfigRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `RealmsAdmin(entopts = null)`

Create a new `RealmsAdmin` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `RequiredAction(entopts = null)`

Create a new `RequiredAction` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `Role(entopts = null)`

Create a new `Role` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `RoleMapper(entopts = null)`

Create a new `RoleMapper` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `RolesById(entopts = null)`

Create a new `RolesById` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `ScopeMapping(entopts = null)`

Create a new `ScopeMapping` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `UpConfig(entopts = null)`

Create a new `UpConfig` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `User(entopts = null)`

Create a new `User` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `UserRepresentation(entopts = null)`

Create a new `UserRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `UserSession(entopts = null)`

Create a new `UserSession` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `UserSessionRepresentation(entopts = null)`

Create a new `UserSessionRepresentation` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `UsersManagementPermission(entopts = null)`

Create a new `UsersManagementPermission` entity instance (returns
`VoxgigKeycloakSdkEntityBase`). Pass `null` for no initial options.

#### `OptionsMap() -> Dictionary`

Return a deep copy of the current SDK options.

#### `GetUtility() -> Utility`

Return a copy of the SDK utility object.

#### `Direct(fetchargs = null) -> Dictionary`

Make a direct HTTP request to any API endpoint. Returns a result
`Dictionary<string, object?>` with `ok`, `status`, `headers`, and `data`
(or `err` on failure). This escape hatch never raises — branch on
`result["ok"]`.

**Parameters:**

| Name | Type | Description |
| --- | --- | --- |
| `fetchargs["path"]` | `string` | URL path with optional `{param}` placeholders. |
| `fetchargs["method"]` | `string` | HTTP method (default: `"GET"`). |
| `fetchargs["params"]` | `Dictionary` | Path parameter values. |
| `fetchargs["query"]` | `Dictionary` | Query string parameters. |
| `fetchargs["headers"]` | `Dictionary` | Request headers (merged with defaults). |
| `fetchargs["body"]` | `object?` | Request body (dictionaries are JSON-serialized). |

**Returns:** `Dictionary<string, object?>`

#### `Prepare(fetchargs = null) -> Dictionary`

Prepare a fetch definition without sending. Returns the `fetchdef` and raises on error.


---

## AccessToken

```csharp
var accessToken = client.AccessToken();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `acr` | `string` | No |  |
| `address` | `Dictionary<string, object?>` | No |  |
| `allowedorigins` | `List<object?>` | No |  |
| `at_hash` | `string` | No |  |
| `authTime` | `long` | No |  |
| `auth_time` | `long` | No |  |
| `authorization` | `Dictionary<string, object?>` | No |  |
| `azp` | `string` | No |  |
| `birthdate` | `string` | No |  |
| `c_hash` | `string` | No |  |
| `claims_locales` | `string` | No |  |
| `cnf` | `Dictionary<string, object?>` | No |  |
| `email` | `string` | No |  |
| `email_verified` | `bool` | No |  |
| `exp` | `long` | No |  |
| `family_name` | `string` | No |  |
| `gender` | `string` | No |  |
| `given_name` | `string` | No |  |
| `iat` | `long` | No |  |
| `iss` | `string` | No |  |
| `jti` | `string` | No |  |
| `locale` | `string` | No |  |
| `middle_name` | `string` | No |  |
| `name` | `string` | No |  |
| `nbf` | `long` | No |  |
| `nickname` | `string` | No |  |
| `nonce` | `string` | No |  |
| `otherClaims` | `Dictionary<string, object?>` | No |  |
| `phone_number` | `string` | No |  |
| `phone_number_verified` | `bool` | No |  |
| `picture` | `string` | No |  |
| `preferred_username` | `string` | No |  |
| `profile` | `string` | No |  |
| `realm_access` | `Dictionary<string, object?>` | No |  |
| `resource_access` | `Dictionary<string, object?>` | No |  |
| `s_hash` | `string` | No |  |
| `scope` | `string` | No |  |
| `session_state` | `string` | No |  |
| `sid` | `string` | No |  |
| `sub` | `string` | No |  |
| `trustedcerts` | `List<object?>` | No |  |
| `typ` | `string` | No |  |
| `updated_at` | `long` | No |  |
| `website` | `string` | No |  |
| `zoneinfo` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.AccessToken().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AccessToken` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## AdminEvent

```csharp
var adminEvent = client.AdminEvent();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `authDetails` | `Dictionary<string, object?>` | No |  |
| `error` | `string` | No |  |
| `operationType` | `string` | No |  |
| `realmId` | `string` | No |  |
| `representation` | `string` | No |  |
| `resourcePath` | `string` | No |  |
| `resourceType` | `string` | No |  |
| `time` | `long` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.AdminEvent().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AdminEvent` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## AttackDetection

```csharp
var attackDetection = client.AttackDetection();
```

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.AttackDetection().Load(new Dictionary<string, object?> { ["realm"] = "realm", ["user_id"] = "user_id" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.AttackDetection().Remove(new Dictionary<string, object?> { ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AttackDetection` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## AuthenticationFlowRepresentation

```csharp
var authenticationFlowRepresentation = client.AuthenticationFlowRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `alias` | `string` | No |  |
| `authenticationExecutions` | `List<object?>` | No |  |
| `builtIn` | `bool` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `providerId` | `string` | No |  |
| `topLevel` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.AuthenticationFlowRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.AuthenticationFlowRepresentation().Load(new Dictionary<string, object?> { ["id"] = "authentication_flow_representation_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AuthenticationFlowRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## AuthenticationManagement

```csharp
var authenticationManagement = client.AuthenticationManagement();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `alias` | `string` | No |  |
| `authenticationConfig` | `string` | No |  |
| `authenticationExecutions` | `List<object?>` | No |  |
| `authenticationFlow` | `bool` | No |  |
| `authenticator` | `string` | No |  |
| `authenticatorConfig` | `string` | No |  |
| `authenticatorFlow` | `bool` | No |  |
| `autheticatorFlow` | `bool` | No |  |
| `builtIn` | `bool` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `configurable` | `bool` | No |  |
| `defaultAction` | `bool` | No |  |
| `defaultValue` | `object?` | No |  |
| `description` | `string` | No |  |
| `displayName` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `flowId` | `string` | No |  |
| `helpText` | `string` | No |  |
| `id` | `string` | No |  |
| `index` | `long` | No |  |
| `label` | `string` | No |  |
| `level` | `long` | No |  |
| `name` | `string` | No |  |
| `options` | `List<object?>` | No |  |
| `parentFlow` | `string` | No |  |
| `priority` | `long` | No |  |
| `providerId` | `string` | No |  |
| `readOnly` | `bool` | No |  |
| `required` | `bool` | No |  |
| `requirement` | `string` | No |  |
| `requirementChoices` | `List<object?>` | No |  |
| `secret` | `bool` | No |  |
| `topLevel` | `bool` | No |  |
| `type` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.AuthenticationManagement().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.AuthenticationManagement().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.AuthenticationManagement().Load(new Dictionary<string, object?> { ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.AuthenticationManagement().Remove(new Dictionary<string, object?> { ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.AuthenticationManagement().Update(new Dictionary<string, object?>
{
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AuthenticationManagement` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## AuthenticatorConfigInfoRepresentation

```csharp
var authenticatorConfigInfoRepresentation = client.AuthenticatorConfigInfoRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `helpText` | `string` | No |  |
| `name` | `string` | No |  |
| `properties` | `List<object?>` | No |  |
| `providerId` | `string` | No |  |

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.AuthenticatorConfigInfoRepresentation().Load(new Dictionary<string, object?> { ["provider_id"] = "provider_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AuthenticatorConfigInfoRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## AuthenticatorConfigRepresentation

```csharp
var authenticatorConfigRepresentation = client.AuthenticatorConfigRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `alias` | `string` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.AuthenticatorConfigRepresentation().Load(new Dictionary<string, object?> { ["id"] = "authenticator_config_representation_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `AuthenticatorConfigRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Available

```csharp
var available = client.Available();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Available().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Available` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Certificate

```csharp
var certificate = client.Certificate();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `certificate` | `string` | No |  |
| `id` | `string` | No |  |
| `kid` | `string` | No |  |
| `privateKey` | `string` | No |  |
| `publicKey` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.Certificate().Load(new Dictionary<string, object?> { ["id"] = "certificate_id", ["client_id"] = "client_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Certificate` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## CertificateRepresentation

```csharp
var certificateRepresentation = client.CertificateRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `certificate` | `string` | No |  |
| `kid` | `string` | No |  |
| `privateKey` | `string` | No |  |
| `publicKey` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.CertificateRepresentation().Create(new Dictionary<string, object?>
{
    ["attr"] = "example_attr",  // string
    ["client_id"] = "example_client_id",  // string
    ["realm"] = "example_realm",  // string
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `CertificateRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Client

```csharp
var client = client.Client();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `access` | `Dictionary<string, object?>` | No |  |
| `adminUrl` | `string` | No |  |
| `alwaysDisplayInConsole` | `bool` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `authenticationFlowBindingOverrides` | `Dictionary<string, object?>` | No |  |
| `authorizationServicesEnabled` | `bool` | No |  |
| `authorizationSettings` | `Dictionary<string, object?>` | No |  |
| `baseUrl` | `string` | No |  |
| `bearerOnly` | `bool` | No |  |
| `clientAuthenticatorType` | `string` | No |  |
| `clientId` | `string` | No |  |
| `clientRole` | `bool` | No |  |
| `clientTemplate` | `string` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `consentRequired` | `bool` | No |  |
| `containerId` | `string` | No |  |
| `defaultClientScopes` | `List<object?>` | No |  |
| `defaultRoles` | `List<object?>` | No |  |
| `description` | `string` | No |  |
| `directAccessGrantsEnabled` | `bool` | No |  |
| `directGrantsOnly` | `bool` | No |  |
| `enabled` | `bool` | No |  |
| `frontchannelLogout` | `bool` | No |  |
| `fullScopeAllowed` | `bool` | No |  |
| `id` | `string` | No |  |
| `implicitFlowEnabled` | `bool` | No |  |
| `name` | `string` | No |  |
| `nodeReRegistrationTimeout` | `long` | No |  |
| `notBefore` | `long` | No |  |
| `oauth2DeviceAuthorizationGrantEnabled` | `bool` | No |  |
| `optionalClientScopes` | `List<object?>` | No |  |
| `origin` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |
| `publicClient` | `bool` | No |  |
| `redirectUris` | `List<object?>` | No |  |
| `registeredNodes` | `Dictionary<string, object?>` | No |  |
| `registrationAccessToken` | `string` | No |  |
| `rootUrl` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |
| `secret` | `string` | No |  |
| `serviceAccountsEnabled` | `bool` | No |  |
| `standardFlowEnabled` | `bool` | No |  |
| `surrogateAuthRequired` | `bool` | No |  |
| `useTemplateConfig` | `bool` | No |  |
| `useTemplateMappers` | `bool` | No |  |
| `useTemplateScope` | `bool` | No |  |
| `webOrigins` | `List<object?>` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.Client().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Client().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.Client().Load(new Dictionary<string, object?> { ["id"] = "client_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.Client().Remove(new Dictionary<string, object?> { ["id"] = "client_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.Client().Update(new Dictionary<string, object?>
{
    ["id"] = "client_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Client` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientInitialAccess

```csharp
var clientInitialAccess = client.ClientInitialAccess();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `id` | `string` | No |  |

### Operations

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.ClientInitialAccess().Remove(new Dictionary<string, object?> { ["id"] = "id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientInitialAccess` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientInitialAccessPresentation

```csharp
var clientInitialAccessPresentation = client.ClientInitialAccessPresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `count` | `long` | No |  |
| `expiration` | `long` | No |  |
| `id` | `string` | No |  |
| `remainingCount` | `long` | No |  |
| `timestamp` | `long` | No |  |
| `token` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.ClientInitialAccessPresentation().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ClientInitialAccessPresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientInitialAccessPresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientPolicyRepresentation

```csharp
var clientPolicyRepresentation = client.ClientPolicyRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `conditions` | `List<object?>` | No |  |
| `description` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `name` | `string` | No |  |
| `profiles` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ClientPolicyRepresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientPolicyRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientProfilesRepresentation

```csharp
var clientProfilesRepresentation = client.ClientProfilesRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `globalProfiles` | `List<object?>` | No |  |
| `profiles` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ClientProfilesRepresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientProfilesRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientRepresentation

```csharp
var clientRepresentation = client.ClientRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `access` | `Dictionary<string, object?>` | No |  |
| `adminUrl` | `string` | No |  |
| `alwaysDisplayInConsole` | `bool` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `authenticationFlowBindingOverrides` | `Dictionary<string, object?>` | No |  |
| `authorizationServicesEnabled` | `bool` | No |  |
| `authorizationSettings` | `Dictionary<string, object?>` | No |  |
| `baseUrl` | `string` | No |  |
| `bearerOnly` | `bool` | No |  |
| `clientAuthenticatorType` | `string` | No |  |
| `clientId` | `string` | No |  |
| `clientTemplate` | `string` | No |  |
| `consentRequired` | `bool` | No |  |
| `defaultClientScopes` | `List<object?>` | No |  |
| `defaultRoles` | `List<object?>` | No |  |
| `description` | `string` | No |  |
| `directAccessGrantsEnabled` | `bool` | No |  |
| `directGrantsOnly` | `bool` | No |  |
| `enabled` | `bool` | No |  |
| `frontchannelLogout` | `bool` | No |  |
| `fullScopeAllowed` | `bool` | No |  |
| `id` | `string` | No |  |
| `implicitFlowEnabled` | `bool` | No |  |
| `name` | `string` | No |  |
| `nodeReRegistrationTimeout` | `long` | No |  |
| `notBefore` | `long` | No |  |
| `oauth2DeviceAuthorizationGrantEnabled` | `bool` | No |  |
| `optionalClientScopes` | `List<object?>` | No |  |
| `origin` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |
| `publicClient` | `bool` | No |  |
| `redirectUris` | `List<object?>` | No |  |
| `registeredNodes` | `Dictionary<string, object?>` | No |  |
| `registrationAccessToken` | `string` | No |  |
| `rootUrl` | `string` | No |  |
| `secret` | `string` | No |  |
| `serviceAccountsEnabled` | `bool` | No |  |
| `standardFlowEnabled` | `bool` | No |  |
| `surrogateAuthRequired` | `bool` | No |  |
| `useTemplateConfig` | `bool` | No |  |
| `useTemplateMappers` | `bool` | No |  |
| `useTemplateScope` | `bool` | No |  |
| `webOrigins` | `List<object?>` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.ClientRepresentation().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientScope

```csharp
var clientScope = client.ClientScope();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.ClientScope().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ClientScope().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.ClientScope().Load(new Dictionary<string, object?> { ["id"] = "client_scope_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.ClientScope().Remove(new Dictionary<string, object?> { ["id"] = "client_scope_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.ClientScope().Update(new Dictionary<string, object?>
{
    ["id"] = "client_scope_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientScope` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ClientScopeRepresentation

```csharp
var clientScopeRepresentation = client.ClientScopeRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ClientScopeRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.ClientScopeRepresentation().Load(new Dictionary<string, object?> { ["id"] = "client_scope_representation_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ClientScopeRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Component

```csharp
var component = client.Component();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `config` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `parentId` | `string` | No |  |
| `providerId` | `string` | No |  |
| `providerType` | `string` | No |  |
| `subType` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.Component().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Component().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.Component().Load(new Dictionary<string, object?> { ["id"] = "component_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.Component().Remove(new Dictionary<string, object?> { ["id"] = "component_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.Component().Update(new Dictionary<string, object?>
{
    ["id"] = "component_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Component` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ComponentTypeRepresentation

```csharp
var componentTypeRepresentation = client.ComponentTypeRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `helpText` | `string` | No |  |
| `id` | `string` | No |  |
| `metadata` | `Dictionary<string, object?>` | No |  |
| `properties` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ComponentTypeRepresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ComponentTypeRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Composite

```csharp
var composite = client.Composite();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Composite().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Composite` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Credential

```csharp
var credential = client.Credential();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `algorithm` | `string` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `counter` | `long` | No |  |
| `createdDate` | `long` | No |  |
| `credentialData` | `string` | No |  |
| `device` | `string` | No |  |
| `digits` | `long` | No |  |
| `hashIterations` | `long` | No |  |
| `hashedSaltedValue` | `string` | No |  |
| `id` | `string` | No |  |
| `period` | `long` | No |  |
| `priority` | `long` | No |  |
| `salt` | `string` | No |  |
| `secretData` | `string` | No |  |
| `temporary` | `bool` | No |  |
| `type` | `string` | No |  |
| `userLabel` | `string` | No |  |
| `value` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Credential().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Credential` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## CredentialRepresentation

```csharp
var credentialRepresentation = client.CredentialRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `algorithm` | `string` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `counter` | `long` | No |  |
| `createdDate` | `long` | No |  |
| `credentialData` | `string` | No |  |
| `device` | `string` | No |  |
| `digits` | `long` | No |  |
| `hashIterations` | `long` | No |  |
| `hashedSaltedValue` | `string` | No |  |
| `id` | `string` | No |  |
| `period` | `long` | No |  |
| `priority` | `long` | No |  |
| `salt` | `string` | No |  |
| `secretData` | `string` | No |  |
| `temporary` | `bool` | No |  |
| `type` | `string` | No |  |
| `userLabel` | `string` | No |  |
| `value` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.CredentialRepresentation().Create(new Dictionary<string, object?>
{
    ["client_id"] = "example_client_id",  // string
    ["realm"] = "example_realm",  // string
});
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.CredentialRepresentation().Load(new Dictionary<string, object?> { ["client_id"] = "client_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `CredentialRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## DeleteByRealm

```csharp
var deleteByRealm = client.DeleteByRealm();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `id` | `string` | No |  |

### Operations

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.DeleteByRealm().Remove(new Dictionary<string, object?> { ["id"] = "id" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `DeleteByRealm` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Event

```csharp
var event_ = client.Event();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `clientId` | `string` | No |  |
| `details` | `Dictionary<string, object?>` | No |  |
| `error` | `string` | No |  |
| `ipAddress` | `string` | No |  |
| `realmId` | `string` | No |  |
| `sessionId` | `string` | No |  |
| `time` | `long` | No |  |
| `type` | `string` | No |  |
| `userId` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Event().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Event` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## FederatedIdentity

```csharp
var federatedIdentity = client.FederatedIdentity();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `identityProvider` | `string` | No |  |
| `userId` | `string` | No |  |
| `userName` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.FederatedIdentity().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `FederatedIdentity` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Flow

```csharp
var flow = client.Flow();
```

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.Flow().Create(new Dictionary<string, object?>
{
    ["flow_alia"] = "example_flow_alia",  // string
    ["realm"] = "example_realm",  // string
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Flow` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Get

```csharp
var get = client.Get();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `accessCodeLifespan` | `long` | No |  |
| `accessCodeLifespanLogin` | `long` | No |  |
| `accessCodeLifespanUserAction` | `long` | No |  |
| `accessTokenLifespan` | `long` | No |  |
| `accessTokenLifespanForImplicitFlow` | `long` | No |  |
| `accountTheme` | `string` | No |  |
| `actionTokenGeneratedByAdminLifespan` | `long` | No |  |
| `actionTokenGeneratedByUserLifespan` | `long` | No |  |
| `adminEventsDetailsEnabled` | `bool` | No |  |
| `adminEventsEnabled` | `bool` | No |  |
| `adminTheme` | `string` | No |  |
| `applicationScopeMappings` | `Dictionary<string, object?>` | No |  |
| `applications` | `List<object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `authenticationFlows` | `List<object?>` | No |  |
| `authenticatorConfig` | `List<object?>` | No |  |
| `browserFlow` | `string` | No |  |
| `browserSecurityHeaders` | `Dictionary<string, object?>` | No |  |
| `bruteForceProtected` | `bool` | No |  |
| `certificate` | `string` | No |  |
| `clientAuthenticationFlow` | `string` | No |  |
| `clientOfflineSessionIdleTimeout` | `long` | No |  |
| `clientOfflineSessionMaxLifespan` | `long` | No |  |
| `clientPolicies` | `Dictionary<string, object?>` | No |  |
| `clientProfiles` | `Dictionary<string, object?>` | No |  |
| `clientScopeMappings` | `Dictionary<string, object?>` | No |  |
| `clientScopes` | `List<object?>` | No |  |
| `clientSessionIdleTimeout` | `long` | No |  |
| `clientSessionMaxLifespan` | `long` | No |  |
| `clientTemplates` | `List<object?>` | No |  |
| `clients` | `List<object?>` | No |  |
| `codeSecret` | `string` | No |  |
| `components` | `Dictionary<string, object?>` | No |  |
| `defaultDefaultClientScopes` | `List<object?>` | No |  |
| `defaultGroups` | `List<object?>` | No |  |
| `defaultLocale` | `string` | No |  |
| `defaultOptionalClientScopes` | `List<object?>` | No |  |
| `defaultRole` | `Dictionary<string, object?>` | No |  |
| `defaultRoles` | `List<object?>` | No |  |
| `defaultSignatureAlgorithm` | `string` | No |  |
| `directGrantFlow` | `string` | No |  |
| `displayName` | `string` | No |  |
| `displayNameHtml` | `string` | No |  |
| `dockerAuthenticationFlow` | `string` | No |  |
| `duplicateEmailsAllowed` | `bool` | No |  |
| `editUsernameAllowed` | `bool` | No |  |
| `emailTheme` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `enabledEventTypes` | `List<object?>` | No |  |
| `eventsEnabled` | `bool` | No |  |
| `eventsExpiration` | `long` | No |  |
| `eventsListeners` | `List<object?>` | No |  |
| `failureFactor` | `long` | No |  |
| `federatedUsers` | `List<object?>` | No |  |
| `groups` | `List<object?>` | No |  |
| `id` | `string` | No |  |
| `identityProviderMappers` | `List<object?>` | No |  |
| `identityProviders` | `List<object?>` | No |  |
| `internationalizationEnabled` | `bool` | No |  |
| `keycloakVersion` | `string` | No |  |
| `localizationTexts` | `Dictionary<string, object?>` | No |  |
| `loginTheme` | `string` | No |  |
| `loginWithEmailAllowed` | `bool` | No |  |
| `maxDeltaTimeSeconds` | `long` | No |  |
| `maxFailureWaitSeconds` | `long` | No |  |
| `minimumQuickLoginWaitSeconds` | `long` | No |  |
| `notBefore` | `long` | No |  |
| `oAuth2DeviceCodeLifespan` | `long` | No |  |
| `oAuth2DevicePollingInterval` | `long` | No |  |
| `oauth2DeviceCodeLifespan` | `long` | No |  |
| `oauth2DevicePollingInterval` | `long` | No |  |
| `oauthClients` | `List<object?>` | No |  |
| `offlineSessionIdleTimeout` | `long` | No |  |
| `offlineSessionMaxLifespan` | `long` | No |  |
| `offlineSessionMaxLifespanEnabled` | `bool` | No |  |
| `otpPolicyAlgorithm` | `string` | No |  |
| `otpPolicyCodeReusable` | `bool` | No |  |
| `otpPolicyDigits` | `long` | No |  |
| `otpPolicyInitialCounter` | `long` | No |  |
| `otpPolicyLookAheadWindow` | `long` | No |  |
| `otpPolicyPeriod` | `long` | No |  |
| `otpPolicyType` | `string` | No |  |
| `otpSupportedApplications` | `List<object?>` | No |  |
| `passwordCredentialGrantAllowed` | `bool` | No |  |
| `passwordPolicy` | `string` | No |  |
| `permanentLockout` | `bool` | No |  |
| `privateKey` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |
| `publicKey` | `string` | No |  |
| `quickLoginCheckMilliSeconds` | `long` | No |  |
| `realm` | `string` | No |  |
| `realmCacheEnabled` | `bool` | No |  |
| `refreshTokenMaxReuse` | `long` | No |  |
| `registrationAllowed` | `bool` | No |  |
| `registrationEmailAsUsername` | `bool` | No |  |
| `registrationFlow` | `string` | No |  |
| `rememberMe` | `bool` | No |  |
| `requiredActions` | `List<object?>` | No |  |
| `requiredCredentials` | `List<object?>` | No |  |
| `resetCredentialsFlow` | `string` | No |  |
| `resetPasswordAllowed` | `bool` | No |  |
| `revokeRefreshToken` | `bool` | No |  |
| `roles` | `Dictionary<string, object?>` | No |  |
| `scopeMappings` | `List<object?>` | No |  |
| `smtpServer` | `Dictionary<string, object?>` | No |  |
| `social` | `bool` | No |  |
| `socialProviders` | `Dictionary<string, object?>` | No |  |
| `sslRequired` | `string` | No |  |
| `ssoSessionIdleTimeout` | `long` | No |  |
| `ssoSessionIdleTimeoutRememberMe` | `long` | No |  |
| `ssoSessionMaxLifespan` | `long` | No |  |
| `ssoSessionMaxLifespanRememberMe` | `long` | No |  |
| `supportedLocales` | `List<object?>` | No |  |
| `updateProfileOnInitialSocialLogin` | `bool` | No |  |
| `userCacheEnabled` | `bool` | No |  |
| `userFederationMappers` | `List<object?>` | No |  |
| `userFederationProviders` | `List<object?>` | No |  |
| `userManagedAccessAllowed` | `bool` | No |  |
| `users` | `List<object?>` | No |  |
| `verifyEmail` | `bool` | No |  |
| `waitIncrementSeconds` | `long` | No |  |
| `webAuthnPolicyAcceptableAaguids` | `List<object?>` | No |  |
| `webAuthnPolicyAttestationConveyancePreference` | `string` | No |  |
| `webAuthnPolicyAuthenticatorAttachment` | `string` | No |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` | `bool` | No |  |
| `webAuthnPolicyCreateTimeout` | `long` | No |  |
| `webAuthnPolicyExtraOrigins` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` | `string` | No |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` | `string` | No |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` | `bool` | No |  |
| `webAuthnPolicyPasswordlessCreateTimeout` | `long` | No |  |
| `webAuthnPolicyPasswordlessExtraOrigins` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` | `string` | No |  |
| `webAuthnPolicyPasswordlessRpEntityName` | `string` | No |  |
| `webAuthnPolicyPasswordlessRpId` | `string` | No |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` | `string` | No |  |
| `webAuthnPolicyRequireResidentKey` | `string` | No |  |
| `webAuthnPolicyRpEntityName` | `string` | No |  |
| `webAuthnPolicyRpId` | `string` | No |  |
| `webAuthnPolicySignatureAlgorithms` | `List<object?>` | No |  |
| `webAuthnPolicyUserVerificationRequirement` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Get().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Get` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## GetByRealm

```csharp
var getByRealm = client.GetByRealm();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `accessCodeLifespan` | `long` | No |  |
| `accessCodeLifespanLogin` | `long` | No |  |
| `accessCodeLifespanUserAction` | `long` | No |  |
| `accessTokenLifespan` | `long` | No |  |
| `accessTokenLifespanForImplicitFlow` | `long` | No |  |
| `accountTheme` | `string` | No |  |
| `actionTokenGeneratedByAdminLifespan` | `long` | No |  |
| `actionTokenGeneratedByUserLifespan` | `long` | No |  |
| `adminEventsDetailsEnabled` | `bool` | No |  |
| `adminEventsEnabled` | `bool` | No |  |
| `adminTheme` | `string` | No |  |
| `applicationScopeMappings` | `Dictionary<string, object?>` | No |  |
| `applications` | `List<object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `authenticationFlows` | `List<object?>` | No |  |
| `authenticatorConfig` | `List<object?>` | No |  |
| `browserFlow` | `string` | No |  |
| `browserSecurityHeaders` | `Dictionary<string, object?>` | No |  |
| `bruteForceProtected` | `bool` | No |  |
| `certificate` | `string` | No |  |
| `clientAuthenticationFlow` | `string` | No |  |
| `clientOfflineSessionIdleTimeout` | `long` | No |  |
| `clientOfflineSessionMaxLifespan` | `long` | No |  |
| `clientPolicies` | `Dictionary<string, object?>` | No |  |
| `clientProfiles` | `Dictionary<string, object?>` | No |  |
| `clientScopeMappings` | `Dictionary<string, object?>` | No |  |
| `clientScopes` | `List<object?>` | No |  |
| `clientSessionIdleTimeout` | `long` | No |  |
| `clientSessionMaxLifespan` | `long` | No |  |
| `clientTemplates` | `List<object?>` | No |  |
| `clients` | `List<object?>` | No |  |
| `codeSecret` | `string` | No |  |
| `components` | `Dictionary<string, object?>` | No |  |
| `defaultDefaultClientScopes` | `List<object?>` | No |  |
| `defaultGroups` | `List<object?>` | No |  |
| `defaultLocale` | `string` | No |  |
| `defaultOptionalClientScopes` | `List<object?>` | No |  |
| `defaultRole` | `Dictionary<string, object?>` | No |  |
| `defaultRoles` | `List<object?>` | No |  |
| `defaultSignatureAlgorithm` | `string` | No |  |
| `directGrantFlow` | `string` | No |  |
| `displayName` | `string` | No |  |
| `displayNameHtml` | `string` | No |  |
| `dockerAuthenticationFlow` | `string` | No |  |
| `duplicateEmailsAllowed` | `bool` | No |  |
| `editUsernameAllowed` | `bool` | No |  |
| `emailTheme` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `enabledEventTypes` | `List<object?>` | No |  |
| `eventsEnabled` | `bool` | No |  |
| `eventsExpiration` | `long` | No |  |
| `eventsListeners` | `List<object?>` | No |  |
| `failureFactor` | `long` | No |  |
| `federatedUsers` | `List<object?>` | No |  |
| `groups` | `List<object?>` | No |  |
| `id` | `string` | No |  |
| `identityProviderMappers` | `List<object?>` | No |  |
| `identityProviders` | `List<object?>` | No |  |
| `internationalizationEnabled` | `bool` | No |  |
| `keycloakVersion` | `string` | No |  |
| `localizationTexts` | `Dictionary<string, object?>` | No |  |
| `loginTheme` | `string` | No |  |
| `loginWithEmailAllowed` | `bool` | No |  |
| `maxDeltaTimeSeconds` | `long` | No |  |
| `maxFailureWaitSeconds` | `long` | No |  |
| `minimumQuickLoginWaitSeconds` | `long` | No |  |
| `notBefore` | `long` | No |  |
| `oAuth2DeviceCodeLifespan` | `long` | No |  |
| `oAuth2DevicePollingInterval` | `long` | No |  |
| `oauth2DeviceCodeLifespan` | `long` | No |  |
| `oauth2DevicePollingInterval` | `long` | No |  |
| `oauthClients` | `List<object?>` | No |  |
| `offlineSessionIdleTimeout` | `long` | No |  |
| `offlineSessionMaxLifespan` | `long` | No |  |
| `offlineSessionMaxLifespanEnabled` | `bool` | No |  |
| `otpPolicyAlgorithm` | `string` | No |  |
| `otpPolicyCodeReusable` | `bool` | No |  |
| `otpPolicyDigits` | `long` | No |  |
| `otpPolicyInitialCounter` | `long` | No |  |
| `otpPolicyLookAheadWindow` | `long` | No |  |
| `otpPolicyPeriod` | `long` | No |  |
| `otpPolicyType` | `string` | No |  |
| `otpSupportedApplications` | `List<object?>` | No |  |
| `passwordCredentialGrantAllowed` | `bool` | No |  |
| `passwordPolicy` | `string` | No |  |
| `permanentLockout` | `bool` | No |  |
| `privateKey` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |
| `publicKey` | `string` | No |  |
| `quickLoginCheckMilliSeconds` | `long` | No |  |
| `realm` | `string` | No |  |
| `realmCacheEnabled` | `bool` | No |  |
| `refreshTokenMaxReuse` | `long` | No |  |
| `registrationAllowed` | `bool` | No |  |
| `registrationEmailAsUsername` | `bool` | No |  |
| `registrationFlow` | `string` | No |  |
| `rememberMe` | `bool` | No |  |
| `requiredActions` | `List<object?>` | No |  |
| `requiredCredentials` | `List<object?>` | No |  |
| `resetCredentialsFlow` | `string` | No |  |
| `resetPasswordAllowed` | `bool` | No |  |
| `revokeRefreshToken` | `bool` | No |  |
| `roles` | `Dictionary<string, object?>` | No |  |
| `scopeMappings` | `List<object?>` | No |  |
| `smtpServer` | `Dictionary<string, object?>` | No |  |
| `social` | `bool` | No |  |
| `socialProviders` | `Dictionary<string, object?>` | No |  |
| `sslRequired` | `string` | No |  |
| `ssoSessionIdleTimeout` | `long` | No |  |
| `ssoSessionIdleTimeoutRememberMe` | `long` | No |  |
| `ssoSessionMaxLifespan` | `long` | No |  |
| `ssoSessionMaxLifespanRememberMe` | `long` | No |  |
| `supportedLocales` | `List<object?>` | No |  |
| `updateProfileOnInitialSocialLogin` | `bool` | No |  |
| `userCacheEnabled` | `bool` | No |  |
| `userFederationMappers` | `List<object?>` | No |  |
| `userFederationProviders` | `List<object?>` | No |  |
| `userManagedAccessAllowed` | `bool` | No |  |
| `users` | `List<object?>` | No |  |
| `verifyEmail` | `bool` | No |  |
| `waitIncrementSeconds` | `long` | No |  |
| `webAuthnPolicyAcceptableAaguids` | `List<object?>` | No |  |
| `webAuthnPolicyAttestationConveyancePreference` | `string` | No |  |
| `webAuthnPolicyAuthenticatorAttachment` | `string` | No |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` | `bool` | No |  |
| `webAuthnPolicyCreateTimeout` | `long` | No |  |
| `webAuthnPolicyExtraOrigins` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` | `string` | No |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` | `string` | No |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` | `bool` | No |  |
| `webAuthnPolicyPasswordlessCreateTimeout` | `long` | No |  |
| `webAuthnPolicyPasswordlessExtraOrigins` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` | `string` | No |  |
| `webAuthnPolicyPasswordlessRpEntityName` | `string` | No |  |
| `webAuthnPolicyPasswordlessRpId` | `string` | No |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` | `string` | No |  |
| `webAuthnPolicyRequireResidentKey` | `string` | No |  |
| `webAuthnPolicyRpEntityName` | `string` | No |  |
| `webAuthnPolicyRpId` | `string` | No |  |
| `webAuthnPolicySignatureAlgorithms` | `List<object?>` | No |  |
| `webAuthnPolicyUserVerificationRequirement` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.GetByRealm().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `GetByRealm` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## GlobalRequestResult

```csharp
var globalRequestResult = client.GlobalRequestResult();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `failedRequests` | `List<object?>` | No |  |
| `successRequests` | `List<object?>` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.GlobalRequestResult().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.GlobalRequestResult().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `GlobalRequestResult` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Granted

```csharp
var granted = client.Granted();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Granted().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Granted` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Group

```csharp
var group = client.Group();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `access` | `Dictionary<string, object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRoles` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `parentId` | `string` | No |  |
| `path` | `string` | No |  |
| `realmRoles` | `List<object?>` | No |  |
| `subGroupCount` | `long` | No |  |
| `subGroups` | `List<object?>` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.Group().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Group().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.Group().Load(new Dictionary<string, object?> { ["id"] = "group_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.Group().Remove(new Dictionary<string, object?> { ["id"] = "group_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.Group().Update(new Dictionary<string, object?>
{
    ["id"] = "group_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Group` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## GroupRepresentation

```csharp
var groupRepresentation = client.GroupRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `access` | `Dictionary<string, object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRoles` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `parentId` | `string` | No |  |
| `path` | `string` | No |  |
| `realmRoles` | `List<object?>` | No |  |
| `subGroupCount` | `long` | No |  |
| `subGroups` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.GroupRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.GroupRepresentation().Load(new Dictionary<string, object?> { ["path"] = "path", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `GroupRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## IdToken

```csharp
var idToken = client.IdToken();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `acr` | `string` | No |  |
| `address` | `Dictionary<string, object?>` | No |  |
| `at_hash` | `string` | No |  |
| `authTime` | `long` | No |  |
| `auth_time` | `long` | No |  |
| `azp` | `string` | No |  |
| `birthdate` | `string` | No |  |
| `c_hash` | `string` | No |  |
| `claims_locales` | `string` | No |  |
| `email` | `string` | No |  |
| `email_verified` | `bool` | No |  |
| `exp` | `long` | No |  |
| `family_name` | `string` | No |  |
| `gender` | `string` | No |  |
| `given_name` | `string` | No |  |
| `iat` | `long` | No |  |
| `iss` | `string` | No |  |
| `jti` | `string` | No |  |
| `locale` | `string` | No |  |
| `middle_name` | `string` | No |  |
| `name` | `string` | No |  |
| `nbf` | `long` | No |  |
| `nickname` | `string` | No |  |
| `nonce` | `string` | No |  |
| `otherClaims` | `Dictionary<string, object?>` | No |  |
| `phone_number` | `string` | No |  |
| `phone_number_verified` | `bool` | No |  |
| `picture` | `string` | No |  |
| `preferred_username` | `string` | No |  |
| `profile` | `string` | No |  |
| `s_hash` | `string` | No |  |
| `session_state` | `string` | No |  |
| `sid` | `string` | No |  |
| `sub` | `string` | No |  |
| `typ` | `string` | No |  |
| `updated_at` | `long` | No |  |
| `website` | `string` | No |  |
| `zoneinfo` | `string` | No |  |

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.IdToken().Load(new Dictionary<string, object?> { ["client_id"] = "client_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `IdToken` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## IdentityProvider

```csharp
var identityProvider = client.IdentityProvider();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `addReadTokenRoleOnCreate` | `bool` | No |  |
| `alias` | `string` | No |  |
| `authenticateByDefault` | `bool` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `displayName` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `firstBrokerLoginFlowAlias` | `string` | No |  |
| `id` | `string` | No |  |
| `identityProviderAlias` | `string` | No |  |
| `identityProviderMapper` | `string` | No |  |
| `internalId` | `string` | No |  |
| `linkOnly` | `bool` | No |  |
| `name` | `string` | No |  |
| `postBrokerLoginFlowAlias` | `string` | No |  |
| `providerId` | `string` | No |  |
| `storeToken` | `bool` | No |  |
| `trustEmail` | `bool` | No |  |
| `updateProfileFirstLogin` | `bool` | No |  |
| `updateProfileFirstLoginMode` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.IdentityProvider().Create(new Dictionary<string, object?>
{
    ["alia"] = "example_alia",  // string
    ["realm"] = "example_realm",  // string
});
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.IdentityProvider().Load(new Dictionary<string, object?> { ["id"] = "identity_provider_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.IdentityProvider().Remove(new Dictionary<string, object?> { ["id"] = "identity_provider_id", ["alia"] = "alia", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.IdentityProvider().Update(new Dictionary<string, object?>
{
    ["id"] = "identity_provider_id",
    ["alia"] = "alia",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `IdentityProvider` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## IdentityProviderMapperRepresentation

```csharp
var identityProviderMapperRepresentation = client.IdentityProviderMapperRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `config` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |
| `identityProviderAlias` | `string` | No |  |
| `identityProviderMapper` | `string` | No |  |
| `name` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.IdentityProviderMapperRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.IdentityProviderMapperRepresentation().Load(new Dictionary<string, object?> { ["id"] = "identity_provider_mapper_representation_id", ["alia"] = "alia", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `IdentityProviderMapperRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## IdentityProviderRepresentation

```csharp
var identityProviderRepresentation = client.IdentityProviderRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `addReadTokenRoleOnCreate` | `bool` | No |  |
| `alias` | `string` | No |  |
| `authenticateByDefault` | `bool` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `displayName` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `firstBrokerLoginFlowAlias` | `string` | No |  |
| `internalId` | `string` | No |  |
| `linkOnly` | `bool` | No |  |
| `postBrokerLoginFlowAlias` | `string` | No |  |
| `providerId` | `string` | No |  |
| `storeToken` | `bool` | No |  |
| `trustEmail` | `bool` | No |  |
| `updateProfileFirstLogin` | `bool` | No |  |
| `updateProfileFirstLoginMode` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.IdentityProviderRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.IdentityProviderRepresentation().Load(new Dictionary<string, object?> { ["alia"] = "alia", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `IdentityProviderRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Key

```csharp
var key = client.Key();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `algorithm` | `string` | No |  |
| `certificate` | `string` | No |  |
| `kid` | `string` | No |  |
| `providerId` | `string` | No |  |
| `providerPriority` | `long` | No |  |
| `publicKey` | `string` | No |  |
| `status` | `string` | No |  |
| `type` | `string` | No |  |
| `use` | `Dictionary<string, object?>` | No |  |
| `validTo` | `long` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Key().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Key` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ManagementPermissionReference

```csharp
var managementPermissionReference = client.ManagementPermissionReference();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `enabled` | `bool` | No |  |
| `resource` | `string` | No |  |
| `scopePermissions` | `Dictionary<string, object?>` | No |  |

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.ManagementPermissionReference().Load(new Dictionary<string, object?> { ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.ManagementPermissionReference().Update(new Dictionary<string, object?>
{
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ManagementPermissionReference` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## MappingsRepresentation

```csharp
var mappingsRepresentation = client.MappingsRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.MappingsRepresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `MappingsRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## NotGranted

```csharp
var notGranted = client.NotGranted();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.NotGranted().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `NotGranted` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Post

```csharp
var post = client.Post();
```

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.Post().Create(new Dictionary<string, object?>
{
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Post` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Protocol

```csharp
var protocol = client.Protocol();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `config` | `Dictionary<string, object?>` | No |  |
| `consentRequired` | `bool` | No |  |
| `consentText` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMapper` | `string` | No |  |

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.Protocol().Load(new Dictionary<string, object?> { ["id"] = "protocol_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Protocol` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ProtocolMapper

```csharp
var protocolMapper = client.ProtocolMapper();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `config` | `Dictionary<string, object?>` | No |  |
| `consentRequired` | `bool` | No |  |
| `consentText` | `string` | No |  |
| `containerId` | `string` | No |  |
| `containerName` | `string` | No |  |
| `containerType` | `string` | No |  |
| `id` | `string` | No |  |
| `mapperId` | `string` | No |  |
| `mapperName` | `string` | No |  |
| `name` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMapper` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ProtocolMapper().List(null);
Console.WriteLine(results);
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.ProtocolMapper().Remove(new Dictionary<string, object?> { ["id2"] = "id2", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.ProtocolMapper().Update(new Dictionary<string, object?>
{
    ["id2"] = "id2",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ProtocolMapper` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ProtocolMapperRepresentation

```csharp
var protocolMapperRepresentation = client.ProtocolMapperRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `config` | `Dictionary<string, object?>` | No |  |
| `consentRequired` | `bool` | No |  |
| `consentText` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `protocol` | `string` | No |  |
| `protocolMapper` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.ProtocolMapperRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.ProtocolMapperRepresentation().Load(new Dictionary<string, object?> { ["id2"] = "id2", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ProtocolMapperRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## PutByRealm

```csharp
var putByRealm = client.PutByRealm();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `accessCodeLifespan` | `long` | No |  |
| `accessCodeLifespanLogin` | `long` | No |  |
| `accessCodeLifespanUserAction` | `long` | No |  |
| `accessTokenLifespan` | `long` | No |  |
| `accessTokenLifespanForImplicitFlow` | `long` | No |  |
| `accountTheme` | `string` | No |  |
| `actionTokenGeneratedByAdminLifespan` | `long` | No |  |
| `actionTokenGeneratedByUserLifespan` | `long` | No |  |
| `adminEventsDetailsEnabled` | `bool` | No |  |
| `adminEventsEnabled` | `bool` | No |  |
| `adminTheme` | `string` | No |  |
| `applicationScopeMappings` | `Dictionary<string, object?>` | No |  |
| `applications` | `List<object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `authenticationFlows` | `List<object?>` | No |  |
| `authenticatorConfig` | `List<object?>` | No |  |
| `browserFlow` | `string` | No |  |
| `browserSecurityHeaders` | `Dictionary<string, object?>` | No |  |
| `bruteForceProtected` | `bool` | No |  |
| `certificate` | `string` | No |  |
| `clientAuthenticationFlow` | `string` | No |  |
| `clientOfflineSessionIdleTimeout` | `long` | No |  |
| `clientOfflineSessionMaxLifespan` | `long` | No |  |
| `clientPolicies` | `Dictionary<string, object?>` | No |  |
| `clientProfiles` | `Dictionary<string, object?>` | No |  |
| `clientScopeMappings` | `Dictionary<string, object?>` | No |  |
| `clientScopes` | `List<object?>` | No |  |
| `clientSessionIdleTimeout` | `long` | No |  |
| `clientSessionMaxLifespan` | `long` | No |  |
| `clientTemplates` | `List<object?>` | No |  |
| `clients` | `List<object?>` | No |  |
| `codeSecret` | `string` | No |  |
| `components` | `Dictionary<string, object?>` | No |  |
| `defaultDefaultClientScopes` | `List<object?>` | No |  |
| `defaultGroups` | `List<object?>` | No |  |
| `defaultLocale` | `string` | No |  |
| `defaultOptionalClientScopes` | `List<object?>` | No |  |
| `defaultRole` | `Dictionary<string, object?>` | No |  |
| `defaultRoles` | `List<object?>` | No |  |
| `defaultSignatureAlgorithm` | `string` | No |  |
| `directGrantFlow` | `string` | No |  |
| `displayName` | `string` | No |  |
| `displayNameHtml` | `string` | No |  |
| `dockerAuthenticationFlow` | `string` | No |  |
| `duplicateEmailsAllowed` | `bool` | No |  |
| `editUsernameAllowed` | `bool` | No |  |
| `emailTheme` | `string` | No |  |
| `enabled` | `bool` | No |  |
| `enabledEventTypes` | `List<object?>` | No |  |
| `eventsEnabled` | `bool` | No |  |
| `eventsExpiration` | `long` | No |  |
| `eventsListeners` | `List<object?>` | No |  |
| `failureFactor` | `long` | No |  |
| `federatedUsers` | `List<object?>` | No |  |
| `groups` | `List<object?>` | No |  |
| `id` | `string` | No |  |
| `identityProviderMappers` | `List<object?>` | No |  |
| `identityProviders` | `List<object?>` | No |  |
| `internationalizationEnabled` | `bool` | No |  |
| `keycloakVersion` | `string` | No |  |
| `localizationTexts` | `Dictionary<string, object?>` | No |  |
| `loginTheme` | `string` | No |  |
| `loginWithEmailAllowed` | `bool` | No |  |
| `maxDeltaTimeSeconds` | `long` | No |  |
| `maxFailureWaitSeconds` | `long` | No |  |
| `minimumQuickLoginWaitSeconds` | `long` | No |  |
| `notBefore` | `long` | No |  |
| `oAuth2DeviceCodeLifespan` | `long` | No |  |
| `oAuth2DevicePollingInterval` | `long` | No |  |
| `oauth2DeviceCodeLifespan` | `long` | No |  |
| `oauth2DevicePollingInterval` | `long` | No |  |
| `oauthClients` | `List<object?>` | No |  |
| `offlineSessionIdleTimeout` | `long` | No |  |
| `offlineSessionMaxLifespan` | `long` | No |  |
| `offlineSessionMaxLifespanEnabled` | `bool` | No |  |
| `otpPolicyAlgorithm` | `string` | No |  |
| `otpPolicyCodeReusable` | `bool` | No |  |
| `otpPolicyDigits` | `long` | No |  |
| `otpPolicyInitialCounter` | `long` | No |  |
| `otpPolicyLookAheadWindow` | `long` | No |  |
| `otpPolicyPeriod` | `long` | No |  |
| `otpPolicyType` | `string` | No |  |
| `otpSupportedApplications` | `List<object?>` | No |  |
| `passwordCredentialGrantAllowed` | `bool` | No |  |
| `passwordPolicy` | `string` | No |  |
| `permanentLockout` | `bool` | No |  |
| `privateKey` | `string` | No |  |
| `protocolMappers` | `List<object?>` | No |  |
| `publicKey` | `string` | No |  |
| `quickLoginCheckMilliSeconds` | `long` | No |  |
| `realm` | `string` | No |  |
| `realmCacheEnabled` | `bool` | No |  |
| `refreshTokenMaxReuse` | `long` | No |  |
| `registrationAllowed` | `bool` | No |  |
| `registrationEmailAsUsername` | `bool` | No |  |
| `registrationFlow` | `string` | No |  |
| `rememberMe` | `bool` | No |  |
| `requiredActions` | `List<object?>` | No |  |
| `requiredCredentials` | `List<object?>` | No |  |
| `resetCredentialsFlow` | `string` | No |  |
| `resetPasswordAllowed` | `bool` | No |  |
| `revokeRefreshToken` | `bool` | No |  |
| `roles` | `Dictionary<string, object?>` | No |  |
| `scopeMappings` | `List<object?>` | No |  |
| `smtpServer` | `Dictionary<string, object?>` | No |  |
| `social` | `bool` | No |  |
| `socialProviders` | `Dictionary<string, object?>` | No |  |
| `sslRequired` | `string` | No |  |
| `ssoSessionIdleTimeout` | `long` | No |  |
| `ssoSessionIdleTimeoutRememberMe` | `long` | No |  |
| `ssoSessionMaxLifespan` | `long` | No |  |
| `ssoSessionMaxLifespanRememberMe` | `long` | No |  |
| `supportedLocales` | `List<object?>` | No |  |
| `updateProfileOnInitialSocialLogin` | `bool` | No |  |
| `userCacheEnabled` | `bool` | No |  |
| `userFederationMappers` | `List<object?>` | No |  |
| `userFederationProviders` | `List<object?>` | No |  |
| `userManagedAccessAllowed` | `bool` | No |  |
| `users` | `List<object?>` | No |  |
| `verifyEmail` | `bool` | No |  |
| `waitIncrementSeconds` | `long` | No |  |
| `webAuthnPolicyAcceptableAaguids` | `List<object?>` | No |  |
| `webAuthnPolicyAttestationConveyancePreference` | `string` | No |  |
| `webAuthnPolicyAuthenticatorAttachment` | `string` | No |  |
| `webAuthnPolicyAvoidSameAuthenticatorRegister` | `bool` | No |  |
| `webAuthnPolicyCreateTimeout` | `long` | No |  |
| `webAuthnPolicyExtraOrigins` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessAcceptableAaguids` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessAttestationConveyancePreference` | `string` | No |  |
| `webAuthnPolicyPasswordlessAuthenticatorAttachment` | `string` | No |  |
| `webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister` | `bool` | No |  |
| `webAuthnPolicyPasswordlessCreateTimeout` | `long` | No |  |
| `webAuthnPolicyPasswordlessExtraOrigins` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessRequireResidentKey` | `string` | No |  |
| `webAuthnPolicyPasswordlessRpEntityName` | `string` | No |  |
| `webAuthnPolicyPasswordlessRpId` | `string` | No |  |
| `webAuthnPolicyPasswordlessSignatureAlgorithms` | `List<object?>` | No |  |
| `webAuthnPolicyPasswordlessUserVerificationRequirement` | `string` | No |  |
| `webAuthnPolicyRequireResidentKey` | `string` | No |  |
| `webAuthnPolicyRpEntityName` | `string` | No |  |
| `webAuthnPolicyRpId` | `string` | No |  |
| `webAuthnPolicySignatureAlgorithms` | `List<object?>` | No |  |
| `webAuthnPolicyUserVerificationRequirement` | `string` | No |  |

### Operations

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.PutByRealm().Update(new Dictionary<string, object?>
{
    ["id"] = "id",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `PutByRealm` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Realm

```csharp
var realm = client.Realm();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Realm().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Realm` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## RealmEventsConfigRepresentation

```csharp
var realmEventsConfigRepresentation = client.RealmEventsConfigRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `adminEventsDetailsEnabled` | `bool` | No |  |
| `adminEventsEnabled` | `bool` | No |  |
| `enabledEventTypes` | `List<object?>` | No |  |
| `eventsEnabled` | `bool` | No |  |
| `eventsExpiration` | `long` | No |  |
| `eventsListeners` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.RealmEventsConfigRepresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `RealmEventsConfigRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## RealmsAdmin

```csharp
var realmsAdmin = client.RealmsAdmin();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `adminEventsDetailsEnabled` | `bool` | No |  |
| `adminEventsEnabled` | `bool` | No |  |
| `enabledEventTypes` | `List<object?>` | No |  |
| `eventsEnabled` | `bool` | No |  |
| `eventsExpiration` | `long` | No |  |
| `eventsListeners` | `List<object?>` | No |  |
| `globalProfiles` | `List<object?>` | No |  |
| `id` | `string` | No |  |
| `policies` | `List<object?>` | No |  |
| `profiles` | `List<object?>` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.RealmsAdmin().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.RealmsAdmin().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.RealmsAdmin().Load(new Dictionary<string, object?> { ["locale"] = "locale", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.RealmsAdmin().Remove(new Dictionary<string, object?> { ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.RealmsAdmin().Update(new Dictionary<string, object?>
{
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `RealmsAdmin` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## RequiredAction

```csharp
var requiredAction = client.RequiredAction();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `alias` | `string` | No |  |
| `config` | `Dictionary<string, object?>` | No |  |
| `defaultAction` | `bool` | No |  |
| `enabled` | `bool` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `priority` | `long` | No |  |
| `providerId` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.RequiredAction().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.RequiredAction().Load(new Dictionary<string, object?> { ["id"] = "required_action_id", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `RequiredAction` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Role

```csharp
var role = client.Role();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.Role().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.Role().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.Role().Load(new Dictionary<string, object?> { ["id"] = "role_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.Role().Remove(new Dictionary<string, object?> { ["id"] = "role_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.Role().Update(new Dictionary<string, object?>
{
    ["id"] = "role_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `Role` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## RoleMapper

```csharp
var roleMapper = client.RoleMapper();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.RoleMapper().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.RoleMapper().Remove(new Dictionary<string, object?> { ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `RoleMapper` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## RolesById

```csharp
var rolesById = client.RolesById();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.RolesById().Create(new Dictionary<string, object?>
{
    ["id"] = "example_id",  // string
    ["realm"] = "example_realm",  // string
});
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.RolesById().Load(new Dictionary<string, object?> { ["id"] = "roles_by_id_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.RolesById().Remove(new Dictionary<string, object?> { ["id"] = "roles_by_id_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.RolesById().Update(new Dictionary<string, object?>
{
    ["id"] = "roles_by_id_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `RolesById` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## ScopeMapping

```csharp
var scopeMapping = client.ScopeMapping();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientRole` | `bool` | No |  |
| `composite` | `bool` | No |  |
| `composites` | `Dictionary<string, object?>` | No |  |
| `containerId` | `string` | No |  |
| `description` | `string` | No |  |
| `id` | `string` | No |  |
| `name` | `string` | No |  |
| `scopeParamRequired` | `bool` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.ScopeMapping().Create(new Dictionary<string, object?>
{
    ["client"] = "example_client",  // string
    ["realm"] = "example_realm",  // string
});
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.ScopeMapping().Remove(new Dictionary<string, object?> { ["client"] = "client", ["realm"] = "realm" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `ScopeMapping` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## UpConfig

```csharp
var upConfig = client.UpConfig();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `attributes` | `List<object?>` | No |  |
| `groups` | `List<object?>` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.UpConfig().List(null);
Console.WriteLine(results);
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.UpConfig().Update(new Dictionary<string, object?>
{
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `UpConfig` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## User

```csharp
var user = client.User();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `access` | `Dictionary<string, object?>` | No |  |
| `applicationRoles` | `Dictionary<string, object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientConsents` | `List<object?>` | No |  |
| `clientRoles` | `Dictionary<string, object?>` | No |  |
| `createdTimestamp` | `long` | No |  |
| `credentials` | `List<object?>` | No |  |
| `disableableCredentialTypes` | `List<object?>` | No |  |
| `email` | `string` | No |  |
| `emailVerified` | `bool` | No |  |
| `enabled` | `bool` | No |  |
| `federatedIdentities` | `List<object?>` | No |  |
| `federationLink` | `string` | No |  |
| `firstName` | `string` | No |  |
| `groups` | `List<object?>` | No |  |
| `id` | `string` | No |  |
| `lastName` | `string` | No |  |
| `notBefore` | `long` | No |  |
| `origin` | `string` | No |  |
| `realmRoles` | `List<object?>` | No |  |
| `requiredActions` | `List<object?>` | No |  |
| `self` | `string` | No |  |
| `serviceAccountClientId` | `string` | No |  |
| `socialLinks` | `List<object?>` | No |  |
| `totp` | `bool` | No |  |
| `userProfileMetadata` | `Dictionary<string, object?>` | No |  |
| `username` | `string` | No |  |

### Operations

#### `Create(reqdata, ctrl = null) -> object?`

Create a new entity with the given data. Returns the created entity and raises on error.

```csharp
var result = client.User().Create(new Dictionary<string, object?>
{
    ["realm"] = "example_realm",  // string
});
```

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.User().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.User().Load(new Dictionary<string, object?> { ["id"] = "user_id", ["realm"] = "realm" });
```

#### `Remove(reqmatch, ctrl = null) -> object?`

Remove the entity matching the given criteria. Returns the entity, marked as deleted, and raises on error.

```csharp
var result = client.User().Remove(new Dictionary<string, object?> { ["id"] = "user_id", ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.User().Update(new Dictionary<string, object?>
{
    ["id"] = "user_id",
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `User` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## UserRepresentation

```csharp
var userRepresentation = client.UserRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `access` | `Dictionary<string, object?>` | No |  |
| `applicationRoles` | `Dictionary<string, object?>` | No |  |
| `attributes` | `Dictionary<string, object?>` | No |  |
| `clientConsents` | `List<object?>` | No |  |
| `clientRoles` | `Dictionary<string, object?>` | No |  |
| `createdTimestamp` | `long` | No |  |
| `credentials` | `List<object?>` | No |  |
| `disableableCredentialTypes` | `List<object?>` | No |  |
| `email` | `string` | No |  |
| `emailVerified` | `bool` | No |  |
| `enabled` | `bool` | No |  |
| `federatedIdentities` | `List<object?>` | No |  |
| `federationLink` | `string` | No |  |
| `firstName` | `string` | No |  |
| `groups` | `List<object?>` | No |  |
| `id` | `string` | No |  |
| `lastName` | `string` | No |  |
| `notBefore` | `long` | No |  |
| `origin` | `string` | No |  |
| `realmRoles` | `List<object?>` | No |  |
| `requiredActions` | `List<object?>` | No |  |
| `self` | `string` | No |  |
| `serviceAccountClientId` | `string` | No |  |
| `socialLinks` | `List<object?>` | No |  |
| `totp` | `bool` | No |  |
| `userProfileMetadata` | `Dictionary<string, object?>` | No |  |
| `username` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.UserRepresentation().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `UserRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## UserSession

```csharp
var userSession = client.UserSession();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `clients` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |
| `ipAddress` | `string` | No |  |
| `lastAccess` | `long` | No |  |
| `rememberMe` | `bool` | No |  |
| `start` | `long` | No |  |
| `userId` | `string` | No |  |
| `username` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.UserSession().List(null);
Console.WriteLine(results);
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `UserSession` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## UserSessionRepresentation

```csharp
var userSessionRepresentation = client.UserSessionRepresentation();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `clients` | `Dictionary<string, object?>` | No |  |
| `id` | `string` | No |  |
| `ipAddress` | `string` | No |  |
| `lastAccess` | `long` | No |  |
| `rememberMe` | `bool` | No |  |
| `start` | `long` | No |  |
| `userId` | `string` | No |  |
| `username` | `string` | No |  |

### Operations

#### `List(reqmatch, ctrl = null) -> object?`

List entities matching the given criteria. The match is optional — call `List(null)` to list all records. Returns a list of entities, one per record, and raises on error.

```csharp
var results = client.UserSessionRepresentation().List(null);
Console.WriteLine(results);
```

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.UserSessionRepresentation().Load(new Dictionary<string, object?> { ["client_uuid"] = "client_uuid", ["realm"] = "realm", ["user_id"] = "user_id" });
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `UserSessionRepresentation` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## UsersManagementPermission

```csharp
var usersManagementPermission = client.UsersManagementPermission();
```

### Fields

| Field | Type | Required | Description |
| --- | --- | --- | --- |
| `enabled` | `bool` | No |  |
| `resource` | `string` | No |  |
| `scopePermissions` | `Dictionary<string, object?>` | No |  |

### Operations

#### `Load(reqmatch, ctrl = null) -> object?`

Load a single entity matching the given criteria. Returns the entity, whose record `Data()` reads, and raises on error.

```csharp
var result = client.UsersManagementPermission().Load(new Dictionary<string, object?> { ["realm"] = "realm" });
```

#### `Update(reqdata, ctrl = null) -> object?`

Update an existing entity. The data must include the entity `id`. Returns the updated entity and raises on error.

```csharp
var result = client.UsersManagementPermission().Update(new Dictionary<string, object?>
{
    ["realm"] = "realm",
    // Fields to update
});
```

### Common Methods

#### `Data(newdata = null) -> object?`

Get or set the entity data.

#### `Match(newmatch = null) -> object?`

Get or set the entity match criteria.

#### `Make() -> IEntity`

Create a new `UsersManagementPermission` entity instance with the same options.

#### `GetName() -> string`

Return the entity name.


---

## Features

| Feature | Version | Description |
| --- | --- | --- |
| `test` | 0.0.1 | Test transport |


Features are activated via the `feature` option:

```csharp
var client = new VoxgigKeycloakSdkSDK(new Dictionary<string, object?>
{
    ["feature"] = new Dictionary<string, object?>
    {
        ["test"] = new Dictionary<string, object?> { ["active"] = true },
    },
});
```


### Configuring features

Each feature is inactive until switched on, and an SDK with no feature
configured does no feature work at all. Every option below keeps its default
unless you name it.

The array form of \`feature\` is significant: several features wrap the
transport, and the order you list them in is the order they nest.

#### `test`

Test transport.

**Configuration**

| Option | Default |
|---|---|
| `active` | `false` |

| Option | Type |
|---|---|
| `entity` | map |
| `net` | map |

These take no default: the feature behaves one way when you supply them and
another when you do not.

**Usage**

Set `feature.test.active` to true in the client options, and override any option above in the same entry. Every option keeps
its default unless you name it.

**Considerations**

- Attaches to pipeline hooks, not the transport, so activation order does
  not change what it observes.
- Installs the BASE transport that the wrapping features wrap, so it must be
  activated before them.
- Inactive by default: leaving it out costs nothing at runtime.

