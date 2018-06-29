using System.Threading.Tasks;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            splashScreenStart();


        }

        //Logic for the progressBar to load for 2 seconds
        private async void splashScreenStart()
        {
            loader.Value = 0;
            loader.Maximum = 100;

            for (int i = 0; i < 101; i++)
            {
                await Task.Delay(5);
                loader.Value += 1;
            }

            Login initialize = new Login();

            initialize.Show();

            this.Close();
        }
    }
}
