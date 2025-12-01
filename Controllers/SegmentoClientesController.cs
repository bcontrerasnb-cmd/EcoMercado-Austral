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

namespace Examen_BastianContreras_NicoleAlegria.Controllers
{
    [ValidarSesion]
    public class SegmentoClientesController : Controller
    {
        private EcoMercadoEntities db = new EcoMercadoEntities();

        // GET: SegmentoClientes
        public ActionResult Index()
        {
            return View(db.SegmentosClientes.ToList());
        }

        // GET: SegmentoClientes/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SegmentoCliente segmentoCliente = db.SegmentosClientes.Find(id);
            if (segmentoCliente == null)
            {
                return HttpNotFound();
            }
            return View(segmentoCliente);
        }

        // GET: SegmentoClientes/Create
        public ActionResult Create()
        {
            // Definimos la lista de opciones
            var estados = new List<string> { "Vigente", "Pendiente", "Deshabilitado" };

            // La guardamos en un ViewBag para enviarla a la vista
            ViewBag.ListaEstados = new SelectList(estados);

            return View();
        }

        // POST: SegmentoClientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Estado")] SegmentoCliente segmentoCliente)
        {
            if (ModelState.IsValid)
            {
                db.SegmentosClientes.Add(segmentoCliente);
                db.SaveChanges();
                TempData["Mensaje"] = "Segmento creado exitosamente.";
                TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }

            var estados = new List<string> { "Vigente", "Pendiente", "Deshabilitado" };
            ViewBag.ListaEstados = new SelectList(estados);

            return View(segmentoCliente);
        }

        // GET: SegmentoClientes/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SegmentoCliente segmentoCliente = db.SegmentosClientes.Find(id);
            if (segmentoCliente == null)
            {
                return HttpNotFound();
            }

            // LISTA DE OPCIONES PARA EDITAR
            var estados = new List<string> { "Vigente", "Pendiente", "Deshabilitado" };

            // El segundo parámetro 'segmentoCliente.Estado' selecciona el que ya tiene guardado
            ViewBag.ListaEstados = new SelectList(estados, segmentoCliente.Estado);

            return View(segmentoCliente);
        }

        // POST: SegmentoClientes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Estado")] SegmentoCliente segmentoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmentoCliente).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensaje"] = "Segmento actualizado correctamente.";
                TempData["Tipo"] = "info";
                return RedirectToAction("Index");
            }

            // SI FALLA, RECARGAMOS LA LISTA
            var estados = new List<string> { "Vigente", "Pendiente", "Deshabilitado" };
            ViewBag.ListaEstados = new SelectList(estados, segmentoCliente.Estado);

            return View(segmentoCliente);
        }

        // GET: SegmentoClientes/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SegmentoCliente segmentoCliente = db.SegmentosClientes.Find(id);
            if (segmentoCliente == null)
            {
                return HttpNotFound();
            }
            return View(segmentoCliente);
        }

        // POST: SegmentoClientes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SegmentoCliente segmento = db.SegmentosClientes.Find(id);

            try
            {
                db.SegmentosClientes.Remove(segmento);
                db.SaveChanges(); 

                TempData["Mensaje"] = "Segmento eliminado correctamente.";
                TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                
                TempData["Mensaje"] = "ERROR: No se puede eliminar el segmento '" + segmento.Nombre + "' porque existen clientes asociados a él. Primero cambia esos clientes a otro segmento.";
                TempData["Tipo"] = "danger"; 

                return RedirectToAction("Index");
            }
        }
    }
}
