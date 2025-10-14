namespace san_vicente_hospital.Models;

public class Doctor : Person
{
    public string specialty { get; set; }

    public Doctor(string name, int docuemnt, int phone, string email, string specialty) : base(name, docuemnt, phone, email)
    {
        this.specialty = specialty;
    }

    public override string ShowInformation()
    {
        return base.ShowInformation() + $",Especialidad: {specialty}";
    }
}
