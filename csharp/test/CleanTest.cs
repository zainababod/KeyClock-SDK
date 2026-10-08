// The canary sweep: every credential slot holds a distinctive value, every
// diagnostic feature this SDK ships is switched on with a capturing sink, a
// real operation runs through every outcome, and every string that leaves
// the SDK is searched for the canaries and their encoded forms. It also
// proves its own sensitivity: with clean switched off the canary MUST show.

using System.Collections;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Voxgig.Struct;
using Xunit;
using Xunit.Abstractions;

using VoxgigKeycloakSdkSdk;
using VoxgigKeycloakSdkSdk.Feature;

namespace VoxgigKeycloakSdkSdk.Test;

public class CleanTest
{
    // Generated: the credential's wire placement is fixed when the SDK is built.
    private const bool AuthSuppressed = false;
    private const string AuthWhere = "header";
    private const string AuthName = "authorization";

    private const string CanaryApikey = "CANARY-APIKEY-k9x2m7q4p1";
    private const string CanarySecret = "CANARY-SECRET-w3e8r5t2y6";
    private const string CanaryHeader = "CANARY-HEADER-z1x4c7v0b3";
    private const string CanaryValue = "CANARY-VALUE-n5m8b2v9c4";

    private const string Mask = "[redacted]";

    private readonly ITestOutputHelper _out;

    public CleanTest(ITestOutputHelper output)
    {
        _out = output;
    }

    // Every form a canary can travel in.
    private static readonly List<string> Forms = BuildForms();

    private static List<string> BuildForms()
    {
        var forms = new List<string>();
        foreach (var v in new[] { CanaryApikey, CanarySecret, CanaryHeader, CanaryValue })
        {
            forms.Add(v);
            forms.Add(Convert.ToBase64String(Encoding.UTF8.GetBytes(v)));
            forms.Add(Uri.EscapeDataString(v));
        }
        forms.Add(Convert.ToBase64String(Encoding.UTF8.GetBytes(CanaryApikey + ":" + CanarySecret)));
        return forms;
    }

    private sealed record Sink(string Name, string Text);

    private sealed record Candidate(string Name, Func<VoxgigKeycloakSdkSDK, VoxgigKeycloakSdkEntityBase> Accessor, string[] Ops);

    private sealed record Target(Candidate Candidate, string Op, Dictionary<string, object?> Match);

    // Header maps keep the caller's spelling; the assertion should not care.
    private static object? Header(object? map, string name)
    {
        if (map is IDictionary dict)
        {
            foreach (DictionaryEntry kv in dict)
            {
                if (string.Equals(Convert.ToString(kv.Key), name, StringComparison.OrdinalIgnoreCase))
                {
                    return kv.Value;
                }
            }
        }
        return null;
    }

    private static List<string> Leaks(string text)
    {
        return Forms.Where(f => text.Contains(f)).ToList();
    }

    private static readonly JsonSerializerOptions FieldsJson = new()
    {
        IncludeFields = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        MaxDepth = 16,
    };

    // The typed pipeline products read through their fields, so the raw spec
    // is visible when clean is off - the sensitivity check depends on it.
    private static string Render(object? val)
    {
        switch (val)
        {
            case null:
                return "null";
            case string s:
                return s;
            case Spec sp:
                return Render(new Dictionary<string, object?>
                {
                    ["method"] = sp.Method, ["url"] = sp.Url, ["path"] = sp.Path,
                    ["headers"] = sp.Headers, ["query"] = sp.Query,
                    ["params"] = sp.Params, ["body"] = sp.Body,
                });
            case Result r:
                return Render(new Dictionary<string, object?>
                {
                    ["ok"] = r.Ok, ["status"] = r.Status, ["headers"] = r.Headers,
                    ["body"] = r.Body, ["resdata"] = r.Resdata,
                    ["err"] = null == r.Err ? null : r.Err.ToString(),
                });
            case IEntity ent:
                return Render(ent.Data());
            case Context ctx:
                return Render(ctx.ToRecord());
            case IDictionary dict:
            {
                var sb = new StringBuilder("{");
                foreach (DictionaryEntry kv in dict)
                {
                    sb.Append(JsonSerializer.Serialize(Convert.ToString(kv.Key)))
                      .Append(':').Append(Render(kv.Value)).Append(',');
                }
                return sb.Append('}').ToString();
            }
            case IList list:
                return "[" + string.Join(",", list.Cast<object?>().Select(Render)) + "]";
            case Exception e:
                return e.ToString();
            default:
                try
                {
                    return JsonSerializer.Serialize(val, FieldsJson);
                }
                catch (Exception)
                {
                    return StructUtils.Jsonify(val, 0);
                }
        }
    }

    // Every default print a value has, plus the SDK's own record of it.
    private static List<Sink> FormsOf(string name, object? val)
    {
        var out_ = new List<Sink>();
        void Push(string kind, Func<string> fn)
        {
            try { out_.Add(new Sink(name + ":" + kind, fn())); } catch (Exception) { }
        }
        Push("json", () => StructUtils.Jsonify(val, 0));
        Push("string", () => Convert.ToString(val) ?? "");
        Push("render", () => Render(val));
        if (val is VoxgigKeycloakSdkError se)
        {
            Push("message", () => se.Message);
            Push("record", () => StructUtils.Jsonify(se.ToRecord(), 0));
        }
        if (val is Exception e)
        {
            Push("message", () => e.Message);
            Push("tostring", () => e.ToString());
            Push("stack", () => e.StackTrace ?? "");
        }
        if (val is Context ctx)
        {
            Push("record", () => StructUtils.Jsonify(ctx.ToRecord(), 0));
        }
        if (val is VoxgigKeycloakSdkSDK)
        {
            // What a structured logger walking own fields would see.
            Push("fields", () => JsonSerializer.Serialize(val, FieldsJson));
        }
        return out_;
    }

    // Captures the serialised context from inside the pipeline: what a hook
    // author would hand to a logger.
    private sealed class CaptureFeature : BaseFeature
    {
        private readonly List<Sink> _sinks;

        public CaptureFeature(List<Sink> sinks)
        {
            Name = "capture";
            Version = "0.0.1";
            Active = true;
            _sinks = sinks;
        }

        public override void PreRequest(Context ctx) => _sinks.AddRange(FormsOf("ctx@PreRequest", ctx));
        public override void PreResponse(Context ctx) => _sinks.AddRange(FormsOf("ctx@PreResponse", ctx));
        public override void PreUnexpected(Context ctx) => _sinks.AddRange(FormsOf("ctx@PreUnexpected", ctx));
    }

    // A feature that throws from inside the pipeline, quoting the request it
    // saw: an exception MakeError never handled.
    private sealed class ThrowFeature : BaseFeature
    {
        private readonly bool _unexpected;

        public ThrowFeature(bool unexpected)
        {
            Name = "throwhook";
            Version = "0.0.1";
            Active = true;
            _unexpected = unexpected;
        }

        public override void PreResponse(Context ctx) =>
            throw new Exception("hook saw " + Render(ctx.Spec));

        // MakeError fires PreUnexpected, so what this throws escapes it.
        public override void PreUnexpected(Context ctx)
        {
            if (_unexpected)
            {
                throw new Exception("hook saw " + Render(ctx.Spec));
            }
        }
    }

    // A stream that succeeds, yielding the result's items.
    private sealed class StreamOkFeature : BaseFeature
    {
        public StreamOkFeature()
        {
            Name = "streamok";
            Version = "0.0.1";
            Active = true;
        }

        public override void PreDone(Context ctx)
        {
            if (null == ctx.Result)
            {
                return;
            }
            var items = ctx.Result.Resdata switch
            {
                IList list => list.Cast<object?>().ToList(),
                null => new List<object?>(),
                var one => new List<object?> { one },
            };
            ctx.Result.Stream = () => items;
        }
    }

    // A stream that fails while the caller iterates it, quoting a credential.
    private sealed class StreamThrowFeature : BaseFeature
    {
        public StreamThrowFeature()
        {
            Name = "streamthrow";
            Version = "0.0.1";
            Active = true;
        }

        public override void PreDone(Context ctx)
        {
            if (null != ctx.Result)
            {
                ctx.Result.Stream = Failing;
            }
        }

        private static IEnumerable<object?> Failing()
        {
            yield return Fail();
        }

        private static object? Fail() => throw new Exception("stream saw " + CanaryApikey);
    }

    private sealed record Scenario(string Name, Func<string, Dictionary<string, object?>, object?> Respond);

    private static Dictionary<string, object?> Response(int status, object? data,
        Dictionary<string, object?>? headers = null)
    {
        var h = new Dictionary<string, object?> { ["content-type"] = "application/json" };
        foreach (var kv in headers ?? new Dictionary<string, object?>())
        {
            h[kv.Key.ToLowerInvariant()] = kv.Value;
        }
        return new Dictionary<string, object?>
        {
            ["status"] = status,
            ["statusText"] = status < 400 ? "OK" : "ERR",
            ["json"] = (Func<object?>)(() => data),
            ["body"] = StructUtils.Jsonify(data, 0),
            ["headers"] = h,
        };
    }

    private static readonly List<Scenario> Scenarios = new()
    {
        new Scenario("ok", (_url, _def) => Response(200,
            new Dictionary<string, object?> { ["id"] = "i1", ["name"] = "n1" },
            new Dictionary<string, object?> { ["x-session-token"] = "RESP-TOKEN-a1b2c3d4e5" })),
        new Scenario("notfound", (_url, _def) => Response(404,
            new Dictionary<string, object?> { ["error"] = "no such record" })),
        new Scenario("server", (_url, _def) => Response(500,
            new Dictionary<string, object?> { ["error"] = "boom" })),
        new Scenario("transport", (url, _def) =>
            throw new Exception("socket hang up (URL was: \"" + url + "\")")),
        new Scenario("notjson", (_url, _def) => new Dictionary<string, object?>
        {
            ["status"] = 200,
            ["statusText"] = "OK",
            ["json"] = (Func<object?>)(() => throw new Exception("Unexpected token < in JSON")),
            ["body"] = "<html>",
            ["headers"] = new Dictionary<string, object?>(),
        }),
    };

    // Offline, as every generated suite is: the test OPTION resolves a
    // required server variable to test-<name>, and installs no transport.
    private static Dictionary<string, object?> Offline(Dictionary<string, object?> opts)
    {
        var copy = new Dictionary<string, object?>(opts);
        copy["test"] = new Dictionary<string, object?> { ["active"] = true };
        return copy;
    }

    // A client the sweep cannot build leaves nothing swept: a harness error,
    // not a leak.
    private static VoxgigKeycloakSdkSDK Construct(Dictionary<string, object?> opts)
    {
        try
        {
            return new VoxgigKeycloakSdkSDK(Offline(opts));
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(
                "clean harness: the client could not be constructed, so nothing was swept: " +
                e.Message, e);
        }
    }

    private static VoxgigKeycloakSdkSDK MakeSdk(Scenario scenario, List<Sink> sinks,
        Dictionary<string, object?>? cleanopts = null, BaseFeature? extra = null,
        Dictionary<string, object?>? auth = null)
    {
        Action<Dictionary<string, object?>> Capture(string name) =>
            rec => sinks.AddRange(FormsOf(name, rec));

        var feature = new Dictionary<string, object?>();
        if (Fh.HasFeature("log"))
        {
            feature["log"] = new Dictionary<string, object?>
            {
                ["active"] = true,
                ["logger"] = (Action<string, string, Dictionary<string, object?>>)(
                    (level, _msg, attrs) => sinks.AddRange(FormsOf("log." + level, attrs))),
            };
        }
        if (Fh.HasFeature("debug"))
        {
            feature["debug"] = new Dictionary<string, object?>
            {
                ["active"] = true, ["onEntry"] = Capture("debug"),
            };
        }
        if (Fh.HasFeature("audit"))
        {
            feature["audit"] = new Dictionary<string, object?>
            {
                ["active"] = true, ["sink"] = Capture("audit"),
            };
        }
        if (Fh.HasFeature("telemetry"))
        {
            feature["telemetry"] = new Dictionary<string, object?>
            {
                ["active"] = true, ["exporter"] = Capture("telemetry"),
            };
        }
        if (Fh.HasFeature("metrics"))
        {
            feature["metrics"] = new Dictionary<string, object?> { ["active"] = true };
        }
        if (Fh.HasFeature("clienttrack"))
        {
            feature["clienttrack"] = new Dictionary<string, object?> { ["active"] = true };
        }

        var clean = new Dictionary<string, object?> { ["values"] = CanaryValue };
        foreach (var kv in cleanopts ?? new Dictionary<string, object?>())
        {
            clean[kv.Key] = kv.Value;
        }

        var fetcher = (Context _ctx, string url, Dictionary<string, object?> fetchdef) =>
            scenario.Respond(url, fetchdef);

        var extend = new List<object?> { new CaptureFeature(sinks) };
        if (null != extra)
        {
            extend.Add(extra);
        }

        var opts = new Dictionary<string, object?>
        {
            ["apikey"] = CanaryApikey,
            ["secret"] = CanarySecret,
            ["headers"] = new Dictionary<string, object?> { ["X-Custom-Token"] = CanaryHeader },
            ["clean"] = clean,
            ["feature"] = feature,
            ["extend"] = extend,
            ["utility"] = new Dictionary<string, object?> { ["fetcher"] = fetcher },
        };
        if (null != auth)
        {
            opts["auth"] = auth;
        }
        return Construct(opts);
    }

    // Emitted from the model: every active entity with the operations it
    // declares, list and load first.
    private static readonly List<Candidate> Candidates = new()
    {
        new Candidate("access_token", sdk => sdk.AccessToken(null), new[] { "list" }),
        new Candidate("admin_event", sdk => sdk.AdminEvent(null), new[] { "list" }),
        new Candidate("attack_detection", sdk => sdk.AttackDetection(null), new[] { "load", "remove" }),
        new Candidate("authentication_flow_representation", sdk => sdk.AuthenticationFlowRepresentation(null), new[] { "list", "load" }),
        new Candidate("authentication_management", sdk => sdk.AuthenticationManagement(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("authenticator_config_info_representation", sdk => sdk.AuthenticatorConfigInfoRepresentation(null), new[] { "load" }),
        new Candidate("authenticator_config_representation", sdk => sdk.AuthenticatorConfigRepresentation(null), new[] { "load" }),
        new Candidate("available", sdk => sdk.Available(null), new[] { "list" }),
        new Candidate("certificate", sdk => sdk.Certificate(null), new[] { "load", "create" }),
        new Candidate("certificate_representation", sdk => sdk.CertificateRepresentation(null), new[] { "create" }),
        new Candidate("client", sdk => sdk.Client(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("client_initial_access", sdk => sdk.ClientInitialAccess(null), new[] { "remove" }),
        new Candidate("client_initial_access_presentation", sdk => sdk.ClientInitialAccessPresentation(null), new[] { "list", "create" }),
        new Candidate("client_policy_representation", sdk => sdk.ClientPolicyRepresentation(null), new[] { "list" }),
        new Candidate("client_profiles_representation", sdk => sdk.ClientProfilesRepresentation(null), new[] { "list" }),
        new Candidate("client_representation", sdk => sdk.ClientRepresentation(null), new[] { "create" }),
        new Candidate("client_scope", sdk => sdk.ClientScope(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("client_scope_representation", sdk => sdk.ClientScopeRepresentation(null), new[] { "list", "load" }),
        new Candidate("component", sdk => sdk.Component(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("component_type_representation", sdk => sdk.ComponentTypeRepresentation(null), new[] { "list" }),
        new Candidate("composite", sdk => sdk.Composite(null), new[] { "list" }),
        new Candidate("credential", sdk => sdk.Credential(null), new[] { "list" }),
        new Candidate("credential_representation", sdk => sdk.CredentialRepresentation(null), new[] { "load", "create" }),
        new Candidate("delete_by_realm", sdk => sdk.DeleteByRealm(null), new[] { "remove" }),
        new Candidate("event", sdk => sdk.Event(null), new[] { "list" }),
        new Candidate("federated_identity", sdk => sdk.FederatedIdentity(null), new[] { "list" }),
        new Candidate("flow", sdk => sdk.Flow(null), new[] { "create" }),
        new Candidate("get", sdk => sdk.Get(null), new[] { "list" }),
        new Candidate("get_by_realm", sdk => sdk.GetByRealm(null), new[] { "list" }),
        new Candidate("global_request_result", sdk => sdk.GlobalRequestResult(null), new[] { "list", "create" }),
        new Candidate("granted", sdk => sdk.Granted(null), new[] { "list" }),
        new Candidate("group", sdk => sdk.Group(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("group_representation", sdk => sdk.GroupRepresentation(null), new[] { "list", "load" }),
        new Candidate("id_token", sdk => sdk.IdToken(null), new[] { "load" }),
        new Candidate("identity_provider", sdk => sdk.IdentityProvider(null), new[] { "load", "create", "remove", "update" }),
        new Candidate("identity_provider_mapper_representation", sdk => sdk.IdentityProviderMapperRepresentation(null), new[] { "list", "load" }),
        new Candidate("identity_provider_representation", sdk => sdk.IdentityProviderRepresentation(null), new[] { "list", "load" }),
        new Candidate("key", sdk => sdk.Key(null), new[] { "list" }),
        new Candidate("management_permission_reference", sdk => sdk.ManagementPermissionReference(null), new[] { "load", "update" }),
        new Candidate("mappings_representation", sdk => sdk.MappingsRepresentation(null), new[] { "list" }),
        new Candidate("not_granted", sdk => sdk.NotGranted(null), new[] { "list" }),
        new Candidate("post", sdk => sdk.Post(null), new[] { "create" }),
        new Candidate("protocol", sdk => sdk.Protocol(null), new[] { "load" }),
        new Candidate("protocol_mapper", sdk => sdk.ProtocolMapper(null), new[] { "list", "create", "remove", "update" }),
        new Candidate("protocol_mapper_representation", sdk => sdk.ProtocolMapperRepresentation(null), new[] { "list", "load" }),
        new Candidate("put_by_realm", sdk => sdk.PutByRealm(null), new[] { "update" }),
        new Candidate("realm", sdk => sdk.Realm(null), new[] { "list" }),
        new Candidate("realm_events_config_representation", sdk => sdk.RealmEventsConfigRepresentation(null), new[] { "list" }),
        new Candidate("realms_admin", sdk => sdk.RealmsAdmin(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("required_action", sdk => sdk.RequiredAction(null), new[] { "list", "load", "create" }),
        new Candidate("role", sdk => sdk.Role(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("role_mapper", sdk => sdk.RoleMapper(null), new[] { "create", "remove" }),
        new Candidate("roles_by_id", sdk => sdk.RolesById(null), new[] { "load", "create", "remove", "update" }),
        new Candidate("scope_mapping", sdk => sdk.ScopeMapping(null), new[] { "create", "remove" }),
        new Candidate("up_config", sdk => sdk.UpConfig(null), new[] { "list", "update" }),
        new Candidate("user", sdk => sdk.User(null), new[] { "list", "load", "create", "remove", "update" }),
        new Candidate("user_representation", sdk => sdk.UserRepresentation(null), new[] { "list" }),
        new Candidate("user_session", sdk => sdk.UserSession(null), new[] { "list" }),
        new Candidate("user_session_representation", sdk => sdk.UserSessionRepresentation(null), new[] { "list", "load" }),
        new Candidate("users_management_permission", sdk => sdk.UsersManagementPermission(null), new[] { "load", "update" }),
    };

    private static object? Invoke(VoxgigKeycloakSdkEntityBase ent, string op,
        Dictionary<string, object?> match, Dictionary<string, object?>? ctrl)
    {
        var args = new Dictionary<string, object?>(match);
        return op switch
        {
            "list" => ent.List(args, ctrl),
            "load" => ent.Load(args, ctrl),
            "create" => ent.Create(args, ctrl),
            "update" => ent.Update(args, ctrl),
            "patch" => ent.Patch(args, ctrl),
            "remove" => ent.Remove(args, ctrl),
            _ => throw new InvalidOperationException("unknown operation: " + op),
        };
    }

    // Every path parameter an op's points declare, filled in.
    private static Dictionary<string, object?> Filled(VoxgigKeycloakSdkSDK sdk, string entity, string op)
    {
        var filled = new Dictionary<string, object?>();
        var points = StructUtils.GetPath(sdk.GetRootCtx().Config,
            StructUtils.Jt("entity", entity, "op", op, "points")) as List<object?>;
        foreach (var point in points ?? new List<object?>())
        {
            var ps = StructUtils.GetPath(point, StructUtils.Jt("args", "params")) as List<object?>;
            foreach (var p in ps ?? new List<object?>())
            {
                if (StructUtils.GetProp(p, "name") is string pname)
                {
                    filled[pname] = "p1";
                }
            }
        }
        return filled;
    }

    // The first operation that completes against a plain 200: with no
    // arguments, else with every path parameter its points declare filled in.
    private static Target? UsableOp()
    {
        var fetcher = (Context _ctx, string _url, Dictionary<string, object?> _def) =>
            (object?)Response(200, new Dictionary<string, object?> { ["id"] = "i1" });
        var plain = Construct(new Dictionary<string, object?>
        {
            ["apikey"] = CanaryApikey,
            ["utility"] = new Dictionary<string, object?> { ["fetcher"] = fetcher },
        });
        foreach (var candidate in Candidates)
        {
            foreach (var op in candidate.Ops)
            {
                foreach (var match in new[] { new Dictionary<string, object?>(), Filled(plain, candidate.Name, op) })
                {
                    try
                    {
                        Invoke(candidate.Accessor(plain), op, match, null);
                        return new Target(candidate, op, match);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
        }
        return null;
    }

    private const string NoOp = "no operation of this SDK completes against a plain 200; nothing to sweep";

    private static Exception? Drive(VoxgigKeycloakSdkSDK sdk, Target target,
        Dictionary<string, object?> ctrl, List<Sink> sinks)
    {
        // A caller may keep the record it passed rather than read ctrl's entry.
        var held = ctrl.GetValueOrDefault("explain");
        var entity = target.Candidate.Accessor(sdk);
        object? out_ = null;
        Exception? err = null;
        try
        {
            out_ = Invoke(entity, target.Op, target.Match, ctrl);
        }
        catch (Exception e)
        {
            err = e;
        }
        if (null != err) sinks.AddRange(FormsOf("error", err));
        if (null != out_) sinks.AddRange(FormsOf("result", out_));
        // Raw, as a caller copying the match into another query reads it.
        sinks.AddRange(FormsOf("match", entity.Match()));
        if (ctrl.TryGetValue("explain", out var explain) && null != explain)
        {
            sinks.AddRange(FormsOf("explain", explain));
        }
        if (null != held && !ReferenceEquals(held, ctrl.GetValueOrDefault("explain")))
        {
            sinks.AddRange(FormsOf("explain:held", held));
        }
        return err;
    }

    private void Report(string line)
    {
        // Both: xunit shows the helper's output, the lane reads the console.
        Console.WriteLine(line);
        _out.WriteLine(line);
    }

    [Fact]
    public async Task NoCredentialLeavesTheSdkInAnyForm()
    {
        var target = UsableOp();
        if (null == target)
        {
            // xunit 2 has no runtime skip, so the skip is a printed reason.
            Report("clean: skipped: " + NoOp);
            return;
        }

        var sinks = new List<Sink>();
        var errors = new Dictionary<string, Exception>();
        var explains = new Dictionary<string, Dictionary<string, object?>>();

        var variants = new (string Name, Func<Dictionary<string, object?>> Ctrl)[]
        {
            ("throw", () => new Dictionary<string, object?>()),
            ("explain", () => new Dictionary<string, object?>
            {
                ["explain"] = new Dictionary<string, object?>(),
            }),
            ("nothrow", () => new Dictionary<string, object?>
            {
                ["throw"] = false,
                ["explain"] = new Dictionary<string, object?>(),
            }),
        };

        foreach (var scenario in Scenarios)
        {
            foreach (var variant in variants)
            {
                var sdk = MakeSdk(scenario, sinks);
                var ctrl = variant.Ctrl();
                var err = Drive(sdk, target, ctrl, sinks);
                var key = scenario.Name + "/" + variant.Name;
                if (null != err) errors[key] = err;
                if (ctrl.TryGetValue("explain", out var ex) && ex is Dictionary<string, object?> exm)
                {
                    explains[key] = exm;
                }
                sinks.AddRange(FormsOf("sdk", sdk));
            }
        }

        // A name given at run time replaces the declared one: the match leaves
        // out whichever name PrepareAuth placed.
        Drive(MakeSdk(Scenarios[0], sinks, auth: new Dictionary<string, object?> { ["name"] = "zzcred" }),
            target, new Dictionary<string, object?>(), sinks);

        // A credential mistyped as a map is rejected by validation, whose
        // message quotes the value it rejected.
        Exception? rejected = null;
        try
        {
            new VoxgigKeycloakSdkSDK(Offline(new Dictionary<string, object?>
            {
                ["apikey"] = new Dictionary<string, object?> { ["value"] = CanaryApikey },
                ["clean"] = new Dictionary<string, object?> { ["values"] = CanaryValue },
            }));
        }
        catch (Exception e)
        {
            rejected = e;
        }
        Assert.True(null != rejected, "a credential mistyped as a map should be rejected");
        sinks.AddRange(FormsOf("rejected", rejected));

        // An exception a feature hook throws, quoting the request, skips MakeError.
        foreach (var unexpected in new[] { false, true })
        {
            var hooked = MakeSdk(Scenarios[0], sinks, null, new ThrowFeature(unexpected));
            var hookerr = Drive(hooked, target, new Dictionary<string, object?>
            {
                ["explain"] = new Dictionary<string, object?>(),
            }, sinks);
            Assert.True(null != hookerr, "the throwing hook should fail the operation");
        }

        // Iterating a stream runs inside the same catch path as the operation,
        // and the explain record the caller passed is cleaned however it ends.
        foreach (var (name, extra) in new (string, BaseFeature?)[]
        {
            ("stream", new StreamThrowFeature()),
            ("stream-ok", new StreamOkFeature()),
            ("stream-plain", null),
        })
        {
            var streaming = target.Candidate.Accessor(MakeSdk(Scenarios[0], sinks, null, extra));
            var explain = new Dictionary<string, object?>();
            Exception? streamerr = null;
            try
            {
                await foreach (var _ in streaming.Stream(target.Op, new Dictionary<string, object?>
                {
                    ["reqmatch"] = new Dictionary<string, object?>(target.Match),
                }, new Dictionary<string, object?>
                {
                    ["ctrl"] = new Dictionary<string, object?> { ["explain"] = explain },
                }))
                {
                }
            }
            catch (Exception e)
            {
                streamerr = e;
            }
            Assert.True(("stream" == name) == (null != streamerr), name + ": only the failing stream throws");
            if (null != streamerr)
            {
                sinks.AddRange(FormsOf(name, streamerr));
            }
            Assert.True(0 < explain.Count, name + ": the explain record was not filled");
            sinks.AddRange(FormsOf(name + ":explain", explain));
        }

        // The raw path returns its failure rather than throwing it.
        var raw = MakeSdk(Scenarios[3], sinks).Direct(new Dictionary<string, object?> { ["path"] = "raw" });
        Assert.True(Equals(false, raw.GetValueOrDefault("ok")) && null != raw.GetValueOrDefault("err"),
            "a transport failure should fail Direct()");
        sinks.AddRange(FormsOf("direct", raw["err"]));

        // A registered value used as a map key is masked; keys that mask alike
        // are kept apart.
        var probe = MakeSdk(Scenarios[0], sinks);
        var named = probe.GetUtility().Clean(probe.GetRootCtx(), new Dictionary<string, object?>
        {
            [CanaryValue] = 1, [CanaryHeader] = 2, ["plain"] = 3,
        }) as Dictionary<string, object?> ?? new Dictionary<string, object?>();
        sinks.AddRange(FormsOf("named", named));

        // An error's code is cleaned like its message.
        var coded = probe.GetUtility().Clean(probe.GetRootCtx(),
            new VoxgigKeycloakSdkError("code_" + CanaryValue, "coded", null));
        sinks.AddRange(FormsOf("coded", coded));

        var leaked = sinks
            .Select(s => (s.Name, Found: Leaks(s.Text)))
            .Where(s => 0 < s.Found.Count)
            .ToList();

        Report("clean: swept " + sinks.Count + " surface(s), " + leaked.Count + " leak(s)");

        Assert.True(0 == leaked.Count, "credential leaked through: " +
            string.Join("; ", leaked.Select(l => l.Name + " [" + string.Join(", ", l.Found) + "]")));

        // The positive half: the slot the credential travelled in is masked,
        // and an unregistered token in a response header is masked by name.
        Assert.True(errors.TryGetValue("notfound/throw", out var notfoundErr), "the 404 scenario must throw");
        var notfound = Assert.IsType<VoxgigKeycloakSdkError>(notfoundErr);
        Assert.Equal(404, notfound.Status);
        var spec = notfound.SpecVal as Dictionary<string, object?> ?? new Dictionary<string, object?>();
        if (!AuthSuppressed)
        {
            if ("query" == AuthWhere)
            {
                Assert.Equal(Mask, Header(spec.GetValueOrDefault("query"), AuthName));
            }
            else if ("cookie" == AuthWhere)
            {
                var cookie = Convert.ToString(Header(spec.GetValueOrDefault("headers"), "cookie")) ?? "";
                Assert.True(cookie.Contains(Mask), "cookie: " + cookie);
            }
            else
            {
                var cred = Convert.ToString(Header(spec.GetValueOrDefault("headers"), AuthName)) ?? "";
                Assert.True(cred.EndsWith(Mask), AuthName + ": " + cred);
            }
        }
        Assert.Equal(Mask, Header(spec.GetValueOrDefault("headers"), "x-custom-token"));

        Assert.True(explains.TryGetValue("ok/explain", out var explained), "the ok scenario should explain");
        var result = explained!.GetValueOrDefault("result") as Dictionary<string, object?>;
        Assert.True(null != result, "the explain record should carry the result");
        Assert.Equal(Mask, Header(result!.GetValueOrDefault("headers"), "x-session-token"));

        Assert.True(3 == named.Count && Equals(1, named.GetValueOrDefault(Mask)) &&
            Equals(2, named.GetValueOrDefault(Mask + "#1")) && Equals(3, named.GetValueOrDefault("plain")),
            "map keys: " + Render(named));
        Assert.Equal("code_" + Mask, (coded as VoxgigKeycloakSdkError)?.Code);
    }

    [Fact]
    public void TheSweepCanSeeALeakCleanSwitchedOffShowsTheCredential()
    {
        var target = UsableOp();
        if (null == target)
        {
            Report("clean: skipped: " + NoOp);
            return;
        }

        var sinks = new List<Sink>();
        var sdk = MakeSdk(Scenarios[1], sinks, new Dictionary<string, object?> { ["active"] = false });
        var err = Drive(sdk, target, new Dictionary<string, object?>(), sinks);
        Assert.True(null != err, "the 404 scenario must throw");

        // Explaining a failure must not cost it its error.
        var explained = Drive(MakeSdk(Scenarios[1], new List<Sink>(),
                new Dictionary<string, object?> { ["active"] = false }), target,
            new Dictionary<string, object?> { ["explain"] = new Dictionary<string, object?>() }, new List<Sink>());
        Assert.True(err?.Message == explained?.Message,
            "with clean off, explain lost the error: expected " + err?.Message + ", got " + explained?.Message);

        var leaked = sinks.Where(s => 0 < Leaks(s.Text).Count).ToList();
        Assert.True(0 < leaked.Count, "with clean off, nothing showed the canary: the sweep is blind");

        if (!AuthSuppressed)
        {
            var text = Render((err as VoxgigKeycloakSdkError)?.SpecVal);
            Assert.True(text.Contains(CanaryApikey) ||
                text.Contains(Convert.ToBase64String(Encoding.UTF8.GetBytes(CanaryApikey + ":" + CanarySecret))),
                "the raw spec should carry the credential when clean is off");
        }
    }

    // A feature's name is not a field name: only the sensitive names inside
    // its settings register. An entity block, of per-entity settings or
    // seeded records keyed by entity name and id, is not read at all, and nor
    // are rbac's rules, keyed by entity and operation names.
    [Fact]
    public void AFeatureNameDoesNotMakeItsSettingsSecret()
    {
        var sdk = Construct(new Dictionary<string, object?>
        {
            ["apikey"] = CanaryApikey,
            ["feature"] = new Dictionary<string, object?>
            {
                ["zzsecrets"] = new Dictionary<string, object?>
                {
                    ["active"] = false, ["kind"] = "PLAINSETTING-q8w2e4r6",
                },
                ["zzfeat"] = new Dictionary<string, object?>
                {
                    ["active"] = false, ["apitoken"] = "FEATTOKEN-z9y8x7w6",
                },
                ["rbac"] = new Dictionary<string, object?>
                {
                    ["active"] = false,
                    ["rules"] = new Dictionary<string, object?> { ["zztoken.load"] = "PLAINRULE-k7j5h3g1" },
                },
                ["test"] = new Dictionary<string, object?>
                {
                    ["active"] = false,
                    ["entity"] = new Dictionary<string, object?>
                    {
                        ["zztoken"] = new Dictionary<string, object?>
                        {
                            ["ZZTOKEN01"] = new Dictionary<string, object?> { ["note"] = "PLAINRECORD-t5r3e1w9" },
                        },
                    },
                },
            },
            ["entity"] = new Dictionary<string, object?>
            {
                ["zztoken"] = new Dictionary<string, object?>
                {
                    ["alias"] = new Dictionary<string, object?> { ["zzkey"] = "PLAINALIAS-m2n4b6v8" },
                },
            },
        });
        object? Cleaned(string s) => sdk.GetUtility().Clean(sdk.GetRootCtx(), s);

        Assert.Equal("kind PLAINSETTING-q8w2e4r6", Cleaned("kind PLAINSETTING-q8w2e4r6"));
        Assert.Equal("token " + Mask, Cleaned("token FEATTOKEN-z9y8x7w6"));
        Assert.Equal("record PLAINRECORD-t5r3e1w9", Cleaned("record PLAINRECORD-t5r3e1w9"));
        Assert.Equal("alias PLAINALIAS-m2n4b6v8", Cleaned("alias PLAINALIAS-m2n4b6v8"));
        Assert.Equal("rule PLAINRULE-k7j5h3g1", Cleaned("rule PLAINRULE-k7j5h3g1"));
    }

    [Fact]
    public void TheGeneratedConfigsOwnCleanBlockIsHonoured()
    {
        var utility = Construct(new Dictionary<string, object?>()).GetUtility();
        var config = new Dictionary<string, object?>
        {
            ["options"] = new Dictionary<string, object?>
            {
                ["clean"] = new Dictionary<string, object?>
                {
                    ["keys"] = "zzsens",
                    ["values"] = "CONFIG-SEEDED-1",
                },
            },
        };
        var ctx = utility.MakeContext(new Dictionary<string, object?>
        {
            ["utility"] = utility,
            ["config"] = config,
            ["options"] = new Dictionary<string, object?>
            {
                ["clean"] = new Dictionary<string, object?> { ["values"] = "CALLER-SEEDED-2" },
            },
        }, null);
        ctx.Options = utility.MakeOptions(ctx);

        Assert.Equal("a " + Mask + " b " + Mask, utility.Clean(ctx, "a CONFIG-SEEDED-1 b CALLER-SEEDED-2"));
        var masked = utility.Clean(ctx, new Dictionary<string, object?>
        {
            ["my_zzsens"] = "x",
            ["other"] = "y",
        }) as Dictionary<string, object?>;
        Assert.Equal(Mask, masked?.GetValueOrDefault("my_zzsens"));
        Assert.Equal("y", masked?.GetValueOrDefault("other"));
        Assert.Equal("CONFIG-SEEDED-1",
            StructUtils.GetPath(config, StructUtils.Jt("options", "clean", "values")));
    }

    [Fact]
    public void WithNoCleanBlockTheSchemaDefaultsApply()
    {
        var utility = Construct(new Dictionary<string, object?>()).GetUtility();
        var ctx = utility.MakeContext(new Dictionary<string, object?>
        {
            ["utility"] = utility,
            ["options"] = new Dictionary<string, object?> { ["apikey"] = "NOBLOCK-APIKEY-k3j5h7" },
        }, null);
        ctx.Options = utility.MakeOptions(ctx);

        Assert.Equal("failed with " + Mask, utility.Clean(ctx, "failed with NOBLOCK-APIKEY-k3j5h7"));
        var masked = utility.Clean(ctx, new Dictionary<string, object?>
        {
            ["x-session-token"] = "RESP-TOKEN-a1b2c3d4e5",
        }) as Dictionary<string, object?>;
        Assert.Equal(Mask, masked?.GetValueOrDefault("x-session-token"));
    }
}
