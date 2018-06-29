using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace CTUCare
{
    /// <summary>
    /// Interaction logic for Accounts.xaml
    /// </summary>
    public partial class Accounts : Window
    {
        public Accounts()
        {
            InitializeComponent();

            loadStatements();
        }

        #region Loading Methods
        private void loadProPrice()
        {
            var selectedPro = procedureList.SelectedItem.ToString();
            var procedure = CTUCareDB.Instance.Procedures.Where(x => x.Name == selectedPro).FirstOrDefault().Cost;
            double money = Convert.ToDouble(procedure);

            txtProPrice.Text = "R" + money.ToString();
        }

        private void loadMediPrice()
        {
            var selectedMed = medicineList.SelectedItem.ToString();
            var medicine = CTUCareDB.Instance.Medicines.Where(x => x.Name == selectedMed).FirstOrDefault().Price;
            double money = Convert.ToDouble(medicine);

            txtMediPrice.Text = "R" + money.ToString();
        }

        private void loadStatements()
        {
            //If dispatch date is null it means that the appointment has not been closed yet and there will be no statement
            var statements = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == History.statementPatient).Where(x => x.DispatchDateID != null);

            foreach (var item in statements)
            {
                patientList.Items.Add(item.EntryDate.DateEntered);
            }
        }

        private void loadProcedures()
        {
            procedureList.Items.Clear();

            //Need to find the procedure with a matching entry date and patient ID
            var dateID = CTUCareDB.Instance.EntryDates.Where(x => x.DateEntered == date).FirstOrDefault().ID;
            var proID = CTUCareDB.Instance.AdministeredProcedures.Where(x => x.EntryDateID == dateID).Where(x => x.PatientID == History.statementPatient).FirstOrDefault().ProcedureID;
            var procedure = CTUCareDB.Instance.Procedures.Where(x => x.ID == proID);

            foreach (var item in procedure)
            {
                procedureList.Items.Add(item.Name);
            }

            procedureList.Items.Refresh();
        }

        private void loadDayIn()
        {
            txtDayIn.Text = date.ToShortDateString();
        }

        private void loadDayOut()
        {
            var entryDateID = CTUCareDB.Instance.EntryDates.Where(x => x.DateEntered == date).FirstOrDefault().ID;
            var dispatchID = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == History.statementPatient).Where(x => x.IntakeDateID == entryDateID).FirstOrDefault().DispatchDateID;
            var dispatchD = CTUCareDB.Instance.DispatchDates.Where(x => x.ID == dispatchID).FirstOrDefault().DispatchDate1;
            DateTime day = (DateTime)dispatchD;

            txtDayOut.Text = day.ToShortDateString();
        }

        private void loadMedicines()
        {
            medicineList.Items.Clear();

            var dateID = CTUCareDB.Instance.EntryDates.Where(x => x.DateEntered == date).FirstOrDefault().ID;
            var medicineID = CTUCareDB.Instance.AdministeredMedicines.Where(x => x.DateAdministeredID == dateID).Where(x => x.PatientID == History.statementPatient).FirstOrDefault().MedicineID;
            var medicine = CTUCareDB.Instance.Medicines.Where(x => x.ID == medicineID);


            foreach (var item in medicine)
            {
                medicineList.Items.Add(item.Name);
            }

            medicineList.Items.Refresh();
        }


        private void loadDrsPrice()
        {
            var dateID = CTUCareDB.Instance.EntryDates.Where(x => x.DateEntered == date).FirstOrDefault().ID;
            var doctorID = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == History.statementPatient).Where(x => x.IntakeDateID == dateID).FirstOrDefault().DrID;
            var doctor = CTUCareDB.Instance.Doctors.Where(x => x.ID == doctorID).FirstOrDefault().ConsultationFee.ToString();
            double price = Convert.ToDouble(doctor);

            txtDrsConsultation.Text = "R" + price.ToString();
        }

        private void loadDr()
        {
            var dateID = CTUCareDB.Instance.EntryDates.Where(x => x.DateEntered == date).FirstOrDefault().ID;
            var doctorID = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == History.statementPatient).Where(x => x.IntakeDateID == dateID).FirstOrDefault().DrID;
            var doctor = CTUCareDB.Instance.Doctors.Where(x => x.ID == doctorID).FirstOrDefault().Name;

            txtDr.Text = doctor;
        }
        #endregion

        #region Event Methods
        //Linked to the selected item in the statements list
        public static DateTime date;
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            date = (DateTime)patientList.SelectedItem;

            loadProcedures();
            loadDrsPrice();
            loadMedicines();
            loadDayIn();
            loadDayOut();
            calculateTotal();
            loadDr();
        }

        private void btnProPrice_Click(object sender, RoutedEventArgs e)
        {
            loadProPrice();
        }

        private void btnMediPrice_Click(object sender, RoutedEventArgs e)
        {
            loadMediPrice();
        }
        #endregion

        #region Total Calculation Methods
        private void calculateTotal()
        {
            double total = calculateProcedureTotal() + calculateMedicineTotal() + calculateDrsTotal();

            txtTotalCost.Text = "R" + total.ToString();
        }

        private double calculateProcedureTotal()
        {
            List<string> procedures = new List<string>();
            List<decimal> proPrices = new List<decimal>();

            foreach (var item in procedureList.Items)
            {
                procedures.Add(item.ToString());
            }

            foreach (var item in procedures)
            {
                proPrices.Add(CTUCareDB.Instance.Procedures.Where(x => x.Name == item).FirstOrDefault().Cost);
            }

            double procedureTotal = proPrices.Sum(x => Convert.ToDouble(x));
            return procedureTotal;
        }

        private double calculateMedicineTotal()
        {
            List<string> medicines = new List<string>();
            List<decimal> medPrices = new List<decimal>();

            foreach (var item in medicineList.Items)
            {
                medicines.Add(item.ToString());
            }

            foreach (var item in medicines)
            {
                medPrices.Add(CTUCareDB.Instance.Medicines.Where(x => x.Name == item).FirstOrDefault().Price);
            }

            double medicineTotal = medPrices.Sum(x => Convert.ToDouble(x));
            return medicineTotal;
        }

        private double calculateDrsTotal()
        {
            var dateID = CTUCareDB.Instance.EntryDates.Where(x => x.DateEntered == date).FirstOrDefault().ID;
            var doctorID = CTUCareDB.Instance.Appointments.Where(x => x.PatientID == History.statementPatient).Where(x => x.IntakeDateID == dateID).FirstOrDefault().DrID;
            var doctor = CTUCareDB.Instance.Doctors.Where(x => x.ID == doctorID).FirstOrDefault().ConsultationFee.ToString();
            double price = Convert.ToDouble(doctor);
            return price;
        }
        #endregion
    }
}
