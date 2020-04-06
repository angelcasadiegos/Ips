using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidacionCuotaModeradoraSubsidiada : LiquidacionCuota
    {
        private int v;

        public LiquidacionCuotaModeradoraSubsidiada(int v)
        {
            this.v = v;
        }

        public LiquidacionCuotaModeradoraSubsidiada(int numerodeLiquidacion, string identificacion, decimal valordeServicio)
        {
            NumerodeLiquidacion = numerodeLiquidacion;
            Identificacion = identificacion;
            ValordeServicio = valordeServicio;
        }

        public LiquidacionCuotaModeradoraSubsidiada(int numerodeLiquidacion, string identificacion, string tipodeAfilicion, decimal salariodePaciente, decimal valordeServicio) : base(numerodeLiquidacion, identificacion, "subsidiada", salariodePaciente, valordeServicio)
        {
        }

        public override void AsignarTarifayTopeMaximo()
        {
             Tarifa = (decimal)0.05;
            TopeMaximo = 200000;
        }
    }
}

