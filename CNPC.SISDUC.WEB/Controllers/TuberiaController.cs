using CNPC.SISDUC.Model.Servicio;
using System;
using System.Web.Mvc;
using PagedList;
using CNPC.SISDUC.Model;
using System.Collections.Generic;
using CNPC.SISDUC.WEB.Models;
using CNPC.SISDUC.Web.Proxy;
//using CNPC.SISDUC.WEB.Proxy;

namespace CNPC.SISDUC.WEB.Controllers
{
    public class TuberiaController : Controller
    {
        // GET: Tuberia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            RegistroInspeccionVisualModel Entidad = new RegistroInspeccionVisualModel();
            return View(Entidad);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroInspeccionVisual nuevaTuberia)
        {
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    nuevaTuberia.RowState = "A";
                    nuevaTuberia.LastUpdate = DateTime.Now;
                    registro.Item = nuevaTuberia;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("Index");
                    else return View(nuevaTuberia.ConvertToViewModel());
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

        public ActionResult List(int id, int? page, string search = "", int pageSize = 10)
        {
            RegistroInspeccionVisualResponse Resultado = null;
            // RegistroInspeccionVisualModel modelo = null;

            ServicioClient proxy = new ServicioClient();
            string error = String.Empty;
            Resultado = proxy.RegistroInspeccionVisualListarByDucto(id, search);
            OleoductoResponse oleoducto =
                proxy.OleoductoEjecutarOperacion(new OleoductoRequest
                {
                    Item = new Model.Oleoducto
                    {
                        Id = id
                    },
                    Operacion = Model.Operacion.BuscarPorId
                });
            List<RegistroInspeccionVisualModel> modelo = Resultado.ConvertToViewModel();
            ViewBag.oleoducto = oleoducto.Item;

            int pageNumber = (page ?? 1);
            return View(modelo.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult GetTuberia(int id, string name)
        {
            ServicioClient proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            RegistroInspeccionVisualModel modelo = new RegistroInspeccionVisualModel();
            if (ModelState.IsValid)
            {
                try
                {
                    registro.Item = new RegistroInspeccionVisual { Id = id };
                    registro.Operacion = Model.Operacion.BuscarPorId;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    resultado.ListTipoSoporte = proxy.TipoSoporteListarAllEntidad();

                    modelo = resultado.Item.ConvertToViewModel();

                    OleoductoResponse ducto = proxy.OleoductoEjecutarOperacion(
                        new OleoductoRequest
                        {
                            Item = new Oleoducto { Id = resultado.Item.OleoductoID },
                            Operacion = Operacion.BuscarPorId
                        });
                    modelo.oleoducto = ducto.Item;

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

            return View(modelo);
        }
        public IEnumerable<RegistroInspeccionVisual> GetIEnumerable(List<RegistroInspeccionVisual> lista)
        {
            List<RegistroInspeccionVisual> books = lista;
            return books;
        }
        [HttpPost]
        public ActionResult ActualizarTuberia(RegistroInspeccionVisualModel model, string returnUrl)
        {
            ServicioClient proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            RegistroInspeccionVisual modelo = new RegistroInspeccionVisual();
            modelo = model.ConvertToModel();
            if (ModelState.IsValid)
            {
                try
                {

                    registro.Item = modelo;
                    registro.Operacion = Model.Operacion.Actualizar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);

                    OleoductoResponse ducto = proxy.OleoductoEjecutarOperacion(
                        new OleoductoRequest
                        {
                            Item = new Oleoducto { Id = resultado.Item.OleoductoID },
                            Operacion = Operacion.BuscarPorId
                        });

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

            return View(modelo);
        }

    }
}