using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Bricelam.EntityFrameworkCore.Design
{
    /// <summary>
    /// Used to the configure design-time services for this library.
    /// </summary>
    public class EFCorePluralizerServices : IDesignTimeServices
    {
        /// <summary>
        /// Adds this library's design-time services to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        public void ConfigureDesignTimeServices(IServiceCollection services)
            => services.AddSingleton<IPluralizer, Pluralizer>();
    }
}
