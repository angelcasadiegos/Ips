using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipssaludvida
{
    class Program
    {
        static void Main(string[] args)
        {


            public int Menu()
        {
            Console.Clear();
            Console.WriteLine("Programa Pulsaciones");
            Console.WriteLine("");
            Console.WriteLine("1-Registrar Paciente");
            Console.WriteLine("2-Consultar Paciente ");
            Console.WriteLine("3-Mostrar Pacientes");
            Console.WriteLine("4-Modificar Paciente");
            Console.WriteLine("5-Eliminar Paciente");
            Console.WriteLine("Programa Pulsaciones");
            int numero = int.Parse(Leer("Digite La opcion deseada"));
            return numero;
        }

        public void EjecutarprogramaIpssaludvida()
        {
            do
            {
                Opcion = Menu();
                EjecutarOpcion(Opcion);
            } while (Opcion != 0);
        }

        public void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1: Console.WriteLine(RegistrarPaciente()); break;
                case 2: ConsultarPaciente(); break;
                case 3: MostrarPaciente(); break;
                case 4: ModificarPaciente(); break;
                case 5: EliminarPaciente(); break;
                case 0: break;
            }
        }

        public LiquidacionCuotaModeradora CrearLiquidacion()
        {
            try
            {
                String NumeroLiquidacion;
                string TipoAfiliacion;
                String salario;
                string identificacion;
                String v
                nombre = Leer("digite el nombre :");
                sexo = Leer("digite el sexo M/F");
                identificacion = Leer("digite la identificacion :");
                edad = int.Parse(Leer("digite su edad"));
                Persona persona = new Persona(nombre, identificacion, sexo, edad);
                persona.CalcularPulsaciones();
                return persona;
            }
            catch (Exception e)
            {
                Console.WriteLine("errror: " + e.Message);
                Console.ReadKey();
                return null;
            }




        }
    }
}
