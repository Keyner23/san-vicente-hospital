namespace san_vicente_hospital.Utils;

public class Menu
{

    public int showMenu()
    {
        Console.Clear();
        Console.WriteLine("=== BIENVENIDOS A LA CLINICA SAN VICENTE ===");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("0. Salir");
        Console.WriteLine("1. Registrar paciente");
        Console.WriteLine("2. Ver pacientes ");
        Console.WriteLine("3. Registrar doctor");
        Console.WriteLine("4. Ver doctores");
        Console.WriteLine("5. Ver doctores por especialidad");
        Console.WriteLine("-----------------------------------------------");
        Console.Write("Seleccione una opción: ");

        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            return opcion;
        }
        else
        {
            Console.WriteLine("Opción inválida.");
            return -1;
        }
    }
}
