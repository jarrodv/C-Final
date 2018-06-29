using System;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for NewMedicine.xaml
    /// </summary>
    public partial class NewMedicine : Window
    {
        public NewMedicine()
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
                    Medicine newMedi = new Medicine
                    {
                        Name = txtName.Text,
                        Price = Decimal.Parse(txtPrice.Text),
                    };

                    db.Medicines.Add(newMedi);
                    db.SaveChanges();

                    Update.updateMedicines();

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
