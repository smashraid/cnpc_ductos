using CNPC.SISDUC.Model.Servicio;
using System;
using System.Web.Mvc;
using PagedList;
using CNPC.SISDUC.Model;
using System.Collections.Generic;
using CNPC.SISDUC.WEB.Models;
using CNPC.SISDUC.Web.Proxy;

namespace CNPC.SISDUC.WEB.Controllers
{
    public class AccesoriosController : Controller
    {
        // GET: Accesorios
        public ActionResult Index(string id, int? page, string search = "", int pageSize = 10)
        {
            AccesorioResponse Resultado = null;
            // RegistroInspeccionVisualModel modelo = null;

            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            Resultado = proxy.AccesoriosListarByTuberia(id, search);

            List<AccesoriosModels> modelo = Resultado.ConvertToViewModel();

            int pageNumber = (page ?? 1);
            return View(modelo.ToPagedList(pageNumber, pageSize));
        }

        // GET: Accesorios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Accesorios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accesorios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Accesorios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Accesorios/Edit/5
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

        // GET: Accesorios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Accesorios/Delete/5
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
