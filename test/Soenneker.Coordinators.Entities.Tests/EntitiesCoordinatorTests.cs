using Soenneker.Tests.HostedUnit;

namespace Soenneker.Coordinators.Entities.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class EntitiesCoordinatorTests : HostedUnitTest
{
    public EntitiesCoordinatorTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
