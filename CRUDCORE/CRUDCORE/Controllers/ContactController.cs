using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Data;
using CRUDCORE.Models;


namespace CRUDCORE.Controllers
{
    public class ContactController : Controller
    {
        ContactData _ContacData = new ContactData();

        public IActionResult Listar()
        {
            var oLista = _ContacData.Listar();
            return View(oLista);
        } 

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {

            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContacData.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }

        public IActionResult Editar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContacData.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContacData.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContacData.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {

            var respuesta = _ContacData.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
