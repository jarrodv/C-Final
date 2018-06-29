using System.Collections.Generic;

namespace CTUCare
{
    public static class Update
    {
        /* These lists are updated using the methods below */
        public static List<Procedure> ProcedureList = new List<Procedure>();
        public static List<Medicine> MedicineList = new List<Medicine>();
        public static List<Doctor> DoctorList = new List<Doctor>();
        public static List<Patient> PatientList = new List<Patient>();
        public static List<AdministeredProcedure> AdminProcedureList = new List<AdministeredProcedure>();
        public static List<MedicalAid> MedicalAidCoList = new List<MedicalAid>();

        /* These methods are used to update comboboxes/listboxes and anything that contains items
           throughout the application. They are static so they can be accessed anywhere */
        #region Methods
        public static void updateCompanies()
        {
            MedicalAidCoList.Clear();

            foreach (var item in CTUCareDB.Instance.MedicalAids)
            {
                MedicalAidCoList.Add(item);
            }
        }
        
        public static void updateProcedures()
        {
            ProcedureList.Clear();

            foreach (var item in CTUCareDB.Instance.Procedures)
            {
                ProcedureList.Add(item);
            }
        }

        public static void updateAdminProcedures()
        {
            AdminProcedureList.Clear();

            foreach (var item in CTUCareDB.Instance.AdministeredProcedures)
            {
                AdminProcedureList.Add(item);
            }
        }
        

        public static void updateMedicines()
        {
            MedicineList.Clear();

            foreach (var item in CTUCareDB.Instance.Medicines)
            {
                MedicineList.Add(item);
            }
        }

        public static void updateDoctors()
        {
            DoctorList.Clear();

            foreach (var item in CTUCareDB.Instance.Doctors)
            {
                DoctorList.Add(item);
            }
        }
        
        public static void updatePatients()
        {
            PatientList.Clear();

            foreach (var item in CTUCareDB.Instance.Patients)
            {
                PatientList.Add(item);
            }
        }
        #endregion

    }
}
