// client_scope entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class ClientScopeEntityTest
{
    // main.kit.test.live.strict is true (the default is true): a live
    // request that fails, or a live test missing an input it needs,
    // fails the test.
    // An account with no record for a test to read skips it either way.
    private const bool LIVE_STRICT = true;

    [Fact]
    public void Instance()
    {
        var testsdk = VoxgigKeycloakSdkSDK.TestSDK(null, null);
        var ent = testsdk.ClientScope();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = ClientScopeBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "create", "list", "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "client_scope." + _op, _mode);
            if (_shouldSkip)
            {
                return; // skipped via sdk-test-control.json
            }
        }
        if (setup.Live)
        {
            foreach (var liveKey in new[] { "realm01" })
            {
                if (setup.SyntheticOnly || StructUtils.GetProp(setup.Idmap, liveKey) == null)
                {
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_SCOPE_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // CREATE
        var clientScopeRef01Ent = client.ClientScope();
        var clientScopeRef01Data = Helpers.ToMapAny(StructUtils.GetProp(
            StructUtils.GetPath(setup.Data, StructUtils.Jt("new", "client_scope")),
            "client_scope_ref01"));
        clientScopeRef01Data!["realm"] = setup.Idmap["realm01"];

        var clientScopeRef01DataResult = clientScopeRef01Ent.Create(clientScopeRef01Data, null);
        clientScopeRef01Data = Helpers.ToMapAny(clientScopeRef01DataResult is IEntity ce ? ce.Data() : clientScopeRef01DataResult);
        Assert.True(clientScopeRef01Data != null, "expected create result to be a map");
        Assert.True(clientScopeRef01Data!["id"] != null, "expected created entity to have an id");

        // LIST
        var clientScopeRef01Match = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var clientScopeRef01ListResult = clientScopeRef01Ent.List(clientScopeRef01Match, null);
        var clientScopeRef01List = clientScopeRef01ListResult as List<object?>;
        Assert.True(clientScopeRef01List != null,
            $"expected list result to be a list, got {clientScopeRef01ListResult?.GetType()}");

        var clientScopeRef01ListFound = StructUtils.Select(
            TestRunner.EntityListToData(clientScopeRef01List!),
            new Dictionary<string, object?> { ["id"] = clientScopeRef01Data!["id"] });
        Assert.False(StructUtils.IsEmpty(clientScopeRef01ListFound),
            "expected to find created entity in list");

        // UPDATE
        var clientScopeRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = clientScopeRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var clientScopeRef01MarkdefUp0Name = "description";
        var clientScopeRef01MarkdefUp0Value = $"Mark01-client_scope_ref01_{setup.Now}";
        clientScopeRef01DataUp0Up[clientScopeRef01MarkdefUp0Name] = clientScopeRef01MarkdefUp0Value;

        var clientScopeRef01ResdataUp0Result = clientScopeRef01Ent.Update(clientScopeRef01DataUp0Up, null);
        var clientScopeRef01ResdataUp0 = Helpers.ToMapAny(clientScopeRef01ResdataUp0Result is IEntity ue ? ue.Data() : clientScopeRef01ResdataUp0Result);
        Assert.True(clientScopeRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(clientScopeRef01ResdataUp0!["id"], clientScopeRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(clientScopeRef01ResdataUp0![clientScopeRef01MarkdefUp0Name], clientScopeRef01MarkdefUp0Value),
            $"expected {clientScopeRef01MarkdefUp0Name} to be updated, got {clientScopeRef01ResdataUp0[clientScopeRef01MarkdefUp0Name]}");

        // LOAD
        var clientScopeRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = clientScopeRef01Data!["id"],
        };
        var clientScopeRef01DataDt0Loaded = clientScopeRef01Ent.Load(clientScopeRef01MatchDt0, null);
        var clientScopeRef01DataDt0LoadResult = Helpers.ToMapAny(clientScopeRef01DataDt0Loaded is IEntity le ? le.Data() : clientScopeRef01DataDt0Loaded);
        Assert.True(clientScopeRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(clientScopeRef01DataDt0LoadResult!["id"], clientScopeRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var clientScopeRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = clientScopeRef01Data!["id"],
        };
        clientScopeRef01Ent.Remove(clientScopeRef01MatchRm0, null);

        // LIST
        var clientScopeRef01MatchRt0 = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var clientScopeRef01ListRt0Result = clientScopeRef01Ent.List(clientScopeRef01MatchRt0, null);
        var clientScopeRef01ListRt0 = clientScopeRef01ListRt0Result as List<object?>;
        Assert.True(clientScopeRef01ListRt0 != null,
            $"expected list result to be a list, got {clientScopeRef01ListRt0Result?.GetType()}");

        var clientScopeRef01ListRt0NotFound = StructUtils.Select(
            TestRunner.EntityListToData(clientScopeRef01ListRt0!),
            new Dictionary<string, object?> { ["id"] = clientScopeRef01Data!["id"] });
        Assert.True(StructUtils.IsEmpty(clientScopeRef01ListRt0NotFound),
            "expected removed entity to not be in list");

    }

    [Fact]
    public void Validate()
    {
        if (!Fh.HasFeature("validate"))
        {
            Console.WriteLine("skip: feature not present in this SDK: validate");
            return;
        }
        var client = VoxgigKeycloakSdkSDK.TestSDK(null,
            new Dictionary<string, object?> { ["feature"] = new Dictionary<string, object?> { ["validate"] = new Dictionary<string, object?> { ["active"] = true } } });
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.ClientScope().List(
            new Dictionary<string, object?> { ["realm"] = 1 }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup ClientScopeBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "client_scope",
            "ClientScopeTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse client_scope test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "client_scope01", "client_scope02", "client_scope03", "realm01" },
            new Dictionary<string, object?>
            {
                ["`$PACK`"] = new List<object?>
                {
                    "",
                    new Dictionary<string, object?>
                    {
                        ["`$KEY`"] = "`$COPY`",
                        ["`$VAL`"] = new List<object?> { "`$FORMAT`", "upper", "`$COPY`" },
                    },
                },
            });

        // Whether *_ENTID supplied the idmap, read before EnvOverride consumes
        // it: without it, the ids a live flow binds are the fixture's synthetic ones.
        var entidEnvRaw = Environment.GetEnvironmentVariable(
            "VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_SCOPE_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_SCOPE_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_SCOPE_ENTID"])
            ?? Helpers.ToMapAny(idmap)
            ?? new Dictionary<string, object?>();

        // Add realm alias for the update test.
        if (StructUtils.GetProp(idmapResolved, "realm") == null)
        {
            idmapResolved["realm"] = StructUtils.GetProp(idmapResolved, "realm01");
        }

        if (Equals(env["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"], "TRUE"))
        {
            // 'extra ?? new ...', not a bare 'extra': Merge returns null when
            // the last entry is null, and BasicSetup is normally called with no
            // argument at all - so a bare 'extra' silently discarded the apikey
            // and server values above and handed the SDK null.
            var extraOpts = extra ?? new Dictionary<string, object?>();
            var mergedOpts = StructUtils.Merge(new List<object?>
            {
                // FIRST, so the generated fields below win: sdk-test-control.json's
                // test.client.options adds to the live client, it does not redirect it.
                TestRunner.LiveClientOptions(),
                new Dictionary<string, object?>
                {
                    ["apikey"] = env["VOXGIG_KEYCLOAK_SDK_APIKEY"],
                },
                extraOpts,
            });
            client = new VoxgigKeycloakSdkSDK(Helpers.ToMapAny(mergedOpts));
        }

        var live = Equals(env["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"], "TRUE");
        return new EntityTestSetup
        {
            Client = client,
            Data = entityData,
            Idmap = idmapResolved,
            Env = env,
            Explain = Equals(env["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"], "TRUE"),
            Live = live,
            SyntheticOnly = live && !idmapOverridden,
            Now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
        };
    }
}
