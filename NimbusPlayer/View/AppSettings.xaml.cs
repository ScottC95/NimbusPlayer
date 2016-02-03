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
using System.Windows.Shapes;
using NimbusPlayer.Properties;
using System.ComponentModel;
using System.Windows.Forms;
using NimbusPlayer.ViewModel;

namespace NimbusPlayer.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AppSettings : INotifyPropertyChanged
    {
        public AppSettings()
        {
            InitializeComponent();
            DataContext = this;
            SelectedPath = Settings.Default.MusicFilePath;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var browser = new System.Windows.Forms.FolderBrowserDialog();
            browser.SelectedPath = SelectedPath;
            DialogResult result = browser.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                SelectedPath = browser.SelectedPath;

        }

        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                if (value != _selectedPath)
                {
                    _selectedPath = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedPath"));
                        Settings.Default.MusicFilePath = value;
                        Settings.Default.Save();
                        Settings.Default.Reload();
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
