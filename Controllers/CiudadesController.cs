using Examen_BastianContreras_NicoleAlegria.Models;
using Examen_BastianContreras_NicoleAlegria.Permisos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Examen_BastianContreras_NicoleAlegria.Helpers;

namespace Examen_BastianContreras_NicoleAlegria.Controllers
{
    [ValidarSesion]
    public class CiudadesController : Controller
    {
        private EcoMercadoEntities db = new EcoMercadoEntities();

        // GET: Ciudades
        public ActionResult Index()
        {
            return View(db.Ciudades.ToList());
        }

        // GET: Ciudades/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudades.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            ViewBag.ListaRegiones = new SelectList(LocalidadesHelper.GetRegiones());
            return View();
        }

        // POST: Ciudades/Create.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Region,Provincia,Nombre")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudad);
                db.SaveChanges();
                TempData["Mensaje"] = "Ciudad creada exitosamente.";
                TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }


            ViewBag.ListaRegiones = new SelectList(LocalidadesHelper.GetRegiones());
            return View(ciudad);
        }

        // GET: Ciudades/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudades.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Ciudad editada exitosamente."; 
                TempData["Tipo"] = "info"; 
                return RedirectToAction("Index");
            }
            return View(ciudad);
        }

        // GET: Ciudades/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudad ciudad = db.Ciudades.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudad ciudad = db.Ciudades.Find(id);
            db.Ciudades.Remove(ciudad);
            db.SaveChanges();
            TempData["Mensaje"] = "Ciudad eliminada correctamente."; 
            TempData["Tipo"] = "danger"; 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult ObtenerProvincias(string region)
        {
            // Verifica si llega el dato
            if (string.IsNullOrEmpty(region)) return Json(new List<string>(), JsonRequestBehavior.AllowGet);

            var provincias = LocalidadesHelper.GetProvincias(region);
            return Json(provincias, JsonRequestBehavior.AllowGet);
        }

        // GET: Obtener Comunas (AJAX)
        public JsonResult ObtenerComunas(string region, string provincia)
        {
            if (string.IsNullOrEmpty(region) || string.IsNullOrEmpty(provincia))
                return Json(new List<string>(), JsonRequestBehavior.AllowGet);

            var comunas = LocalidadesHelper.GetComunas(region, provincia);
            return Json(comunas, JsonRequestBehavior.AllowGet);
        }
    }
}
