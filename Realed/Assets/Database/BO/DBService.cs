using SQLite4Unity3d;
using UnityEngine;
using System.Collections.Generic;
using System;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif

public class DBService {

	private SQLiteConnection dbConnection;
    private string dbName;
    private bool isWritten;
    private bool addData;

	public DBService(string databaseName) {
        dbName = databaseName;
        isWritten =addData= false;
	}

    public DBService AssertDatabaseExists() {
    #if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/{0}", dbName);
#else
        var filePath = string.Format("{0}/{1}", Application.persistentDataPath, dbName);

        if (!File.Exists(filePath)) {
            addData=true;
            Debug.Log("Database not found in Persistent path.");

#if UNITY_ANDROID
            var loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + dbName);
            while (!loadDB.isDone) { }
            File.WriteAllBytes(filePath, loadDB.bytes);
#elif UNITY_WINRT
		    var loadDB = Application.dataPath + "/StreamingAssets/" + dbName;
		    File.Copy(loadDB, filePath);
#else
	        var loadDB = Application.dataPath + "/StreamingAssets/" + dbName;
	        File.Copy(loadDB, filePath);
#endif
            Debug.Log("Database written.");
        
        }
        else{
        isWritten=true;
        }
        var dbPath = filePath;
#endif

        dbConnection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

        if (!isWritten) {
            dbConnection.CreateTable<Patient>();
            dbConnection.CreateTable<HealthInfo>();
            dbConnection.CreateTable<Appointment>();
            dbConnection.CreateTable<Doctor>();
            InitializeDBWithExamples();
        }
     

        Debug.Log("Database path: " + dbPath); 
        isWritten = true;

        return this;
    }

    public DBService InitializeDBWithExamples() {
        dbConnection.InsertAll(new[] {
            new Patient{
                Id = 3,
                FirstName = "Mihajlo",
                LastName = "Starcevic",
                PicPath="Assets/img3.jpg",
                Age = 21,
                JMBG = "1234567893333",
                MedicalRecordNumber = "12345678333",
                Address = "Hemingvejeva 12, Beograd"
            },
            new Patient{
				Id = 1,
				FirstName = "Filip",
				LastName = "Grdovic",
                PicPath="Assets/img1.jpg",
				Age = 21,
                JMBG = "1234567891111",
                MedicalRecordNumber = "12345678111",
                Address = "Blok 23A, Beograd"
			},
			new Patient{
				Id = 2,
				FirstName = "Dusan",
				LastName = "Bobicic",
                PicPath="Assets/img2.jpg",
                Age = 21,
                JMBG = "1234567892222",
                MedicalRecordNumber = "12345678222",
                Address = "Kamenicka 19, Beograd"
			}
		});
        dbConnection.InsertAll(new[] {
            new HealthInfo {
                Id = 1,
	            BloodType = "B-",
                Allergies = "Nuts, Animal hair, Dust",
                Condition = "Healthy",
                PatientID = 1
            },
            new HealthInfo {
                Id = 2,
	            BloodType = "O+",
                Allergies = "None",
                Condition = "Healthy",
                PatientID = 2
            },
            new HealthInfo {
                Id = 3,
	            BloodType = "A+",
                Allergies = "Panklav pills",
                Condition = "Healthy",
                PatientID = 3
            }
        });
        dbConnection.InsertAll(new[] {
            new Appointment {
                Id = 1,
                PatientID = 3,
                DoctorID = 1, 
                AppointmentDate = new DateTime(2018, 12, 23),
                Title = "Appointment at the dentist.",
                Description = "Fill cavaty for the upper right fourth tooth."
            },
            new Appointment {
                Id = 2,
                PatientID = 3,
                DoctorID = 1, 
                AppointmentDate = new DateTime(2018, 12, 27),
                Title = "Appointment at the dentist.",
                Description = "Fill cavaty for the upper left sixth tooth."
            }
        });
        dbConnection.InsertAll(new[] {
            new Doctor {
                Id = 1,
                FirstName = "Andjela",
                LastName = "Nikolic"
            }
        });

        return this;
    }

	public IEnumerable<Patient> GetPatientTable() {
		return dbConnection.Table<Patient>();
	}

    public IEnumerable<HealthInfo> GetHealthInfoTable() {
		return dbConnection.Table<HealthInfo>();
	}

    public IEnumerable<Appointment> GetAppointmentTable() {
		return dbConnection.Table<Appointment>();
	}

    public IEnumerable<Doctor> GetDoctorTable() {
		return dbConnection.Table<Doctor>();
	}
}
