using Fiap.Exemplo03.MVC.Models;
using Fiap.Exemplo03.MVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo03.MVC.Controllers
{
    public class FrutaController : Controller
    {
        
        [HttpGet]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar(Fruta fruta)
        {
            try
            {
                using (SacolaoContext context = new SacolaoContext())
                {
                    fruta.DataCadastro = System.DateTime.Now;
                    context.Frutas.Add(fruta);
                    context.SaveChanges();
                    TempData["msg"] = "Sucesso ao cadastrar. ";
                    TempData["classe"] = "alert alert-success";
                }
            }catch(Exception e)
            {
                TempData["msg"] = "Falha ao cadastrar. " + e.Message;
                TempData["classe"] = "alert alert-danger";
                return View(fruta);
            }
            
            return RedirectToAction("Cadastrar");
        }

        public ActionResult Listar()
        {
            using (SacolaoContext context = new SacolaoContext())
            {
                var lista = context.Frutas.ToList();
                return View(lista);
            }  
        }
    }
}