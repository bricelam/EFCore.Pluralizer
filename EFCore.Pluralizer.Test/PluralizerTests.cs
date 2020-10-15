using Xunit;

namespace Bricelam.EntityFrameworkCore.Design
{
    public class PluralizerTests
    {
        [Fact]
        public void Pluralize_works()
            => Assert.Equal("Tests", new Pluralizer().Pluralize("Test"));

        [Fact]
        public void Singularize_works()
            => Assert.Equal("Test", new Pluralizer().Singularize("Tests"));
        [Fact]
        public void Pluralize_status()
            => Assert.Equal("Statuses", new Pluralizer().Pluralize("Status"));

        [Fact]
        public void Singularize_status()
            => Assert.Equal("Status", new Pluralizer().Singularize("Statuses"));
    }
}
