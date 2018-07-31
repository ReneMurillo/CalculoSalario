using PlanillaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanillaMVC.Controllers
{
    public class PlanillasController : Controller
    {
        Planilla planilla = new Planilla();
        // GET: Planillas
        public ActionResult Index()
        {
            if(Request.HttpMethod == "POST")
            {
                double pagoHora = Convert.ToDouble(Request["txtpagoHora"]);
                int horasT = Convert.ToInt32(Request["txthoras"]);
                
                ViewBag.Nombre = Request["txtnombre"];

                if (Request["op1"] == "afp")
                {
                    planilla.AplicarAfp = true;
                }                
                if (Request["op2"] == "isss")
                {
                    planilla.AplicarIsss = true;
                }
                if (Request["op3"] == "renta")
                {
                    planilla.AplicarRenta = true;
                }
                if (Request["op4"] == "ninguno")
                {
                    planilla.AplicarAfp = false;
                    planilla.AplicarIsss = false;
                    planilla.AplicarRenta = false;
                }

                ViewBag.SalarioBruto = "$" + planilla.SalariosBruto(horasT, pagoHora);
                ViewBag.AFP = "$" + planilla.Afp;
                ViewBag.Isss = "$" + planilla.Isss;
                ViewBag.Salario = "$" + planilla.Salario;
                ViewBag.Renta = "$" + planilla.Renta;
                ViewBag.SalarioQuincenal = "$" + planilla.SalarioQuincenal;
                ViewBag.SalarioMensual = "$" + planilla.SalarioMensual;
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(string prestaciones, string txtnombre, double txtpagoHora, int txthoras)
        //{
        //    ViewBag.SalarioBruto = planilla.SalariosBruto(txthoras, txtpagoHora);
        //    ViewBag.Nombre = txtnombre;
        //    ViewBag.AFP = planilla.Afp;
        //    ViewBag.Isss = planilla.Isss;
        //    ViewBag.Salario = planilla.Salario;
        //    ViewBag.Renta = planilla.Renta;
        //    ViewBag.SalarioQuincenal = planilla.SalarioQuincenal;
        //    ViewBag.SalarioMensual = planilla.SalarioMensual;
        //    return View();
        //}
    }
}