using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Window
    {
        public Appointments()
        {
            InitializeComponent();
        }

        NewAppointment newApp = new NewAppointment();

        private void btnNewAppointment_Click(object sender, RoutedEventArgs e)
        {
            NewAppointment newApp = new NewAppointment();
            newApp.Show();

            this.Close();
        }

        private void btnCloseAppointment_Click(object sender, RoutedEventArgs e)
        {
            OpenAppointments openApp = new OpenAppointments();
            openApp.Show();

            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Home goBack = new Home();
            goBack.Show();
            this.Close();
        }
    }
}
