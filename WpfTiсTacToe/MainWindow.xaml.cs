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

namespace WpfTiсTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicTacToeOperator ticTacToe;

        int iCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
            ticTacToe = new TicTacToeOperator();
        }

        private void Button00_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                // 1-st turn for X
                if (iCounter%2 == 0)
                {
                    button.Background = Brushes.Coral;
                    button.Content = "X";
                    ticTacToe.SetX(Grid.GetRow(button), Grid.GetColumn(button));
                }
                if (iCounter%2 != 0)
                {
                    button.Background = Brushes.ForestGreen;
                    button.Content = "O";
                    ticTacToe.SetO(Grid.GetRow(button), Grid.GetColumn(button));
                }
                button.IsEnabled = false;
                iCounter++;
                if (ticTacToe.Inspection(Grid.GetRow(button), Grid.GetColumn(button)))
                {
                    MessageBox.Show("Victory!!! :)");
                    iCounter++;
                    this.Close();
                }
                if (iCounter == 9)
                {
                    MessageBox.Show("Draw :/");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
