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
        List<int> unsortedIntegerList = new List<int>() {5,200,547,3,6,7,123,444,856};

        public MainWindow()
        {
            InitializeComponent();

            this.SizeChanged += OnWindowSizeChanged;

            BubbleSorting(unsortedIntegerList);
        }

        // Event-Methode wenn Fenstergröße sich ändert ! In der Methode wird die Bubblesort Box und das Label dafür responsiv gemacht (Abhängig von Fenstergröße)
        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowWidth       = e.NewSize.Width;
            double newWindowHeight      = e.NewSize.Height;
            //double prevWindowWidth    = e.PreviousSize.Width;
            //double prevWindowHeight   = e.PreviousSize.Height;


            Thickness newBoxMargin      = BubbleSortBox.Margin;
            Thickness newLabelMargin    = BubbleSortBox.Margin;

            newBoxMargin.Left           = (newWindowWidth  / 2) - (BubbleSortBox.ActualWidth  / 2) - 8;
            newBoxMargin.Top            = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 19.5;
            newLabelMargin.Left         = (newWindowWidth / 2)  - (BubbleSortBox.ActualWidth / 5);
            newLabelMargin.Top          = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 20;

            BubbleSortBox.Margin        = newBoxMargin;
            BubbleSortBoxLabel.Margin   = newLabelMargin;

            //BubbleSortBox.Text = "\n\nW-Width: " + newWindowWidth.ToString() + "\nBox-Width: " + BubbleSortBox.Margin.ToString();
        }

        private void BubbleSorting(List<int> unsortedIntegerList)
        {
            List<int> sortingList = new List<int>();
            
            int buffer = 0;

            for(int i = 100; i >= 0; i--)
            {
                sortingList.Clear();

                for(int x = 0; x < unsortedIntegerList.Count() - 1; x++) 
                {
                    buffer = unsortedIntegerList[x];

                    if(unsortedIntegerList.Count() == x + 1)
                    {
                        continue;
                    }
                    else
                    {
                        if (unsortedIntegerList[x + 1] < buffer)
                        {
                            sortingList.Add(unsortedIntegerList[x + 1]);
                            sortingList.Add(buffer);
                        }
                    }
                }

                BubbleSortBox.Clear();
                BubbleSortBox.AppendText("\n\n\n");

                foreach (var item in sortingList)
                {
                    BubbleSortBox.AppendText($"\t{item}");
                    Task.Delay(500);
                }
            }
        }
    }
}