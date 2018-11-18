using SQLite4Unity3d;
using System.Linq;
using System.Collections.Generic;
using System;

public class Patient {

	[PrimaryKey, AutoIncrement] public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
    public string PicPath { get; set; }
    public int Age { get; set; }
    public string JMBG { get; set; }
    public string MedicalRecordNumber { get; set; }
    public string Address { get; set; }

    public static Patient GetInfo(DBService database, int patientID) {
        return database.GetPatientTable().Where(patient => patient.Id == patientID).FirstOrDefault();
    }
    public static List<Patient> GetAll(DBService database)
    {
        return new List<Patient>(database.GetPatientTable());
    }
    public override string ToString() {
		return string.Format("[Patient: Id={0}, FirstName={1}, LastName={2},PicPath={3}, Age={4}, JMBG={5}, MedicalRecordNumber={6}, Address={7}]",
                             Id, FirstName, LastName,PicPath ,Age, JMBG, MedicalRecordNumber, Address);
	}

}
