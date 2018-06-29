using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for NewAppointment.xaml
    /// </summary>
    public partial class NewAppointment : Window
    {
        public NewAppointment()
        {
            InitializeComponent();

            populatePatientList();
            populateDrBox();
            populateProcedureList();
        }

        private void populatePatientList()
        {
            Update.updatePatients();
            patientList.Items.Clear();

            foreach (var item in Update.PatientList)
            {
                patientList.Items.Add(item.Name);
            }

            patientList.Items.Refresh();
        }

        private void populateDrBox()
        {
            Update.updateDoctors();
            cBoxDr.Items.Clear();

            foreach (var item in Update.DoctorList)
            {
                cBoxDr.Items.Add(item.Name);
            }

            cBoxDr.Items.Refresh();
        }

        private void populateProcedureList()
        {
            Update.updateProcedures();
            cBoxProcedure.Items.Clear();

            foreach (var item in Update.ProcedureList)
            {
                cBoxProcedure.Items.Add(item.Name);
            }

            cBoxProcedure.Items.Refresh();
        }

        private void search()
        {
            if (searchBox.Text == "")
            {
                populatePatientList();
            }
            else
            {
                patientList.Items.Clear();

                foreach (var item in Update.PatientList)
                {
                    if (item.Name.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        patientList.Items.Add(item.Name);
                    }
                }
            }
        }

        #region Event Methods
        CTUCareDB db = new CTUCareDB();

        //Enables the dispatch options
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            lblDispatch.IsEnabled = false;
            dateDispatch.IsEnabled = false;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            lblDispatch.IsEnabled = true;
            dateDispatch.IsEnabled = true;
        }

        NewDr newDoc = new NewDr();

        private void btnNewDr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newDoc.Show();
            }
            catch (Exception)
            {
                NewDr newDoc = new NewDr();
                newDoc.Show();
            }
        }

        NewPatient newPat = new NewPatient();

        private void btnNewPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newPat.Show();
            }
            catch
            {
                NewPatient newPat = new NewPatient();
                newPat.Show();
            }
        }

        NewProcedure newPro = new NewProcedure();

        private void btnNewProcedure_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newPro.Show();
            }
            catch (Exception)
            {
                NewProcedure newPro = new NewProcedure();
                newPro.Show();
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            search();
        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {

            searchBox.Foreground = Brushes.Black;
            searchBox.Text = "";
        }

        private void btnSaveAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var patient = patientList.SelectedItem.ToString();
                var appPatient = CTUCareDB.Instance.Patients.Where(x => x.Name == patient).FirstOrDefault();

                var doctor = cBoxDr.SelectedItem.ToString();
                var appDoctor = CTUCareDB.Instance.Doctors.Where(x => x.Name == doctor).FirstOrDefault();

                var procedure = cBoxProcedure.SelectedItem.ToString();
                var appProcedure = CTUCareDB.Instance.Procedures.Where(x => x.Name == procedure).FirstOrDefault();

                var intakeDate = dateIntake.SelectedDate;

                var dispatchDate = dateDispatch.SelectedDate;

                EntryDate loadNewEntry = new EntryDate();
                Appointment loadNewApp = new Appointment();
                AdministeredProcedure loadNewPro = new AdministeredProcedure();

                loadNewEntry.PatientID = appPatient.ID;
                loadNewEntry.DateEntered = intakeDate;

                db.EntryDates.Add(loadNewEntry);
                db.SaveChanges();

                //Done after entry dates were added so that an ID can be assigned
                var entryDate = CTUCareDB.Instance.EntryDates.Where(x => x.PatientID == loadNewEntry.PatientID).ToList();
                var entryDateID = entryDate.Last().ID;

                loadNewApp.PatientID = appPatient.ID;
                loadNewApp.IntakeDateID = entryDateID;
                loadNewApp.DrID = appDoctor.ID;


                //Only adds if the checkbox is unchecked
                if (checkBox.IsChecked == false)
                {
                    loadNewApp.SheduledDispatchDate = (DateTime)dispatchDate;
                }

                db.Appointments.Add(loadNewApp);
                db.SaveChanges();

                //Done after appointments to generate an ID
                loadNewPro.PatientID = appPatient.ID;
                loadNewPro.ProcedureID = appProcedure.ID;
                loadNewPro.EntryDateID = entryDateID;

                db.AdministeredProcedures.Add(loadNewPro);

                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("One or more fields still require entries, refer to user manual for more details");
            }

            Appointments goBack = new Appointments();
            goBack.Show();
            this.Close();
        }

        private void cBoxDr_DropDownOpened(object sender, EventArgs e)
        {
            populateDrBox();
        }

        private void btnReloadPatients_Click(object sender, RoutedEventArgs e)
        {
            populatePatientList();
        }
        #endregion

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Appointments goBack = new Appointments();
            goBack.Show();
            this.Close();
        }
    }
}
