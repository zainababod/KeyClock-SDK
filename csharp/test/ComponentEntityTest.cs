// component entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class ComponentEntityTest
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
        var ent = testsdk.Component();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = ComponentBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "create", "list", "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "component." + _op, _mode);
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
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_COMPONENT_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // CREATE
        var componentRef01Ent = client.Component();
        var componentRef01Data = Helpers.ToMapAny(StructUtils.GetProp(
            StructUtils.GetPath(setup.Data, StructUtils.Jt("new", "component")),
            "component_ref01"));
        componentRef01Data!["realm"] = setup.Idmap["realm01"];

        var componentRef01DataResult = componentRef01Ent.Create(componentRef01Data, null);
        componentRef01Data = Helpers.ToMapAny(componentRef01DataResult is IEntity ce ? ce.Data() : componentRef01DataResult);
        Assert.True(componentRef01Data != null, "expected create result to be a map");
        Assert.True(componentRef01Data!["id"] != null, "expected created entity to have an id");

        // LIST
        var componentRef01Match = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var componentRef01ListResult = componentRef01Ent.List(componentRef01Match, null);
        var componentRef01List = componentRef01ListResult as List<object?>;
        Assert.True(componentRef01List != null,
            $"expected list result to be a list, got {componentRef01ListResult?.GetType()}");

        var componentRef01ListFound = StructUtils.Select(
            TestRunner.EntityListToData(componentRef01List!),
            new Dictionary<string, object?> { ["id"] = componentRef01Data!["id"] });
        Assert.False(StructUtils.IsEmpty(componentRef01ListFound),
            "expected to find created entity in list");

        // UPDATE
        var componentRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = componentRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var componentRef01MarkdefUp0Name = "name";
        var componentRef01MarkdefUp0Value = $"Mark01-component_ref01_{setup.Now}";
        componentRef01DataUp0Up[componentRef01MarkdefUp0Name] = componentRef01MarkdefUp0Value;

        var componentRef01ResdataUp0Result = componentRef01Ent.Update(componentRef01DataUp0Up, null);
        var componentRef01ResdataUp0 = Helpers.ToMapAny(componentRef01ResdataUp0Result is IEntity ue ? ue.Data() : componentRef01ResdataUp0Result);
        Assert.True(componentRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(componentRef01ResdataUp0!["id"], componentRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(componentRef01ResdataUp0![componentRef01MarkdefUp0Name], componentRef01MarkdefUp0Value),
            $"expected {componentRef01MarkdefUp0Name} to be updated, got {componentRef01ResdataUp0[componentRef01MarkdefUp0Name]}");

        // LOAD
        var componentRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = componentRef01Data!["id"],
        };
        var componentRef01DataDt0Loaded = componentRef01Ent.Load(componentRef01MatchDt0, null);
        var componentRef01DataDt0LoadResult = Helpers.ToMapAny(componentRef01DataDt0Loaded is IEntity le ? le.Data() : componentRef01DataDt0Loaded);
        Assert.True(componentRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(componentRef01DataDt0LoadResult!["id"], componentRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var componentRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = componentRef01Data!["id"],
        };
        componentRef01Ent.Remove(componentRef01MatchRm0, null);

        // LIST
        var componentRef01MatchRt0 = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var componentRef01ListRt0Result = componentRef01Ent.List(componentRef01MatchRt0, null);
        var componentRef01ListRt0 = componentRef01ListRt0Result as List<object?>;
        Assert.True(componentRef01ListRt0 != null,
            $"expected list result to be a list, got {componentRef01ListRt0Result?.GetType()}");

        var componentRef01ListRt0NotFound = StructUtils.Select(
            TestRunner.EntityListToData(componentRef01ListRt0!),
            new Dictionary<string, object?> { ["id"] = componentRef01Data!["id"] });
        Assert.True(StructUtils.IsEmpty(componentRef01ListRt0NotFound),
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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.Component().List(
            new Dictionary<string, object?> { ["realm"] = 1 }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup ComponentBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "component",
            "ComponentTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse component test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "component01", "component02", "component03", "realm01" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_COMPONENT_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_COMPONENT_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_COMPONENT_ENTID"])
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
