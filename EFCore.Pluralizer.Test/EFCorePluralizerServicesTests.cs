using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Bricelam.EntityFrameworkCore.Design
{
    public class EFCorePluralizerServicesTests
    {
        [Fact]
        public void ConfigureDesignTimeServices_works()
        {
            var serviceCollection = new ServiceCollection();

            new EFCorePluralizerServices().ConfigureDesignTimeServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            Assert.IsType<Pluralizer>(serviceProvider.GetService<IPluralizer>());
        }
    }
}
