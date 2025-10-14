namespace san_vicente_hospital.Models;

public class Patient : Person
{
    public int age { get; set; }

    public Patient(string name, int docuemnt, int phone, string email, int age) : base(name, docuemnt, phone, email)
    {
        this.age = age;
    }

    public override string ShowInformation()
    {
        return base.ShowInformation() + $",Edad: {age}";
    }
}
