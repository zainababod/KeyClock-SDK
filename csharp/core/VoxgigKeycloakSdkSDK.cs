// VoxgigKeycloakSdk SDK client.

using Voxgig.Struct;

using VoxgigKeycloakSdkSdk.Feature;

namespace VoxgigKeycloakSdkSdk;

public class VoxgigKeycloakSdkSDK
{
    // NOTE: type references in EXPRESSION position are `global::`-qualified
    // throughout this class. Entity accessors are PascalCase methods declared
    // on it (see MainEntity_csharp), so an entity named `utility` declares
    // `Utility(...)` here and C# then resolves the simple name `Utility` in an
    // expression to the METHOD, not the type: "'X.Utility(...)' is a method,
    // which is not valid in the given context". Qualifying makes the class
    // immune to that whatever the API names its entities. Type POSITIONS
    // (field and return types) are unaffected and stay unqualified.

    public string Mode = "live";
    private Dictionary<string, object?> _options;
    private readonly Utility _utility;
    public List<BaseFeature> Features = new();
    private readonly Context _rootctx;

    public VoxgigKeycloakSdkSDK(Dictionary<string, object?>? options = null)
    {
        _utility = new Utility();

        // The process-wide config (sdkgen rung L2): read-only on the request
        // path, so every client shares one rather than rebuilding it.
        var config = global::VoxgigKeycloakSdkSdk.SdkConfig.SharedConfig();

        _rootctx = _utility.MakeContext(new Dictionary<string, object?>
        {
            ["client"] = this,
            ["utility"] = _utility,
            ["config"] = config,
            ["options"] = options,
            ["shared"] = new Dictionary<string, object?>(),
        }, null);

        _options = _utility.MakeOptions(_rootctx);

        if (Equals(global::Voxgig.Struct.StructUtils.GetPath(_options,
            global::Voxgig.Struct.StructUtils.Jt("feature", "test", "active")), true))
        {
            Mode = "test";
        }

        _rootctx.Options = _options;

        // Add features in the resolved order (MakeOptions puts an explicit
        // list order first, else defaults to test-first). Ordering matters:
        // the `test` feature installs the base mock transport and the transport
        // features (retry/cache/netsim/proxy/ratelimit) wrap whatever is
        // current, so `test` must be added before them to sit at the base of
        // the chain.
        var featureOpts = global::VoxgigKeycloakSdkSdk.Helpers.ToMapAny(global::Voxgig.Struct.StructUtils.GetProp(_options, "feature"))
            ?? new Dictionary<string, object?>();
        var featureOrder = global::Voxgig.Struct.StructUtils.GetPath(_options,
            global::Voxgig.Struct.StructUtils.Jt("__derived__", "featureorder")) as List<object?>
            ?? new List<object?>();
        foreach (var fnameObj in featureOrder)
        {
            var fname = fnameObj as string ?? "";
            var fopts = global::VoxgigKeycloakSdkSdk.Helpers.ToMapAny(global::Voxgig.Struct.StructUtils.GetProp(featureOpts, fname));
            if (fopts != null &&
                fopts.TryGetValue("active", out var active) &&
                active is bool ab && ab)
            {
                _utility.FeatureAdd(_rootctx, global::VoxgigKeycloakSdkSdk.SdkConfig.MakeFeature(fname));
            }
        }

        // Add extension features.
        if (global::Voxgig.Struct.StructUtils.GetProp(_options, "extend") is List<object?> extList)
        {
            foreach (var f in extList)
            {
                if (f is BaseFeature feat)
                {
                    _utility.FeatureAdd(_rootctx, feat);
                }
            }
        }

        // Initialize features.
        foreach (var f in Features.ToList())
        {
            _utility.FeatureInit(_rootctx, f);
        }

        _utility.FeatureHook(_rootctx, "PostConstruct");
    }

    public Dictionary<string, object?> OptionsMap()
    {
        return global::Voxgig.Struct.StructUtils.Clone(_options) as Dictionary<string, object?>
            ?? new Dictionary<string, object?>();
    }

    public Utility GetUtility()
    {
        return global::VoxgigKeycloakSdkSdk.Utility.Copy(_utility);
    }

    public Context GetRootCtx()
    {
        return _rootctx;
    }

    public Dictionary<string, object?> Prepare(Dictionary<string, object?>? fetchargs)
    {
        var utility = _utility;

        fetchargs ??= new Dictionary<string, object?>();

        var ctrl = global::VoxgigKeycloakSdkSdk.Helpers.ToMapAny(global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "ctrl"))
            ?? new Dictionary<string, object?>();

        var ctx = utility.MakeContext(new Dictionary<string, object?>
        {
            ["opname"] = "prepare",
            ["ctrl"] = ctrl,
        }, _rootctx);

        var options = _options;

        var path = global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "path") as string ?? "";
        var method = global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "method") as string ?? "";
        if (method == "")
        {
            method = "GET";
        }
        method = method.ToUpperInvariant();

        var allowMethod = global::Voxgig.Struct.StructUtils.GetPath(options, global::Voxgig.Struct.StructUtils.Jt("allow", "method"));
        if (!global::VoxgigKeycloakSdkSdk.Helpers.Allowed(allowMethod, method))
        {
            throw ctx.MakeError("spec_method_allow",
                "Method \"" + method + "\" not allowed by SDK option allow.method value: \"" +
                (allowMethod as string ?? "") + "\"");
        }

        var pathParams = global::VoxgigKeycloakSdkSdk.Helpers.ToMapAny(global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "params"))
            ?? new Dictionary<string, object?>();
        var query = global::VoxgigKeycloakSdkSdk.Helpers.ToMapAny(global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "query"))
            ?? new Dictionary<string, object?>();

        var headers = utility.PrepareHeaders(ctx);

        var basev = global::Voxgig.Struct.StructUtils.GetProp(options, "base") as string ?? "";
        var prefix = global::Voxgig.Struct.StructUtils.GetProp(options, "prefix") as string ?? "";
        var suffix = global::Voxgig.Struct.StructUtils.GetProp(options, "suffix") as string ?? "";

        ctx.Spec = new Spec(new Dictionary<string, object?>
        {
            ["base"] = basev,
            ["prefix"] = prefix,
            ["suffix"] = suffix,
            ["path"] = path,
            ["method"] = method,
            ["params"] = pathParams,
            ["query"] = query,
            ["headers"] = headers,
            ["body"] = global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "body"),
            ["step"] = "start",
        });

        // Merge user-provided headers.
        if (global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "headers") is Dictionary<string, object?> uhm)
        {
            foreach (var kv in uhm)
            {
                ctx.Spec.Headers[kv.Key] = kv.Value;
            }
        }

        utility.PrepareAuth(ctx);

        return utility.MakeFetchDef(ctx);
    }

    // Raw endpoint access is operator-controllable, like every entity op.
    // Blocking it means denying BOTH the 'direct' and 'graphql' tokens,
    // since either one reaches the same endpoint.
    public Dictionary<string, object?> Direct(Dictionary<string, object?>? fetchargs)
    {
        if (!OpAllowed("direct"))
        {
            return OpDenied("direct");
        }

        return RawRequest(fetchargs);
    }

    // Is this raw-access op permitted by the SDK's allow.op option?
    private bool OpAllowed(string op)
    {
        return global::VoxgigKeycloakSdkSdk.Helpers.Allowed(
            global::Voxgig.Struct.StructUtils.GetPath(_options, global::Voxgig.Struct.StructUtils.Jt("allow", "op")), op);
    }

    private Dictionary<string, object?> OpDenied(string op)
    {
        var allow = global::Voxgig.Struct.StructUtils.GetPath(_options, global::Voxgig.Struct.StructUtils.Jt("allow", "op"))
            as string ?? "";
        return new Dictionary<string, object?>
        {
            ["ok"] = false,
            ["err"] = new Exception("VoxgigKeycloakSdkSDK: " + op +
                ": operation not allowed by SDK option allow.op value: \"" +
                allow + "\""),
        };
    }

    // Ungated request path shared by Direct and Graphql, each of which
    // checks its own allow.op token first. Private, rather than a flag on
    // fetchargs: a caller-supplied marker would let anyone opt straight back
    // out of the gate by passing it.
    private Dictionary<string, object?> RawRequest(Dictionary<string, object?>? fetchargs)
    {
        var utility = _utility;

        Dictionary<string, object?> fetchdef;
        try
        {
            fetchdef = Prepare(fetchargs);
        }
        catch (Exception err)
        {
            return new Dictionary<string, object?>
            {
                ["ok"] = false,
                ["err"] = CleanErr(_rootctx, err),
            };
        }

        fetchargs ??= new Dictionary<string, object?>();

        var ctrl = global::VoxgigKeycloakSdkSdk.Helpers.ToMapAny(global::Voxgig.Struct.StructUtils.GetProp(fetchargs, "ctrl"))
            ?? new Dictionary<string, object?>();

        var ctx = utility.MakeContext(new Dictionary<string, object?>
        {
            ["opname"] = "direct",
            ["ctrl"] = ctrl,
        }, _rootctx);

        var url = fetchdef.TryGetValue("url", out var u) ? u as string ?? "" : "";

        object? fetched;
        try
        {
            fetched = utility.Fetcher(ctx, url, fetchdef);
        }
        catch (Exception fetchErr)
        {
            return new Dictionary<string, object?>
            {
                ["ok"] = false,
                ["err"] = CleanErr(ctx, fetchErr),
            };
        }

        if (fetched == null)
        {
            return new Dictionary<string, object?>
            {
                ["ok"] = false,
                ["err"] = ctx.MakeError("direct_no_response", "response: undefined"),
            };
        }

        if (fetched is Dictionary<string, object?> fm)
        {
            var status = global::VoxgigKeycloakSdkSdk.Helpers.ToInt(global::Voxgig.Struct.StructUtils.GetProp(fm, "status"));
            var headers = global::Voxgig.Struct.StructUtils.GetProp(fm, "headers");

            // No-body responses (204, 304) and explicit zero content-length
            // must skip JSON parsing - calling json() on an empty body errors.
            var contentLength = "";
            if (headers is Dictionary<string, object?> hm &&
                hm.TryGetValue("content-length", out var cl) && cl != null)
            {
                contentLength = global::Voxgig.Struct.StructUtils.Stringify(cl);
            }
            var noBody = status == 204 || status == 304 || contentLength == "0";

            object? jsonData = null;
            if (!noBody && global::Voxgig.Struct.StructUtils.GetProp(fm, "json") is Func<object?> jf)
            {
                // jf() returns null on parse error in our fetcher.
                jsonData = jf();
            }

            Exception? bodyErr = null;
            if (!noBody && global::Voxgig.Struct.StructUtils.GetProp(fm, "unreadable") is true)
            {
                var failed = status >= 200 && status < 300 ? null : ctx.MakeError("request_status",
                    "request: " + status + ": " + global::Voxgig.Struct.StructUtils.GetProp(fm, "statusText"));
                bodyErr = global::VoxgigKeycloakSdkSdk.Response.UnreadableBody(ctx, status, headers,
                    global::Voxgig.Struct.StructUtils.GetProp(fm, "body"),
                    fetchdef.TryGetValue("headers", out var sent) ? sent : null, failed);
            }

            var direct = new Dictionary<string, object?>
            {
                ["ok"] = bodyErr == null && status >= 200 && status < 300,
                ["status"] = status,
                ["headers"] = headers,
                ["data"] = jsonData,
            };
            if (bodyErr != null)
            {
                direct["err"] = CleanErr(ctx, bodyErr);
            }
            return direct;
        }

        return new Dictionary<string, object?>
        {
            ["ok"] = false,
            ["err"] = ctx.MakeError("direct_invalid", "invalid response type"),
        };
    }

    // A raw request returns its error rather than passing it through MakeError.
    private Exception CleanErr(Context ctx, Exception err)
    {
        return _utility.Clean(ctx, err) as Exception ?? err;
    }

    // Raw GraphQL access: the pressure valve that makes the generated
    // surface's deliberate omissions (per-call selection sets, typed filter
    // builders, batching, subscriptions) livable — the whole schema stays
    // reachable.
    //
    // Thin wrapper over the same prepare/fetch path Direct uses, with the
    // one thing raw Direct cannot do for GraphQL: a GraphQL failure rides
    // HTTP 200 as a top-level `errors` array, so status alone would report a
    // failed query as ok.
    //
    // NOTE: like Direct, this bypasses the feature pipeline — no retry,
    // ratelimit or paging features apply.
    public Dictionary<string, object?> Graphql(string query,
        Dictionary<string, object?>? variables = null,
        Dictionary<string, object?>? ctrl = null)
    {
        if (!OpAllowed("graphql"))
        {
            return OpDenied("graphql");
        }

        var res = RawRequest(new Dictionary<string, object?>
        {
            ["method"] = "POST",
            ["headers"] = new Dictionary<string, object?>
            {
                ["content-type"] = "application/json",
            },
            ["body"] = new Dictionary<string, object?>
            {
                ["query"] = query,
                ["variables"] = variables ?? new Dictionary<string, object?>(),
            },
            ["ctrl"] = ctrl ?? new Dictionary<string, object?>(),
        });

        // Errors are read BEFORE any status check: a GraphQL parse or
        // validation failure comes back as HTTP 400 carrying the standard
        // { errors: [...] } body, and the raw path represents a non-2xx as
        // ok:false with no err — so returning early on status would discard
        // the server's own diagnostics, which are the only useful part of
        // that response.
        var errors = global::Voxgig.Struct.StructUtils.GetPath(res, global::Voxgig.Struct.StructUtils.Jt("data", "errors"))
            as List<object?>;

        if (null != errors && 0 < errors.Count)
        {
            var msg = global::Voxgig.Struct.StructUtils.GetProp(errors[0], "message") as string;
            if (string.IsNullOrEmpty(msg))
            {
                msg = "graphql error";
            }
            res["ok"] = false;
            res["err"] = new Exception("VoxgigKeycloakSdkSDK: graphql: " + msg);
            res["graphql"] = errors;
        }

        return res;
    }


    // AccessToken returns a AccessToken entity bound to this client.
    // Idiomatic usage: client.AccessToken().List(null) or
    // client.AccessToken().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AccessToken(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AccessTokenEntity(this, entopts);
    }

    // AdminEvent returns a AdminEvent entity bound to this client.
    // Idiomatic usage: client.AdminEvent().List(null) or
    // client.AdminEvent().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AdminEvent(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AdminEventEntity(this, entopts);
    }

    // AttackDetection returns a AttackDetection entity bound to this client.
    // Idiomatic usage: client.AttackDetection().List(null) or
    // client.AttackDetection().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AttackDetection(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AttackDetectionEntity(this, entopts);
    }

    // AuthenticationFlowRepresentation returns a AuthenticationFlowRepresentation entity bound to this client.
    // Idiomatic usage: client.AuthenticationFlowRepresentation().List(null) or
    // client.AuthenticationFlowRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AuthenticationFlowRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AuthenticationFlowRepresentationEntity(this, entopts);
    }

    // AuthenticationManagement returns a AuthenticationManagement entity bound to this client.
    // Idiomatic usage: client.AuthenticationManagement().List(null) or
    // client.AuthenticationManagement().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AuthenticationManagement(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AuthenticationManagementEntity(this, entopts);
    }

    // AuthenticatorConfigInfoRepresentation returns a AuthenticatorConfigInfoRepresentation entity bound to this client.
    // Idiomatic usage: client.AuthenticatorConfigInfoRepresentation().List(null) or
    // client.AuthenticatorConfigInfoRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AuthenticatorConfigInfoRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AuthenticatorConfigInfoRepresentationEntity(this, entopts);
    }

    // AuthenticatorConfigRepresentation returns a AuthenticatorConfigRepresentation entity bound to this client.
    // Idiomatic usage: client.AuthenticatorConfigRepresentation().List(null) or
    // client.AuthenticatorConfigRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase AuthenticatorConfigRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AuthenticatorConfigRepresentationEntity(this, entopts);
    }

    // Available returns a Available entity bound to this client.
    // Idiomatic usage: client.Available().List(null) or
    // client.Available().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Available(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.AvailableEntity(this, entopts);
    }

    // Certificate returns a Certificate entity bound to this client.
    // Idiomatic usage: client.Certificate().List(null) or
    // client.Certificate().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Certificate(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.CertificateEntity(this, entopts);
    }

    // CertificateRepresentation returns a CertificateRepresentation entity bound to this client.
    // Idiomatic usage: client.CertificateRepresentation().List(null) or
    // client.CertificateRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase CertificateRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.CertificateRepresentationEntity(this, entopts);
    }

    // Client returns a Client entity bound to this client.
    // Idiomatic usage: client.Client().List(null) or
    // client.Client().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Client(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientEntity(this, entopts);
    }

    // ClientInitialAccess returns a ClientInitialAccess entity bound to this client.
    // Idiomatic usage: client.ClientInitialAccess().List(null) or
    // client.ClientInitialAccess().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientInitialAccess(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientInitialAccessEntity(this, entopts);
    }

    // ClientInitialAccessPresentation returns a ClientInitialAccessPresentation entity bound to this client.
    // Idiomatic usage: client.ClientInitialAccessPresentation().List(null) or
    // client.ClientInitialAccessPresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientInitialAccessPresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientInitialAccessPresentationEntity(this, entopts);
    }

    // ClientPolicyRepresentation returns a ClientPolicyRepresentation entity bound to this client.
    // Idiomatic usage: client.ClientPolicyRepresentation().List(null) or
    // client.ClientPolicyRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientPolicyRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientPolicyRepresentationEntity(this, entopts);
    }

    // ClientProfilesRepresentation returns a ClientProfilesRepresentation entity bound to this client.
    // Idiomatic usage: client.ClientProfilesRepresentation().List(null) or
    // client.ClientProfilesRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientProfilesRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientProfilesRepresentationEntity(this, entopts);
    }

    // ClientRepresentation returns a ClientRepresentation entity bound to this client.
    // Idiomatic usage: client.ClientRepresentation().List(null) or
    // client.ClientRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientRepresentationEntity(this, entopts);
    }

    // ClientScope returns a ClientScope entity bound to this client.
    // Idiomatic usage: client.ClientScope().List(null) or
    // client.ClientScope().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientScope(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientScopeEntity(this, entopts);
    }

    // ClientScopeRepresentation returns a ClientScopeRepresentation entity bound to this client.
    // Idiomatic usage: client.ClientScopeRepresentation().List(null) or
    // client.ClientScopeRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ClientScopeRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ClientScopeRepresentationEntity(this, entopts);
    }

    // Component returns a Component entity bound to this client.
    // Idiomatic usage: client.Component().List(null) or
    // client.Component().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Component(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ComponentEntity(this, entopts);
    }

    // ComponentTypeRepresentation returns a ComponentTypeRepresentation entity bound to this client.
    // Idiomatic usage: client.ComponentTypeRepresentation().List(null) or
    // client.ComponentTypeRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ComponentTypeRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ComponentTypeRepresentationEntity(this, entopts);
    }

    // Composite returns a Composite entity bound to this client.
    // Idiomatic usage: client.Composite().List(null) or
    // client.Composite().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Composite(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.CompositeEntity(this, entopts);
    }

    // Credential returns a Credential entity bound to this client.
    // Idiomatic usage: client.Credential().List(null) or
    // client.Credential().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Credential(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.CredentialEntity(this, entopts);
    }

    // CredentialRepresentation returns a CredentialRepresentation entity bound to this client.
    // Idiomatic usage: client.CredentialRepresentation().List(null) or
    // client.CredentialRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase CredentialRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.CredentialRepresentationEntity(this, entopts);
    }

    // DeleteByRealm returns a DeleteByRealm entity bound to this client.
    // Idiomatic usage: client.DeleteByRealm().List(null) or
    // client.DeleteByRealm().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase DeleteByRealm(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.DeleteByRealmEntity(this, entopts);
    }

    // Event returns a Event entity bound to this client.
    // Idiomatic usage: client.Event().List(null) or
    // client.Event().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Event(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.EventEntity(this, entopts);
    }

    // FederatedIdentity returns a FederatedIdentity entity bound to this client.
    // Idiomatic usage: client.FederatedIdentity().List(null) or
    // client.FederatedIdentity().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase FederatedIdentity(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.FederatedIdentityEntity(this, entopts);
    }

    // Flow returns a Flow entity bound to this client.
    // Idiomatic usage: client.Flow().List(null) or
    // client.Flow().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Flow(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.FlowEntity(this, entopts);
    }

    // Get returns a Get entity bound to this client.
    // Idiomatic usage: client.Get().List(null) or
    // client.Get().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Get(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.GetEntity(this, entopts);
    }

    // GetByRealm returns a GetByRealm entity bound to this client.
    // Idiomatic usage: client.GetByRealm().List(null) or
    // client.GetByRealm().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase GetByRealm(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.GetByRealmEntity(this, entopts);
    }

    // GlobalRequestResult returns a GlobalRequestResult entity bound to this client.
    // Idiomatic usage: client.GlobalRequestResult().List(null) or
    // client.GlobalRequestResult().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase GlobalRequestResult(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.GlobalRequestResultEntity(this, entopts);
    }

    // Granted returns a Granted entity bound to this client.
    // Idiomatic usage: client.Granted().List(null) or
    // client.Granted().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Granted(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.GrantedEntity(this, entopts);
    }

    // Group returns a Group entity bound to this client.
    // Idiomatic usage: client.Group().List(null) or
    // client.Group().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Group(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.GroupEntity(this, entopts);
    }

    // GroupRepresentation returns a GroupRepresentation entity bound to this client.
    // Idiomatic usage: client.GroupRepresentation().List(null) or
    // client.GroupRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase GroupRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.GroupRepresentationEntity(this, entopts);
    }

    // IdToken returns a IdToken entity bound to this client.
    // Idiomatic usage: client.IdToken().List(null) or
    // client.IdToken().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase IdToken(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.IdTokenEntity(this, entopts);
    }

    // IdentityProvider returns a IdentityProvider entity bound to this client.
    // Idiomatic usage: client.IdentityProvider().List(null) or
    // client.IdentityProvider().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase IdentityProvider(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.IdentityProviderEntity(this, entopts);
    }

    // IdentityProviderMapperRepresentation returns a IdentityProviderMapperRepresentation entity bound to this client.
    // Idiomatic usage: client.IdentityProviderMapperRepresentation().List(null) or
    // client.IdentityProviderMapperRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase IdentityProviderMapperRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.IdentityProviderMapperRepresentationEntity(this, entopts);
    }

    // IdentityProviderRepresentation returns a IdentityProviderRepresentation entity bound to this client.
    // Idiomatic usage: client.IdentityProviderRepresentation().List(null) or
    // client.IdentityProviderRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase IdentityProviderRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.IdentityProviderRepresentationEntity(this, entopts);
    }

    // Key returns a Key entity bound to this client.
    // Idiomatic usage: client.Key().List(null) or
    // client.Key().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Key(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.KeyEntity(this, entopts);
    }

    // ManagementPermissionReference returns a ManagementPermissionReference entity bound to this client.
    // Idiomatic usage: client.ManagementPermissionReference().List(null) or
    // client.ManagementPermissionReference().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ManagementPermissionReference(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ManagementPermissionReferenceEntity(this, entopts);
    }

    // MappingsRepresentation returns a MappingsRepresentation entity bound to this client.
    // Idiomatic usage: client.MappingsRepresentation().List(null) or
    // client.MappingsRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase MappingsRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.MappingsRepresentationEntity(this, entopts);
    }

    // NotGranted returns a NotGranted entity bound to this client.
    // Idiomatic usage: client.NotGranted().List(null) or
    // client.NotGranted().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase NotGranted(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.NotGrantedEntity(this, entopts);
    }

    // Post returns a Post entity bound to this client.
    // Idiomatic usage: client.Post().List(null) or
    // client.Post().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Post(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.PostEntity(this, entopts);
    }

    // Protocol returns a Protocol entity bound to this client.
    // Idiomatic usage: client.Protocol().List(null) or
    // client.Protocol().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Protocol(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ProtocolEntity(this, entopts);
    }

    // ProtocolMapper returns a ProtocolMapper entity bound to this client.
    // Idiomatic usage: client.ProtocolMapper().List(null) or
    // client.ProtocolMapper().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ProtocolMapper(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ProtocolMapperEntity(this, entopts);
    }

    // ProtocolMapperRepresentation returns a ProtocolMapperRepresentation entity bound to this client.
    // Idiomatic usage: client.ProtocolMapperRepresentation().List(null) or
    // client.ProtocolMapperRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ProtocolMapperRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ProtocolMapperRepresentationEntity(this, entopts);
    }

    // PutByRealm returns a PutByRealm entity bound to this client.
    // Idiomatic usage: client.PutByRealm().List(null) or
    // client.PutByRealm().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase PutByRealm(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.PutByRealmEntity(this, entopts);
    }

    // Realm returns a Realm entity bound to this client.
    // Idiomatic usage: client.Realm().List(null) or
    // client.Realm().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Realm(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RealmEntity(this, entopts);
    }

    // RealmEventsConfigRepresentation returns a RealmEventsConfigRepresentation entity bound to this client.
    // Idiomatic usage: client.RealmEventsConfigRepresentation().List(null) or
    // client.RealmEventsConfigRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase RealmEventsConfigRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RealmEventsConfigRepresentationEntity(this, entopts);
    }

    // RealmsAdmin returns a RealmsAdmin entity bound to this client.
    // Idiomatic usage: client.RealmsAdmin().List(null) or
    // client.RealmsAdmin().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase RealmsAdmin(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RealmsAdminEntity(this, entopts);
    }

    // RequiredAction returns a RequiredAction entity bound to this client.
    // Idiomatic usage: client.RequiredAction().List(null) or
    // client.RequiredAction().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase RequiredAction(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RequiredActionEntity(this, entopts);
    }

    // Role returns a Role entity bound to this client.
    // Idiomatic usage: client.Role().List(null) or
    // client.Role().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase Role(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RoleEntity(this, entopts);
    }

    // RoleMapper returns a RoleMapper entity bound to this client.
    // Idiomatic usage: client.RoleMapper().List(null) or
    // client.RoleMapper().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase RoleMapper(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RoleMapperEntity(this, entopts);
    }

    // RolesById returns a RolesById entity bound to this client.
    // Idiomatic usage: client.RolesById().List(null) or
    // client.RolesById().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase RolesById(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.RolesByIdEntity(this, entopts);
    }

    // ScopeMapping returns a ScopeMapping entity bound to this client.
    // Idiomatic usage: client.ScopeMapping().List(null) or
    // client.ScopeMapping().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase ScopeMapping(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.ScopeMappingEntity(this, entopts);
    }

    // UpConfig returns a UpConfig entity bound to this client.
    // Idiomatic usage: client.UpConfig().List(null) or
    // client.UpConfig().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase UpConfig(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.UpConfigEntity(this, entopts);
    }

    // User returns a User entity bound to this client.
    // Idiomatic usage: client.User().List(null) or
    // client.User().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase User(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.UserEntity(this, entopts);
    }

    // UserRepresentation returns a UserRepresentation entity bound to this client.
    // Idiomatic usage: client.UserRepresentation().List(null) or
    // client.UserRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase UserRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.UserRepresentationEntity(this, entopts);
    }

    // UserSession returns a UserSession entity bound to this client.
    // Idiomatic usage: client.UserSession().List(null) or
    // client.UserSession().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase UserSession(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.UserSessionEntity(this, entopts);
    }

    // UserSessionRepresentation returns a UserSessionRepresentation entity bound to this client.
    // Idiomatic usage: client.UserSessionRepresentation().List(null) or
    // client.UserSessionRepresentation().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase UserSessionRepresentation(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.UserSessionRepresentationEntity(this, entopts);
    }

    // UsersManagementPermission returns a UsersManagementPermission entity bound to this client.
    // Idiomatic usage: client.UsersManagementPermission().List(null) or
    // client.UsersManagementPermission().Load(new() { ["id"] = ... }).
    public VoxgigKeycloakSdkEntityBase UsersManagementPermission(Dictionary<string, object?>? entopts = null)
    {
        return new global::VoxgigKeycloakSdkSdk.Entity.UsersManagementPermissionEntity(this, entopts);
    }


    public static VoxgigKeycloakSdkSDK TestSDK(Dictionary<string, object?>? testopts,
        Dictionary<string, object?>? sdkopts)
    {
        sdkopts = global::Voxgig.Struct.StructUtils.Clone(sdkopts ?? new Dictionary<string, object?>())
            as Dictionary<string, object?> ?? new Dictionary<string, object?>();

        testopts = global::Voxgig.Struct.StructUtils.Clone(testopts ?? new Dictionary<string, object?>())
            as Dictionary<string, object?> ?? new Dictionary<string, object?>();
        testopts["active"] = true;

        global::Voxgig.Struct.StructUtils.SetPath(sdkopts, global::Voxgig.Struct.StructUtils.Jt("feature", "test"), testopts);

        var sdk = new VoxgigKeycloakSdkSDK(sdkopts)
        {
            Mode = "test",
        };

        return sdk;
    }
}
