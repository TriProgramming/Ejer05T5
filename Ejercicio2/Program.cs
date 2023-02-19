namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string NombreArchivo = "";
            int NumeroLineas = 0;
            bool Comprobación = false;
            
            do
            {
                Console.Write("Introduce el nombre del archivo (El archivo se llama, archivo.txt): ");

                //Se comprueba con un bucle do-while que el  nombre del archivo existe, si no, lo vuelve a pedir
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

                //Si el archivo existe pedimos que el usuario introduzca el número de lineas a leer
                if (File.Exists(NombreArchivo))
                {
                    Console.Write("Introduce el número de líneas a mostrar: ");
                    while (!int.TryParse(Console.ReadLine(), out NumeroLineas) || NumeroLineas < 0)
                    {
                        Console.WriteLine("Debe introducir un número entero positivo vuelva a intentarlo");
                    }
                    //Se crea un array de strings para almacenar todas las lineas del fichero
                    string[] Archivo = File.ReadAllLines(NombreArchivo);
                    //Creamos un int en 0 para luego igualarlo a la cantidad de lineas del fichero
                    int NumeroTotalLineas = Archivo.Length;
                    //Comprobamos cual es el valor máximo de las 2 variables, el mayor se guardará en la variable LineaInicial
                    int LineaInicial = Math.Max(NumeroTotalLineas - NumeroLineas, 0);
                    int opciones;
                    //Si el número de lineas es mayor al total, mostrará todas las lineas del fichero
                    if (NumeroLineas > NumeroTotalLineas)
                    {
                        Console.WriteLine("El número introducido es mayor al número total de líneas del archivo");
                        Console.WriteLine("Se mostrará todas las líneas del archivo seleccionado");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    //Si no, mostrará las últimas lineas que ha introducido el usuario que quiere ver
                    else
                    {
                        Console.WriteLine("Se mostrará las {0} últimas líneas del archivo seleccionado", NumeroLineas);
                        Console.ReadKey();
                        Console.Clear();
                    }
                    //Recorremos con un for, las lineas del fichero para que las muestre
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
                //Si no existe el fichero, va a volver al principio del bucle y lo va a pedir de nuevo
                else
                {
                    Console.WriteLine("El archivo no existe");
                    Comprobación = false;
                }
            } while (Comprobación == false) ;
        }
    }
}