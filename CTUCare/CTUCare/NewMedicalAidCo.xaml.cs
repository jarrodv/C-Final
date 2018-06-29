using System;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for NewMedicalAidCo.xaml
    /// </summary>
    public partial class NewMedicalAidCo : Window
    {
        public NewMedicalAidCo()
        {
            InitializeComponent();
        }

        private void saveNewCo()
        {
            try
            {
                string name = txtName.Text;
                string email = txtEmail.Text;

                MedicalAid newCo = new MedicalAid
                {
                    Name = name,
                    Email = email,
                };

                CTUCareDB.Instance.MedicalAids.Add(newCo);
                CTUCareDB.Instance.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Error one or more fields missing or invalid");
            }
        }
    }
}
