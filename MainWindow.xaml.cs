using System.Diagnostics.Metrics;
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
using System.Windows.Shell;

namespace BubbleSortAnimatedWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<int> unsortedIntegerList = new List<int>()
        //{   505,  888,  203,  744,  216,  449,  197,  500,  284,  548,  159,  845,  999,  949,  691,  981,  324,  563,  854,  468,  117,  465,  502,  413,  232,
        //    645,  848,  646,  549,  765,  225,  437,  681,  2,  44,  362,  845,  895,  627,  43,  708,  883,  950,  268,  814,  747,  689,  568,  504,  234,  781,
        //    780,  574,  759,  937,  95,  761,  934,  936,  523,  459,  55,  698,  551,  111,  649,  499,  879,  77,  446,  89,  503,  917,  1,  988,  435,  681,
        //    797,  885,  501,  706,  84,  771,  782,  380,  916,  484,  525,  135,  495,  265,  428,  389,  662,  411,  876,  604, 650, 915, 637, 159, 123, 182
        //};

        private List<int> randomIntegerList = new List<int>();

        private Random generateRandoms = new Random();

        //int     counter            = 1;
        bool    bubbleSort_active  = false;
        bool    bubbleSort_paused  = false;

        public MainWindow()
        {
            InitializeComponent();

            this.SizeChanged += OnWindowSizeChanged;

            GeneratingRandomNumbers.Content = "PLEASE WAIT ... GENERATING RANDOM NUMBERS LIST !";
        }

        // Algorithm to generate a list of random Integers and output the list in Textbox
        private async void RandomGenerator()
        {
            int counter         = 1;
            int random_number   = 0;

            randomIntegerList.Clear();

            BubbleSortBox.Clear();

            GeneratingRandomNumbers.Visibility = Visibility.Visible;

            for (int rd = 99; rd > 0; rd--)
            {
                await Task.Delay(100);

                Jump:
                random_number = generateRandoms.Next(1, 1000);

                if(randomIntegerList.Count() == 0)
                {
                    randomIntegerList.Add(random_number);
                }
                else
                {
                    foreach (var item in randomIntegerList)
                    {
                        if (random_number == item)
                        {
                            goto Jump;
                        }
                        else
                        {

                        }
                    }

                    randomIntegerList.Add(random_number);
                }
            }

            GeneratingRandomNumbers.Visibility = Visibility.Collapsed;

            BubbleSortBox.AppendText("\n\n\t");

            foreach (var item in randomIntegerList)
            {

                if (counter % 9 == 0)
                {
                    BubbleSortBox.AppendText($"{item}\n\t");
                }
                else
                {
                    BubbleSortBox.AppendText($"{item}\t");
                }

                counter++;
            }

            start_pause_button.IsEnabled    = true;
            randoms_generate.IsEnabled      = true;
            quit_program.IsEnabled          = true;
        }

        // Event-Methode wenn Fenstergröße sich ändert ! In der Methode wird die Bubblesort Box und das Label dafür responsiv gemacht (Abhängig von Fenstergröße)
        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowWidth       = e.NewSize.Width;
            double newWindowHeight      = e.NewSize.Height;
            //double prevWindowWidth    = e.PreviousSize.Width;
            //double prevWindowHeight   = e.PreviousSize.Height;


            Thickness newBoxMargin = BubbleSortBox.Margin;
            Thickness newLabelMargin = BubbleSortBox.Margin;

            //newBoxMargin.Left = (newWindowWidth / 2) - (BubbleSortBox.ActualWidth / 2) - 130;
            //newBoxMargin.Top = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 210;
            //newLabelMargin.Left = (newWindowWidth / 2) - (BubbleSortBox.ActualWidth / 2) + 130;
            //newLabelMargin.Top = (newWindowHeight / 2) - (BubbleSortBox.ActualHeight / 2) - 220;

            //BubbleSortBox.Margin = newBoxMargin;
            //button_stack.Margin = newBoxMargin;
            //BubbleSortBoxLabel.Margin = newLabelMargin;

            //BubbleSortBox.Text = "\n\nW-Width: " + newWindowWidth.ToString() + "\nBox-Width: " + BubbleSortBox.Margin.ToString();
        }

        private async void BubbleSorting(List<int> randomsList)
        {
            randoms_generate.IsEnabled      = false;
            quit_program.IsEnabled          = false;

            List<int> sortingList = new List<int>();

            int counter = 1;

            bubbleSort_active = true;

            int buffer  = 0;

            foreach (var item in randomsList)
            {
                sortingList.Add(item);
            }

            TaskPercentCompleted.Content    = $"Sorting Progress: {0}%";
            TaskPercentCompleted.Visibility = Visibility.Visible;

            await Task.Delay(3000);

            for(int i = 0; i <= 100; i++)
            {

                while (bubbleSort_paused)
                {
                    if(BubbleSortBoxLabel.Foreground != Brushes.OrangeRed) 
                    {
                        BubbleSortBoxLabel.Foreground = Brushes.OrangeRed;
                    }

                    await Task.Delay(150);
                }

                if(BubbleSortBoxLabel.Foreground != Brushes.GreenYellow) 
                {
                    BubbleSortBoxLabel.Foreground = Brushes.GreenYellow;                
                }

                if (i % 100 == 0 && i != 0)
                {
                    TaskPercentCompleted.Content = $"Sorting Progress: {100}%";
                }
                else
                {
                    TaskPercentCompleted.Content = $"Sorting Progress: {i % 100}%";
                }

                for (int x = 0; x < sortingList.Count() - 1; x++) 
                {
                    buffer = sortingList[x];

                    if(x == sortingList.Count())
                    {
                        
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

                BubbleSortBox.Clear();

                BubbleSortBox.AppendText("\n\n\t");

                foreach (var item in sortingList)
                {
                    if (counter % 9 == 0)
                    {
                        BubbleSortBox.AppendText($"{item}\n\t");
                    }
                    else
                    {
                        BubbleSortBox.AppendText($"{item}\t");
                    }

                    counter++;
                }

                await Task.Delay(200);
            }

            await Task.Delay(4000);

            sortingList.Clear();

            BubbleSortBoxLabel.Foreground   = Brushes.OrangeRed;
            bubbleSort_active               = false;
            start_pause_button.IsChecked    = false;
            bubbleSort_paused               = false;
            TaskPercentCompleted.Visibility = Visibility.Collapsed;
            randoms_generate.IsEnabled      = true;
            quit_program.IsEnabled          = true;
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
            if(bubbleSort_active)
            {
                bubbleSort_paused = false;
            }
            else
            {
                BubbleSorting(randomIntegerList);
            }
        }

        private void start_pause_button_Unchecked(object sender, RoutedEventArgs e)
        {
            bubbleSort_paused = true;
        }
        private void quit_program_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void randoms_generate_Click(object sender, RoutedEventArgs e)
        {
            start_pause_button.IsEnabled    = false;
            randoms_generate.IsEnabled      = false;
            quit_program.IsEnabled          = false;

            await Task.Delay(350);

            RandomGenerator();
        }
    }
}