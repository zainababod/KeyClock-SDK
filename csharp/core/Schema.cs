// VoxgigKeycloakSdk SDK - generated schemas. GENERATED from the API model -
// do not edit by hand.
//
// Built from the model: `main.kit.optspec` and each feature's
// `config.options` for Optspec; entity `fields{}.type` for Entityspec.

namespace VoxgigKeycloakSdkSdk;

public static class SdkSchema
{
    // Built ONCE, on first use. The spec is read on every client construction
    // and never mutated, so rebuilding it per call would be pure waste — and
    // a shared dictionary is safe for the same reason the spec is a constant:
    // MakeOptions validates AGAINST it and writes into the options, never
    // into the spec.
    //
    // A static field initializer, so the CLR's type initializer gives the
    // once-only, thread-safe guarantee with no locking on the read path.

    /// <summary>The option spec MakeOptions validates client options against.</summary>
    public static readonly Dictionary<string, object?> Optspec =
        new Dictionary<string, object?>
        {
            ["allow"] = new Dictionary<string, object?>
            {
                ["method"] = "GET,PUT,POST,PATCH,DELETE,OPTIONS",
                ["op"] = "create,update,patch,load,list,remove,command,direct,graphql",
            },
            ["apikey"] = "",
            ["auth"] = new Dictionary<string, object?>
            {
                ["basic"] = false,
                ["in"] = "",
                ["name"] = "",
                ["prefix"] = "",
            },
            ["base"] = "http://localhost:8000",
            ["clean"] = new Dictionary<string, object?>
            {
                ["active"] = true,
                ["hint"] = "0",
                ["keys"] = "key,secret,token,password,passwd,authorization,cookie,credential,signature",
                ["mask"] = "[redacted]",
                ["min"] = "4",
                ["values"] = "",
            },
            ["entity"] = new Dictionary<string, object?>
            {
                ["`$CHILD`"] = new Dictionary<string, object?>
                {
                    ["`$OPEN`"] = true,
                    ["active"] = false,
                    ["alias"] = new Dictionary<string, object?>(),
                },
            },
            ["extend"] = "`$ANY`",
            ["headers"] = new Dictionary<string, object?>
            {
                ["`$CHILD`"] = "`$STRING`",
            },
            ["prefix"] = "",
            ["secret"] = "",
            ["server"] = new Dictionary<string, object?>
            {
                ["`$CHILD`"] = "",
            },
            ["suffix"] = "",
            ["system"] = new Dictionary<string, object?>
            {
                ["fetch"] = "`$ANY`",
            },
            ["test"] = new Dictionary<string, object?>
            {
                ["active"] = false,
                ["entity"] = new Dictionary<string, object?>
                {
                    ["`$OPEN`"] = true,
                },
            },
            ["utility"] = new Dictionary<string, object?>(),
            ["feature"] = new Dictionary<string, object?>
            {
                ["`$CHILD`"] = new Dictionary<string, object?>
                {
                    ["`$OPEN`"] = true,
                    ["active"] = false,
                },
                ["test"] = new List<object?>
                {
                    "`$ONE`",
                    new Dictionary<string, object?>
                    {
                        ["`$OPEN`"] = true,
                        ["active"] = new List<object?>
                        {
                            "`$ONE`",
                            "`$BOOLEAN`",
                            "`$NIL`",
                        },
                        ["entity"] = new List<object?>
                        {
                            "`$ONE`",
                            "`$MAP`",
                            "`$NIL`",
                        },
                        ["net"] = new List<object?>
                        {
                            "`$ONE`",
                            "`$MAP`",
                            "`$NIL`",
                        },
                    },
                    "`$NIL`",
                },
            },
        };

    /// <summary>Per-entity data and request specs, keyed by entity name.</summary>
    public static readonly Dictionary<string, object?> Entityspec =
        new Dictionary<string, object?>();
}
