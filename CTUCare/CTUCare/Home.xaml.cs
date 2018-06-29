using System;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }      

        private void btnAppointments_Click(object sender, RoutedEventArgs e)
        {
            Appointments newApp = new Appointments();

            newApp.Show();

            this.Close();
        }

        History openHistory = new History();
        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                openHistory.Show();
            }
            catch (Exception)
            {
                History openHistory = new History();
                openHistory.Show();
            }

            this.Close();
        }
    }
}
