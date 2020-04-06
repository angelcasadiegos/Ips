using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;



namespace BLL
{
    public class LiquidacionCuotaService
    {
        private LIquidacionCuotaRepository liquidacionesRepository;
        public LiquidacionCuotaService()
        {
            liquidacionesRepository = new LIquidacionCuotaRepository();
        }
        public string Guardar(LiquidacionCuota liquidacioncuota)
        {
            try
            {
                if (liquidacionesRepository.Buscar(liquidacioncuota.NumerodeLiquidacion) == null)
                {
                    liquidacionesRepository.Guardar(liquidacioncuota);
                    return $"Los datos de la cuenta numero {liquidacioncuota.NumerodeLiquidacion} han sido guardados correctamente";
                }
                return $"No es posible registrar la cuenta con numero {liquidacioncuota.NumerodeLiquidacion}, porque ya se encuentra registrada";
            }
            catch (Exception E)
            {
                return "Error de lectura o escritura de archivos" + E.Message;
            }
        }
        public string Eliminar(int numerodeliquidacion)
        {
            try
            {
                ENTITY.LiquidacionCuota liquidacioncuota = liquidacionesRepository.Buscar(numerodeliquidacion);
                if (liquidacioncuota != null)
                {
                    liquidacionesRepository.Eliminar(numerodeliquidacion);
                    Console.WriteLine($"Los datos de la cuenta numero {numerodeliquidacion} han sido eliminados correctamente");
                    return null;
                }
                Console.WriteLine($"No es posible eliminar la cuenta con numero {numerodeliquidacion}, porque no se encuentra registrada");
                return null;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
        public void Modificar(ENTITY.LiquidacionCuota liquidacioncuota)
        {
            try
            {
                liquidacionesRepository.Modificar(liquidacioncuota);
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
            }
        }
        public List<ENTITY.LiquidacionCuota> Consultar()
        {
            try
            {
                List<ENTITY.LiquidacionCuota> liquidacionescuotas = liquidacionesRepository.Consultar();
                if (liquidacionescuotas == null)
                {
                    Console.WriteLine("No existen cuentas registradas");
                }
                return liquidacionescuotas;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }
        }
        public void ImprimirDatos(ENTITY.LiquidacionCuota liqudacioncuota)
        {
            Console.WriteLine("{0,10}{1,11}{2,12}{3,12}", "No. Liquidacion", "Tipode afiliacion", "identificacion ", "salario", "valor");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0,10}{1,11}{2,12}{3,12}\n\n", liqudacioncuota.NumerodeLiquidacion, liqudacioncuota.TipodeAfiliacion, liqudacioncuota.Identificacion, liqudacioncuota.SalariodePaciente, liqudacioncuota.ValordeServicio);
        }
        public ENTITY.LiquidacionCuota Buscar(int numerodeliquidacion)
        {
            try
            {
                ENTITY.LiquidacionCuota liquidacioncuota = liquidacionesRepository.Buscar(numerodeliquidacion);
                if (liquidacioncuota == null)
                {
                    Console.WriteLine($"La cuenta numero {numerodeliquidacion} no se encuentra registrada");
                }
                return liquidacioncuota;
            }
            catch (Exception E)
            {
                Console.WriteLine("Error de lectura o escritura de archivos" + E.Message);
                return null;
            }





        }
    }
}


