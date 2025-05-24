using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using HomeWork.Models;
using HomeWork.Services;
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

        private readonly IDialogService _dialog;

        private string _playerName;
        public string PlayerName { get => _playerName; set => SetProp(value, ref _playerName); }

        public ObservableCollection<BioEntity> LeftSide { get; } = new ObservableCollection<BioEntity>(animals);

        public ObservableCollection<BioEntity> RightSide { get; } = new ObservableCollection<BioEntity>();
        public ObservableCollection<GameResult> GameResults { get; }

        private Direction _routeDirection;
        public Direction RouteDirection { get => _routeDirection; set => SetProp(value, ref _routeDirection); }

        private const string GAME_HISTORY_FILE = "gamehistory.txt";

        private BioEntity? _selectedPassanger;

        public BioEntity? SelectedPassanger { get => _selectedPassanger; set => SetProp(value, ref _selectedPassanger); }

        public DelegateCommand MoveToOtherSide { get; }

        public GameViewModel() : this(new DialogService())
        {
        }

        public static GameViewModel CreateForTests(IDialogService dialog) => new GameViewModel(dialog);

        private GameViewModel(IDialogService dialog)
        {
            _dialog = dialog;
            MoveToOtherSide = new DelegateCommand(Move);
            if (!File.Exists(GAME_HISTORY_FILE))
            {
                var stream = File.Create(GAME_HISTORY_FILE);
                stream.Dispose();
                GameResults = new ObservableCollection<GameResult>();
            }
            else
            {
                var lines = File.ReadAllLines(GAME_HISTORY_FILE);
                GameResults = new ObservableCollection<GameResult>(
                    lines.Select(GameResult.Parse)
                    );
            }
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
                    SaveGameResult(false);
                    if (_dialog.ShowYesNoDialog(title: "You won!", question: "Do you want to restart?"))
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
            SaveGameResult(true);
            if (_dialog.ShowYesNoDialog(title: "You wonlost", question: "Do you want to restart?"))
            {
                RestartGame();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        internal static bool IsGameLost(ObservableCollection<BioEntity> currentSide)
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

        private void SaveGameResult(bool isGameLost)
        {
            var currentDateTime = DateTime.Now;
            var result = new GameResult()
            {
                IsGameLost = isGameLost,
                Player = PlayerName,
                Date = currentDateTime
            };
            GameResults.Add(result);
            File.AppendAllLines(GAME_HISTORY_FILE, [result.ToString()]);
        }
    }
}
