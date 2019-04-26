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

namespace CItyTrafficSimulator.Windows
{
    /// <summary>
    /// Interaction logic for ExpWithAlgWindow.xaml
    /// </summary>
    public partial class ExpWithAlgWindow : Window
    {
        private MainWindow _mainWindow;
        public ExpWithAlgWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Closed += OnWindowClosed;
        }

        private void OnWindowClosed(object sender, System.EventArgs e)
        {
            _mainWindow.Show();
        }
    }
}
