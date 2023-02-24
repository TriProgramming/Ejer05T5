using System.IO;
using System.Runtime.CompilerServices;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string NOTAS = "Datos notas.csv";
            const string SALIDANOTAS = "salida.txt";
            int count = 1;
            string linea;
            string[] nombreAlumno;
            decimal[] notasEjercicioEntrega;
            decimal[] notasIntervencion;
            decimal[] notasExamenes;
            decimal[] notaFinal;

            List<string> datosGuardados = new List<string>();


            StreamReader entrada = new StreamReader(NOTAS);
            StreamWriter salida = new StreamWriter(SALIDANOTAS);


            //Bucle creado para leer el fichero hasta que no sea el final del fichero
            //cada vez que recorre el while va comprobando las lineas impares del fichero
            while (!entrada.EndOfStream) 
            {
                linea = entrada.ReadLine();
                if (count % 2 != 0)
                {

                    datosGuardados.Add(linea);
                }                
                count++;
            }

            //Se le da un tamaño al array de notas, para que no se sobreescriba
            notasEjercicioEntrega = new decimal[datosGuardados.Count];
            notasIntervencion = new decimal[datosGuardados.Count];
            notasExamenes = new decimal[datosGuardados.Count];
            notaFinal = new decimal[datosGuardados.Count];

            //Se crea un bucle para empezar a leer los datos de la lista creada

            for (int i = 0; i < datosGuardados.Count; i++)
            {
                //Cada vez que detecte un ; guardará en un array de strings los nombres de cada alumno
                nombreAlumno = datosGuardados[i].Split(";");
                
                //Se comprueban las 3 primeras notas del alumno para sacar su media de ejercicios entregados para luego guardarlo en un array
                //de dichas notas de los ejercicios entregados
                decimal ejercicioEntrega = (decimal.Parse(nombreAlumno[1]) + decimal.Parse(nombreAlumno[2]) + decimal.Parse(nombreAlumno[3]))/3m * 0.3m;
                notasEjercicioEntrega[i] = ejercicioEntrega;

                decimal intervenciones = (decimal.Parse(nombreAlumno[4]) + decimal.Parse(nombreAlumno[5]) + decimal.Parse(nombreAlumno[6]))/3m * 0.2m;
                notasIntervencion[i] = intervenciones;

                decimal notaExamenes = (decimal.Parse(nombreAlumno[7]) + decimal.Parse(nombreAlumno[8])) / 2m * 0.5m;
                notasExamenes[i] = notaExamenes;

                notaFinal[i] = Math.Floor(ejercicioEntrega + intervenciones + notaExamenes);

                salida.WriteLine(nombreAlumno[0] +"; "+ notaFinal[i]);
            }
            entrada.Close();
            salida.Close();
            Console.WriteLine(File.ReadAllText(SALIDANOTAS));

        }
    }
}