using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        public History()
        {
            InitializeComponent();

            populateList();
        }

        public static int statementPatient;

        private void search()
        {
            listPatients.Items.Clear();

            if (cboxSearchBy.SelectedItem == iName)
            {
                listPatients.Items.Clear();

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    if (item.Name.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        listPatients.Items.Add(item.Name);
                    }
                }
            }
            else if (cboxSearchBy.SelectedItem == iSurname)
            {
                listPatients.Items.Clear();

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    if (item.Name.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        listPatients.Items.Add(item.Surname);
                    }
                }
            }
            else if (cboxSearchBy.SelectedItem == iIdNo)
            {
                listPatients.Items.Clear();

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    if (item.IDNumber.Contains(searchBox.Text.ToLower()))
                    {
                        listPatients.Items.Add(item.IDNumber);
                    }
                }
            }
            else if (cboxSearchBy.SelectedItem == iMedicalAidNo)
            {
                listPatients.Items.Clear();

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    if (item.MedicalAidNo.Contains(searchBox.Text.ToLower()))
                    {
                        listPatients.Items.Add(item.MedicalAidNo);
                    }
                }
            }
            else if (cboxSearchBy.SelectedItem == iAccNo)
            {
                listPatients.Items.Clear();

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    if (item.AccountNumber.ToString().Contains(searchBox.Text.ToLower()))
                    {
                        listPatients.Items.Add(item.AccountNumber);
                    }
                }
            }
            else if (cboxSearchBy.SelectedItem == iFileNo)
            {
                listPatients.Items.Clear();

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    if (item.ID.ToString().Contains(searchBox.Text.ToLower()))
                    {
                        listPatients.Items.Add(item.ID);
                    }
                }
            }

        }

        private void populateList()
        {
            listPatients.Items.Clear();

            if (cboxSearchBy.SelectedItem == iName)
            {
                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    listPatients.Items.Add(item.Name);
                }
            }
            else if (cboxSearchBy.SelectedItem == iSurname)
            {

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    listPatients.Items.Add(item.Surname);
                }
            }
            else if (cboxSearchBy.SelectedItem == iIdNo)
            {

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    listPatients.Items.Add(item.IDNumber);
                }
            }
            else if (cboxSearchBy.SelectedItem == iMedicalAidNo)
            {

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    listPatients.Items.Add(item.MedicalAidNo);
                }
            }
            else if (cboxSearchBy.SelectedItem == iAccNo)
            {

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    listPatients.Items.Add(item.AccountNumber);
                }
            }
            else if (cboxSearchBy.SelectedItem == iFileNo)
            {

                foreach (var item in CTUCareDB.Instance.Patients)
                {
                    listPatients.Items.Add(item.ID);
                }
            }
        }

        private void setPatient()
        {
            if (cboxSearchBy.SelectedItem == iName)
            {
                int user = CTUCareDB.Instance.Patients.Where(x => x.Name == listPatients.SelectedItem.ToString()).FirstOrDefault().ID;
                PatientToken.patientID = user;
            }
            else if (cboxSearchBy.SelectedItem == iSurname)
            {
                int user = CTUCareDB.Instance.Patients.Where(x => x.Surname == listPatients.SelectedItem.ToString()).FirstOrDefault().ID;
                PatientToken.patientID = user;
            }
            else if (cboxSearchBy.SelectedItem == iIdNo)
            {
                int user = CTUCareDB.Instance.Patients.Where(x => x.IDNumber == listPatients.SelectedItem.ToString()).FirstOrDefault().ID;
                PatientToken.patientID = user;
            }
            else if (cboxSearchBy.SelectedItem == iMedicalAidNo)
            {
                int user = CTUCareDB.Instance.Patients.Where(x => x.MedicalAidNo == listPatients.SelectedItem.ToString()).FirstOrDefault().ID;
                PatientToken.patientID = user;
            }
            else if (cboxSearchBy.SelectedItem == iAccNo)
            {
                int user = CTUCareDB.Instance.Patients.Where(x => x.AccountNumber == Convert.ToInt32(listPatients.SelectedItem.ToString())).FirstOrDefault().ID;
                PatientToken.patientID = user;
            }
            else if (cboxSearchBy.SelectedItem == iFileNo)
            {
                int user = CTUCareDB.Instance.Patients.Where(x => x.ID == Convert.ToInt32(listPatients.SelectedItem.ToString())).FirstOrDefault().ID;
                PatientToken.patientID = user;
            }
        }

        #region Event Methods
        private void cboxSearchBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateList();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            search();
        }


        Information openInfo = new Information();
        private void btnInformation_Click(object sender, RoutedEventArgs e)
        {
            if (listPatients.SelectedIndex != -1)
            {
                setPatient();

                try
                {
                    openInfo.Show();
                }
                catch (Exception)
                {
                    Information openInfo = new Information();
                    openInfo.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient");
            }
        }

        Accounts HistoryNAccounts = new Accounts();
        private void btnAccountsNHistory_Click(object sender, RoutedEventArgs e)
        {
            if (listPatients.SelectedIndex != -1)
            {
                statementPatient = CTUCareDB.Instance.Patients.Where(x => x.Name == listPatients.SelectedItem.ToString()).FirstOrDefault().ID;

                setPatient();

                try
                {
                    HistoryNAccounts.Show();
                }
                catch (Exception)
                {
                    Accounts HistoryNAccounts = new Accounts();
                    HistoryNAccounts.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Home goBack = new Home();
            goBack.Show();
            this.Close();
        }
        #endregion



    }
}
