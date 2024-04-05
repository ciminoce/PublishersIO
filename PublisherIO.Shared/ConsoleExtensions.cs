namespace PublisherIO.Shared
{
    public static class ConsoleExtensions
    {
        public static string? GetString(string mensaje)
        {
            string? stringVar=string.Empty;
            bool seguir = true;
            do
            {
                Console.Write(mensaje);
                stringVar= Console.ReadLine();
                if (!string.IsNullOrEmpty(stringVar))
                {
                    seguir = false;
                    continue;
                }
                else
                {
                    Console.WriteLine("Ingreso requerido!!!");
                }

            } while (seguir);
            return stringVar;
        }

        public static int GetInteger(string mensaje)
        {
            int intVar = 0;
            bool seguir = true;
            do
            {
                Console.Write(mensaje);
                var stringVar = Console.ReadLine();
                if (!int.TryParse(stringVar, out intVar))
                {
                    Console.WriteLine("Ingreso no válido");
                }
                else
                {
                    seguir = false;
                }
            }
            while (seguir);
            return intVar;
        }
    }
}
