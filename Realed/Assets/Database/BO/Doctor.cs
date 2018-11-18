using SQLite4Unity3d;

public class Doctor {

	[PrimaryKey, AutoIncrement] public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

}