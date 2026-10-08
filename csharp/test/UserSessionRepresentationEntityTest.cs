// user_session_representation entity test - basic flow (generated from the API model).

using System.Text.Json;

using VoxgigKeycloakSdkSdk.Feature;
using Voxgig.Struct;
using Xunit;

namespace VoxgigKeycloakSdkSdk.Test;

public class UserSessionRepresentationEntityTest
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
        var ent = testsdk.UserSessionRepresentation();
        Assert.NotNull(ent);
    }

    [Fact]
    public void Basic()
    {
        var setup = UserSessionRepresentationBasicSetup(null);
        // Bootstrap entity data from existing test data (no create step in flow).
        var userSessionRepresentationRef01DataRaw = StructUtils.Items(
            Helpers.ToMapAny(StructUtils.GetPath(setup.Data, "existing.user_session_representation")));
        var userSessionRepresentationRef01Data = userSessionRepresentationRef01DataRaw.Count > 0
            ? Helpers.ToMapAny(userSessionRepresentationRef01DataRaw[0][1])
            : null;

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
        var err = Assert.ThrowsAny<VoxgigKeycloakSdkError>(() => client.UserSessionRepresentation().List(
            new Dictionary<string, object?> { ["client_id"] = 1, ["realm"] = "x" }, null));
        Assert.Equal("validate_failed", err.Code);
    }

    private static EntityTestSetup UserSessionRepresentationBasicSetup(
        Dictionary<string, object?>? extra)
    {
        TestRunner.LoadEnvLocal();

        var entityDataFile = Path.Combine(TestRunner.TestDir(),
            "..", "..", ".sdk", "test", "entity", "user_session_representation",
            "UserSessionRepresentationTestData.json");

        var entityDataEl = JsonSerializer.Deserialize<JsonElement>(
            File.ReadAllText(entityDataFile));
        var entityData = StructRunner.ConvertElement(entityDataEl)
            as Dictionary<string, object?>
            ?? throw new InvalidOperationException(
                "failed to parse user_session_representation test data");

        var options = new Dictionary<string, object?>
        {
            ["entity"] = entityData["existing"],
        };

        var client = VoxgigKeycloakSdkSDK.TestSDK(options, extra);

        // Generate idmap via transform, matching the TS pattern.
        var idmap = StructUtils.Transform(
            new List<object?> { "user_session_representation01", "user_session_representation02", "user_session_representation03", "client01", "client02", "client03", "user01", "user02", "user03" },
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
            "VOXGIG_KEYCLOAK_SDK_TEST_USER_SESSION_REPRESENTATION_ENTID") ?? "";
        var idmapOverridden = entidEnvRaw != "" &&
            entidEnvRaw.Trim().StartsWith("{");

        var env = TestRunner.EnvOverride(new Dictionary<string, object?>
        {
            ["VOXGIG_KEYCLOAK_SDK_TEST_USER_SESSION_REPRESENTATION_ENTID"] = idmap,
            ["VOXGIG_KEYCLOAK_SDK_TEST_LIVE"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_TEST_EXPLAIN"] = "FALSE",
            ["VOXGIG_KEYCLOAK_SDK_APIKEY"] = "",
        });

        var idmapResolved = Helpers.ToMapAny(env["VOXGIG_KEYCLOAK_SDK_TEST_USER_SESSION_REPRESENTATION_ENTID"])
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
