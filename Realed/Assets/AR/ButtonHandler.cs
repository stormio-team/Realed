using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using Image = Vuforia.Image;

public class ButtonHandler : MonoBehaviour {

    private Image.PIXEL_FORMAT _pixel_format = Image.PIXEL_FORMAT.UNKNOWN_FORMAT;
    private DBService dbsr;

    public Button ScreenShotButton;

    void Start ()
    {
        Debug.Log("Button handler");
        var btn = ScreenShotButton.GetComponent<Button>();
        btn.onClick.AddListener(CompareFaces);
    }

    public void CompareFaces()
    {
        Debug.Log("Compare faces");
        var image = CameraDevice.Instance.GetCameraImage(_pixel_format);
        if (image != null)
        {
            byte[] pixels = image.Pixels;
            dbsr = new DBService("real_data.db");
            dbsr.AssertDatabaseExists();

            var id_user = FAUtils.getIdConfidenceForCompare(pixels, dbsr);
            var patient = Patient.GetInfo(dbsr, id_user);
            var health_info = HealthInfo.GetHealthInfoForPatient(dbsr, id_user);
            var appointment = Appointment.GetAppointmentsForPatient(dbsr, id_user);

            var text = GameObject.Find("Patient_Name").GetComponent<TextMesh>();
            text.text = patient.FirstName + " " + patient.LastName;
            text = GameObject.Find("Patient_JMBG").GetComponent<TextMesh>();
            text.text = patient.JMBG;
            text = GameObject.Find("Patient_Age").GetComponent<TextMesh>();
            text.text = patient.Age.ToString();
            text = GameObject.Find("Patient_Record").GetComponent<TextMesh>();
            text.text = patient.MedicalRecordNumber;
            text = GameObject.Find("Patien_Condition").GetComponent<TextMesh>();
            text.text = health_info.Condition;
            text = GameObject.Find("Patient_BloodType").GetComponent<TextMesh>();
            text.text = health_info.BloodType;
            text = GameObject.Find("Patient_Alergies").GetComponent<TextMesh>();
            text.text = health_info.Allergies;
            text = GameObject.Find("Patient_Title").GetComponent<TextMesh>();
            text.text = appointment.First().Title;
            text = GameObject.Find("Patient_Date").GetComponent<TextMesh>();
            text.text = appointment.First().AppointmentDate.ToString("dd.MM.yyyy.");
            text = GameObject.Find("Patient_Description").GetComponent<TextMesh>();
            text.text = appointment.First().Description;
        }
    }

}
