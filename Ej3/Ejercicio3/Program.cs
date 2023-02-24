using System.IO;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string LECTURAPARO = "paro.txt";
            string salidaParo = "salida.txt";
            string[] contenidoJunto;
            string linea;
            bool salida = false;

            //StreamReader lectura = new StreamReader(lecturaParo);
            //StreamWriter salida = new StreamWriter(salidaParo);
            if (File.Exists(LECTURAPARO))
            {
                try
                {
                    StreamReader lectura = new StreamReader(LECTURAPARO);
                    //Llega al final del documento, llamado lectura.
                    while (!lectura.EndOfStream)
                    {
                        linea = lectura.ReadLine();
                        Console.WriteLine(linea);

                        contenidoJunto = linea.Split(',');
                        while (!salida)
                        {
                            posicionMunicipio = Array.IndexOf(contenidoJunto, "MUNICIPIO")

                            /*for (int i = 0; i < contenidoJunto.Length; i++)
                            {
                                if (contenidoJunto[i] == "MUNICIPIO")
                                {
                                    List<string> mierda = new List<string>();
                                    mierda.Add(contenidoJunto[i]);
                                    salida = true;
                                }
                            }*/
                        }
                    }
                    //StreamWriter salida = new StreamWriter(salidaParo);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine("ERROR. El fichero no existe.");
            }
        }
    }
}
