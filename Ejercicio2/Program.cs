namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string NombreArchivo = "";
            int NumeroLineas = 0;
            bool Comprobación = false;
            

            while (Comprobación == false)
            {
                Console.Write("Introduce el nombre del archivo: ");
                do
                {
                    NombreArchivo = Console.ReadLine();
                    if (NombreArchivo == "")
                    {
                        Console.WriteLine("El campo no puede estar vacío, vuelva a intentarlo");
                        Comprobación = false;
                    }
                    else
                    {
                        Comprobación = true;
                    }

                } while (Comprobación == false);

                if (File.Exists(NombreArchivo))
                {
                    Console.Write("Introduce el número de líneas a mostrar: ");
                    while (!int.TryParse(Console.ReadLine(), out NumeroLineas) || NumeroLineas < 0)
                    {
                        Console.WriteLine("Debe introducir un número entero positivo vuelva a intentarlo");
                    }
                    string[] Archivo = File.ReadAllLines(NombreArchivo);
                    int NumeroTotalLineas = Archivo.Length;
                    int LineaInicial = Math.Max(NumeroTotalLineas - NumeroLineas, 0);
                    int opciones;
                    if (NumeroLineas > NumeroTotalLineas)
                    {
                        Console.WriteLine("El número introducido es mayor al número total de líneas del archivo");
                        Console.WriteLine("Se mostrará todas las líneas del archivo seleccionado");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Se mostrará las {0} últimas líneas del archivo seleccionado", NumeroLineas);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    for (int i = LineaInicial; i < NumeroTotalLineas; i++)
                    {
                        Console.WriteLine(Archivo[i]);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("¿Desea buscar otro archivo?");
                    Console.WriteLine("Sí -------------- Pulse '1'");
                    Console.WriteLine("No -------------- Pulse '2'");
                    while (!int.TryParse(Console.ReadLine(), out opciones) || opciones < 1 || opciones > 2)
                    {
                        Console.WriteLine("Dato incorrecto, Debe introducir un número entero dentro de las opciones");
                    }
                    if (opciones == 1)
                    {
                        Comprobación = false;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Pulse una tecla para finalizar el programa. Hasta pronto :)");
                        Console.ReadKey();
                    }
                    
                }
                else
                {
                    Console.WriteLine("El archivo no existe");
                }
            }
        }
    }
}