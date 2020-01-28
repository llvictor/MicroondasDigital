using MicroondasDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroondasDigital.Controllers
{
    public class ProgramaController : Controller
    {
        // GET: Programa
        public ActionResult Index()
        {
            return View("Index", ListarProgramas());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NovoPrograma(Programa programa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Microondas microondas = Microondas.Instance();
                    microondas.Adicionar(new Programa(
                        programa.nome,
                        programa.instrucao,
                        programa.tempo,
                        programa.potencia,
                        programa.caracter
                    ));
                }
                catch(Exception e)
                {
                    ModelState.AddModelError(string.Empty, "Houve um erro ao tentar adicionar o novo programa");
                }
            }

            return View("Index", ListarProgramas());
        }

        public List<Programa> ListarProgramas()
        {
            List<Programa> lista = Microondas.Instance().programas.ToList();
            return lista;
        }
    }
}