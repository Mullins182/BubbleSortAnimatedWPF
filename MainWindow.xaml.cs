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
        public List<int> unsortedIntegerList = new List<int>()
        {   505,  888,  203,  744,  216,  449,  197,  500,  284,  548,  159,  845,  159,  949,  691,  981,  324,  563,  854,  468,  117,  465,  502,  413,  232,
            645,  848,  646,  549,  765,  225,  437,  681,  2,  44,  362,  845,  895,  627,  43,  708,  883,  950,  268,  814,  747,  689,  568,  504,  234,  781,
            780,  574,  759,  937,  95,  761,  934,  936,  523,  459,  55,  698,  551,  111,  649,  499,  879,  77,  446,  89,  503,  917,  1,  988,  435,  689,
            797,  950,  885,  501,  706,  84,  771,  782,  380,  916,  484,  525,  135,  495,  265,  428,  389,  662,  411,  876,  604, 650, 915
        };

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

        private async void BubbleSorting(List<int> unsortedIntegerList)
        {
            List<int> sortingList = new List<int>();
            
            int buffer = 0;

            for(int i = 120; i > 0; i--)
            {
                BubbleSortBox.Clear();

                for (int x = 0; x < unsortedIntegerList.Count() - 1; x++) 
                {
                    buffer = unsortedIntegerList[x];

                    if(x == unsortedIntegerList.Count())
                    {
                        continue;
                    }
                    else
                    {
                        if (unsortedIntegerList[x+1] < buffer)
                        {
                            unsortedIntegerList[x]      = unsortedIntegerList[x+1];
                            unsortedIntegerList[x+1]  = buffer;
                        }
                    }
                }

                BubbleSortBox.AppendText("\n\n");

                foreach (var item in unsortedIntegerList)
                {
                    BubbleSortBox.AppendText($"\t{item}");
                }

                await Task.Delay(250);
            }
        }
    }
}