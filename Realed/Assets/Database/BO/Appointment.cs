using SQLite4Unity3d;
using System.Collections.Generic;
using System.Linq;
using System;

public class Appointment {

	[PrimaryKey, AutoIncrement] public int Id { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public static IEnumerable<Appointment> GetAppointmentsForPatient(DBService database, int patientID) {
        return database.GetAppointmentTable().Where(patient => patient.PatientID == patientID);
    }
}
