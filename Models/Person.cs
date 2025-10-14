namespace san_vicente_hospital.Models;

public class Person
{
    public string name { get; set; }
    public int docuemnt { get; set; }
    public int phone { get; set; }
    public string email { get; set; }


    public Person(string name, int docuemnt, int phone, string email)
    {
        this.name = name;
        this.docuemnt = docuemnt;
        this.phone = phone;
        this.email = email;
    }

    public virtual string ShowInformation()
    {
        return $"Nombre: {name}, Docuemnto: {docuemnt}, Telefono: {phone} email: {email}";
    }
}
