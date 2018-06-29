using System;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();

            loadFields();
        }

        private void loadFields()
        {
            try
            {
                txtName.Text = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().Name;
                txtSurname.Text = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().Surname;
                txtIDNo.Text = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().IDNumber;
                txtMedicalAidNo.Text = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().MedicalAidNo;
                txtAccNo.Text = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().AccountNumber.ToString();
                txtCell.Text = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().Cell;
                txtFileNo.Text = PatientToken.patientID.ToString();

                var medicID = CTUCareDB.Instance.Patients.Where(x => x.ID == PatientToken.patientID).FirstOrDefault().MedicalAidID;
                txtMedicalAidCo.Text = CTUCareDB.Instance.MedicalAids.Where(x => x.ID == medicID).FirstOrDefault().Name;

                if (UserType.UserKind == 2)
                {
                    txtAccNo.Visibility = Visibility.Collapsed;
                    lblAccNo.Visibility = Visibility.Collapsed;

                    txtCell.Visibility = Visibility.Collapsed;
                    lblCell.Visibility = Visibility.Collapsed;

                    txtMedicalAidCo.Visibility = Visibility.Collapsed;
                    lblMedicalAidCo.Visibility = Visibility.Collapsed;
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
