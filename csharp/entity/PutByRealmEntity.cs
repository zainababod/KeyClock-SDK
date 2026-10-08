// PutByRealm entity client for the VoxgigKeycloakSdk SDK.

using Voxgig.Struct;

namespace VoxgigKeycloakSdkSdk.Entity;

public class PutByRealmEntity : VoxgigKeycloakSdkEntityBase
{
    public PutByRealmEntity(VoxgigKeycloakSdkSDK client, Dictionary<string, object?>? entopts = null)
        : base(client, entopts, "put_by_realm")
    {
    }

    public override IEntity Make()
    {
        return new PutByRealmEntity(client, CloneOpts());
    }

    // (load not defined by this API - base class throws UnsupportedOp)

    // (list not defined by this API - base class throws UnsupportedOp)

    // (create not defined by this API - base class throws UnsupportedOp)

    public override object? Update(Dictionary<string, object?>? reqdata,
        Dictionary<string, object?>? ctrl = null)
    {
        var ctx = utility.MakeContext(new Dictionary<string, object?>
        {
            ["opname"] = "update",
            ["ctrl"] = ctrl,
            ["match"] = match,
            ["data"] = data,
            ["reqdata"] = reqdata,
        }, entctx);
    
        return RunOp(ctx, () =>
        {
            if (ctx.Result != null)
            {
                if (ctx.Result.Resmatch != null)
                {
                    match = ctx.Result.Resmatch;
                }
                if (ctx.Result.Resdata != null)
                {
                    data = Helpers.ToMapAny(
                        Voxgig.Struct.StructUtils.Clone(ctx.Result.Resdata))
                        ?? new Dictionary<string, object?>();
                }
            }
        });
    }

    // (patch not defined by this API - base class throws UnsupportedOp)

    // (remove not defined by this API - base class throws UnsupportedOp)
}
