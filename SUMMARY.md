# Keycloak Admin REST API

This is a REST API reference for the Keycloak Admin REST API.

## Start here

This guide introduces the API, the client libraries, and the companion tools in this repository. Start with the API capabilities, choose a client for your application, and use the linked reference when you need exact request and response details.

The selected API surface contains 60 entities and 316 HTTP routes. There are 1 SDK targets.

An entity groups related API operations. An operation can have several routes with different inputs or authentication requirements. The SDK exposes the entity and its operations using the conventions of the selected language.

## What the API provides

### AccessToken

Results: OK.

SDK operations: `list`.

### AdminEvent

Results: OK.

SDK operations: `list`.

### AttackDetection

Results: OK; No Content.

SDK operations: `load`, `remove`.

### AuthenticationFlowRepresentation

Results: OK.

SDK operations: `list`, `load`.

### AuthenticationManagement

Results: OK; Created; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### AuthenticatorConfigInfoRepresentation

Results: OK.

SDK operations: `load`.

### AuthenticatorConfigRepresentation

Results: OK.

SDK operations: `load`.

### Available

Results: OK.

SDK operations: `list`.

### Certificate

Results: OK.

SDK operations: `create`, `load`.

### CertificateRepresentation

Results: OK.

SDK operations: `create`.

### Client

Results: Created; OK; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### ClientInitialAccess

Results: No Content.

SDK operations: `remove`.

### ClientInitialAccessPresentation

Results: OK.

SDK operations: `create`, `list`.

### ClientPolicyRepresentation

Results: OK.

SDK operations: `list`.

### ClientProfilesRepresentation

Results: OK.

SDK operations: `list`.

### ClientRepresentation

Results: OK.

SDK operations: `create`.

### ClientScope

Results: OK.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### ClientScopeRepresentation

Results: OK.

SDK operations: `list`, `load`.

### Component

Results: OK; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### ComponentTypeRepresentation

Results: OK.

SDK operations: `list`.

### Composite

Results: OK.

SDK operations: `list`.

### Credential

Results: OK.

SDK operations: `list`.

### CredentialRepresentation

Results: OK.

SDK operations: `create`, `load`.

### DeleteByRealm

Results: No Content.

SDK operations: `remove`.

### Event

Results: OK.

SDK operations: `list`.

### FederatedIdentity

Results: OK.

SDK operations: `list`.

### Flow

Results: OK.

SDK operations: `create`.

### Get

Results: OK.

SDK operations: `list`.

### GetByRealm

Results: OK.

SDK operations: `list`.

### GlobalRequestResult

Results: OK.

SDK operations: `create`, `list`.

### Granted

Results: OK.

SDK operations: `list`.

### Group

Results: OK; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### GroupRepresentation

Results: OK.

SDK operations: `list`, `load`.

### IdToken

Results: OK.

SDK operations: `load`.

### IdentityProvider

Results: OK; No Content.

SDK operations: `create`, `load`, `remove`, `update`.

### IdentityProviderMapperRepresentation

Results: OK.

SDK operations: `list`, `load`.

### IdentityProviderRepresentation

Results: OK.

SDK operations: `list`, `load`.

### Key

Results: OK.

SDK operations: `list`.

### ManagementPermissionReference

Results: OK.

SDK operations: `load`, `update`.

### MappingsRepresentation

Results: OK.

SDK operations: `list`.

### NotGranted

Results: OK.

SDK operations: `list`.

### Post

Results: OK.

SDK operations: `create`.

### Protocol

Results: OK.

SDK operations: `load`.

### ProtocolMapper

Results: Created; OK; No Content.

SDK operations: `create`, `list`, `remove`, `update`.

### ProtocolMapperRepresentation

Results: OK.

SDK operations: `list`, `load`.

### PutByRealm

Results: OK.

SDK operations: `update`.

### Realm

Results: OK.

SDK operations: `list`.

### RealmEventsConfigRepresentation

Results: OK.

SDK operations: `list`.

### RealmsAdmin

Results: Created; OK; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### RequiredAction

Results: Created; OK.

SDK operations: `create`, `list`, `load`.

### Role

Results: Created; OK; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### RoleMapper

Results: Created; No Content.

SDK operations: `create`, `remove`.

### RolesById

Results: Created; OK; No Content.

SDK operations: `create`, `load`, `remove`, `update`.

### ScopeMapping

Results: Created; No Content.

SDK operations: `create`, `remove`.

### UpConfig

Results: OK.

SDK operations: `list`, `update`.

### User

Results: Created; OK; No Content.

SDK operations: `create`, `list`, `load`, `remove`, `update`.

### UserRepresentation

Results: OK.

SDK operations: `list`.

### UserSession

Results: OK.

SDK operations: `list`.

### UserSessionRepresentation

Results: OK.

SDK operations: `list`, `load`.

### UsersManagementPermission

Results: OK.

SDK operations: `load`, `update`.

### Route map

Use this map to locate a capability. Consult the entity reference before supplying request data; routes for the same operation can require different fields.

| Entity | SDK operation | HTTP route | Authentication |
| --- | --- | --- | --- |
| AccessToken | `list` | `GET /{realm}/clients/{id}/evaluate-scopes/generate-example-access-token` | Required |
| AdminEvent | `list` | `GET /{realm}/admin-events` | Required |
| AttackDetection | `load` | `GET /{realm}/attack-detection/brute-force/users/{userId}` | Required |
| AttackDetection | `remove` | `DELETE /{realm}/attack-detection/brute-force/users/{userId}` | Required |
| AttackDetection | `remove` | `DELETE /{realm}/attack-detection/brute-force/users` | Required |
| AuthenticationFlowRepresentation | `list` | `GET /{realm}/authentication/flows` | Required |
| AuthenticationFlowRepresentation | `load` | `GET /{realm}/authentication/flows/{id}` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/executions/{executionId}/config` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/executions/{executionId}/lower-priority` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/executions/{executionId}/raise-priority` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/flows/{flowAlias}/executions/execution` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/flows/{flowAlias}/executions/flow` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/config` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/executions` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/flows` | Required |
| AuthenticationManagement | `create` | `POST /{realm}/authentication/register-required-action` | Required |
| AuthenticationManagement | `list` | `GET /{realm}/authentication/authenticator-providers` | Required |
| AuthenticationManagement | `list` | `GET /{realm}/authentication/client-authenticator-providers` | Required |
| AuthenticationManagement | `list` | `GET /{realm}/authentication/form-action-providers` | Required |
| AuthenticationManagement | `list` | `GET /{realm}/authentication/form-providers` | Required |
| AuthenticationManagement | `list` | `GET /{realm}/authentication/unregistered-required-actions` | Required |
| AuthenticationManagement | `load` | `GET /{realm}/authentication/executions/{executionId}` | Required |
| AuthenticationManagement | `load` | `GET /{realm}/authentication/flows/{flowAlias}/executions` | Required |
| AuthenticationManagement | `load` | `GET /{realm}/authentication/per-client-config-description` | Required |
| AuthenticationManagement | `remove` | `DELETE /{realm}/authentication/required-actions/{alias}` | Required |
| AuthenticationManagement | `remove` | `DELETE /{realm}/authentication/executions/{executionId}` | Required |
| AuthenticationManagement | `remove` | `DELETE /{realm}/authentication/config/{id}` | Required |
| AuthenticationManagement | `remove` | `DELETE /{realm}/authentication/flows/{id}` | Required |
| AuthenticationManagement | `update` | `PUT /{realm}/authentication/required-actions/{alias}` | Required |
| AuthenticationManagement | `update` | `PUT /{realm}/authentication/flows/{flowAlias}/executions` | Required |
| AuthenticationManagement | `update` | `PUT /{realm}/authentication/config/{id}` | Required |
| AuthenticationManagement | `update` | `PUT /{realm}/authentication/flows/{id}` | Required |
| AuthenticatorConfigInfoRepresentation | `load` | `GET /{realm}/authentication/config-description/{providerId}` | Required |
| AuthenticatorConfigRepresentation | `load` | `GET /{realm}/authentication/executions/{executionId}/config/{id}` | Required |
| AuthenticatorConfigRepresentation | `load` | `GET /{realm}/authentication/config/{id}` | Required |
| Available | `list` | `GET /{realm}/clients/{id}/scope-mappings/clients/{client}/available` | Required |
| Available | `list` | `GET /{realm}/client-scopes/{id}/scope-mappings/clients/{client}/available` | Required |
| Available | `list` | `GET /{realm}/client-templates/{id}/scope-mappings/clients/{client}/available` | Required |
| Available | `list` | `GET /{realm}/groups/{id}/role-mappings/clients/{client}/available` | Required |
| Available | `list` | `GET /{realm}/users/{id}/role-mappings/clients/{client}/available` | Required |
| Available | `list` | `GET /{realm}/clients/{id}/scope-mappings/realm/available` | Required |
| Available | `list` | `GET /{realm}/client-scopes/{id}/scope-mappings/realm/available` | Required |
| Available | `list` | `GET /{realm}/client-templates/{id}/scope-mappings/realm/available` | Required |
| Available | `list` | `GET /{realm}/groups/{id}/role-mappings/realm/available` | Required |
| Available | `list` | `GET /{realm}/users/{id}/role-mappings/realm/available` | Required |
| Certificate | `create` | `POST /{realm}/clients/{id}/certificates/{attr}/download` | Required |
| Certificate | `create` | `POST /{realm}/clients/{id}/certificates/{attr}/generate-and-download` | Required |
| Certificate | `load` | `GET /{realm}/clients/{id}/certificates/{attr}` | Required |
| CertificateRepresentation | `create` | `POST /{realm}/clients/{id}/certificates/{attr}/generate` | Required |
| CertificateRepresentation | `create` | `POST /{realm}/clients/{id}/certificates/{attr}/upload` | Required |
| CertificateRepresentation | `create` | `POST /{realm}/clients/{id}/certificates/{attr}/upload-certificate` | Required |
| Client | `create` | `POST /{realm}/groups/{id}/role-mappings/clients/{client}` | Required |
| Client | `create` | `POST /{realm}/users/{id}/role-mappings/clients/{client}` | Required |
| Client | `create` | `POST /{realm}/clients/{id}/nodes` | Required |
| Client | `create` | `POST /{realm}/clients` | Required |
| Client | `list` | `GET /{realm}/clients` | Required |
| Client | `load` | `GET /{realm}/clients/{id}/roles/{role-name}/composites/clients/{clientUuid}` | Required |
| Client | `load` | `GET /{realm}/clients/{id}/scope-mappings/clients/{client}` | Required |
| Client | `load` | `GET /{realm}/client-scopes/{id}/scope-mappings/clients/{client}` | Required |
| Client | `load` | `GET /{realm}/client-templates/{id}/scope-mappings/clients/{client}` | Required |
| Client | `load` | `GET /{realm}/groups/{id}/role-mappings/clients/{client}` | Required |
| Client | `load` | `GET /{realm}/clients/{id}/installation/providers/{providerId}` | Required |
| Client | `load` | `GET /{realm}/roles/{role-name}/composites/clients/{clientUuid}` | Required |
| Client | `load` | `GET /{realm}/roles-by-id/{role-id}/composites/clients/{clientUuid}` | Required |
| Client | `load` | `GET /{realm}/users/{id}/role-mappings/clients/{client}` | Required |
| Client | `load` | `GET /{realm}/clients/{id}` | Required |
| Client | `load` | `GET /{realm}/clients/{id}/evaluate-scopes/generate-example-userinfo` | Required |
| Client | `load` | `GET /{realm}/clients/{id}/offline-session-count` | Required |
| Client | `load` | `GET /{realm}/clients/{id}/session-count` | Required |
| Client | `remove` | `DELETE /{realm}/clients/{id}/default-client-scopes/{clientScopeId}` | Required |
| Client | `remove` | `DELETE /{realm}/clients/{id}/optional-client-scopes/{clientScopeId}` | Required |
| Client | `remove` | `DELETE /{realm}/groups/{id}/role-mappings/clients/{client}` | Required |
| Client | `remove` | `DELETE /{realm}/clients/{id}/nodes/{node}` | Required |
| Client | `remove` | `DELETE /{realm}/users/{id}/role-mappings/clients/{client}` | Required |
| Client | `remove` | `DELETE /{realm}/clients/{id}` | Required |
| Client | `remove` | `DELETE /{realm}/clients/{id}/client-secret/rotated` | Required |
| Client | `update` | `PUT /{realm}/clients/{id}/default-client-scopes/{clientScopeId}` | Required |
| Client | `update` | `PUT /{realm}/clients/{id}/optional-client-scopes/{clientScopeId}` | Required |
| Client | `update` | `PUT /{realm}/clients/{id}` | Required |
| ClientInitialAccess | `remove` | `DELETE /{realm}/clients-initial-access/{id}` | Required |
| ClientInitialAccessPresentation | `create` | `POST /{realm}/clients-initial-access` | Required |
| ClientInitialAccessPresentation | `list` | `GET /{realm}/clients-initial-access` | Required |
| ClientPolicyRepresentation | `list` | `GET /{realm}/client-policies/policies` | Required |
| ClientProfilesRepresentation | `list` | `GET /{realm}/client-policies/profiles` | Required |
| ClientRepresentation | `create` | `POST /{realm}/clients/{id}/registration-access-token` | Required |
| ClientRepresentation | `create` | `POST /{realm}/client-description-converter` | Required |
| ClientScope | `create` | `POST /{realm}/client-scopes` | Required |
| ClientScope | `create` | `POST /{realm}/client-templates` | Required |
| ClientScope | `list` | `GET /{realm}/client-scopes` | Required |
| ClientScope | `load` | `GET /{realm}/client-scopes/{id}` | Required |
| ClientScope | `remove` | `DELETE /{realm}/client-scopes/{id}` | Required |
| ClientScope | `remove` | `DELETE /{realm}/client-templates/{id}` | Required |
| ClientScope | `update` | `PUT /{realm}/client-scopes/{id}` | Required |
| ClientScope | `update` | `PUT /{realm}/client-templates/{id}` | Required |
| ClientScopeRepresentation | `list` | `GET /{realm}/clients/{id}/default-client-scopes` | Required |
| ClientScopeRepresentation | `list` | `GET /{realm}/clients/{id}/optional-client-scopes` | Required |
| ClientScopeRepresentation | `list` | `GET /{realm}/client-templates` | Required |
| ClientScopeRepresentation | `list` | `GET /{realm}/default-default-client-scopes` | Required |
| ClientScopeRepresentation | `list` | `GET /{realm}/default-optional-client-scopes` | Required |
| ClientScopeRepresentation | `load` | `GET /{realm}/client-templates/{id}` | Required |
| Component | `create` | `POST /{realm}/components` | Required |
| Component | `list` | `GET /{realm}/components` | Required |
| Component | `load` | `GET /{realm}/components/{id}` | Required |
| Component | `remove` | `DELETE /{realm}/components/{id}` | Required |
| Component | `update` | `PUT /{realm}/components/{id}` | Required |
| ComponentTypeRepresentation | `list` | `GET /{realm}/components/{id}/sub-component-types` | Required |
| ComponentTypeRepresentation | `list` | `GET /{realm}/client-registration-policy/providers` | Required |
| Composite | `list` | `GET /{realm}/clients/{id}/scope-mappings/clients/{client}/composite` | Required |
| Composite | `list` | `GET /{realm}/client-scopes/{id}/scope-mappings/clients/{client}/composite` | Required |
| Composite | `list` | `GET /{realm}/client-templates/{id}/scope-mappings/clients/{client}/composite` | Required |
| Composite | `list` | `GET /{realm}/groups/{id}/role-mappings/clients/{client}/composite` | Required |
| Composite | `list` | `GET /{realm}/clients/{id}/roles/{role-name}/composites` | Required |
| Composite | `list` | `GET /{realm}/users/{id}/role-mappings/clients/{client}/composite` | Required |
| Composite | `list` | `GET /{realm}/clients/{id}/scope-mappings/realm/composite` | Required |
| Composite | `list` | `GET /{realm}/client-scopes/{id}/scope-mappings/realm/composite` | Required |
| Composite | `list` | `GET /{realm}/client-templates/{id}/scope-mappings/realm/composite` | Required |
| Composite | `list` | `GET /{realm}/groups/{id}/role-mappings/realm/composite` | Required |
| Composite | `list` | `GET /{realm}/roles/{role-name}/composites` | Required |
| Composite | `list` | `GET /{realm}/roles-by-id/{role-id}/composites` | Required |
| Composite | `list` | `GET /{realm}/users/{id}/role-mappings/realm/composite` | Required |
| Credential | `list` | `GET /{realm}/users/{id}/credentials` | Required |
| CredentialRepresentation | `create` | `POST /{realm}/clients/{id}/client-secret` | Required |
| CredentialRepresentation | `load` | `GET /{realm}/clients/{id}/client-secret` | Required |
| CredentialRepresentation | `load` | `GET /{realm}/clients/{id}/client-secret/rotated` | Required |
| DeleteByRealm | `remove` | `DELETE /{realm}` | Required |
| Event | `list` | `GET /{realm}/events` | Required |
| FederatedIdentity | `list` | `GET /{realm}/users/{id}/federated-identity` | Required |
| Flow | `create` | `POST /{realm}/authentication/flows/{flowAlias}/copy` | Required |
| Get | `list` | `GET /` | Required |
| GetByRealm | `list` | `GET /{realm}` | Required |
| GlobalRequestResult | `create` | `POST /{realm}/clients/{id}/push-revocation` | Required |
| GlobalRequestResult | `create` | `POST /{realm}/logout-all` | Required |
| GlobalRequestResult | `create` | `POST /{realm}/push-revocation` | Required |
| GlobalRequestResult | `list` | `GET /{realm}/clients/{id}/test-nodes-available` | Required |
| Granted | `list` | `GET /{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/granted` | Required |
| Group | `create` | `POST /{realm}/groups/{id}/children` | Required |
| Group | `create` | `POST /{realm}/groups` | Required |
| Group | `list` | `GET /{realm}/clients/{id}/roles/{role-name}/groups` | Required |
| Group | `list` | `GET /{realm}/roles/{role-name}/groups` | Required |
| Group | `list` | `GET /{realm}/users/{id}/groups` | Required |
| Group | `list` | `GET /{realm}/groups` | Required |
| Group | `load` | `GET /{realm}/groups/{id}` | Required |
| Group | `load` | `GET /{realm}/groups/count` | Required |
| Group | `remove` | `DELETE /{realm}/groups/{id}` | Required |
| Group | `update` | `PUT /{realm}/groups/{id}` | Required |
| GroupRepresentation | `list` | `GET /{realm}/groups/{id}/children` | Required |
| GroupRepresentation | `list` | `GET /{realm}/default-groups` | Required |
| GroupRepresentation | `load` | `GET /{realm}/group-by-path/{path}` | Required |
| IdToken | `load` | `GET /{realm}/clients/{id}/evaluate-scopes/generate-example-id-token` | Required |
| IdentityProvider | `create` | `POST /{realm}/identity-provider/instances/{alias}/mappers` | Required |
| IdentityProvider | `create` | `POST /{realm}/identity-provider/import-config` | Required |
| IdentityProvider | `create` | `POST /{realm}/identity-provider/instances` | Required |
| IdentityProvider | `load` | `GET /{realm}/identity-provider/instances/{alias}/export` | Required |
| IdentityProvider | `load` | `GET /{realm}/identity-provider/instances/{alias}/mapper-types` | Required |
| IdentityProvider | `load` | `GET /{realm}/identity-provider/providers/{provider_id}` | Required |
| IdentityProvider | `remove` | `DELETE /{realm}/identity-provider/instances/{alias}/mappers/{id}` | Required |
| IdentityProvider | `remove` | `DELETE /{realm}/identity-provider/instances/{alias}` | Required |
| IdentityProvider | `update` | `PUT /{realm}/identity-provider/instances/{alias}/mappers/{id}` | Required |
| IdentityProvider | `update` | `PUT /{realm}/identity-provider/instances/{alias}` | Required |
| IdentityProviderMapperRepresentation | `list` | `GET /{realm}/identity-provider/instances/{alias}/mappers` | Required |
| IdentityProviderMapperRepresentation | `load` | `GET /{realm}/identity-provider/instances/{alias}/mappers/{id}` | Required |
| IdentityProviderRepresentation | `list` | `GET /{realm}/identity-provider/instances` | Required |
| IdentityProviderRepresentation | `load` | `GET /{realm}/identity-provider/instances/{alias}` | Required |
| Key | `list` | `GET /{realm}/keys` | Required |
| ManagementPermissionReference | `load` | `GET /{realm}/clients/{id}/roles/{role-name}/management/permissions` | Required |
| ManagementPermissionReference | `load` | `GET /{realm}/clients/{id}/management/permissions` | Required |
| ManagementPermissionReference | `load` | `GET /{realm}/groups/{id}/management/permissions` | Required |
| ManagementPermissionReference | `load` | `GET /{realm}/identity-provider/instances/{alias}/management/permissions` | Required |
| ManagementPermissionReference | `load` | `GET /{realm}/roles/{role-name}/management/permissions` | Required |
| ManagementPermissionReference | `load` | `GET /{realm}/roles-by-id/{role-id}/management/permissions` | Required |
| ManagementPermissionReference | `update` | `PUT /{realm}/clients/{id}/roles/{role-name}/management/permissions` | Required |
| ManagementPermissionReference | `update` | `PUT /{realm}/clients/{id}/management/permissions` | Required |
| ManagementPermissionReference | `update` | `PUT /{realm}/groups/{id}/management/permissions` | Required |
| ManagementPermissionReference | `update` | `PUT /{realm}/identity-provider/instances/{alias}/management/permissions` | Required |
| ManagementPermissionReference | `update` | `PUT /{realm}/roles/{role-name}/management/permissions` | Required |
| ManagementPermissionReference | `update` | `PUT /{realm}/roles-by-id/{role-id}/management/permissions` | Required |
| MappingsRepresentation | `list` | `GET /{realm}/clients/{id}/scope-mappings` | Required |
| MappingsRepresentation | `list` | `GET /{realm}/client-scopes/{id}/scope-mappings` | Required |
| MappingsRepresentation | `list` | `GET /{realm}/client-templates/{id}/scope-mappings` | Required |
| MappingsRepresentation | `list` | `GET /{realm}/groups/{id}/role-mappings` | Required |
| MappingsRepresentation | `list` | `GET /{realm}/users/{id}/role-mappings` | Required |
| NotGranted | `list` | `GET /{realm}/clients/{id}/evaluate-scopes/scope-mappings/{roleContainerId}/not-granted` | Required |
| Post | `create` | `POST /` | Required |
| Protocol | `load` | `GET /{realm}/clients/{id}/protocol-mappers/protocol/{protocol}` | Required |
| Protocol | `load` | `GET /{realm}/client-scopes/{id}/protocol-mappers/protocol/{protocol}` | Required |
| Protocol | `load` | `GET /{realm}/client-templates/{id}/protocol-mappers/protocol/{protocol}` | Required |
| ProtocolMapper | `create` | `POST /{realm}/clients/{id}/protocol-mappers/add-models` | Required |
| ProtocolMapper | `create` | `POST /{realm}/client-scopes/{id}/protocol-mappers/add-models` | Required |
| ProtocolMapper | `create` | `POST /{realm}/client-templates/{id}/protocol-mappers/add-models` | Required |
| ProtocolMapper | `create` | `POST /{realm}/clients/{id}/protocol-mappers/models` | Required |
| ProtocolMapper | `create` | `POST /{realm}/client-scopes/{id}/protocol-mappers/models` | Required |
| ProtocolMapper | `create` | `POST /{realm}/client-templates/{id}/protocol-mappers/models` | Required |
| ProtocolMapper | `list` | `GET /{realm}/clients/{id}/evaluate-scopes/protocol-mappers` | Required |
| ProtocolMapper | `remove` | `DELETE /{realm}/clients/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapper | `remove` | `DELETE /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapper | `remove` | `DELETE /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapper | `update` | `PUT /{realm}/clients/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapper | `update` | `PUT /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapper | `update` | `PUT /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapperRepresentation | `list` | `GET /{realm}/clients/{id}/protocol-mappers/models` | Required |
| ProtocolMapperRepresentation | `list` | `GET /{realm}/client-scopes/{id}/protocol-mappers/models` | Required |
| ProtocolMapperRepresentation | `list` | `GET /{realm}/client-templates/{id}/protocol-mappers/models` | Required |
| ProtocolMapperRepresentation | `load` | `GET /{realm}/clients/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapperRepresentation | `load` | `GET /{realm}/client-scopes/{id1}/protocol-mappers/models/{id2}` | Required |
| ProtocolMapperRepresentation | `load` | `GET /{realm}/client-templates/{id1}/protocol-mappers/models/{id2}` | Required |
| PutByRealm | `update` | `PUT /{realm}` | Required |
| Realm | `list` | `GET /{realm}/clients/{id}/roles/{role-name}/composites/realm` | Required |
| Realm | `list` | `GET /{realm}/clients/{id}/scope-mappings/realm` | Required |
| Realm | `list` | `GET /{realm}/client-scopes/{id}/scope-mappings/realm` | Required |
| Realm | `list` | `GET /{realm}/client-templates/{id}/scope-mappings/realm` | Required |
| Realm | `list` | `GET /{realm}/groups/{id}/role-mappings/realm` | Required |
| Realm | `list` | `GET /{realm}/roles/{role-name}/composites/realm` | Required |
| Realm | `list` | `GET /{realm}/roles-by-id/{role-id}/composites/realm` | Required |
| Realm | `list` | `GET /{realm}/users/{id}/role-mappings/realm` | Required |
| RealmEventsConfigRepresentation | `list` | `GET /{realm}/events/config` | Required |
| RealmsAdmin | `create` | `POST /{realm}/localization/{locale}` | Required |
| RealmsAdmin | `create` | `POST /{realm}/partial-export` | Required |
| RealmsAdmin | `create` | `POST /{realm}/partialImport` | Required |
| RealmsAdmin | `create` | `POST /{realm}/testSMTPConnection` | Required |
| RealmsAdmin | `list` | `GET /{realm}/client-session-stats` | Required |
| RealmsAdmin | `list` | `GET /{realm}/credential-registrators` | Required |
| RealmsAdmin | `list` | `GET /{realm}/localization` | Required |
| RealmsAdmin | `load` | `GET /{realm}/localization/{locale}/{key}` | Required |
| RealmsAdmin | `load` | `GET /{realm}/localization/{locale}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/localization/{locale}/{key}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/default-default-client-scopes/{clientScopeId}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/default-optional-client-scopes/{clientScopeId}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/default-groups/{groupId}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/localization/{locale}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/sessions/{session}` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/admin-events` | Required |
| RealmsAdmin | `remove` | `DELETE /{realm}/events` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/localization/{locale}/{key}` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/default-default-client-scopes/{clientScopeId}` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/default-optional-client-scopes/{clientScopeId}` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/default-groups/{groupId}` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/client-policies/policies` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/client-policies/profiles` | Required |
| RealmsAdmin | `update` | `PUT /{realm}/events/config` | Required |
| RequiredAction | `create` | `POST /{realm}/authentication/required-actions/{alias}/lower-priority` | Required |
| RequiredAction | `create` | `POST /{realm}/authentication/required-actions/{alias}/raise-priority` | Required |
| RequiredAction | `list` | `GET /{realm}/authentication/required-actions` | Required |
| RequiredAction | `load` | `GET /{realm}/authentication/required-actions/{alias}` | Required |
| Role | `create` | `POST /{realm}/clients/{id}/roles/{role-name}/composites` | Required |
| Role | `create` | `POST /{realm}/clients/{id}/roles` | Required |
| Role | `create` | `POST /{realm}/roles/{role-name}/composites` | Required |
| Role | `create` | `POST /{realm}/roles` | Required |
| Role | `list` | `GET /{realm}/clients/{id}/roles` | Required |
| Role | `list` | `GET /{realm}/roles` | Required |
| Role | `load` | `GET /{realm}/clients/{id}/roles/{role-name}` | Required |
| Role | `load` | `GET /{realm}/roles/{role-name}` | Required |
| Role | `remove` | `DELETE /{realm}/clients/{id}/roles/{role-name}` | Required |
| Role | `remove` | `DELETE /{realm}/clients/{id}/roles/{role-name}/composites` | Required |
| Role | `remove` | `DELETE /{realm}/roles/{role-name}` | Required |
| Role | `remove` | `DELETE /{realm}/roles/{role-name}/composites` | Required |
| Role | `update` | `PUT /{realm}/clients/{id}/roles/{role-name}` | Required |
| Role | `update` | `PUT /{realm}/roles/{role-name}` | Required |
| RoleMapper | `create` | `POST /{realm}/groups/{id}/role-mappings/realm` | Required |
| RoleMapper | `create` | `POST /{realm}/users/{id}/role-mappings/realm` | Required |
| RoleMapper | `remove` | `DELETE /{realm}/groups/{id}/role-mappings/realm` | Required |
| RoleMapper | `remove` | `DELETE /{realm}/users/{id}/role-mappings/realm` | Required |
| RolesById | `create` | `POST /{realm}/roles-by-id/{role-id}/composites` | Required |
| RolesById | `load` | `GET /{realm}/roles-by-id/{role-id}` | Required |
| RolesById | `remove` | `DELETE /{realm}/roles-by-id/{role-id}` | Required |
| RolesById | `remove` | `DELETE /{realm}/roles-by-id/{role-id}/composites` | Required |
| RolesById | `update` | `PUT /{realm}/roles-by-id/{role-id}` | Required |
| ScopeMapping | `create` | `POST /{realm}/clients/{id}/scope-mappings/clients/{client}` | Required |
| ScopeMapping | `create` | `POST /{realm}/client-scopes/{id}/scope-mappings/clients/{client}` | Required |
| ScopeMapping | `create` | `POST /{realm}/client-templates/{id}/scope-mappings/clients/{client}` | Required |
| ScopeMapping | `create` | `POST /{realm}/clients/{id}/scope-mappings/realm` | Required |
| ScopeMapping | `create` | `POST /{realm}/client-scopes/{id}/scope-mappings/realm` | Required |
| ScopeMapping | `create` | `POST /{realm}/client-templates/{id}/scope-mappings/realm` | Required |
| ScopeMapping | `remove` | `DELETE /{realm}/clients/{id}/scope-mappings/clients/{client}` | Required |
| ScopeMapping | `remove` | `DELETE /{realm}/client-scopes/{id}/scope-mappings/clients/{client}` | Required |
| ScopeMapping | `remove` | `DELETE /{realm}/client-templates/{id}/scope-mappings/clients/{client}` | Required |
| ScopeMapping | `remove` | `DELETE /{realm}/clients/{id}/scope-mappings/realm` | Required |
| ScopeMapping | `remove` | `DELETE /{realm}/client-scopes/{id}/scope-mappings/realm` | Required |
| ScopeMapping | `remove` | `DELETE /{realm}/client-templates/{id}/scope-mappings/realm` | Required |
| UpConfig | `list` | `GET /{realm}/users/profile` | Required |
| UpConfig | `update` | `PUT /{realm}/users/profile` | Required |
| User | `create` | `POST /{realm}/users/{id}/credentials/{credentialId}/moveAfter/{newPreviousCredentialId}` | Required |
| User | `create` | `POST /{realm}/users/{id}/credentials/{credentialId}/moveToFirst` | Required |
| User | `create` | `POST /{realm}/users/{id}/federated-identity/{provider}` | Required |
| User | `create` | `POST /{realm}/users/{id}/impersonation` | Required |
| User | `create` | `POST /{realm}/users/{id}/logout` | Required |
| User | `create` | `POST /{realm}/users` | Required |
| User | `list` | `GET /{realm}/clients/{id}/roles/{role-name}/users` | Required |
| User | `list` | `GET /{realm}/users/{id}/configured-user-storage-credential-types` | Required |
| User | `list` | `GET /{realm}/users/{id}/consents` | Required |
| User | `list` | `GET /{realm}/roles/{role-name}/users` | Required |
| User | `list` | `GET /{realm}/users` | Required |
| User | `list` | `GET /{realm}/users/profile/metadata` | Required |
| User | `load` | `GET /{realm}/users/{id}` | Required |
| User | `load` | `GET /{realm}/users/{id}/groups/count` | Required |
| User | `load` | `GET /{realm}/users/count` | Required |
| User | `remove` | `DELETE /{realm}/users/{id}/consents/{client}` | Required |
| User | `remove` | `DELETE /{realm}/users/{id}/credentials/{credentialId}` | Required |
| User | `remove` | `DELETE /{realm}/users/{id}/groups/{groupId}` | Required |
| User | `remove` | `DELETE /{realm}/users/{id}/federated-identity/{provider}` | Required |
| User | `remove` | `DELETE /{realm}/users/{id}` | Required |
| User | `update` | `PUT /{realm}/users/{id}/credentials/{credentialId}/userLabel` | Required |
| User | `update` | `PUT /{realm}/users/{id}/groups/{groupId}` | Required |
| User | `update` | `PUT /{realm}/users/{id}` | Required |
| User | `update` | `PUT /{realm}/users/{id}/disable-credential-types` | Required |
| User | `update` | `PUT /{realm}/users/{id}/execute-actions-email` | Required |
| User | `update` | `PUT /{realm}/users/{id}/reset-password` | Required |
| User | `update` | `PUT /{realm}/users/{id}/reset-password-email` | Required |
| User | `update` | `PUT /{realm}/users/{id}/send-verify-email` | Required |
| UserRepresentation | `list` | `GET /{realm}/clients/{id}/service-account-user` | Required |
| UserRepresentation | `list` | `GET /{realm}/groups/{id}/members` | Required |
| UserSession | `list` | `GET /{realm}/clients/{id}/user-sessions` | Required |
| UserSessionRepresentation | `list` | `GET /{realm}/clients/{id}/offline-sessions` | Required |
| UserSessionRepresentation | `list` | `GET /{realm}/users/{id}/sessions` | Required |
| UserSessionRepresentation | `load` | `GET /{realm}/users/{id}/offline-sessions/{clientUuid}` | Required |
| UsersManagementPermission | `load` | `GET /{realm}/users-management-permissions` | Required |
| UsersManagementPermission | `update` | `PUT /{realm}/users-management-permissions` | Required |

## Connect to the API

- API server: `https://keycloak.example.com/admin/realms`

The default credential is sent in the `Authorization` header with the `Bearer` prefix.

Check authentication for the route you plan to call. A route that declares no authentication can be used without credentials; this does not change the requirements of other routes. Keep credentials in environment variables or a configured secret provider, and keep them out of source control and logs.

## Make a first request

1. Choose the API server and an operation that matches your task.
2. Check the operation’s required input and authentication. Use values valid for your account and environment.
3. Send one request and inspect the returned data before adding retries, concurrency, or a larger batch.

For an SDK call, install or build the chosen client, create a client instance with its documented configuration, and call the required entity operation. Language references describe the argument shape, asynchronous behaviour, and returned values.

## Choose an SDK

Choose the language already used by your application or service. The clients represent the same API model, while package setup, naming, and return types follow each language. Check the selected client’s reference and tests before integrating it into an existing application.

| Client | Repository directory | Distribution |
| --- | --- | --- |
| C# | `csharp/` | Build from source |

Build-from-source entries are not marked as published in the project model. Follow the build instructions in that target’s README, then consume the resulting package using your language’s local dependency mechanism. Published entries give the installation command recorded for that client.

## Operational features

Features supply behaviour around API calls, such as request handling, diagnostics, or local testing. Inclusion in this project does not mean a feature is enabled at runtime. Check the selected SDK’s supported features and configuration defaults, then enable the behaviour your application needs.

- `test`: In-memory mock transport for testing without a live server

Start with the default client configuration. Add request limits and diagnostics as needed, test error paths, and review retry behaviour before using operations that change data. A retry can repeat an operation unless the API provides a suitable guarantee.

## Continue with the documentation

- Follow the first-call guide for the setup sequence.
- Read the authentication guide before using protected routes.
- Use the API reference for request schemas, response formats, and status codes.
- Check the chosen SDK or companion tool reference for its configuration and supported operations.

