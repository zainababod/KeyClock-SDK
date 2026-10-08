// realm entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class RealmEntityTest
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
        var ent = testsdk.Realm();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = RealmBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "list" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "realm." + _op, _mode);
            if (_shouldSkip)
            {
                return; // skipped via sdk-test-control.json
            }
        }
        if (setup.Live)
        {
            foreach (var liveKey in new[] { "realm01", "user01" })
            {
                if (setup.SyntheticOnly || StructUtils.GetProp(setup.Idmap, liveKey) == null)
                {
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_REALM_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // Bootstrap entity data from existing test data (no create step in flow).
        var realmRef01DataRaw = StructUtils.Items(
            Helpers.ToMapAny(StructUtils.GetPath(setup.Data, "existing.realm")));
        var realmRef01Data = realmRef01DataRaw.Count > 0
            ? Helpers.ToMapAny(realmRef01DataRaw[0][1])
            : null;

        // LIST
        var realmRef01Ent = client.Realm();
        var realmRef01Match = new Dictionary<string, object?>
        {
            ["realm"] = setup.Idmap["realm01"],
            ["user_id"] = setup.Idmap["user01"],
        };

        var realmRef01ListResult = realmRef01Ent.List(realmRef01Match, null);
        var realmRef01List = realmRef01ListResult as List<object?>;
        Assert.True(realmRef01List != null,
            $"expected list result to be a list, got {realmRef01ListResult?.GetType()}");

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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.Realm().List(
            new Dictionary<string, object?> { ["client_id"] = 1, ["realm"] = "x" }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup RealmBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "realm",
            "RealmTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse realm test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "realm01", "realm02", "realm03", "client_scope01", "client_scope02", "client_scope03", "client01", "client02", "client03", "group01", "group02", "group03", "roles_by_id01", "roles_by_id02", "roles_by_id03", "user01", "user02", "user03", "role01", "role02", "role03" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_REALM_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_REALM_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_REALM_ENTID"])
            ?? Helpers.ToMapAny(idmap)
            ?? new Dictionary<string, object?>();

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
