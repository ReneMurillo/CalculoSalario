using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanillaMVC.Models
{
    public class Planilla
    {
        public double Afp { get; set; }
        public double Isss { get; set; }
        public double Renta { get; set; }
        public double SalarioBruto { get; set; }
        public double Salario { get; set; }
        public double SalarioQuincenal { get; set; }
        public double SalarioMensual { get; set; }
        public double PagoPorHora { get; set; }
        public int HorasTrabajadas { get; set; }
        public int HorasExtra { get; set; }
        public bool AplicarAfp { get; set; }
        public bool AplicarIsss { get; set; }
        public bool AplicarRenta { get; set; }


        public double SalariosBruto(int pHoras, double pPagoHoras)
        {
            this.HorasTrabajadas = pHoras;
            this.PagoPorHora = pPagoHoras;

            if(HorasTrabajadas > 180)
            {
                HorasExtra = HorasTrabajadas - 180;
                SalarioBruto = (HorasTrabajadas * PagoPorHora) + (HorasExtra * (PagoPorHora * 2));
                Afp = CalcularAfp(SalarioBruto);
                Isss = CalcularIsss(SalarioBruto);
                Salario = SalarioBruto - (Afp + Isss);
                Renta = CalcularRenta(Salario);
                SalarioQuincenal = (Salario - Renta) / 2;
                SalarioMensual = Salario - Renta;
            }
            else
            {
                SalarioBruto = HorasTrabajadas * PagoPorHora;
                Afp = CalcularAfp(SalarioBruto);
                Isss = CalcularIsss(SalarioBruto);
                Salario = SalarioBruto - (Afp + Isss);
                Renta = CalcularRenta(Salario);
                SalarioQuincenal = (Salario - Renta) / 2;
                SalarioMensual = Salario - Renta;
            }
            return SalarioBruto;
        }

        public double CalcularAfp(double pSalario)
        {
            Afp = 0;
            if (AplicarAfp) { 
            Afp = pSalario * 0.0725;
            }
            return Afp;
        }

        public double CalcularIsss(double pSalario)
        {
            Isss = 0;
            if (AplicarIsss) { 
            Isss = pSalario * 0.0750;
            }
            return Isss;
        }

        public double CalcularRenta(double pSalario)
        {
            Renta = 0;
            if (AplicarRenta) { 
                if (pSalario > 0.01 && pSalario <= 487.60)
                {
                    Renta = 0;
                }
                else if (pSalario >= 487.61 && pSalario <= 642.85)
                {
                    Renta = ((pSalario - 487.60) * 0.1) + 17.48;
                }
                else if (pSalario >= 642.86 && pSalario <= 915.81)
                {
                    Renta = ((pSalario - 642.85) * 0.1) + 32.70;
                }
                else if (pSalario >= 915.82 && pSalario <= 2058.67)
                {
                    Renta = ((pSalario - 915.81) * 0.2) + 60.00;
                }
                else if (pSalario >= 2058.68)
                {
                    Renta = ((pSalario - 2058.67) * 0.3) + 288.57;
                }
            }
            return Renta;
        }
    }
}