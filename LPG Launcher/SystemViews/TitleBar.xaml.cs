using LPG_Launcher.ViewModels;
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

namespace LPG_Launcher.SystemViews
{
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        private Window parentWindow;
        public TitleBar()
        {
            InitializeComponent();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            parentWindow = App.Current.MainWindow;
        }

        private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            parentWindow.WindowState = WindowState.Minimized;
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            parentWindow.Close();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                parentWindow.DragMove();
        }
    }
}
