using Fiap.Exemplo03.MVC.Models;
using Fiap.Exemplo03.MVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo03.MVC.Controllers
{
    public class ProdutorController : Controller
    {
        // GET: Produtor
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produtor produtor)
        {
            using(SacolaoContext contexto = new SacolaoContext())
            {
                try
                {
                    produtor.DataCadastro = System.DateTime.Now;
                    contexto.Produtores.Add(produtor);
                    contexto.SaveChanges();
                    TempData["msg"] = "Produtor cadastrado com sucesso";
                    TempData["classe"] = "alert alert-success";
                }catch(Exception erro)
                {
                    TempData["msg"] = "Erro ao cadastrar produtor - " + erro.Message;
                    TempData["classe"] = "alert alert-danger";
                    return View();
                }
            }
            return RedirectToAction("Cadastrar");
        }

        public ActionResult Listar()
        {
            using(SacolaoContext contexto = new SacolaoContext())
            {
                var lista = contexto.Produtores.ToList();
                return View(lista);
            }
        }
    }
}