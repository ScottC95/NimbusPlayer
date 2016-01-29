using System.Collections.ObjectModel;
using NimbusPlayer.DataAccess;
using NimbusPlayer.DataAccess.Implementation;

namespace NimbusPlayer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly SongFilesRepository _songFilesRepository;

        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            _songFilesRepository = new SongFilesRepository();
            //SongListViewModel viewModel = new SongListViewModel(_songFilesRepository);
            //this.ViewModels.Add(viewModel);
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>(); 
                }
                return _viewModels;
            }
        }
    }
}
