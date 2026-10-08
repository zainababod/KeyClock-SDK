// VoxgigKeycloakSdk SDK exists test.

using Xunit;

using VoxgigKeycloakSdkSdk;

namespace VoxgigKeycloakSdkSdk.Test;

public class ExistsTest
{
    [Fact]
    public void TestMode()
    {
        var testsdk = VoxgigKeycloakSdkSDK.TestSDK(null, null);
        Assert.NotNull(testsdk);
    }
}
