using Soenneker.Coordinators.Entities.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Coordinators.Entities.Tests;

[Collection("Collection")]
public class EntitiesCoordinatorTests : FixturedUnitTest
{
    private readonly IEntitiesCoordinator _util;

    public EntitiesCoordinatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IEntitiesCoordinator>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
