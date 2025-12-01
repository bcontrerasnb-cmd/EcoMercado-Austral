using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Examen_BastianContreras_NicoleAlegria.Models;
using Examen_BastianContreras_NicoleAlegria.Permisos;

namespace Examen_BastianContreras_NicoleAlegria.Controllers
{
    [ValidarSesion]
    public class ClientesController : Controller
    {
        private EcoMercadoEntities db = new EcoMercadoEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            // Incluimos Segmento y Ciudades para mostrar en la tabla
            return View(db.Clientes.Include(c => c.Segmento).Include(c => c.Ciudades).ToList());
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            var viewModel = new ClienteViewModel();
            viewModel.Cliente = new Cliente();
            viewModel.ListaSegmentos = new SelectList(
                db.SegmentosClientes.Where(s => s.Estado == "Vigente").OrderBy(s => s.Nombre),
                "Id", "Nombre"
            );
            viewModel.ListaCiudades = db.Ciudades.Select(c => new CheckBoxItem
            {
                Id = c.Id,
                Nombre = c.Nombre + " (" + c.Region + ")",
                IsSelected = false
            }).ToList();

            return View(viewModel);
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel model)
        {
            if (ModelState.IsValid) // Valida solo campos básicos
            {
                // Crear el Cliente base
                var nuevoCliente = model.Cliente;

                // Asociar las ciudades marcadas
                var idsSeleccionados = model.ListaCiudades.Where(x => x.IsSelected).Select(x => x.Id).ToList();
                foreach (var ciudadId in idsSeleccionados)
                {
                    var ciudad = db.Ciudades.Find(ciudadId);
                    if (ciudad != null)
                    {
                        nuevoCliente.Ciudades.Add(ciudad);
                    }
                }

                db.Clientes.Add(nuevoCliente);
                db.SaveChanges();
                TempData["Mensaje"] = "Perfil de cliente creado con múltiples localidades.";
                TempData["Tipo"] = "success";
                return RedirectToAction("Index");
            }

            // Si falla, recargar listas
            model.ListaSegmentos = new SelectList(
            db.SegmentosClientes.Where(s => s.Estado == "Vigente").OrderBy(s => s.Nombre),
            "Id", "Nombre",
            model.Cliente.SegmentoId);
            return View(model);
        }

        // GET: Clientes/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // 1. PRIMERO buscamos el cliente (Aquí nace la variable 'cliente')
            var cliente = db.Clientes.Include(c => c.Ciudades).FirstOrDefault(c => c.Id == id);

            if (cliente == null) return HttpNotFound();

            var viewModel = new ClienteViewModel();
            viewModel.Cliente = cliente;

            // 2. AHORA SÍ podemos usar la variable 'cliente' dentro del Where
            var segmentosDisponibles = db.SegmentosClientes
                .Where(s => s.Estado == "Vigente" || s.Id == cliente.SegmentoId) 
                .OrderBy(s => s.Nombre);

            viewModel.ListaSegmentos = new SelectList(segmentosDisponibles, "Id", "Nombre", cliente.SegmentoId);

            // Cargar Ciudades y marcar las que ya tiene
            var ciudadesDb = db.Ciudades.ToList();
            viewModel.ListaCiudades = new List<CheckBoxItem>();

            foreach (var ciudad in ciudadesDb)
            {
                viewModel.ListaCiudades.Add(new CheckBoxItem
                {
                    Id = ciudad.Id,
                    Nombre = ciudad.Nombre + " (" + ciudad.Region + ")",
                    IsSelected = cliente.Ciudades.Any(c => c.Id == ciudad.Id)
                });
            }

            return View(viewModel);
        }

        // POST: Clientes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 1. Traer el cliente original de la BD INCLUYENDO sus relaciones actuales
                var clienteDb = db.Clientes.Include(c => c.Ciudades).FirstOrDefault(c => c.Id == model.Cliente.Id);

                // 2. Actualizar datos (Nombre, Rut, etc)
                clienteDb.Rut = model.Cliente.Rut;
                clienteDb.Nombre = model.Cliente.Nombre;
                clienteDb.Empresa = model.Cliente.Empresa;
                clienteDb.Email = model.Cliente.Email;
                clienteDb.Telefono = model.Cliente.Telefono;
                clienteDb.SegmentoId = model.Cliente.SegmentoId;

                //Limpiar las ciudades actuales
                clienteDb.Ciudades.Clear();

                //Agregar las nuevas seleccionadas
                var idsSeleccionados = model.ListaCiudades.Where(x => x.IsSelected).Select(x => x.Id).ToList();
                foreach (var id in idsSeleccionados)
                {
                    var ciudad = db.Ciudades.Find(id);
                    clienteDb.Ciudades.Add(ciudad);
                }

                db.Entry(clienteDb).State = EntityState.Modified;
                db.SaveChanges();

                TempData["Mensaje"] = "Perfil actualizado correctamente.";
                TempData["Tipo"] = "info";
                return RedirectToAction("Index");
            }

            // Recargar listas si falla
            model.ListaSegmentos = new SelectList(
               db.SegmentosClientes.Where(s => s.Estado == "Vigente" || s.Id == model.Cliente.SegmentoId).OrderBy(s => s.Nombre),
               "Id", "Nombre",
               model.Cliente.SegmentoId);
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Buscamos al cliente con sus datos para mostrarlos en la tarjeta de confirmación
            var cliente = db.Clientes
                            .Include(c => c.Segmento)
                            .Include(c => c.Ciudades)
                            .FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = db.Clientes.Include(c => c.Ciudades).FirstOrDefault(c => c.Id == id);

            if (cliente != null)
            {
                try
                {

                    cliente.Ciudades.Clear();

                    // 2. Borramos al cliente
                    db.Clientes.Remove(cliente);
                    db.SaveChanges();

                    TempData["Mensaje"] = "Cliente eliminado correctamente.";
                    TempData["Tipo"] = "success";
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Error al eliminar: " + ex.Message;
                    TempData["Tipo"] = "danger";
                }
            }

            return RedirectToAction("Index");
        }
    }
}

