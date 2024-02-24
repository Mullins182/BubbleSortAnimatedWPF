using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BubbleSortAnimatedWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.SizeChanged += OnWindowSizeChanged;
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowWidth   = e.NewSize.Width;
            double newWindowHeight  = e.NewSize.Height;
            //double prevWindowWidth  = e.PreviousSize.Width;
            //double prevWindowHeight = e.PreviousSize.Height;


            Thickness newBoxMargin  = BubbleSortBox.Margin;

            newBoxMargin.Left = (newWindowWidth  / 2) - (BubbleSortBox.ActualWidth  / 2) - 8;
            newBoxMargin.Top  = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 19.5;

            BubbleSortBox.Margin = newBoxMargin;

            BubbleSortBox.Text = "\n\nW-Width: " + newWindowWidth.ToString() + "\nBox-Width: " + BubbleSortBox.Margin.ToString();
        }
    }
}