using System.Net;
using System.Numerics;
using System.Security.Claims;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ejerciciosListas2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // EJERCICIO 1
            Colectivo colectivo1 = new Colectivo("98", 85, 25);
            Colectivo colectivo2 = new Colectivo("65", 85, 10);
            Colectivo colectivo3 = new Colectivo("151", 92, 32);
            Colectivo colectivo4 = new Colectivo("603", 85, 1);

            Colectivo[] colectivos = { colectivo1, colectivo2, colectivo3, colectivo4 };

            calcularMetricas(colectivos);

            // EJERCICIO 2

            Jugador jugador1 = new Jugador("Driussi", 9, 12);
            Jugador jugador2 = new Jugador("Juanfer", 10, 8);
            Jugador jugador3 = new Jugador("Salas", 7, 0);
            Jugador jugador4 = new Jugador("Montiel", 29, 7);
            Jugador jugador5 = new Jugador("Acuña", 34, 3);
            Jugador[] jugadores = { jugador1, jugador2, jugador3, jugador4, jugador5 };

            analizarEquipo(jugadores);

            // EJERCICIO 3

            Libro libro1 = new Libro("El Aleph", "Borges", 1945);
            Libro libro2 = new Libro("Telón", "Agatha Christie", 1975);
            Libro libro3 = new Libro("Ficciones", "Borges", 1944);
            Libro libro4 = new Libro("Los siete locos", "Roberto Arlt", 1929);
            Libro libro5 = new Libro("Los lanzallamas", "Roberto Arlt", 1931);

            Libro[] libros = { libro1, libro2, libro3, libro4, libro5 };

            string autorBuscado = "Borges";
            BuscarLibro(autorBuscado, libros);

            // EJERCICIO 4 
            Flor flor1 = new Flor("Rosa");
            Flor flor2 = new Flor("Lavanda");

            Arbol arbol1 = new Arbol("Limonero");
            Arbol arbol2 = new Arbol("Jacaranda");

            Planta[] plantas = { flor1, flor2, arbol1, arbol2 };


            ListarPlantas(plantas);
            
        }
        //Control de Flota de Colectivos
        //Una empresa de transporte urbano necesita un reporte del estado de sus unidades en circulación.
        //Defina la clase Colectivo con los atributos Linea (entero o string), CapacidadMaxima(entero) y PasajerosActuales(entero).
        //En el programa principal, instancie un arreglo de 4 objetos Colectivo con datos ficticios.
        //Recorra el arreglo para determinar e informar por pantalla dos métricas:
        //La cantidad total de pasajeros que está transportando la flota en este momento(sumatoria).
        //La línea del colectivo que tiene la mayor cantidad de asientos libres(calculado como CapacidadMaxima - PasajerosActuales).

        public class Colectivo
        {
            public string Linea { get; set; }
            public int CapacidadMaxima { get; set; }
            public int PasajerosActuales { get; set; }

            public Colectivo(string linea, int capacidadMaxima, int pasajerosActuales)
            {
                this.Linea = linea;
                this.CapacidadMaxima = capacidadMaxima;
                this.PasajerosActuales = pasajerosActuales;
            }
        }


        public static void calcularMetricas(Colectivo[] colectivos)
        {
            int cantidadTotalPasajeros = 0;

            int diferenciaAsientos = 0;
            string lineaConMayorPasajeros = "";
            foreach (Colectivo colectivo in colectivos)
            {
                cantidadTotalPasajeros += colectivo.PasajerosActuales;

                diferenciaAsientos = colectivo.CapacidadMaxima - colectivo.PasajerosActuales;
                for (int i = 1; i < colectivos.Length - 1; i++)
                {
                    int diferenciaActual = colectivos[i].CapacidadMaxima - colectivos[i].PasajerosActuales;
                    if (diferenciaAsientos > diferenciaActual)
                    {
                        lineaConMayorPasajeros = colectivo.Linea;
                    }
                    else
                    {
                        lineaConMayorPasajeros = colectivos[i].Linea;
                    }
                }
            }

            Console.WriteLine($"Los colectivos tienen un total de {cantidadTotalPasajeros} pasajeros. \nLa linea con mas asientos libres es {lineaConMayorPasajeros}.");
        }


        //Estadísticas del Plantel de Fútbol
        //El cuerpo técnico necesita un análisis rápido del rendimiento goleador del equipo.
        //Cree la clase Jugador con los atributos Nombre(string), NroCamiseta(entero) y GolesMarcados(entero). 
        //Declare e instancie un arreglo con 5 jugadores, asignando distintas cantidades de goles a cada uno.
        //Mediante un ciclo de repetición, analice el arreglo para identificar al goleador del equipo.
        //El sistema debe imprimir el nombre del jugador con más goles.Además, debe calcular y mostrar el promedio de goles del plantel completo.

        public class Jugador
        {
            public string Nombre { get; set; }
            public int NroCamiseta { get; set; }
            public int GolesMarcados { get; set; }

            public Jugador(string nombre, int nroCamiseta, int golesMarcados)
            {
                Nombre = nombre;
                NroCamiseta = nroCamiseta;
                GolesMarcados = golesMarcados;
            }
        }

        public static void analizarEquipo(Jugador[] jugadores)
        {
            int golesTotales = 0;
            int masGoles = jugadores[0].GolesMarcados;

            string goleador = jugadores[0].Nombre;
            for (int i = 0; i < jugadores.Length; i++)
            {
                golesTotales += jugadores[i].GolesMarcados;

                if (jugadores[i].GolesMarcados > masGoles)
                {
                    masGoles = jugadores[i].GolesMarcados;
                    goleador = jugadores[i].Nombre;
                }
            }

            double promedioGol = golesTotales / jugadores.Length;

            Console.WriteLine($"El goleador es {goleador}. El promedio de gol en el equipo es de {promedioGol}");
        }


        //Buscador de la Biblioteca Barrial
        //Una biblioteca necesita filtrar su catálogo de libros rápidamente sin depender de bases de datos complejas.
        //Defina la clase Libro con los atributos Titulo(string), Autor(string) y AnioPublicacion(entero).
        //Cree un arreglo de 4 libros.Asegurate de que al menos dos libros pertenezcan al mismo autor(por ejemplo, "Borges").
        //Declare una variable independiente string autorABuscar = "Borges"(o el autor que prefieras).
        //Recorre el arreglo de objetos y muestre por pantalla únicamente los títulos de los libros cuyo atributo Autor coincida exactamente con la variable buscada.

        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int AnioPublicacion { get; set; }

            public Libro(string titulo, string autor, int anioPublicacion)
            {
                Titulo = titulo;
                Autor = autor;
                AnioPublicacion = anioPublicacion;
            }
        }

        public static void BuscarLibro(string autor, Libro[] libros)
        {
            for (int i = 0; i < libros.Length; i++)
            {
                if (autor.Equals(libros[i].Autor))
                {
                    Console.WriteLine($"Autor encontrado. Libro: {libros[i].Titulo}");
                }
            }
        }

        //Relevamiento de Espacios Verdes(Introducción al Polimorfismo)
        //El área de espacio público necesita listar rápidamente las distintas especies plantadas en una plaza, sin importar su tipo específico.
        //Clase Padre: Cree una clase Planta que contenga únicamente el atributo NombreEspecie(string) y su respectivo constructor.
        //Clases hijas: Cree dos clases que hereden de Planta: Arbol y Flor.
        //Ambas deben tener un constructor que reciba el nombre y se lo pase al constructor de la clase padre.
        //No es necesario agregarles atributos extra a las clases hijas.
        //Estructura Polimórfica: En el programa principal, instancie un arreglo de tipo Planta con capacidad para 4 elementos.
        //Asigne en las distintas posiciones del arreglo una mezcla de clases hijas
        //(por ejemplo, dos objetos de tipo Arbol como "Jacarandá" y "Palo Borracho", y dos de tipo Flor como "Jazmín" y "Margarita").
        //Utilice un ciclo iterativo para recorrer el arreglo base e imprima por pantalla una lista con el NombreEspecie de cada elemento.
        public class Planta
        {
            public string NombreEspecie {  get; set; }

            public Planta(string nombreEspecie)
            {
                NombreEspecie = nombreEspecie;
            }
        }

        public class Arbol : Planta
        {
            public Arbol(string nombreEspecie) : base(nombreEspecie) { }
        }

        public class Flor : Planta
        {
            public Flor(string nombreEspecie) : base(nombreEspecie) { }
        }

        public static void ListarPlantas(Planta[] plantas)
        {
            foreach (Planta planta in plantas)
            {
                Console.WriteLine($"Planta del tipo {planta.NombreEspecie}");
            }
        }
    }
}
