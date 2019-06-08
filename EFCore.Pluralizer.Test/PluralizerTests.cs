using Xunit;

namespace Bricelam.EntityFrameworkCore.Design
{
    public class PluralizerTests
    {
        [Theory]
        [InlineData("Tests", "Test")]
        [InlineData("Statuses", "Status")]
        [InlineData("ItemStatuses", "ItemStatus")]
        [InlineData("Statuses", "Statuses")]
        [InlineData("ItemStatuses", "ItemStatuses")]
        public void Pluralize_works(string result, string input)
            => Assert.Equal(result, new Pluralizer().Pluralize(input));

        [Theory]
        [InlineData("Test", "Tests")]
        [InlineData("Status", "Statuses")]
        [InlineData("ItemStatus", "ItemStatuses")]
        [InlineData("Status", "Status")]
        [InlineData("ItemStatus", "ItemStatus")]
        public void Singularize_works(string result, string input)
            => Assert.Equal(result, new Pluralizer().Singularize(input));
    }
}