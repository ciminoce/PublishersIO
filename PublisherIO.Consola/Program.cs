
using PublisherIO.Data;
using PublisherIO.Entidades;
using PublisherIO.Shared;

namespace PublisherIO.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Bienvenido EF Core");
                Console.WriteLine("1. Listar Autores");
                Console.WriteLine("2. Agregar Autor");
                Console.WriteLine("3. Listar Autores Ordenados");
                Console.WriteLine("4. Borrar Autor por ID");
                Console.WriteLine("5. Borrar Autor por Nombre y Apellido");
                Console.WriteLine("6. Editar Autor por ID");
                Console.WriteLine("x. Salir");

                Console.Write("Por favor, seleccione una opción: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Listar Autores");
                        GetAuthors();
                        break;
                    case "2":
                        Console.WriteLine("Agregar Autor");
                        InsertAuthor();
                        break;
                    case "3":
                        Console.WriteLine("Lista Ordenada de Autores");
                        GetAutoresOrdenados();
                        break;
                    case "4":
                        Console.WriteLine("Borrar Autor Por ID");
                        BorrarAutorPorID();
                        break;
                    case "5":
                        Console.WriteLine("Borrar Autor Por Nombre y Apellido");
                        BorrarAutorPorNombre();
                        break;
                    case "6":
                        Console.WriteLine("Editar Autor Por ID");
                        EditarAutorPorId();
                        break;

                    case "x":
                        exit = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }

                Console.WriteLine(); 
            }
        }

        private static void EditarAutorPorId()
        {
            using (var context = new PublisherDbContext())
            {
                var lista = context.Authors
                    .OrderBy(a => a.AuthorId)
                    .ToList();
                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.AuthorId}. {item.FullName}");
                }
                var index = ConsoleExtensions.GetInteger("Ingrese el ID a modificar:");
                var authorInDb = context.Authors.Find(index);
                if (authorInDb != null)
                {
                    var firstName = ConsoleExtensions.GetString("Enter New FirstName:");
                    var lastName = ConsoleExtensions.GetString("Enter New LastName:");
                    authorInDb.FirstName = firstName;
                    authorInDb.LastName = lastName;

                    context.SaveChanges();
                    Console.WriteLine($"Autor {authorInDb.FullName} editado!!!");
                }
                else
                {
                    Console.WriteLine("ID de autor no existente!!!");
                }
            }

        }

        private static void BorrarAutorPorNombre()
        {
            var firstName = ConsoleExtensions.GetString("Enter FistName:");
            var lastName = ConsoleExtensions.GetString("Enter LastName:");
            using (var context=new PublisherDbContext())
            {
                var autorInDb=context.Authors
                    .FirstOrDefault(a=>a.FirstName==firstName && 
                    a.LastName==lastName);
                if (autorInDb!=null)
                {
                    context.Authors.Remove(autorInDb);
                    context.SaveChanges();
                    Console.WriteLine($"Autor {autorInDb.FullName} borrado!!!");
                }
                else { Console.WriteLine("Autor no encontrado"); }

            }
        }

        private static void BorrarAutorPorID()
        {
            using (var context=new PublisherDbContext())
            {
                var lista = context.Authors
                    .OrderBy(a=>a.AuthorId)
                    .ToList();
                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.AuthorId}. {item.FullName}");
                }
                var index = ConsoleExtensions.GetInteger("Ingrese el ID a dar de baja:");
                var authorInDb = context.Authors.Find(index);
                if (authorInDb != null)
                {
                    context.Authors.Remove(authorInDb);
                    context.SaveChanges();
                    Console.WriteLine($"Autor {authorInDb.FullName} borrado!!!");
                }
                else
                {
                    Console.WriteLine("ID de autor no existente!!!");
                }
            }
        }

        private static void GetAutoresOrdenados()
        {
            using (var context=new PublisherDbContext())
            {
                var listaOrdenada = context.Authors
                    .OrderBy(a => a.LastName)
                    .ThenBy(a => a.FirstName)
                    .ToList();
                foreach (var autor in listaOrdenada)
                {
                    Console.WriteLine($"{autor.LastName},  {autor.FirstName}");
                }
            }
        }

        private static void InsertAuthor()
        {
            try
            {
                var firstName = ConsoleExtensions.GetString("Enter FirstName:");
                var lastName = ConsoleExtensions.GetString("Enter LastName:");

                var autor = new Author
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                using (var context = new PublisherDbContext())
                {
                    //context.Add(autor);
                    context.Authors.Add(autor);
                    context.SaveChanges();

                }
                Console.WriteLine($"Autor {autor.FullName} Agregado!!!");

            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null && 
                    ex.InnerException.Message.Contains("IX"))
                {
                    Console.WriteLine("Registro Existente!!!");
                }
                else
                {
                    Console.WriteLine("Joder ocurrio otra cosa!!!");
                };
            } 
        }

        private static void GetAuthors()
        {
            using (var context=new PublisherDbContext())
            {
                var lista = context.Authors.ToList();
                foreach (var autor in lista)
                {
                    Console.WriteLine($"{autor.FirstName} {autor.LastName}");
                }
            }
        }
    }
}
