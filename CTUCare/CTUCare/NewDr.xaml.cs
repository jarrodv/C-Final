using System;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for NewDr.xaml
    /// </summary>
    public partial class NewDr : Window
    {
        public NewDr()
        {
            InitializeComponent();
        }

        CTUCareDB db = new CTUCareDB();

        private void btnSaveNew_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Count() > 0)
            {
                try
                {
                    Doctor newDoc = new Doctor
                    {
                        Name = txtName.Text,
                        ConsultationFee = Decimal.Parse(txtPrice.Text),
                    };

                    db.Doctors.Add(newDoc);
                    db.SaveChanges();

                    Update.updateDoctors();

                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter a monetary value");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid name");
            }
        }
    
    }
}
