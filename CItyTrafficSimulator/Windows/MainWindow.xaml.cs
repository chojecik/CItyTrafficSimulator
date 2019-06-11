using CItyTrafficSimulator.Windows;
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

namespace CItyTrafficSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExpWithoutAlg_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ExperimentWindow experimentWindow = new ExperimentWindow(this, false);
            experimentWindow.Show();
           
        }

        private void ExpWithAlg_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            ExperimentWindow experimentWindow = new ExperimentWindow(this, true);
            experimentWindow.Show();
        }
    }
}
