using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;


namespace Ips
{
    class Program
    {
        public static LiquidacionCuotaService liquidacionCuotaModeradoraService = new LiquidacionCuotaService();
        static string mensaje;
        static void Main(string[] args)
        {
            DesplegarMenuPrincipal();
        }

        public static void DesplegarMenuPrincipal()
        {
            int opcion = 6;
            do
            {
                Console.Clear();
                Console.WriteLine("                  Menú Principal                  ");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("1. Registrar Liquidación");
                Console.WriteLine("2. Eliminar Liquidación");
                Console.WriteLine("3. Buscar Liquidación");
                Console.WriteLine("4. Modificar valor del servicio de una liquidacion");
                Console.WriteLine("5. Ver listado de liquidaciones");
                Console.WriteLine("0. Salir de la aplicacion\n");
                Console.WriteLine("Digite su opcion: ");
                opcion = ValidarLimitesNumericos("Error, debe ingresar una de las opciones anteriores", 0, 5);
                EjecutarOpcion(opcion);
            } while (opcion != 0);
        }
        public static void EjecutarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    RegistrarLiquidacion();
                    break;
                case 2:
                    EliminarLiquidacion();
                    break;
                case 3:
                    BuscarLiquidacion();
                    break;
                case 4:
                    ModificarServicio();
                    break;
                case 5:
                    ListarLiquidaciones();
                    break;
                case 0:
                    break;
            }
        }
        public static void RegistrarLiquidacion()
        {
            string respuesta;
            do
            {
                Console.Clear();
                ENTITY.LiquidacionCuota liquidacionCuotaModeradora = PedirDatos();
                liquidacionCuotaModeradora.AsignarTarifayTopeMaximo();
                liquidacionCuotaModeradora.CalcularCuota();
                mensaje = liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora);
                Console.WriteLine($"{mensaje}");
                Console.WriteLine("El valor de la cuota moderadora es: {0}", liquidacionCuotaModeradora.ValordeServicio);
                Console.WriteLine("¿Desea registrar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("Error, debe ingresar S o N", "S", "N");
            } while (respuesta == "S");
        }
        public static ENTITY.LiquidacionCuota PedirDatos()
        {
            ENTITY.LiquidacionCuota liquidacionCuotaModeradora;
            Console.WriteLine("¿Que tipo de afiliacion desea registrar? Régimen Contributivo->(C)  Régimen Subsidiado->(S)");
            string TipodeAfiliacion = ValidarLimitesAlfabeticos("Error, debe ingresar C o S", "C", "S");
            Console.WriteLine("Ingrese numero de liquidación:");
            int NumerodeLiquidacion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de identificacion del paciente:");
            string Identificacion = Console.ReadLine();
            decimal SalariodePaciente;
            Console.WriteLine("Ingrese el valor del servicio de hospitalización:");
            decimal ValordeServicio = decimal.Parse(Console.ReadLine());
            if (TipodeAfiliacion == "C")
            {
                Console.WriteLine("Ingrese el valor del salario devengado por el paciente:");
                SalariodePaciente = decimal.Parse(Console.ReadLine());
                liquidacionCuotaModeradora =  new LiquidacionCuotaModeradoraContributiva(NumerodeLiquidacion, Identificacion, SalariodePaciente, ValordeServicio);
            }
            else
            {
                liquidacionCuotaModeradora = new LiquidacionCuotaModeradoraSubsidiada (NumerodeLiquidacion, Identificacion, ValordeServicio);
            }
            return liquidacionCuotaModeradora;
        }
        public static void EliminarLiquidacion()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el numero de la liquidación a eliminar:");
                int NumeroLiquidacion = int.Parse(Console.ReadLine());
                mensaje = liquidacionCuotaModeradoraService.Eliminar(NumeroLiquidacion);
                Console.WriteLine($"{mensaje}");
                Console.WriteLine("¿Desea eliminar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("Error, debe ingresar S o N", "S", "N");
            } while (respuesta == "S");
        }
        public static void BuscarLiquidacion()
        {
            string respuesta;
            do
            {
                Console.Clear();
                List<ENTITY.LiquidacionCuota> liquidacionesCuotasModeradoras = new List<ENTITY.LiquidacionCuota>();
                Console.WriteLine("Ingrese el numero de la liquidación a buscar:");
                int NumerodeLiquidacion = int.Parse(Console.ReadLine());
                ENTITY.LiquidacionCuota liquidacionCuotaModeradora = liquidacionCuotaModeradoraService.Buscar(NumerodeLiquidacion);
                if (liquidacionCuotaModeradora != null)
                {
                    Console.WriteLine("Liquidación encontrada\n\n");
                    liquidacionesCuotasModeradoras.Add(liquidacionCuotaModeradora);
                   
                }
               
                Console.WriteLine("¿Desea buscar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("Error, debe ingresar S o N", "S", "N");
            } while (respuesta == "S");
        }
        public static void ModificarServicio()
        {
            string respuesta;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese el numero de la liquidacion a modificar:");
                int NumerodeLiquidacion = int.Parse(Console.ReadLine());
                ENTITY.LiquidacionCuota liquidacioncuotamoderadora = liquidacionCuotaModeradoraService.Buscar(NumerodeLiquidacion);
                if (liquidacioncuotamoderadora != null)
                {
                    Console.WriteLine("Ingrese el nuevo valor del servicio de hospitalizacion:");
                    liquidacioncuotamoderadora.ValordeServicio = decimal.Parse(Console.ReadLine());
                    liquidacioncuotamoderadora.CalcularCuota();
                   
                    Console.WriteLine($"{mensaje}");
                    Console.WriteLine("El nuevo valor de la cuota moderadora es: {0}", liquidacioncuotamoderadora.CuotaModeradora);
                }
                Console.WriteLine("¿Desea modificar otra liquidación? S/N");
                respuesta = ValidarLimitesAlfabeticos("Error, debe ingresar S o N", "S", "N");
            } while (respuesta == "S");
        }
        public static void ListarLiquidaciones()
        {
            Console.Clear();
            liquidacionCuotaModeradoraService.Consultar();
            Console.ReadKey();
        }
        public static int ValidarLimitesNumericos(string mensaje, int limiteInferior, int limiteSuperior)
        {
            int opcion;
            do
            {
                opcion = int.Parse(Console.ReadLine());
                if (opcion < limiteInferior || opcion > limiteSuperior)
                {
                    Console.WriteLine(mensaje);
                    Console.ReadKey();
                }
            } while (opcion < limiteInferior && opcion > limiteSuperior);
            return opcion;
        }
        public static string ValidarLimitesAlfabeticos(string mensaje, string Letra1, string Letra2)
        {
            string opcion;
            do
            {
                opcion = Console.ReadLine().ToUpper();
                if (opcion != Letra1 && opcion != Letra2)
                {
                    Console.WriteLine(mensaje + "\n");
                    Console.ReadKey();
                }
            } while (opcion != Letra1 && opcion != Letra2);
            return opcion;
        }
    }
}
