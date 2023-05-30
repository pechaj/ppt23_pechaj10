using Bunit;
using Ppt23.Client.Components;
using Ppt23.Client.Pages;
using Ppt23.Shared;

namespace Ppt23TestProject
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public void VybaveRowRendersCorrectly()
        {

            // Arrange
            var vyb = new VybaveniVm();

            // Act
            var cut = RenderComponent<VybaveRow>(parameters => parameters
                .Add(p => p.Vyb, vyb)

            );
            

            // Assert
            //Assert.NotNull(cut.Find("grid-cols-6"));
            Assert.Contains($"{vyb.Name}", cut.Markup);
        }

        [Fact]
        public void VybaveniDetailRevizesRendersCorrectly()
        {
            var vyb = new VybaveniSRevizemaVm();

            var rev = new RevizeViewModel
            {
                Id = Guid.NewGuid(),
                Name = "test",
                DateTime = DateTime.Now,
            };


            vyb.Revizes.Add(rev);

            var cut = RenderComponent<VybaveniDetail>(parameters => parameters
                .Add(p => p._RevVyb, vyb));
            

            if (vyb.Revizes.Any())
            {
                Assert.Contains($"{vyb.Revizes.Last().Id}", cut.Markup);
            }
            else
            {
                Assert.Empty(vyb.Revizes);
            }
        }
    }
}