// identity_provider entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class IdentityProviderEntityTest
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
        var ent = testsdk.IdentityProvider();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = IdentityProviderBasicSetup(null);
        // Per-op sdk-test-control.json skip - basic test exercises a flow
        // with multiple ops; skipping any op skips the whole flow.
        var _mode = setup.Live ? "live" : "unit";
        foreach (var _op in new[] { "create", "update", "load", "remove" })
        {
            var (_shouldSkip, _) = TestRunner.IsControlSkipped(
                "entityOp", "identity_provider." + _op, _mode);
            if (_shouldSkip)
            {
                return; // skipped via sdk-test-control.json
            }
        }
        if (setup.Live)
        {
            foreach (var liveKey in new[] { "alia01", "realm01" })
            {
                if (setup.SyntheticOnly || StructUtils.GetProp(setup.Idmap, liveKey) == null)
                {
                    TestRunner.LiveMiss(LIVE_STRICT, "Live entity test blocked: needs " + liveKey + " via VOXGIG_KEYCLOAK_SDK_TEST_IDENTITY_PROVIDER_ENTID");
                    return;
                }
            }
        }
        var client = setup.Client;

        // CREATE
        var identityProviderRef01Ent = client.IdentityProvider();
        var identityProviderRef01Data = Helpers.ToMapAny(StructUtils.GetProp(
            StructUtils.GetPath(setup.Data, StructUtils.Jt("new", "identity_provider")),
            "identity_provider_ref01"));
        identityProviderRef01Data!["alia"] = setup.Idmap["alia01"];
        identityProviderRef01Data!["realm"] = setup.Idmap["realm01"];

        var identityProviderRef01DataResult = identityProviderRef01Ent.Create(identityProviderRef01Data, null);
        identityProviderRef01Data = Helpers.ToMapAny(identityProviderRef01DataResult is IEntity ce ? ce.Data() : identityProviderRef01DataResult);
        Assert.True(identityProviderRef01Data != null, "expected create result to be a map");
        Assert.True(identityProviderRef01Data!["id"] != null, "expected created entity to have an id");

        // UPDATE
        var identityProviderRef01DataUp0Up = new Dictionary<string, object?>
        {
            ["id"] = identityProviderRef01Data!["id"],
            ["realm"] = setup.Idmap["realm"],
        };

        var identityProviderRef01MarkdefUp0Name = "alias";
        var identityProviderRef01MarkdefUp0Value = $"Mark01-identity_provider_ref01_{setup.Now}";
        identityProviderRef01DataUp0Up[identityProviderRef01MarkdefUp0Name] = identityProviderRef01MarkdefUp0Value;

        var identityProviderRef01ResdataUp0Result = identityProviderRef01Ent.Update(identityProviderRef01DataUp0Up, null);
        var identityProviderRef01ResdataUp0 = Helpers.ToMapAny(identityProviderRef01ResdataUp0Result is IEntity ue ? ue.Data() : identityProviderRef01ResdataUp0Result);
        Assert.True(identityProviderRef01ResdataUp0 != null, "expected update result to be a map");
        Assert.True(StructRunner.DeepEqual(identityProviderRef01ResdataUp0!["id"], identityProviderRef01DataUp0Up["id"]),
            "expected update result id to match");
        Assert.True(Equals(identityProviderRef01ResdataUp0![identityProviderRef01MarkdefUp0Name], identityProviderRef01MarkdefUp0Value),
            $"expected {identityProviderRef01MarkdefUp0Name} to be updated, got {identityProviderRef01ResdataUp0[identityProviderRef01MarkdefUp0Name]}");

        // LOAD
        var identityProviderRef01MatchDt0 = new Dictionary<string, object?>
        {
            ["id"] = identityProviderRef01Data!["id"],
        };
        var identityProviderRef01DataDt0Loaded = identityProviderRef01Ent.Load(identityProviderRef01MatchDt0, null);
        var identityProviderRef01DataDt0LoadResult = Helpers.ToMapAny(identityProviderRef01DataDt0Loaded is IEntity le ? le.Data() : identityProviderRef01DataDt0Loaded);
        Assert.True(identityProviderRef01DataDt0LoadResult != null, "expected load result to be a map");
        Assert.True(StructRunner.DeepEqual(identityProviderRef01DataDt0LoadResult!["id"], identityProviderRef01Data["id"]),
            "expected load result id to match");

        // REMOVE
        var identityProviderRef01MatchRm0 = new Dictionary<string, object?>
        {
            ["id"] = identityProviderRef01Data!["id"],
        };
        identityProviderRef01Ent.Remove(identityProviderRef01MatchRm0, null);

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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.IdentityProvider().Load(
            new Dictionary<string, object?> { ["alia"] = 1, ["realm"] = "x" }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup IdentityProviderBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "identity_provider",
            "IdentityProviderTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse identity_provider test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "identity_provider01", "identity_provider02", "identity_provider03", "alia01", "realm01" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_IDENTITY_PROVIDER_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_IDENTITY_PROVIDER_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_IDENTITY_PROVIDER_ENTID"])
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
