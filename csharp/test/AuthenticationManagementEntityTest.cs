// authentication_management entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class AuthenticationManagementEntityTest
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
        var ent = testsdk.AuthenticationManagement();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = AuthenticationManagementBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "create", "list", "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "authentication_management." + _op, _mode);
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
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_AUTHENTICATION_MANAGEMENT_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // CREATE
        var authenticationManagementRef01Ent = client.AuthenticationManagement();
        var authenticationManagementRef01Data = Helpers.ToMapAny(StructUtils.GetProp(
            StructUtils.GetPath(setup.Data, StructUtils.Jt("new", "authentication_management")),
            "authentication_management_ref01"));
        authenticationManagementRef01Data!["realm"] = setup.Idmap["realm01"];

        var authenticationManagementRef01DataResult = authenticationManagementRef01Ent.Create(authenticationManagementRef01Data, null);
        authenticationManagementRef01Data = Helpers.ToMapAny(authenticationManagementRef01DataResult is IEntity ce ? ce.Data() : authenticationManagementRef01DataResult);
        Assert.True(authenticationManagementRef01Data != null, "expected create result to be a map");
        Assert.True(authenticationManagementRef01Data!["id"] != null, "expected created entity to have an id");

        // LIST
        var authenticationManagementRef01Match = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var authenticationManagementRef01ListResult = authenticationManagementRef01Ent.List(authenticationManagementRef01Match, null);
        var authenticationManagementRef01List = authenticationManagementRef01ListResult as List<object?>;
        Assert.True(authenticationManagementRef01List != null,
            $"expected list result to be a list, got {authenticationManagementRef01ListResult?.GetType()}");

        var authenticationManagementRef01ListFound = StructUtils.Select(
            TestRunner.EntityListToData(authenticationManagementRef01List!),
            new Dictionary<string, object?> { ["id"] = authenticationManagementRef01Data!["id"] });
        Assert.False(StructUtils.IsEmpty(authenticationManagementRef01ListFound),
            "expected to find created entity in list");

        // UPDATE
        var authenticationManagementRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = authenticationManagementRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var authenticationManagementRef01MarkdefUp0Name = "alias";
        var authenticationManagementRef01MarkdefUp0Value = $"Mark01-authentication_management_ref01_{setup.Now}";
        authenticationManagementRef01DataUp0Up[authenticationManagementRef01MarkdefUp0Name] = authenticationManagementRef01MarkdefUp0Value;

        var authenticationManagementRef01ResdataUp0Result = authenticationManagementRef01Ent.Update(authenticationManagementRef01DataUp0Up, null);
        var authenticationManagementRef01ResdataUp0 = Helpers.ToMapAny(authenticationManagementRef01ResdataUp0Result is IEntity ue ? ue.Data() : authenticationManagementRef01ResdataUp0Result);
        Assert.True(authenticationManagementRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(authenticationManagementRef01ResdataUp0!["id"], authenticationManagementRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(authenticationManagementRef01ResdataUp0![authenticationManagementRef01MarkdefUp0Name], authenticationManagementRef01MarkdefUp0Value),
            $"expected {authenticationManagementRef01MarkdefUp0Name} to be updated, got {authenticationManagementRef01ResdataUp0[authenticationManagementRef01MarkdefUp0Name]}");

        // LOAD
        var authenticationManagementRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = authenticationManagementRef01Data!["id"],
        };
        var authenticationManagementRef01DataDt0Loaded = authenticationManagementRef01Ent.Load(authenticationManagementRef01MatchDt0, null);
        var authenticationManagementRef01DataDt0LoadResult = Helpers.ToMapAny(authenticationManagementRef01DataDt0Loaded is IEntity le ? le.Data() : authenticationManagementRef01DataDt0Loaded);
        Assert.True(authenticationManagementRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(authenticationManagementRef01DataDt0LoadResult!["id"], authenticationManagementRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var authenticationManagementRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = authenticationManagementRef01Data!["id"],
        };
        authenticationManagementRef01Ent.Remove(authenticationManagementRef01MatchRm0, null);

        // LIST
        var authenticationManagementRef01MatchRt0 = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
        };

        var authenticationManagementRef01ListRt0Result = authenticationManagementRef01Ent.List(authenticationManagementRef01MatchRt0, null);
        var authenticationManagementRef01ListRt0 = authenticationManagementRef01ListRt0Result as List<object?>;
        Assert.True(authenticationManagementRef01ListRt0 != null,
            $"expected list result to be a list, got {authenticationManagementRef01ListRt0Result?.GetType()}");

        var authenticationManagementRef01ListRt0NotFound = StructUtils.Select(
            TestRunner.EntityListToData(authenticationManagementRef01ListRt0!),
            new Dictionary<string, object?> { ["id"] = authenticationManagementRef01Data!["id"] });
        Assert.True(StructUtils.IsEmpty(authenticationManagementRef01ListRt0NotFound),
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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.AuthenticationManagement().List(
            new Dictionary<string, object?> { ["realm"] = 1 }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup AuthenticationManagementBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "authentication_management",
            "AuthenticationManagementTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse authentication_management test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "authentication_management01", "authentication_management02", "authentication_management03", "flow01", "flow02", "flow03", "required_action01", "required_action02", "required_action03", "realm01" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_AUTHENTICATION_MANAGEMENT_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_AUTHENTICATION_MANAGEMENT_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_AUTHENTICATION_MANAGEMENT_ENTID"])
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
