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
            797,  950,  885,  501,  706,  84,  771,  782,  380,  916,  484,  525,  135,  495,  265,  428,  389,  662,  411,  876,  604, 650, 915, 637, 999
        };

        bool bubblesort_active = false;

        public MainWindow()
        {
            InitializeComponent();

            this.SizeChanged += OnWindowSizeChanged;
        }

        // Event-Methode wenn Fenstergröße sich ändert ! In der Methode wird die Bubblesort Box und das Label dafür responsiv gemacht (Abhängig von Fenstergröße)
        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowWidth = e.NewSize.Width;
            double newWindowHeight = e.NewSize.Height;
            //double prevWindowWidth    = e.PreviousSize.Width;
            //double prevWindowHeight   = e.PreviousSize.Height;


            Thickness newBoxMargin = BubbleSortBox.Margin;
            Thickness newLabelMargin = BubbleSortBox.Margin;

            newBoxMargin.Left = (newWindowWidth / 2) - (BubbleSortBox.ActualWidth / 2) - 330;
            newBoxMargin.Top = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 19.5;
            newLabelMargin.Left = (newWindowWidth / 2) - (BubbleSortBox.ActualWidth / 6) + 40;
            newLabelMargin.Top = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 20;

            BubbleSortBox.Margin = newBoxMargin;
            BubbleSortBoxLabel.Margin = newLabelMargin;

            //BubbleSortBox.Text = "\n\nW-Width: " + newWindowWidth.ToString() + "\nBox-Width: " + BubbleSortBox.Margin.ToString();
        }

        private async void BubbleSorting(List<int> unsortedIntegerList)
        {
            List<int> sortingList = new List<int>();

            int buffer  = 0;

            int counter = 1;

            BubbleSortBox.Clear();

            BubbleSortBox.AppendText("\n\n");

            foreach (var item in unsortedIntegerList)
            {
                sortingList.Add(item);
            }

            foreach (var item in sortingList)
            {

                if(counter % 8 == 0)
                {
                    BubbleSortBox.AppendText($"\n{item}\t");
                }

                BubbleSortBox.AppendText($"{item}\t");

                counter++;
            }

            TaskPercentCompleted.Content = $"Algorithmus Fortschritt: {0}%";

            await Task.Delay(3000);

            BubbleSortBoxLabel.Foreground = Brushes.GreenYellow;

            for(int i = 0; i <= 100; i++)
            {
                if(!bubblesort_active)
                {
                    while (!bubblesort_active)
                    {
                        //Thread.Sleep(250);
                        await Task.Delay(250);
                    }
                }

                if(i % 100 == 0 && i != 0)
                {
                    TaskPercentCompleted.Content = $"Algorithmus Fortschritt: {100}%";
                }
                else
                {
                    TaskPercentCompleted.Content = $"Algorithmus Fortschritt: {i % 100}%";
                }

                BubbleSortBox.Clear();

                for (int x = 0; x < sortingList.Count() - 1; x++) 
                {
                    buffer = sortingList[x];

                    if(x == sortingList.Count())
                    {
                        continue;
                    }
                    else
                    {
                        if (sortingList[x+1] < buffer)
                        {
                            sortingList[x]    = sortingList[x+1];
                            sortingList[x+1]  = buffer;
                        }
                    }
                }

                BubbleSortBox.AppendText("\n\n");
                counter = 1;

                foreach (var item in sortingList)
                {
                    if (counter % 8 == 0)
                    {
                        BubbleSortBox.AppendText($"\n{item}\t");
                    }

                    BubbleSortBox.AppendText($"{item}\t");

                    counter++;
                }

                await Task.Delay(200);
            }

            sortingList.Clear();

            BubbleSortBoxLabel.Foreground   = Brushes.OrangeRed;
            bubblesort_active               = false;
            start_pause_button.IsChecked    = false;
        }

        private void BubbleSortBox_MouseEnter(object sender, MouseEventArgs e)
        {
            BubbleSortBox.BorderBrush       = Brushes.DarkGoldenrod;
            BubbleSortBox.SelectionBrush    = Brushes.DarkGoldenrod;
            BubbleSortBox.IsInactiveSelectionHighlightEnabled = false;
        }

        private void BubbleSortBox_MouseLeave(object sender, MouseEventArgs e)
        {
            BubbleSortBox.BorderBrush       = Brushes.DarkGoldenrod;
            BubbleSortBox.SelectionBrush    = Brushes.DarkGoldenrod;
            BubbleSortBox.IsInactiveSelectionHighlightEnabled = false;
        }
        private void start_pause_button_Checked(object sender, RoutedEventArgs e)
        {
            bubblesort_active = true;
            BubbleSorting(unsortedIntegerList);
        }

        private void start_pause_button_Unchecked(object sender, RoutedEventArgs e)
        {
            bubblesort_active = false;
        }
        private void quit_program_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}