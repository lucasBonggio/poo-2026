using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace encap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CuentaBancaria cuenta = new CuentaBancaria();


            cuenta.depositarSaldo(0);
            cuenta.depositarSaldo(1500);

            cuenta.retirarDinero(1200);

            Usuario usuario = new Usuario("lukario", "12312345");


            Servidor servidor = new Servidor("192.9.0.0.1");

            Console.WriteLine("Está conectado? " + servidor.getEstaConectado());

            servidor.HacerPing();

            Console.WriteLine("Está conectado? " + servidor.getEstaConectado());


            Vaca vaca = new Vaca("Lola");
            Gato gato = new Gato("Braulio");
            Perro perro = new Perro("Elizamon");

            Animal[] animales = new Animal[3];

            animales[0] = vaca;
            animales[1] = gato;
            animales[2] = perro;

            foreach (Animal animal in animales)
            {
                animal.HacerRuido();   
            }


            Router router1 = new Router("192.2.3.24");
            Switch switch1 = new Switch("9.12.18.8");
            Router router2 = new Router("192.5.3.00");
            Switch switch2 = new Switch("7.77.77.77");

            DispositivoRed[] dispositivos = new DispositivoRed[4];

            dispositivos[0] = router1;
            dispositivos[1] = switch1;
            dispositivos[3] = switch2;
            dispositivos[2] = router2;

            foreach(DispositivoRed dispositivo in dispositivos)
            {
                dispositivo.EjecutarDiagnostico();
            }

        }
    }

    //Ejercicio 1: El Cajero Automático
    //Crea una clase CuentaBancaria que tenga un atributo private decimal saldo.Crea
    //un método público para depositar y un setter para retirar dinero.
    //Regla de negocio: El setter o método de retiro debe verificar que el monto a retirar
    //no sea mayor al saldo actual ni negativo.Si lo es, debe mostrar un mensaje de
    //error por consola en lugar de restar el dinero.

    public class CuentaBancaria
    {
        private decimal saldo;

        public void depositarSaldo(decimal deposito)
        {
            if(deposito <= 0)
            {
                Console.WriteLine("El deposito tiene que ser superior a 0.");
            }
            else
            {
                this.saldo += deposito;
                Console.WriteLine("Su saldo ha sido depositado.");
                Console.WriteLine($"Saldo actual: ${this.saldo}");
            }
        }

        public void retirarDinero(decimal retiro)
        {
            if (retiro  > 0 & this.saldo >= retiro)
            {
                this.saldo -= retiro;
                Console.WriteLine("El retiro se completo exitosamente.");
                Console.WriteLine($"Saldo actual: ${this.saldo}");
            }else if(retiro > this.saldo)
            {
                Console.WriteLine("Fondos insuficientes.");
            }
        }
    }

    //Ejercicio 2: El Videojuego
    //Programa una clase Personaje con los atributos private int vida y private string
    //nombre.
    //Regla de negocio: A través del setter, verifica que la vida del personaje nunca
    //pueda bajar de 0 (si recibe mucho daño, queda en 0) ni subir de 100 (si toma una
    //poción, el máximo es 100). Imprimí el estado del personaje en el Main.

    public class Personaje
    {
        private int vida;
        private string nombre;

        public void setVida(int vida)
        {
            if(vida < 0)
            {
                this.vida -= vida;
                if(this.vida < 0)
                {
                    this.vida = 0;
                }
            }else if(vida > 0)
            {
                this.vida += vida;
                if(this.vida > 100)
                {
                    this.vida = 100;
                }
            }
        }

        public void getVida()
        {

        }
    }

    //Ejercicio 3: E-Commerce
    //Crea una clase padre Producto con protected float costoFabricacion y private float
    //precioVenta.Crea una clase hija llamada ProductoImportado.
    //Regla de negocio: La clase hija debe tener un método que calcule los impuestos
    //de importación basándose en el costoFabricacion (al ser protected, el hijo puede
    //leerlo). Sin embargo, intentar modificar el precioVenta desde la clase hija debe dar
    //error, obligando a usar un setter público definido en el padre

    public class ProductoImportado : Producto 
    {
        public float IVA = 0.21f;

        public ProductoImportado(float costoFabricacion) : base(costoFabricacion)
        {
        }

        public float CalcularImpuestos()
        {
            return this.costoFabricacion * IVA;
        }
    }
    public class Producto
    {
        protected float costoFabricacion { get; set; }
        private float precioVenta { get; set; }

        public Producto(float costoFabricacion)
        {
            this.costoFabricacion = costoFabricacion;
        }

        public void setPrecioVenta(float precioVenta)
        {
            this.precioVenta = precioVenta;
        }
    }


    //Ejercicio 4: Sistema de Usuarios
    //Definí una clase Usuario con private string password.
    //Regla de negocio: El setter de la contraseña debe verificar que el value recibido
    //tenga al menos 8 caracteres.Si tiene menos, debe rechazar la asignación y avisar
    //por consola. Desde el Main, instancia un usuario e intenta ponerle la contraseña
    //"123"

    public class Usuario
    {
        private string username;
        private string password;

        public Usuario(string username, string password)
        {
            this.username = username;
            setPassword(password);
        }

        public void setPassword(string password)
        {
            if(password.Length < 8)
            {
                Console.WriteLine("La contraseña debe tener 8 caracteres o más. Intentelo nuevamente.");
                return;
            }
            this.password = password;
        }
    }

    //Ejercicio 5: La Red Corporativa
    //Crea una clase Servidor con protected string direccionIP y private bool
    //estaConectado.
    //Regla de negocio: La variable estaConectado solo debe tener un Getter público
    //(sin setter público). Para que el servidor se conecte, debes crear un método
    //público llamado HacerPing(), que internamente cambie estaConectado a true.
    //Esto demuestra cómo proteger un estado de modificaciones directas desde el
    //Main

    public class Servidor
    {
        protected string direccionIP;
        private bool estaConectado;

        public Servidor(string direccion)
        {
            this.direccionIP = direccion;
            this.estaConectado = false;
        }

        public bool getEstaConectado()
        {
            return this.estaConectado;
        }


        public void HacerPing()
        {
            this.estaConectado = true;
        }
    }

    //Ejercicio 6: El Zoológico Virtual
    //Crea una clase abstracta Animal con una propiedad Nombre y un método
    //abstracto HacerRuido().Crea tres clases hijas: Perro, Gato y Vaca, que hereden de
    //Animal y sobreescriban al método HacerRuido().
    //Implementación: En el Main, crea un arreglo de tipo Animal[] con 3 posiciones.
    //Guarda un Perro, un Gato y una Vaca en cada posición.Usa un bucle foreach para
    //recorrer el arreglo y llama al método HacerRuido() de cada uno.

    public class Vaca : Animal
    {
        public Vaca(string nombre) : base(nombre)
        {
        }

        public override void HacerRuido()
        {
            Console.WriteLine("La vaca está mugiendo...");
        }
    }

    public class Gato : Animal
    {
        public Gato(string nombre) : base(nombre)
        {
        }

        public override void HacerRuido()
        {
            Console.WriteLine("El gato está maullando...");
        }
    }

    public class Perro : Animal
    {
        public Perro(string nombre) : base(nombre)
        {
        }

        public override void HacerRuido()
        {
            Console.WriteLine("El perro está ladrando...");
        }
    }

    public abstract class Animal
    {
        private string Nombre;

        public Animal(string nombre)
        {
            this.Nombre = nombre;
        }
        public abstract void HacerRuido();
    }

    //Ejercicio 7: Monitoreo de Infraestructura IT
    //Crea una clase abstracta DispositivoRed con un atributo DireccionIP y un método
    //abstracto EjecutarDiagnostico(). Crea dos clases hijas: Router(su diagnóstico
    //imprime por consola "Revisando tablas de ruteo en {IP}") y Switch(su diagnóstico
    //imprime por consla "Revisando puertos VLAN en {IP}").
    //Implementación: Instancia un arreglo DispositivoRed[] datacenter = new
    //DispositivoRed[4]; mezclando Routers y Switches.Recorre el arreglo con un for o
    //foreach y ejecuta el diagnóstico de todos los equipos con una sola línea de código
    //dentro del bucle.

    public class Switch : DispositivoRed
    {
        public Switch(string direccionIP) : base(direccionIP)
        {
        }

        public override void EjecutarDiagnostico()
        {
            Console.WriteLine($"Revisando puertos VLAN en {this.DireccionIP}");
        }
    }

    public class Router : DispositivoRed
    {
        public Router(string direccionIP) : base(direccionIP)
        {
        }

        public override void EjecutarDiagnostico()
        {
            Console.WriteLine($"Revisando tablas de ruteo en {this.DireccionIP}");
        }
    }

    public abstract class DispositivoRed
    {
        public string DireccionIP;

        public DispositivoRed(string direccionIP)
        {
            this.DireccionIP = direccionIP;
        }

        public abstract void EjecutarDiagnostico();
    }
}
