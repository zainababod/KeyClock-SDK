// client entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class ClientEntityTest
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
        var ent = testsdk.Client();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = ClientBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "create", "list", "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "client." + _op, _mode);
            if (_shouldSkip)
            {
                return; // skipped via sdk-test-control.json
            }
        }
        if (setup.Live)
        {
            foreach (var liveKey in new[] { "client_scope01", "client_template01", "group01", "realm01", "role_name01", "roles_by_id01", "user01" })
            {
                if (setup.SyntheticOnly || StructUtils.GetProp(setup.Idmap, liveKey) == null)
                {
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // CREATE
        var clientRef01Ent = client.Client();
        var clientRef01Data = Helpers.ToMapAny(StructUtils.GetProp(
            StructUtils.GetPath(setup.Data, StructUtils.Jt("new", "client")),
            "client_ref01"));
        clientRef01Data!["client_scope_id"] = setup.Idmap["client_scope01"];
        clientRef01Data!["client_template_id"] = setup.Idmap["client_template01"];
        clientRef01Data!["group_id"] = setup.Idmap["group01"];
        clientRef01Data!["realm"] = setup.Idmap["realm01"];
        clientRef01Data!["role_name"] = setup.Idmap["role_name01"];
        clientRef01Data!["roles_by_id_id"] = setup.Idmap["roles_by_id01"];
        clientRef01Data!["user_id"] = setup.Idmap["user01"];

        var clientRef01DataResult = clientRef01Ent.Create(clientRef01Data, null);
        clientRef01Data = Helpers.ToMapAny(clientRef01DataResult is IEntity ce ? ce.Data() : clientRef01DataResult);
        Assert.True(clientRef01Data != null, "expected create result to be a map");
        Assert.True(clientRef01Data!["id"] != null, "expected created entity to have an id");

        // LIST
        var clientRef01Match = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var clientRef01ListResult = clientRef01Ent.List(clientRef01Match, null);
        var clientRef01List = clientRef01ListResult as List<object?>;
        Assert.True(clientRef01List != null,
            $"expected list result to be a list, got {clientRef01ListResult?.GetType()}");

        var clientRef01ListFound = StructUtils.Select(
            TestRunner.EntityListToData(clientRef01List!),
            new Dictionary<string, object?> { ["id"] = clientRef01Data!["id"] });
        Assert.False(StructUtils.IsEmpty(clientRef01ListFound),
            "expected to find created entity in list");

        // UPDATE
        var clientRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = clientRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var clientRef01MarkdefUp0Name = "adminUrl";
        var clientRef01MarkdefUp0Value = $"Mark01-client_ref01_{setup.Now}";
        clientRef01DataUp0Up[clientRef01MarkdefUp0Name] = clientRef01MarkdefUp0Value;

        var clientRef01ResdataUp0Result = clientRef01Ent.Update(clientRef01DataUp0Up, null);
        var clientRef01ResdataUp0 = Helpers.ToMapAny(clientRef01ResdataUp0Result is IEntity ue ? ue.Data() : clientRef01ResdataUp0Result);
        Assert.True(clientRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(clientRef01ResdataUp0!["id"], clientRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(clientRef01ResdataUp0![clientRef01MarkdefUp0Name], clientRef01MarkdefUp0Value),
            $"expected {clientRef01MarkdefUp0Name} to be updated, got {clientRef01ResdataUp0[clientRef01MarkdefUp0Name]}");

        // LOAD
        var clientRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = clientRef01Data!["id"],
        };
        var clientRef01DataDt0Loaded = clientRef01Ent.Load(clientRef01MatchDt0, null);
        var clientRef01DataDt0LoadResult = Helpers.ToMapAny(clientRef01DataDt0Loaded is IEntity le ? le.Data() : clientRef01DataDt0Loaded);
        Assert.True(clientRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(clientRef01DataDt0LoadResult!["id"], clientRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var clientRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = clientRef01Data!["id"],
        };
        clientRef01Ent.Remove(clientRef01MatchRm0, null);

        // LIST
        var clientRef01MatchRt0 = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var clientRef01ListRt0Result = clientRef01Ent.List(clientRef01MatchRt0, null);
        var clientRef01ListRt0 = clientRef01ListRt0Result as List<object?>;
        Assert.True(clientRef01ListRt0 != null,
            $"expected list result to be a list, got {clientRef01ListRt0Result?.GetType()}");

        var clientRef01ListRt0NotFound = StructUtils.Select(
            TestRunner.EntityListToData(clientRef01ListRt0!),
            new Dictionary<string, object?> { ["id"] = clientRef01Data!["id"] });
        Assert.True(StructUtils.IsEmpty(clientRef01ListRt0NotFound),
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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.Client().List(
            new Dictionary<string, object?> { ["realm"] = 1 }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup ClientBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "client",
            "ClientTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse client test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "client01", "client02", "client03", "client_scope01", "client_scope02", "client_scope03", "group01", "group02", "group03", "roles_by_id01", "roles_by_id02", "roles_by_id03", "role01", "role02", "role03", "user01", "user02", "user03", "client_template01", "realm01", "role_name01" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_CLIENT_ENTID"])
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
