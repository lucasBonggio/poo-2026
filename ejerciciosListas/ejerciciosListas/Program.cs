using Microsoft.Win32;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace ejerciciosListas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] temperaturas = new double[7];

            temperaturas[0] = 13.5;
            temperaturas[1] =21.0;
            temperaturas[2] = 14.3;
            temperaturas[3] = 10.5;
            temperaturas[4]= 16.3;
            temperaturas[5] = 9;
            temperaturas[6] =12.5;

            int[] ventas = new int[10] {200, 345, 455, 390, 218, 238, 777, 912, 230, 2910};

            double[] notas = new double[23] {6.4, 4.2, 3, 7, 8.3, 9, 10, 0.1, 2, 5.5, 7.7, 6, 6.6, 2.8, 7.8, 8.2, 7.9, 1, 6.7, 8.8, 10, 7, 2};

            string[] alumnosPresentes = new string[5] { "Lucas", "Adriano", "Eduardo", "Sebastian", "Marcos" };

            string alumnoBuscado = "Adriano";

            Console.WriteLine($"Temperatura promedio de los ultimos 7 días: {calcularPromedioTemperatura(temperaturas)} grados. ");

            Console.WriteLine($"La venta mas alta fue de: {ventaMasAlta(ventas)}");

            contadorCalificaciones(notas);

            pasarLista(alumnoBuscado, alumnosPresentes);
        }
        
        //1. Promedio de Temperaturas
        //Se dispone de un arreglo de tipo double que almacena las temperaturas máximas registradas durante la última semana(7 días). 
        //Desarrolle un algoritmo que recorra el arreglo, calcule el promedio de temperatura de la semana y lo informe por pantalla.

        public static double calcularPromedioTemperatura(double[] temperaturas)
        {
            double totalTemperaturas = 0;
            foreach (double temp in temperaturas)
            {
                totalTemperaturas += temp;
            }

            return Math.Round(totalTemperaturas / temperaturas.Length, 2);
        }

        //2. Registro de Ventas Máximas
        //Una PyME desea identificar su mejor rendimiento diario.
        //Dado un arreglo de 10 posiciones de tipo int con los montos de ventas del día,
        //diseñe un programa que identifique y muestre cuál fue el monto de la venta más alta registrada.

        public static int ventaMasAlta(int[] ventas)
        {
            int ventaMasAlta = 0;
            for (int i = 0; i < ventas.Length; i++)
            {
                if( ventas[i] > ventaMasAlta){
                    ventaMasAlta = ventas[i];
                }
            }

            return ventaMasAlta;
        }

        
        //3. Contador de Calificaciones
        //Un docente tiene un arreglo con las notas(enteros del 1 al 10) de un examen de 23 alumnos.
        //Se solicita desarrollar una lógica que recorra el arreglo y contabilice cuántos alumnos están aprobados(nota mayor o igual a 6) y cuántos desaprobados.
        public static void contadorCalificaciones(double[] notas)
        {
            int cantidadAprobados = 0, cantidadDesaprobados = 0;

            for (int i = 0; i < notas.Length; i++)
            {
                if (notas[i] >= 6) cantidadAprobados++;
                else cantidadDesaprobados++;
            }

            Console.WriteLine($"La cantidad de notas son {notas.Length}. Con un total de aprobados: {cantidadAprobados} y {cantidadDesaprobados} de desaprobados. ");
        }

        
        //4. Búsqueda de Nombres
        //Dado un arreglo de tipo string que contiene los nombres de los alumnos presentes en el aula, 
        //escriba una variable separada con el nombre de un alumno específico a buscar y desarrolle una lógica que verifique si dicho alumno se encuentra en el listado.
        //El programa debe informar únicamente "Alumno encontrado" o "Alumno ausente".

        public static void pasarLista(string nombreAlumno, string[] alumnosPresentes)
        {
            bool EstaPresente = false;
            foreach (var alumno in alumnosPresentes)
            {
                if (nombreAlumno.Equals(alumno)) 
                {
                    EstaPresente = true;
                    break;
                }
                else EstaPresente = false;
            }
            
            if (EstaPresente) Console.WriteLine("Alumno encontrado");
            else Console.WriteLine("Alumno ausente");
        }
    }
}
