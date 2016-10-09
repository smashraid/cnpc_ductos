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

        public ActionResult Create(int id)
        {
            RegistroInspeccionVisualModel Entidad = new RegistroInspeccionVisualModel();

            //Oleoducto nuevoDucto = new Oleoducto();
            OleoductoRequest registroOleo = new OleoductoRequest();
            OleoductoResponse resultadoOleo = null;
            var proxy = new ServicioClient();

            registroOleo.Item = new Oleoducto { Id = id };
            registroOleo.Operacion = Model.Operacion.BuscarPorId;
            resultadoOleo = proxy.OleoductoEjecutarOperacion(registroOleo);

            var Modelo_Oleo = resultadoOleo.Item.ConvertToViewModel();

            //Entidad.Id = 0;
            Entidad.OleoductoID = Modelo_Oleo.Id;
            Entidad.NumeroOleoducto = Modelo_Oleo.Codigo;

            return View(Entidad);

        }

        public ActionResult Details(int id)
        {
            var proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            
            registro.Item = new RegistroInspeccionVisual { Id = id };
            registro.Operacion = Model.Operacion.BuscarPorId;
            resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);

            return View(resultado.Item.ConvertToViewModel());

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroInspeccionVisual nuevaTuberia)
        {
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            //OleoductoRequest registroOleo = new OleoductoRequest();
            //OleoductoResponse resultadoOleo = null;
            //Oleoducto nuevoDucto = new Oleoducto();

            RegistroInspeccionVisualResponse resultado = null;
            var proxy = new ServicioClient();
            if (ModelState.IsValid)
            {
                try
                {
                    //nuevoDucto.Id = nuevaTuberia.Id;
                    //registroOleo.Item = nuevoDucto;
                    //registroOleo.Operacion = Model.Operacion.BuscarPorId;
                    //resultadoOleo = proxy.OleoductoEjecutarOperacion(registroOleo);

                    nuevaTuberia.RowState = "A";
                    nuevaTuberia.LastUpdate = DateTime.Now;
                    nuevaTuberia.CodigoDelTubo02 = "0";
                    nuevaTuberia.CodigoDelTubo03 = "0216";
                    nuevaTuberia.CodigoDelTubo = string.Format("{0}-{1}-{2}-{3}", nuevaTuberia.NumeroOleoducto
                                                                            , nuevaTuberia.CodigoDelTubo01
                                                                            , nuevaTuberia.CodigoDelTubo02
                                                                            , nuevaTuberia.CodigoDelTubo03);
                    //nuevaTuberia.OleoductoID = nuevaTuberia.Id;
                    //nuevaTuberia.NumeroOleoducto = resultadoOleo.Item.ConvertToViewModel().Codigo;
                    //nuevaTuberia.Id = 0;
                    registro.Item = nuevaTuberia;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("List/"+nuevaTuberia.OleoductoID);
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

            OleoductoRequest registros = new OleoductoRequest();
            OleoductoResponse resultados = null;

            registros.Item = new Oleoducto { Id = modelo.OleoductoID };
            registros.Operacion = Model.Operacion.BuscarPorId;
            resultados = proxy.OleoductoEjecutarOperacion(registros);

            if (ModelState.IsValid)
            {
                try
                {
                    modelo.RowState = "A";
                    modelo.LastUpdate = DateTime.Now;
                    modelo.CodigoDelTubo02 = "0";
                    modelo.CodigoDelTubo03 = "0216";
                    modelo.CodigoDelTubo = string.Format("{0}-{1}-{2}-{3}", resultados.Item.ConvertToViewModel().Codigo
                                                                            , modelo.CodigoDelTubo01
                                                                            , modelo.CodigoDelTubo02
                                                                            , modelo.CodigoDelTubo03);
                    modelo.UltimaFechaDeInspeccion = DateTime.Now;
                    registro.Item = modelo;
                    registro.Operacion = Model.Operacion.Actualizar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("List/" + model.OleoductoID);
                    else return View(model.ConvertToModel().ConvertToViewModel());
                    //OleoductoResponse ducto = proxy.OleoductoEjecutarOperacion(
                    //    new OleoductoRequest
                    //    {
                    //        Item = new Oleoducto { Id = resultado.Item.OleoductoID },
                    //        Operacion = Operacion.BuscarPorId
                    //    });

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