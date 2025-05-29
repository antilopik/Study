using HomeWork.Models;
using HomeWork.Tests.ServicesFakes;
using HomeWork.ViewModels;
using Shouldly;

namespace HomeWork.Tests
{
    public class GameViewModelTests
    {
        private static void TransferPassenger<TPassenger>(GameViewModel viewModel, Direction direction)
            where TPassenger : BioEntity
        {
            IReadOnlyList<BioEntity> from;
            switch (direction)
            {
                case Direction.LeftToRight:
                    from = viewModel.LeftSide;
                    break;
                case Direction.RightToLeft:
                    from = viewModel.RightSide;
                    break;
                default:
                    throw new NotImplementedException();
            }

            viewModel.SelectedPassanger = from.First(x => x is TPassenger);
            viewModel.MoveToOtherSide.Execute(null);
        }

        [Fact]
        public void GameEndConditionsTest()
        {
            var viewModel = GameViewModel.CreateForTests(new FakeDialog(), new FakeFileService());
            viewModel.LeftSide.Count.ShouldBe(3);
            viewModel.RightSide.Count.ShouldBe(0);
            viewModel.RouteDirection.ShouldBe(Direction.LeftToRight);

            viewModel.MoveToOtherSide.Execute(null);
            GameViewModel.IsGameLost(viewModel.LeftSide).ShouldBe(true);
            viewModel.LeftSide.Count.ShouldBe(3);
            viewModel.RightSide.Count.ShouldBe(0);
        }

        [Fact]
        public void GameLostSaveResultsTest()
        {
            var testPlayer = "Test Player Name";
            var fakeFileService = new FakeFileService();
            var viewModel = GameViewModel.CreateForTests(new FakeDialog(), fakeFileService);
            viewModel.PlayerName = testPlayer;
            TransferPassenger<Cabbage>(viewModel, Direction.LeftToRight);
            
            fakeFileService.LastSavedResult!.IsGameLost.ShouldBe(true);
            fakeFileService.LastSavedResult.Player.ShouldBe(testPlayer);
        }
        
        
        [Fact]
        public void GameWonSaveResultsTest()
        {
            var testPlayer = "Test Player Name";
            var fakeFileService = new FakeFileService();
            var viewModel = GameViewModel.CreateForTests(new FakeDialog(), fakeFileService);
            viewModel.PlayerName = testPlayer;
            TransferPassenger<Sheep>(viewModel, Direction.LeftToRight);
            viewModel.SelectedPassanger = null;
            viewModel.MoveToOtherSide.Execute(null);
            TransferPassenger<Cabbage>(viewModel, Direction.LeftToRight);
            TransferPassenger<Sheep>(viewModel, Direction.RightToLeft);
            TransferPassenger<Wolf>(viewModel, Direction.LeftToRight);
            viewModel.SelectedPassanger = null;
            viewModel.MoveToOtherSide.Execute(null);
            TransferPassenger<Sheep>(viewModel, Direction.LeftToRight);
            
            fakeFileService.LastSavedResult!.IsGameLost.ShouldBe(false);
            fakeFileService.LastSavedResult.Player.ShouldBe(testPlayer);
        }
    }
}