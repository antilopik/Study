using System.Collections.ObjectModel;
using System.Windows;
using HomeWork.Models;
using Model.View.ViewModel.Base;
using Model.View.ViewModel.Base.Commands;

namespace HomeWork.ViewModels
{
    internal sealed class GameViewModel : ViewModelBase
    {
        public static readonly List<BioEntity> animals = new List<BioEntity>()
        {
            { new Wolf() },
            { new Cabbage() },
            { new Sheep() }
        };


        private string _playerName;
        public string PlayerName { get => _playerName; set => SetProp(value, ref _playerName); }

        public ObservableCollection<BioEntity> LeftSide { get; } = new ObservableCollection<BioEntity>(animals);

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
                if (SelectedPassanger != null)
                {
                    RightSide.Add(SelectedPassanger);
                    LeftSide.Remove(SelectedPassanger);
                }
                // тут пока еше RouteDirection это текущее положение лодочника
                if (RightSide.Count == 3)
                {
                    if (MessageBox.Show("Do you want to restart?", "You won!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        RestartGame();
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                    return;
                }
                else if (IsGameLost(LeftSide))
                {
                    ProcessLoose();
                    return;
                }
                //после следующей строки RouteDirection это куда лодочник поплывет в следующий раз
                RouteDirection = Direction.RightToLeft;
            }
            else
            {
                if (SelectedPassanger != null)
                {
                    LeftSide.Add(SelectedPassanger);
                    RightSide.Remove(SelectedPassanger);
                }
                // тут пока еше RouteDirection это текущее положение лодочника
                if (IsGameLost(RightSide))
                {
                    ProcessLoose();
                    return;
                }
                //после следующей строки RouteDirection это куда лодочник поплывет в следующий раз
                RouteDirection = Direction.LeftToRight;
            }
        }

        private void ProcessLoose()
        {
            var date = DateTime.Now;
            if (MessageBox.Show("Do you want to restart?", "You lost!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                RestartGame();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        static bool IsGameLost(ObservableCollection<BioEntity> currentSide)
        {
            for (int i = 0; i < currentSide.Count; i++)
            {
                BioEntity current = currentSide[i];
                for (int j = i + 1; j < currentSide.Count; j++)
                {
                    if (current.CanEat(currentSide[j]))
                    {
                        Console.WriteLine($"{current} has eaten {currentSide[j]}");
                        return true;
                    }
                    else if (currentSide[j].CanEat(current))
                    {
                        Console.WriteLine($"{currentSide[j]} has eaten {current}");
                        return true;
                    }
                }
            }

            return false;
        }

        private void RestartGame()
        {
            SelectedPassanger = null;
            RouteDirection = Direction.LeftToRight;
            RightSide.Clear();
            LeftSide.Clear();
            animals.ForEach(x => LeftSide.Add(x));
        }
    }
}
