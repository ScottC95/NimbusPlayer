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

namespace NimbusPlayer.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AppSettings : Window
    {
        public AppSettings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var browser = new System.Windows.Forms.FolderBrowserDialog();
            browser.SelectedPath = Settings.Default["MusicFilePath"].ToString();
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
                    Settings.Default["MusicFilePath"] = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
