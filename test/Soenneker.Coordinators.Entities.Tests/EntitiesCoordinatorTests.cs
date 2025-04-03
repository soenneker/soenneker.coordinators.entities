using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Coordinators.Entities.Tests;

[Collection("Collection")]
public class EntitiesCoordinatorTests : FixturedUnitTest
{
    public EntitiesCoordinatorTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
