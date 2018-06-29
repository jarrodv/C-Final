using System;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for NewPatient.xaml
    /// </summary>
    public partial class NewPatient : Window
    {
        public NewPatient()
        {
            InitializeComponent();

            updateMedicCompanies();
        }

        NewMedicalAidCo newMed = new NewMedicalAidCo();

        private void btnNewMedicalAid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newMed.Show();
            }
                catch (Exception)
            {
                NewMedicalAidCo newMed = new NewMedicalAidCo();
                newMed.Show();
            }

            updateMedicCompanies();
        }

        private void updateMedicCompanies()
        {
            Update.updateCompanies();

            cboxMedicalAidCo.Items.Clear();

            foreach (var item in Update.MedicalAidCoList)
            {
                cboxMedicalAidCo.Items.Add(item.Name);
            }
        }

        private void cboxMedicalAidCo_DropDownOpened(object sender, EventArgs e)
        {
            updateMedicCompanies();

            cboxMedicalAidCo.Items.Refresh();
        }

        private void btnSaveNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string cellNo = txtCell.Text;
                string idNo = txtIDNo.Text;
                string address = txtAdd.Text;
                string medicalAidNo = txtMedicalAidNo.Text;
                string medicalAidCo = cboxMedicalAidCo.SelectedItem.ToString();
                int accNo = Convert.ToInt32(txtAccNo.Text);

                Patient newPatient = new Patient
                {
                    Name = name,
                    Surname = surname,
                    Cell = cellNo,
                    IDNumber = idNo,
                    Address = address,
                    MedicalAidNo = medicalAidNo,
                    MedicalAidID = CTUCareDB.Instance.MedicalAids.Where(x => x.Name == medicalAidCo).FirstOrDefault().ID,
                    AccountNumber = accNo,
                };

                CTUCareDB.Instance.Patients.Add(newPatient);
                CTUCareDB.Instance.SaveChanges();

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("One or more values are still invalid or missing");
            }
        }
    }
}
