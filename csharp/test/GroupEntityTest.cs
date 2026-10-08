// group entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class GroupEntityTest
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
        var ent = testsdk.Group();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = GroupBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "create", "list", "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "group." + _op, _mode);
            if (_shouldSkip)
            {
                return; // skipped via sdk-test-control.json
            }
        }
        if (setup.Live)
        {
            foreach (var liveKey in new[] { "client01", "realm01", "role_name01", "user01" })
            {
                if (setup.SyntheticOnly || StructUtils.GetProp(setup.Idmap, liveKey) == null)
                {
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_GROUP_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // CREATE
        var groupRef01Ent = client.Group();
        var groupRef01Data = Helpers.ToMapAny(StructUtils.GetProp(
            StructUtils.GetPath(setup.Data, StructUtils.Jt("new", "group")),
            "group_ref01"));
        groupRef01Data!["client_id"] = setup.Idmap["client01"];
        groupRef01Data!["realm"] = setup.Idmap["realm01"];
        groupRef01Data!["role_name"] = setup.Idmap["role_name01"];
        groupRef01Data!["user_id"] = setup.Idmap["user01"];

        var groupRef01DataResult = groupRef01Ent.Create(groupRef01Data, null);
        groupRef01Data = Helpers.ToMapAny(groupRef01DataResult is IEntity ce ? ce.Data() : groupRef01DataResult);
        Assert.True(groupRef01Data != null, "expected create result to be a map");
        Assert.True(groupRef01Data!["id"] != null, "expected created entity to have an id");

        // LIST
        var groupRef01Match = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var groupRef01ListResult = groupRef01Ent.List(groupRef01Match, null);
        var groupRef01List = groupRef01ListResult as List<object?>;
        Assert.True(groupRef01List != null,
            $"expected list result to be a list, got {groupRef01ListResult?.GetType()}");

        var groupRef01ListFound = StructUtils.Select(
            TestRunner.EntityListToData(groupRef01List!),
            new Dictionary<string, object?> { ["id"] = groupRef01Data!["id"] });
        Assert.False(StructUtils.IsEmpty(groupRef01ListFound),
            "expected to find created entity in list");

        // UPDATE
        var groupRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = groupRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var groupRef01MarkdefUp0Name = "name";
        var groupRef01MarkdefUp0Value = $"Mark01-group_ref01_{setup.Now}";
        groupRef01DataUp0Up[groupRef01MarkdefUp0Name] = groupRef01MarkdefUp0Value;

        var groupRef01ResdataUp0Result = groupRef01Ent.Update(groupRef01DataUp0Up, null);
        var groupRef01ResdataUp0 = Helpers.ToMapAny(groupRef01ResdataUp0Result is IEntity ue ? ue.Data() : groupRef01ResdataUp0Result);
        Assert.True(groupRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(groupRef01ResdataUp0!["id"], groupRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(groupRef01ResdataUp0![groupRef01MarkdefUp0Name], groupRef01MarkdefUp0Value),
            $"expected {groupRef01MarkdefUp0Name} to be updated, got {groupRef01ResdataUp0[groupRef01MarkdefUp0Name]}");

        // LOAD
        var groupRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = groupRef01Data!["id"],
        };
        var groupRef01DataDt0Loaded = groupRef01Ent.Load(groupRef01MatchDt0, null);
        var groupRef01DataDt0LoadResult = Helpers.ToMapAny(groupRef01DataDt0Loaded is IEntity le ? le.Data() : groupRef01DataDt0Loaded);
        Assert.True(groupRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(groupRef01DataDt0LoadResult!["id"], groupRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var groupRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = groupRef01Data!["id"],
        };
        groupRef01Ent.Remove(groupRef01MatchRm0, null);

        // LIST
        var groupRef01MatchRt0 = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var groupRef01ListRt0Result = groupRef01Ent.List(groupRef01MatchRt0, null);
        var groupRef01ListRt0 = groupRef01ListRt0Result as List<object?>;
        Assert.True(groupRef01ListRt0 != null,
            $"expected list result to be a list, got {groupRef01ListRt0Result?.GetType()}");

        var groupRef01ListRt0NotFound = StructUtils.Select(
            TestRunner.EntityListToData(groupRef01ListRt0!),
            new Dictionary<string, object?> { ["id"] = groupRef01Data!["id"] });
        Assert.True(StructUtils.IsEmpty(groupRef01ListRt0NotFound),
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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.Group().List(
            new Dictionary<string, object?> { ["client_id"] = 1, ["realm"] = "x" }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup GroupBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "group",
            "GroupTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse group test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "group01", "group02", "group03", "user01", "user02", "user03", "client01", "client02", "client03", "role01", "role02", "role03", "realm01", "role_name01" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_GROUP_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_GROUP_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_GROUP_ENTID"])
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
