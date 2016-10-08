using CNPC.SISDUC.Model;
using CNPC.SISDUC.Model.Servicio;
using System;
using System.Web.Mvc;
using PagedList;
using CNPC.SISDUC.Web.Proxy;
using CNPC.SISDUC.Web.Models;
using System.Collections.Generic;

namespace CNPC.SISDUC.WEB.Controllers
{
    public class OleoductoController : Controller
    {
        // GET: Oleoducto
        public ActionResult Index(int? page, string search = "", int pageSize = 10)
        {
            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            OleoductoResponse listado = proxy.OleoductoListarAllEntidad(search);
            List<OleoductoViewModel> lista= listado.ConvertToViewModel();
            int pageNumber = (page ?? 1);
            return View(lista.ToPagedList(pageNumber, pageSize));
            //return View(listado);
        }
        public ActionResult Edit(int id = 0)
        {
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item = new Oleoducto { Id = id };
                    registro.Operacion = Model.Operacion.BuscarPorId;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            //Oleoducto valor = 
            return View(resultado.Item.ConvertToViewModel());
        }
        public ActionResult GetOleoductos(string name, int page, int records)
        {
            var proxy = new ServicioClient();
            var error = String.Empty;
            OleoductoResponse listado = proxy.OleoductoListarEntidad(name, page, records);
            return View(listado);
        }

        public ActionResult Create()
        {
            OleoductoViewModel Entidad = new OleoductoViewModel();
            return View(Entidad);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Oleoducto nuevoDucto)
        {
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    nuevoDucto.Cliente = "CNPC PERU SA";
                    nuevoDucto.RowState = "A";
                    nuevoDucto.LastUpdate = DateTime.Now;
                    registro.Item = nuevoDucto;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("Index");
                    else return View(nuevoDucto.ConvertToViewModel());
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            return View(resultado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Oleoducto editarDucto)
        {
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    editarDucto.Cliente = "CNPC PERU SA";
                    editarDucto.RowState = "A";
                    editarDucto.LastUpdate = DateTime.Now;
                    registro.Item = editarDucto;
                    registro.Operacion = Model.Operacion.Actualizar;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("Index");
                    else return View(editarDucto.ConvertToViewModel());
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            return View(resultado);
        }
        public ActionResult Delete(int id)
        {
            OleoductoRequest registro = new OleoductoRequest();
            OleoductoResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item.Id = id;
                    registro.Operacion = Model.Operacion.Eliminar;
                    resultado = proxy.OleoductoEjecutarOperacion(registro);
                }
                catch (Exception ex)
                {
                    resultado.MensajeError = ex.Message;
                }
            }
            else
            {
                resultado.MensajeError = "Error en el ingreso de Datos";
            }
            return View(resultado);
        }
    }
}