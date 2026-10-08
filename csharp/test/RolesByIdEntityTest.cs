// roles_by_id entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class RolesByIdEntityTest
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
        var ent = testsdk.RolesById();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = RolesByIdBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "roles_by_id." + _op, _mode);
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
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_ROLES_BY_ID_ENTID");
                    return;
                }
            }
        }
        if (setup.Live)
        {
            TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: " + "the flow updates a roles_by_id record it did not create");
            return;
        }
        var client = setup.Client;

        // Bootstrap entity data from existing test data (no create step in flow).
        var rolesByIdRef01DataRaw = StructUtils.Items(
            Helpers.ToMapAny(StructUtils.GetPath(setup.Data, "existing.roles_by_id")));
        var rolesByIdRef01Data = rolesByIdRef01DataRaw.Count > 0
            ? Helpers.ToMapAny(rolesByIdRef01DataRaw[0][1])
            : null;

        // UPDATE
        var rolesByIdRef01Ent = client.RolesById();
        var rolesByIdRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = rolesByIdRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var rolesByIdRef01MarkdefUp0Name = "containerId";
        var rolesByIdRef01MarkdefUp0Value = $"Mark01-roles_by_id_ref01_{setup.Now}";
        rolesByIdRef01DataUp0Up[rolesByIdRef01MarkdefUp0Name] = rolesByIdRef01MarkdefUp0Value;

        var rolesByIdRef01ResdataUp0Result = rolesByIdRef01Ent.Update(rolesByIdRef01DataUp0Up, null);
        var rolesByIdRef01ResdataUp0 = Helpers.ToMapAny(rolesByIdRef01ResdataUp0Result is IEntity ue ? ue.Data() : rolesByIdRef01ResdataUp0Result);
        Assert.True(rolesByIdRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(rolesByIdRef01ResdataUp0!["id"], rolesByIdRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(rolesByIdRef01ResdataUp0![rolesByIdRef01MarkdefUp0Name], rolesByIdRef01MarkdefUp0Value),
            $"expected {rolesByIdRef01MarkdefUp0Name} to be updated, got {rolesByIdRef01ResdataUp0[rolesByIdRef01MarkdefUp0Name]}");

        // LOAD
        var rolesByIdRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = rolesByIdRef01Data!["id"],
        };
        var rolesByIdRef01DataDt0Loaded = rolesByIdRef01Ent.Load(rolesByIdRef01MatchDt0, null);
        var rolesByIdRef01DataDt0LoadResult = Helpers.ToMapAny(rolesByIdRef01DataDt0Loaded is IEntity le ? le.Data() : rolesByIdRef01DataDt0Loaded);
        Assert.True(rolesByIdRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(rolesByIdRef01DataDt0LoadResult!["id"], rolesByIdRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var rolesByIdRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = rolesByIdRef01Data!["id"],
        };
        rolesByIdRef01Ent.Remove(rolesByIdRef01MatchRm0, null);

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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.RolesById().Load(
            new Dictionary<string, object?> { ["id"] = 1, ["realm"] = "x" }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup RolesByIdBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "roles_by_id",
            "RolesByIdTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse roles_by_id test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "roles_by_id01", "roles_by_id02", "roles_by_id03", "realm01" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_ROLES_BY_ID_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_ROLES_BY_ID_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_ROLES_BY_ID_ENTID"])
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
