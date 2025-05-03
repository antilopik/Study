using System.Collections.ObjectModel;
using HomeWork.Models;
using Model.View.ViewModel.Base;

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
    }
}
