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
            //RegistroInspeccionVisualResponse resultado = new RegistroInspeccionVisualResponse();
            RegistroInspeccionVisualModel Entidad = new RegistroInspeccionVisualModel();

            var proxy = new ServicioClient();

            OleoductoResponse oleoducto =
               proxy.OleoductoEjecutarOperacion(new OleoductoRequest
               {
                   Item = new Model.Oleoducto
                   {
                       Id = id
                   },
                   Operacion = Model.Operacion.BuscarPorId
               });

            //ViewBag.oleoducto = oleoducto.Item;
            var Modelo_Oleo = oleoducto.Item.ConvertToViewModel();

            List<SelectListItem> list = new List<SelectListItem>();
            var listado = proxy.TipoSoporteListarAllEntidad();
            foreach (var item in listado.List)
            {
                var newItem = new SelectListItem { Text = item.Nombre, Value = item.Valor };
                list.Add(newItem);
            }            
            //resultado.ListTipoSoporte = proxy.TipoSoporteListarAllEntidad();

            //Entidad.ListaTipoSoporte = resultado.ListTipoSoporte;
            Entidad.oleoducto = oleoducto.Item;
            Entidad.ListaTipoSoporte = list;
            Entidad.OleoductoID = Modelo_Oleo.Id;
            Entidad.NumeroOleoducto = Modelo_Oleo.Codigo;
            

            RegistroInspeccionVisualResponse Resultado = null;
            Resultado = proxy.RegistroInspeccionVisualListarByDucto(id, "", "D");
            Entidad.ListaEliminados = Resultado.ConvertToViewModel();

            return View(Entidad);

        }

        public ActionResult Details(int id,int Codigo)
        {
            var proxy = new ServicioClient();
            RegistroInspeccionVisualRequest registro = new RegistroInspeccionVisualRequest();
            RegistroInspeccionVisualResponse resultado = null;
            
            registro.Item = new RegistroInspeccionVisual { Id = id };
            registro.Operacion = Model.Operacion.BuscarPorId;
            resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);

            OleoductoResponse oleoducto =
                proxy.OleoductoEjecutarOperacion(new OleoductoRequest
                {
                    Item = new Model.Oleoducto
                    {
                        Id = Codigo
                    },
                    Operacion = Model.Operacion.BuscarPorId
                });
            ViewBag.oleoducto = oleoducto.Item;

            return View(resultado.Item.ConvertToViewModel());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(string hd_id_oleoducto,int id_oleoducto, int hd_id_tuberia, string Motivo, string OrdenServicio)
        {
            CambiosTuberiaRequest registro = new CambiosTuberiaRequest();
            CambiosTuberiaResponse resultado = null;
            CambiosTuberia Entidad = new CambiosTuberia();
            var proxy = new ServicioClient();

            RegistroInspeccionVisualResponse Tuberia =
                proxy.RegistroInspeccionVisualEjecutarOperacion(new RegistroInspeccionVisualRequest
                {
                    Item = new Model.RegistroInspeccionVisual
                    {
                        Id = hd_id_tuberia
                    },
                    Operacion = Model.Operacion.BuscarPorId
                });

            Entidad.NumeroOleoducto = hd_id_oleoducto;
            Entidad.CodigoDelTubo01 = Tuberia.Item.ConvertToViewModel().CodigoDelTubo;
            Entidad.LastUpdate = DateTime.Now;
            Entidad.OrdenServicio = OrdenServicio;
            Entidad.Motivo = Motivo;
            Entidad.RowState = "A";
            
            registro.Item = Entidad;
            registro.Operacion = Model.Operacion.Agregar;
            resultado = proxy.CambiosTuberiaEjecutarOperacion(registro);

            RegistroInspeccionVisualResponse ElimTuberia =
               proxy.RegistroInspeccionVisualEjecutarOperacion(new RegistroInspeccionVisualRequest
               {
                   Item = new Model.RegistroInspeccionVisual
                   {
                       Id = hd_id_tuberia
                   },
                   Operacion = Model.Operacion.Eliminar
               });

            return RedirectToAction("List/" + id_oleoducto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegistroInspeccionVisual nuevaTuberia, string motivo, string OrdenServicio, string id_marcados)
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
                    nuevaTuberia.CodigoDelTubo02 = "0";
                    nuevaTuberia.CodigoDelTubo03 = "0216";
                    nuevaTuberia.CodigoDelTubo = string.Format("{0}-{1}-{2}-{3}", nuevaTuberia.NumeroOleoducto
                                                                            , nuevaTuberia.CodigoDelTubo01
                                                                            , nuevaTuberia.CodigoDelTubo02
                                                                            , nuevaTuberia.CodigoDelTubo03);

                    registro.Item = nuevaTuberia;
                    registro.Operacion = Model.Operacion.Agregar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);

                    //REGISTRO DE CAMBIOS
                    CambiosTuberiaRequest CambioRequest = new CambiosTuberiaRequest();
                    CambiosTuberiaResponse CambioResponse = null;
                    
                    if (motivo == "Agregado")
                    {
                        CambiosTuberia Cambio = new CambiosTuberia();
                        Cambio.NumeroOleoducto = nuevaTuberia.NumeroOleoducto;
                        Cambio.CodigoDelTubo01 = nuevaTuberia.CodigoDelTubo;
                        Cambio.CodigoDelTuboReemplazado = "";
                        Cambio.LastUpdate = DateTime.Now;
                        Cambio.OrdenServicio = OrdenServicio;
                        Cambio.Motivo = motivo;
                        Cambio.RowState = "A";

                        CambioRequest.Item = Cambio;
                        CambioRequest.Operacion = Model.Operacion.Agregar;
                        CambioResponse = proxy.CambiosTuberiaEjecutarOperacion(CambioRequest);
                    }
                    else {
                        foreach (var item in id_marcados.Split(','))
                        {
                            CambiosTuberia Cambio = new CambiosTuberia();
                            Cambio.NumeroOleoducto = nuevaTuberia.NumeroOleoducto;
                            Cambio.CodigoDelTubo01 = nuevaTuberia.CodigoDelTubo;
                            Cambio.CodigoDelTuboReemplazado = item;
                            Cambio.LastUpdate = DateTime.Now;
                            Cambio.OrdenServicio = OrdenServicio;
                            Cambio.Motivo = motivo;
                            Cambio.RowState = "A";

                            CambioRequest.Item = Cambio;
                            CambioRequest.Operacion = Model.Operacion.Agregar;
                            CambioResponse = proxy.CambiosTuberiaEjecutarOperacion(CambioRequest);
                        }
                    }
                   
                    //FIN REGISTRO DE CAMBIOS

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
            Resultado = proxy.RegistroInspeccionVisualListarByDucto(id, search, "A");
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

                    List<SelectListItem> list = new List<SelectListItem>();
                    foreach (var item in resultado.ListTipoSoporte.List)
                    {
                        var newItem = new SelectListItem { Text = item.Nombre, Value = item.Valor};
                        list.Add(newItem);
                    }
                    modelo.ListaTipoSoporte = list;
                    
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
     
            OleoductoResponse resultados =
             proxy.OleoductoEjecutarOperacion(new OleoductoRequest
             {
                 Item = new Model.Oleoducto
                 {
                     Id = modelo.OleoductoID
                 },
                 Operacion = Model.Operacion.BuscarPorId
             });

            if (ModelState.IsValid)
            {
                try
                {
                    modelo.RowState = "A";
                    modelo.LastUpdate = DateTime.Now;
                    modelo.NumeroOleoducto = resultados.Item.Codigo;
                    modelo.CodigoDelTubo02 = "0";
                    modelo.CodigoDelTubo03 = "0216";
                    modelo.CodigoDelTubo = string.Format("{0}-{1}-{2}-{3}", modelo.NumeroOleoducto
                                                                            , modelo.CodigoDelTubo01
                                                                            , modelo.CodigoDelTubo02
                                                                            , modelo.CodigoDelTubo03);
                    modelo.UltimaFechaDeInspeccion = DateTime.Now;
                    registro.Item = modelo;
                    registro.Operacion = Model.Operacion.Actualizar;
                    resultado = proxy.RegistroInspeccionVisualEjecutarOperacion(registro);
                    if (resultado.Resultado) return RedirectToAction("List/" + model.OleoductoID);
                    else return View(model);
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