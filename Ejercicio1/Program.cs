using System;
using System.IO;
class Program
{
    static void Main(string[]args)
    {
        string fichero1 = "1.txt";
        string fichero2 = "2.txt";
        string ficheroDiferencias = "diferencias.txt";

        //Leemos los ficheros 1 y 2, luego creamos el fichero de diferencias
        StreamReader lecturaFichero1 = new StreamReader(fichero1);
        StreamReader lecturaFichero2 = new StreamReader(fichero2);
        StreamWriter escrituraDiferencias = new StreamWriter(ficheroDiferencias);

        //Leemos la primera linea de cada fichero
        string lineaFichero1 = lecturaFichero1.ReadLine();
        string lineaFichero2 = lecturaFichero2.ReadLine();
        int numLinea=1;

        //Se crea un bucle para ir leyendo linea a linea de cada fichero
        while(lineaFichero1 != null && lineaFichero2 != null)
        {
            
            if (lineaFichero1 != lineaFichero2)
            {
                escrituraDiferencias.Write(numLinea+";"+lineaFichero1+";"+lineaFichero2+"\n");
            }
            lineaFichero1 = lecturaFichero1.ReadLine();
            lineaFichero2 = lecturaFichero2.ReadLine();
            numLinea++;
        }
        
        //Como todavía está leyendo el fichero si el 2º fichero está vacio, va a guardar la linea
        //que no esté vacia en el nuevo fichero
        if (lineaFichero2 == null)
        {
            escrituraDiferencias.Write(numLinea + ";" + lineaFichero1 + ";");
        }

        //Se cierran los ficheros
        lecturaFichero1.Close();
        lecturaFichero2.Close();
        escrituraDiferencias.Close();

        //Se muestra todo el contenido del fichero
        Console.WriteLine(File.ReadAllText(ficheroDiferencias));
    }
}
