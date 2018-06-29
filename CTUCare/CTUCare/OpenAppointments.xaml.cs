using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for OpenAppointments.xaml
    /// </summary>
    public partial class OpenAppointments : Window
    {
        public OpenAppointments()
        {
            InitializeComponent();

            updateProcedureBox();
            updatePatientsAppointments();
            updateMedicineBox();

            updateDrs();
        }

        public int currentPatient;

        private void setDate()
        {
            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;
            var selectedDate = CTUCareDB.Instance.EntryDates.Where(x => x.ID == intakeDatum).FirstOrDefault().DateEntered;

            txtCurrentDay.Text = selectedDate.ToString();

            dateIntake.SelectedDate = selectedDate;
        }

        private void goBack()
        {
            Appointments goBack = new Appointments();
            goBack.Show();
            this.Close();
        }

        private void saveNewDate()
        {
            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;

            DispatchDate newExitDate = new DispatchDate();

            newExitDate.PatientID = currentPatient;
            newExitDate.DispatchDate1 = DateTime.Now;

            CTUCareDB.Instance.DispatchDates.Add(newExitDate);
            CTUCareDB.Instance.SaveChanges();

            var lookupDate = CTUCareDB.Instance.DispatchDates.Where(x => x.PatientID == currentPatient).ToList();

            CTUCareDB.Instance.Appointments.Where(x => x.EntryDate.ID == intakeDatum).Where(x => x.PatientID == currentPatient).FirstOrDefault().DispatchDateID = lookupDate.LastOrDefault().ID;

            CTUCareDB.Instance.SaveChanges();
        }

        #region Update/Loading Methods
        public void updateProcedureBox()
        {
            Update.updateProcedures();

            cboxProcedures.Items.Clear();

            foreach (var item in Update.ProcedureList)
            {
                cboxProcedures.Items.Add(item.Name);
            }

            cboxProcedures.Items.Refresh();
        }

        public void updateMedicineBox()
        {
            Update.updateMedicines();

            cboxMedicines.Items.Clear();

            foreach (var item in Update.MedicineList)
            {
                cboxMedicines.Items.Add(item.Name);
            }

            cboxMedicines.Items.Refresh();
        }



        private void updateDrs()
        {
            cboxDrs.Items.Clear();

            Update.updateDoctors();

            foreach (var item in Update.DoctorList)
            {
                cboxDrs.Items.Add(item.Name);
            }

            cboxDrs.Items.Refresh();
        }

        private void updateDate()
        {
            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;

            CTUCareDB.Instance.EntryDates.Remove(CTUCareDB.Instance.EntryDates.Where(x => x.ID == intakeDatum).FirstOrDefault());

            EntryDate updatedDate = new EntryDate();

            updatedDate.ID = (int)intakeDatum;
            updatedDate.PatientID = currentPatient;
            updatedDate.DateEntered = dateIntake.SelectedDate;

            CTUCareDB.Instance.EntryDates.Add(updatedDate);

        }

        private void updatePatientsAppointments()
        {
            List<Appointment> openAppointments = new List<Appointment>();

            var Appointments = CTUCareDB.Instance.Appointments.Where(x => x.DispatchDate == null);

            foreach (var item in Appointments)
            {
                openAppointments.Add(item);
            }

            foreach (var item in openAppointments)
            {
                listPatients.Items.Add(item.Patient.Name);
            }

        }


        private void loadDoctor()
        {
            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;
            txtCurrentDoc.Text = CTUCareDB.Instance.Appointments.Where(x => x.IntakeDateID == intakeDatum).FirstOrDefault().Doctor.Name;
        }

        private void updateMedicinesList()
        {
            try
            {
                listMedicinesAdmin.Items.Clear();

                List<AdministeredMedicine> appliedMedicines = new List<AdministeredMedicine>();

                var appMedicines = CTUCareDB.Instance.AdministeredMedicines.Where(x => x.PatientID == currentPatient).FirstOrDefault().DateAdministeredID;
                var currentMeds = CTUCareDB.Instance.AdministeredMedicines.Where(x => x.DateAdministeredID == appMedicines).ToList();

                foreach (var item in currentMeds)
                {
                    listMedicinesAdmin.Items.Add(item.Medicine.Name);
                }

                listMedicinesAdmin.Items.Refresh();
            }
            catch (Exception)
            {

            }
        }

        private void updateProcedureList()
        {
            listProceduresAdmin.Items.Clear();

            List<AdministeredProcedure> appliedProcedures = new List<AdministeredProcedure>();

            var appProcedures = CTUCareDB.Instance.AdministeredProcedures.Where(x => x.PatientID == currentPatient).FirstOrDefault().EntryDateID;
            var currentProcedures = CTUCareDB.Instance.AdministeredProcedures.Where(x => x.EntryDateID == appProcedures).ToList();

            foreach (var item in currentProcedures)
            {
                listProceduresAdmin.Items.Add(item.Procedure.Name);
            }

            listProceduresAdmin.Items.Refresh();
        }

        private void saveProcedures()
        {
            var appProcedures = CTUCareDB.Instance.AdministeredProcedures.Where(x => x.PatientID == currentPatient).FirstOrDefault().EntryDateID;
            var currentProcedures = CTUCareDB.Instance.AdministeredProcedures.Where(x => x.EntryDateID == appProcedures).ToList();

            foreach (var item in currentProcedures)
            {
                Update.AdminProcedureList.Remove(item);
            }
        }
        #endregion

        #region Event Methods
        private void btnChangeDoctor_Click(object sender, RoutedEventArgs e)
        {
            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;
            CTUCareDB.Instance.Appointments.Where(x => x.IntakeDateID == intakeDatum).FirstOrDefault().DrID =
                CTUCareDB.Instance.Doctors.Where(x => x.Name == cboxDrs.SelectedItem.ToString()).FirstOrDefault().ID;

            txtCurrentDoc.Text = cboxDrs.SelectedItem.ToString();
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            saveNewDate();

            goBack();
        }

        private void btnChangeDate_Click(object sender, RoutedEventArgs e)
        {
            updateDate();

            txtCurrentDay.Text = dateIntake.SelectedDate.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CTUCareDB.Instance.SaveChanges();

            goBack();
        }

        private void btnLoadAppointment_Click(object sender, RoutedEventArgs e)
        {
            currentPatient = CTUCareDB.Instance.Patients.Where(x => x.Name == listPatients.SelectedItem.ToString()).FirstOrDefault().ID;

            updateMedicinesList();
            updateProcedureList();
            loadDoctor();
            setDate();
        }

        NewMedicine newMed = new NewMedicine();

        private void btnNewMedicine_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newMed.Show();
            }
            catch (Exception)
            {
                NewMedicine newMed = new NewMedicine();
                newMed.Show();
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


        private void btnAddProcedure_Click(object sender, RoutedEventArgs e)
        {
            listProceduresAdmin.Items.Add(cboxProcedures.SelectedItem);

            AdministeredProcedure newAdminPro = new AdministeredProcedure();

            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;

            newAdminPro.PatientID = currentPatient;
            newAdminPro.ProcedureID = CTUCareDB.Instance.Procedures.Where(x => x.Name == cboxProcedures.SelectedItem.ToString()).FirstOrDefault().ID;
            newAdminPro.EntryDateID = intakeDatum;

            CTUCareDB.Instance.AdministeredProcedures.Add(newAdminPro);
        }

        private void btnRemoveProcedure_Click(object sender, RoutedEventArgs e)
        {
            var selected = listProceduresAdmin.SelectedItem;

            listProceduresAdmin.Items.Remove(listProceduresAdmin.SelectedItem);

            CTUCareDB.Instance.AdministeredProcedures.Remove(CTUCareDB.Instance.AdministeredProcedures.Where
                (x => x.Procedure.Name == selected.ToString()).FirstOrDefault());
        }

        private void cboxProcedures_DropDownOpened(object sender, EventArgs e)
        {
            updateProcedureBox();

            cboxProcedures.Items.Refresh();
        }

        private void cboxMedicines_DropDownOpened(object sender, EventArgs e)
        {
            updateMedicineBox();

            cboxMedicines.Items.Refresh();
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            listMedicinesAdmin.Items.Add(cboxMedicines.SelectedItem);

            AdministeredMedicine newAdminMedicine = new AdministeredMedicine();

            var intakeDatum = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == currentPatient).FirstOrDefault().IntakeDateID;

            newAdminMedicine.PatientID = currentPatient;
            newAdminMedicine.MedicineID = CTUCareDB.Instance.Medicines.Where(x => x.Name == cboxMedicines.SelectedItem.ToString()).FirstOrDefault().ID;
            newAdminMedicine.DateAdministeredID = intakeDatum;

            CTUCareDB.Instance.AdministeredMedicines.Add(newAdminMedicine);

        }

        private void btnRemoveMedicine_Click(object sender, RoutedEventArgs e)
        {
            var selected = listMedicinesAdmin.SelectedItem;

            CTUCareDB.Instance.AdministeredMedicines.Remove(CTUCareDB.Instance.AdministeredMedicines.Where
                (x => x.Medicine.Name == selected.ToString()).FirstOrDefault());

            listMedicinesAdmin.Items.Remove(listMedicinesAdmin.SelectedItem);
        }

        private void cboxDrs_DropDownOpened(object sender, EventArgs e)
        {
            updateDrs();
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
