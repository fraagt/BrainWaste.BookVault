namespace BrainWaste.BookVault.Api.Services.Impls;

public class SystemTimeService : ITimeService
{
    public long GetCurrentTimeMs()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}