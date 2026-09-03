using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{

    public class CuentaBancaria
    {
        private string nombre_del_titular;
        private string numero_cuenta;
        private float balance_disponible;

        //Este es el constructor por defecto
        public CuentaBancaria()
        {
            nombre_del_titular = "Giancarlo Marte";
            numero_cuenta = "A100667358";
            balance_disponible = 4545.23F;
        }
        //En este constructor se pueden especificar los valores de los datos
        public CuentaBancaria(string nombre, string cuenta, float balance)
        {
            nombre_del_titular = nombre;
            numero_cuenta = cuenta;
            balance_disponible = balance;
        }
        //función para depositar dinero y dice el saldo después del depósito
        public void depositar(float cantidad)
        {
            balance_disponible += cantidad;
            Console.WriteLine("El depósito de " + cantidad + " en la cuenta " + numero_cuenta + " fue exitoso.");
            Console.WriteLine("Su saldo actual es de: " + balance_disponible);
        }

        //Función para retirar dinero, valida que haya suficiente dinero.
        public void retirar(float cantidad)
        {
            if(balance_disponible >= cantidad)
            {
                balance_disponible -= cantidad;
                Console.WriteLine("El retiro de" + cantidad + " de la cuenta " + numero_cuenta + " fue exitoso.");
                Console.WriteLine("Su saldo actual es de: " + balance_disponible);
            }
            else
            {
                Console.WriteLine("El retiro de" + cantidad + " de la cuenta " + numero_cuenta + " NO fue exitoso.");
                Console.WriteLine("No tiene saldo suficiente para realizar ese retiro.");
            }
        }
        
        //Función para imprimir los detalles de la cuenta
        public void MostrarDetalles()
        {
            Console.WriteLine("Nombre del titular: " + nombre_del_titular);
            Console.WriteLine("Número de cuenta: " + numero_cuenta);
            Console.WriteLine("Saldo disponible: " + balance_disponible);
        }
    }
    class Program{
        static void Main(string[] args)
        {
            //Primero declaramos 4 objetos sin inicializar
            CuentaBancaria[] cuentas = new CuentaBancaria[4];
            string nombre, cuenta;
            float balance; 
            //Inicializamos los primeros 3 objetos con datos insertados por el usuario
            //usando el constructor que acepta datos.
            for(int i = 0; i<3; i++)
            {
                Console.Clear();
                Console.WriteLine("Introduzca los datos de la cuenta #" + i+1);
                Console.WriteLine("Introduzca el nombre del titular: ");
                nombre = Console.ReadLine();
                Console.WriteLine("Introduzca el número de cuenta: ");
                cuenta = Console.ReadLine();
                Console.WriteLine("Introduzca el balance disponible: ");
                balance = float.Parse(Console.ReadLine());
                cuentas[i] = new CuentaBancaria(nombre, cuenta, balance); 
            }
            //Inicializaos el cuarto objeto con el constructor por defecto,
            //de manera que tenga los datos predeterminados
            cuentas[3] = new CuentaBancaria();
            //Vamos a imprimir la información de las 4 cuentas
            Console.Write("Presione cualquier tecla para continuar . . . "); 
            Console.ReadKey(true); 
            Console.Clear();
            for(int i = 0; i<4; i++)
            {
                Console.WriteLine("Información de la cuenta #" + i);
                cuentas[i].MostrarDetalles(); 
            }
            //Vamos a realizar unos depositos y a sacar algo de dinero:
            Console.Clear();
            Console.WriteLine("Se harán ahora algunas operaciones predeterminadas");
            Console.WriteLine("Presione cualquier tecla para continuar . . . "); 
            Console.ReadKey(true); 
            Console.Clear();
            cuentas[0].depositar(500F);
            cuentas[1].depositar(1000.44F);
            cuentas[2].retirar(200F);
            cuentas[3].retirar(4000F);
            Console.WriteLine("Presione cualquier tecla para continuar . . . "); 
            Console.ReadKey(true); 
            Console.Clear();
            //Por último, vamos a imprimir la información de las 4 cuentas después
            //de las modificaciones
            for(int i = 0; i<4; i++)
            {
                Console.WriteLine("Información de la cuenta #" + i+1);
                cuentas[i].MostrarDetalles(); 
            }
        }
    }
}