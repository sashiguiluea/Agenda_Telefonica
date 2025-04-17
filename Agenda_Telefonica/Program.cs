using System;
using System.Collections.Generic;
using System.Linq;

// Define la clase Contacto que representa la información básica de un contacto
class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(string nombre, string telefono, string email, string direccion)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}\nTeléfono: {Telefono}\nEmail: {Email}\nDirección: {Direccion}\n";
    }
}

// Clase que gestiona los contactos
class AgendaTelefonica
{
    private List<Contacto> contactos;

    public AgendaTelefonica()
    {
        contactos = new List<Contacto>();
    }

    public void AgregarContacto()
    {
        Console.WriteLine("\n============ Agregar Nuevo Contacto =======\n");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto(nombre, telefono, email, direccion));
        Console.WriteLine("¡Contacto agregado exitosamente!");
    }

    public void BuscarContacto()
    {
        Console.WriteLine("\n=== Buscar Contacto ===");
        Console.Write("Ingrese el nombre a buscar: ");
        string nombre = Console.ReadLine();

        bool encontrado = false;

        foreach (var contacto in contactos)
        {
            if (contacto.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine("\nContacto encontrado:");
                Console.WriteLine(contacto);
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }

    public void MostrarContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("\nNo hay contactos en la agenda.");
            return;
        }

        Console.WriteLine("\n=== Lista de Contactos ===");
        for (int i = 0; i < contactos.Count; i++)
        {
            Console.WriteLine($"\nContacto #{i + 1}");
            Console.WriteLine(contactos[i]);
        }
    }

    public void GenerarInforme()
    {
        Console.WriteLine("\n=== Informe de Contactos ===");

        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos en la agenda.");
            return;
        }

        int totalContactos = contactos.Count;
        Console.WriteLine($"Total de contactos: {totalContactos}");

        var contactosPorInicial = contactos
            .GroupBy(c => c.Nombre[0].ToString().ToUpper())
            .OrderBy(g => g.Key);

        Console.WriteLine("\nDesglose por inicial del nombre:");
        foreach (var grupo in contactosPorInicial)
        {
            Console.WriteLine($"  {grupo.Key}: {grupo.Count()} contacto(s)");
        }

        double longitudPromedio = contactos.Average(c => c.Nombre.Length);
        Console.WriteLine($"\nLongitud promedio de los nombres: {longitudPromedio:F2} caracteres");

        var emailsUnicos = contactos.Select(c => c.Email).Distinct().Count();
        Console.WriteLine($"Total de emails únicos: {emailsUnicos}");
    }

    public static void Main(string[] args)
    {
        AgendaTelefonica agenda = new AgendaTelefonica();
        int opcion;

        do
        {
            Console.WriteLine("\n=== AGENDA TELEFÓNICA ===\n");
            Console.WriteLine("1. Agregar contacto\n");
            Console.WriteLine("2. Buscar contacto \n");
            Console.WriteLine("3. Mostrar todos los contactos\n");
            Console.WriteLine("4. Generar informe \n");
            Console.WriteLine("5. Salir \n");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    agenda.AgregarContacto();
                    break;
                case 2:
                    agenda.BuscarContacto();
                    break;
                case 3:
                    agenda.MostrarContactos();
                    break;
                case 4:
                    agenda.GenerarInforme();
                    break;
                case 5:
                    Console.WriteLine("¡Hasta luego gracias por utilizar la agenda telefónica!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 5);
    }
}
