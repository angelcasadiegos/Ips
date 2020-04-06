using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class LiquidacionCuota
    {
        public int NumerodeLiquidacion { get; set; }
        public string Identificacion { get; set; }
        public string TipodeAfiliacion { get; set; }
        public decimal SalariodePaciente { get; set; }
        public decimal ValordeServicio { get; set; }
        public decimal Tarifa { get; set; }
        public decimal TopeMaximo { get; set; }
        public decimal CuotaModeradora { get; set; }

        public decimal SalarioMinimo = 877803;
        public abstract void AsignarTarifayTopeMaximo();   
        public LiquidacionCuota(int numerodeLiquidacion,string identificacion, String tipodeAfilicion, decimal salariodePaciente, decimal valordeServicio)
        {
            NumerodeLiquidacion = numerodeLiquidacion;
            Identificacion = Identificacion;
            TipodeAfiliacion = tipodeAfilicion;
            SalariodePaciente = salariodePaciente;
            ValordeServicio = ValordeServicio;
}

        public LiquidacionCuota()
        {
        }

        public void CalcularCuota()
        {
            CuotaModeradora = ValordeServicio * Tarifa;
            if (CuotaModeradora > TopeMaximo)
            {
                CuotaModeradora = TopeMaximo;
            }

        }

        public override string ToString()
        {
            return $"{NumerodeLiquidacion};{Identificacion};{TipodeAfiliacion};{SalariodePaciente};{ValordeServicio};{Tarifa};{TopeMaximo};{CuotaModeradora}";
        }

    }
}
