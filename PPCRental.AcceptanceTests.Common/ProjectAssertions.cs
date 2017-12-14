using System.Linq;
using System.Collections.Generic;
using PPCRental.Models;
using FluentAssertions;

namespace PPCRental.AcceptanceTests.Common
{
    public class ProjectAssertions
    {
        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> actualProjects, IEnumerable<string> expectedProjects)
        {
            actualProjects.Select(p => p.PropertyName).Should().BeEquivalentTo(actualProjects);
        }
    }
}
