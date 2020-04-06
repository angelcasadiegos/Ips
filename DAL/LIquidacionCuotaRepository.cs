using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;

namespace DAL
{
    public class LIquidacionCuotaRepository
    {
        private string ruta = @"C:\Users\Rochety\Documents\Visual Studio 2015\Projects\Ipssaludvida\Ipssaludvida";
        private List<LiquidacionCuota> liquidacionesCuotas;

        public List<LiquidacionCuota> LiquidacionCuota { get; private set; }
        

        public LIquidacionCuotaRepository()
        {
            LiquidacionCuota = new List<LiquidacionCuota>();
        }

        public object Buscar(object numerodeLiquidacion)
        {
            throw new NotImplementedException();
        }

        public void Guardar(LiquidacionCuota liquidacioncuota)

        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter stream = new StreamWriter(fileStream);
            stream.WriteLine(liquidacioncuota.ToString());
            stream.Close();
            fileStream.Close();

        }

       
        

        public List <LiquidacionCuota>  Consultar()
        {
            liquidacionesCuotas.Clear();
            FileStream filestream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(filestream);
            string linea = string.Empty;

            while ((linea = reader.ReadLine())!= null)
            {

                LiquidacionCuota liquidacioncuota = MapearLiquidacionCuota(linea);
                liquidacionesCuotas.Add(liquidacioncuota);
}
            filestream.Close();
            reader.Close();
            return liquidacionesCuotas;



        }

        public LiquidacionCuota MapearLiquidacionCuota(string linea)
        {
            string[] datos = linea.Split(';');
            if (datos[1] == "contributiva")  
            {
                LiquidacionCuota liquidacioncuotamoderadoracontributiva = new LiquidacionCuotaModeradoraContributiva(0);

                liquidacioncuotamoderadoracontributiva.NumerodeLiquidacion = int.Parse(datos[0]);
                liquidacioncuotamoderadoracontributiva.TipodeAfiliacion = datos[1];
                liquidacioncuotamoderadoracontributiva.Identificacion = datos[2];
                liquidacioncuotamoderadoracontributiva.SalariodePaciente = Decimal.Parse(datos[3]);
                liquidacioncuotamoderadoracontributiva.ValordeServicio = decimal.Parse(datos[4]);
                return liquidacioncuotamoderadoracontributiva;
            }
    
         else{
                LiquidacionCuota liquidacioncuotamoderadorasubsidiada = new LiquidacionCuotaModeradoraSubsidiada(0);
                liquidacioncuotamoderadorasubsidiada.NumerodeLiquidacion = int.Parse(datos[0]);
                liquidacioncuotamoderadorasubsidiada.TipodeAfiliacion = datos[1];
                liquidacioncuotamoderadorasubsidiada.Identificacion = datos[2];
                liquidacioncuotamoderadorasubsidiada.SalariodePaciente = Decimal.Parse(datos[3]);
                liquidacioncuotamoderadorasubsidiada.ValordeServicio = decimal.Parse(datos[4]);
                return liquidacioncuotamoderadorasubsidiada;

            }

        }
        public void Eliminar(int Numerodeliquidacion)
        {
            liquidacionesCuotas.Clear();
            liquidacionesCuotas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidacionesCuotas)
            {
                if (item.NumerodeLiquidacion != Numerodeliquidacion)
                {
                    Guardar(item);
                }
            }

        }

        public LiquidacionCuota Buscar(int numerodeliquidacion)
        {
            liquidacionesCuotas.Clear();
            liquidacionesCuotas = Consultar();
            
            foreach (var item in liquidacionesCuotas)
            {
                if (item.NumerodeLiquidacion.Equals(numerodeliquidacion))
                {
                    return item;
                }
            }
            return null;
        }

        public void Modificar(LiquidacionCuota liquidacioncuotamoderadora)
        {
           liquidacionesCuotas.Clear();
           liquidacionesCuotas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in liquidacionesCuotas)
            {
                if (item.NumerodeLiquidacion!= liquidacioncuotamoderadora.NumerodeLiquidacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidacioncuotamoderadora);
                }
            }

        }





    }
}
