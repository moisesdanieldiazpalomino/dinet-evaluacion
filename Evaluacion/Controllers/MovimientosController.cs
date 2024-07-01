using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;

namespace Evaluacion.Controllers
{
    public class MovimientosController : Controller
    {
        // GET: Movimientos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(DateTime? fechaInicio, DateTime? fechaFin, string tipoMovimiento, string numeroDocumento)
        {
            try
            {
                Negocio_Movimientos ngMovimiento = new Negocio_Movimientos();

                List<Movimiento> movimientos = ngMovimiento.BuscarMovimientos(fechaInicio, fechaFin, tipoMovimiento, numeroDocumento);

                return View("Index", movimientos);
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
            }
        }

        // GET: Movimientos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movimientos/Create
        [HttpPost]
        public ActionResult Create(Movimiento movimiento)
        {
            try
            {
                bool resutado;
                Negocio_Movimientos ngMovimiento = new Negocio_Movimientos();

                resutado = ngMovimiento.RegistrarMovimientos(movimiento);

                if(resutado)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.ErrorMessage = "No es posibe registrar los datos";
                    return View("Error");
                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        // GET: Movimientos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movimientos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movimientos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movimientos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
