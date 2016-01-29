using NimbusPlayer.Model;
using NimbusPlayer.View;
using NimbusPlayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NimbusPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PlayerViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new PlayerViewModel();
            InitializeComponent();
            DataContext = _viewModel;
        }


        private void Album_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listView = sender as ListView;
            if (listView != null)
            {
                _viewModel.AddToPlaylist(listView.SelectedItem as Album);
            }
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as DataGrid;

            if (grid != null)
            {
                var song = grid.SelectedItem as SongViewModel;
                _viewModel.GetSelectedSong(song);
            }
        }

        private void DataGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var listView = sender as ListView;

            if (listView != null)
            {
                var selectedItem = listView.SelectedItem;
            }
        }

        private void SongProgress_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Settings_Click(object sender, MouseButtonEventArgs e)
        {
            AppSettings settings = new AppSettings();
            settings.Show();
        }
    }
}
