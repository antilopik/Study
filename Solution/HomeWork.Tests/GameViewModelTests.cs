using HomeWork.Models;
using HomeWork.Tests.ServicesFakes;
using HomeWork.ViewModels;
using Shouldly;

namespace HomeWork.Tests
{
    public class GameViewModelTests
    {
        [Fact]
        public void GameViewModelTest()
        {
            var viewModel = GameViewModel.CreateForTests(new FakeDialog());
            viewModel.LeftSide.Count.ShouldBe(3);
            viewModel.RightSide.Count.ShouldBe(0);
            viewModel.RouteDirection.ShouldBe(Direction.LeftToRight);

            viewModel.MoveToOtherSide.Execute(null);
            GameViewModel.IsGameLost(viewModel.LeftSide).ShouldBe(true);
            viewModel.LeftSide.Count.ShouldBe(3);
            viewModel.RightSide.Count.ShouldBe(0);
        }
    }
}