using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for ExpWithoutAlgWindow.xaml
    /// </summary>
    public partial class ExpWithoutAlgWindow : Window
    {
        private MainWindow _mainWindow;
        public ExpWithoutAlgWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Closed += OnWindowClosed;
        }

        public void OnWindowClosed(object sender, System.EventArgs e)
        {
            _mainWindow.Show();
        }


    }
}
