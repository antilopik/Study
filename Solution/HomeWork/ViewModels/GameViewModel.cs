using System.Collections.ObjectModel;
using HomeWork.Models;
using Model.View.ViewModel.Base;
using Model.View.ViewModel.Base.Commands;

namespace HomeWork.ViewModels
{
    internal sealed class GameViewModel : ViewModelBase
    {
        public ObservableCollection<BioEntity> LeftSide { get; } = new ObservableCollection<BioEntity>()
        {
            { new Wolf() },
            { new Cabbage() },
            { new Sheep() }
        };

        public ObservableCollection<BioEntity> RightSide { get; } = new ObservableCollection<BioEntity>();

        private Direction _routeDirection;
        public Direction RouteDirection { get => _routeDirection; set => SetProp(value, ref _routeDirection); }

        private BioEntity? _selectedPassanger;

        public BioEntity? SelectedPassanger { get => _selectedPassanger; set => SetProp(value, ref _selectedPassanger); }

        public DelegateCommand MoveToOtherSide { get; }

        public GameViewModel()
        {
            MoveToOtherSide = new DelegateCommand(Move);
        }

        private void Move(object? parameter)
        {
            if (RouteDirection == Direction.LeftToRight)
            {
                RightSide.Add(SelectedPassanger);
                LeftSide.Remove(SelectedPassanger);
                RouteDirection = Direction.RightToLeft;
            }
            else
            {
                LeftSide.Add(SelectedPassanger);
                RightSide.Remove(SelectedPassanger);
                RouteDirection = Direction.LeftToRight;
            }
        }
    }
}
