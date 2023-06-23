using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Ppt23.Client.Components;
using Ppt23.Shared;

namespace Ppt23TestProject
{
    public class UnitTest1 : TestContext
    {
        [Fact]
        public void VybaveRowRendersCorrectly()
        {

            
            var vyb = new VybaveniVm();

            
            var cut = RenderComponent<VybaveRow>(parameters => parameters
                .Add(p => p.Vyb, vyb)

            );
            

            // Assert
            Assert.Contains($"{vyb.Name}", cut.Markup);
            Assert.Contains("Smazat", cut.Markup);
        }

        [Fact]
        public void VybaveniDeleteButton()
        {
            // Arrange
            bool smazEventCallBack = false;
            VybaveniVm vybaveni = new VybaveniVm();

            var cut = RenderComponent<VybaveRow>(parameters => parameters
                .Add(p => p.Vyb, vybaveni)
                .Add(p => p.SmazEventCallback, EventCallback.Factory.Create(this, () => smazEventCallBack = true))
                );

            // Click
            var buttons = cut.FindAll("button");
            var deleteButton = buttons.FirstOrDefault(b => b.TextContent.Contains("Smazat"));
            deleteButton?.Click();

            // Assert
            Assert.True(smazEventCallBack);


        }
    }
}