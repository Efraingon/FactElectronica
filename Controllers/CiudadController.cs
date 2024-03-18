using FactElectronica.Datos;
using FactElectronica.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactElectronica.Controllers
{
   
    public class CiudadController : Controller
    {
        CiudadAdm admin = new CiudadAdm();
        public IActionResult Index()
        {
            return View(admin.Consultar());
        }
        public IActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Ciudad modelo)
        {
            ViewBag.mensaje = "Se Guardo la Ciudad";

            admin.Guardar(modelo);
           
            return View(modelo);
        }
    }
}
