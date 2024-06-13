using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public PruebaDBEntities db = new PruebaDBEntities();
        public ActionResult Index(string nroDocumento, string usuario)
        {
            var nroDocumentoBuscar = nroDocumento;
            var usuarioBuscar = usuario;
            if (nroDocumento == "")
            {
                nroDocumentoBuscar = null;
            }
            if (usuario == "")
            {
                usuarioBuscar = null;
            }

            if (nroDocumentoBuscar == null)
            {
                var lista = db.Consultar(null, usuarioBuscar).ToList();
                return View(lista);
            }
            var lista2 = db.Consultar(Convert.ToInt32(nroDocumentoBuscar), usuarioBuscar).ToList();
            return View(lista2);
        }

        [HttpPost]
        public ActionResult Agregar(Consultar_Result result)
        {
            db.AGREGAR(result.USUARIO, result.TIPO_DOCUMENTO, result.NRO_DOCUMENTO, result.CANTIDAD, result.FECHA_TRANSACCION, result.SALDO_FINAL);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Consultar_Result result)
        {
            db.ACTUALIZAR(result.USUARIO, result.TIPO_DOCUMENTO, result.NRO_DOCUMENTO, result.CANTIDAD, result.FECHA_TRANSACCION, result.SALDO_FINAL);
            return RedirectToAction("Index");
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
    }
}