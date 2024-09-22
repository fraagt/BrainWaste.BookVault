using BrainWaste.BookVault.Api.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BrainWaste.BookVault.Api.Data;

public class CreatedAtMsValueGenerator(ITimeService timeService) : ValueGenerator<long>
{
    public override bool GeneratesTemporaryValues => false;

    public override long Next(EntityEntry entry)
    {
        return timeService.GetCurrentTimeMs();
    }
}