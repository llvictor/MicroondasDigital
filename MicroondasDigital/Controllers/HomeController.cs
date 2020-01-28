using MicroondasDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroondasDigital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.erros = TempData["erros"];
            return View("Index", ListarProgramas());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Programa> ListarProgramas()
        {
            return Microondas.Instance().programas.ToList();
        }


        [HttpPost]
        public ActionResult Executar(Programa programa, string alimento)
        {
            bool success = false;
            string mensagem = "";

            if (string.IsNullOrEmpty(alimento.Trim()))
            {
                ModelState.AddModelError(string.Empty, "Informe o alimento");
                mensagem += "Informe o alimento";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Microondas microondas = Microondas.Instance();
                    if (! microondas.Executar(programa.nome, alimento))
                    {
                        ModelState.AddModelError(string.Empty, "Alimento incompatível com o programa selecionado");
                        mensagem += "Alimento incompatível com o programa selecionado";
                    }
                    else
                    {
                        success = true;
                    }

                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, "Houve um erro ao tentar aquecer");
                    mensagem += "Houve um erro ao tentar aquecer";
                }

            }

            var resultado = new
            {
                success = success,
                result = mensagem
            };

            return Json(resultado);
        }



    }
}