using SQLite4Unity3d;
using System.Linq;
using System;

public class HealthInfo {

	[PrimaryKey, AutoIncrement] public int Id { get; set; }
	public string BloodType { get; set; }
    public string Allergies { get; set; }
    public string Condition { get; set; }
    public int PatientID { get; set; }

    public static HealthInfo GetHealthInfoForPatient(DBService database, int patientID) {
        return database.GetHealthInfoTable().Where(patient => patient.PatientID == patientID).FirstOrDefault();
    }

}
