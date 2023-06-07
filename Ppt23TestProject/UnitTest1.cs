using Bunit;
using Mapster;
using Ppt23.Client.Components;
using Ppt23.Client.Pages;
using Ppt23.Shared;
using System.ComponentModel;

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
        }

        // chce to Mock HTTP klienta, nedok�e to po�kat na dokon�en� OnInitialisedAsync()
        /*[Fact]
        public void VybaveniCountCorrect()
        {
            var vybVm = new VybaveniVm();
            List<VybaveniVm> seznamVms = new List<VybaveniVm>();

            var textService = new TaskCompletionSource<string>();

            var cut = RenderComponent<VybaveniNemocnice>(parameters => parameters
                .Add(p => p._seznamVybaveni, seznamVms));

            textService.SetResult("Po�et vybaven�");
            cut.WaitForState(() => cut.Find("<div>").TextContent == "Po�et vybaven�: 1");

            //Assert.Contains("Po�et vybaven�: 1", cut.Markup);
            cut.MarkupMatches("<div>Po�et vybaven�: 1</div>");

        }*/
    }
}