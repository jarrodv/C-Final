using System;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for NewProcedure.xaml
    /// </summary>
    public partial class NewProcedure : Window
    {
        public NewProcedure()
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
                    Procedure newPro = new Procedure
                    {
                        Name = txtName.Text,
                        Cost = Decimal.Parse(txtPrice.Text),
                    };

                    db.Procedures.Add(newPro);
                    db.SaveChanges();

                    Update.updateProcedures();

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
