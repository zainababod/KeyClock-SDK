// UserSession entity client for the VoxgigKeycloakSdk SDK.

using Voxgig.Struct;

namespace VoxgigKeycloakSdkSdk.Entity;

public class UserSessionEntity : VoxgigKeycloakSdkEntityBase
{
    public UserSessionEntity(VoxgigKeycloakSdkSDK client, Dictionary<string, object?>? entopts = null)
        : base(client, entopts, "user_session")
    {
    }

    public override IEntity Make()
    {
        return new UserSessionEntity(client, CloneOpts());
    }

    // (load not defined by this API - base class throws UnsupportedOp)

    public override object? List(Dictionary<string, object?>? reqmatch,
        Dictionary<string, object?>? ctrl = null)
    {
        var ctx = utility.MakeContext(new Dictionary<string, object?>
        {
            ["opname"] = "list",
            ["ctrl"] = ctrl,
            ["match"] = match,
            ["data"] = data,
            ["reqmatch"] = reqmatch,
        }, entctx);
    
        return RunOp(ctx, () =>
        {
            if (ctx.Result != null)
            {
                if (ctx.Result.Resmatch != null)
                {
                    match = ctx.Result.Resmatch;
                }
            }
        });
    }

    // (create not defined by this API - base class throws UnsupportedOp)

    // (update not defined by this API - base class throws UnsupportedOp)

    // (patch not defined by this API - base class throws UnsupportedOp)

    // (remove not defined by this API - base class throws UnsupportedOp)
}
