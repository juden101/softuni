public class StudentSpecialty
{
    public string SpecialityName { get; set; }
    public string FacultyNumber { get; set; }

    public StudentSpecialty(string specialityName, string facultyNumber)
    {
        this.SpecialityName = specialityName;
        this.FacultyNumber = facultyNumber;
    }
}