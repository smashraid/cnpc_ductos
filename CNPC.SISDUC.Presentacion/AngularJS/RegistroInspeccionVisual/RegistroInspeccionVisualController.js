app.controller("RegistroInspeccionVisualController",
    function ($scope, $routeParams, RegistroInspeccionVisualRepository, CambioRepository) {
        //Metodo GET
        var getSuccessCallback = function (data, status) {
            $scope.listaTuberia = data.List;
            $scope.listaTipoSoporte = data.ListTipoSoporte.List;
            $scope.oleoducto = data.oleoducto;
            $scope.parameterlist.pages = data.TotalPages;
            $scope.parameterlist.totalRecords = data.TotalRecords;
        }
        var errorCallBack = function (data, status, headers, config) {
            alert("Ocurrio un problema de consulta de Datos");
        }

        //Paginación
        $scope.parameterlist = {
            oleoductoid: $routeParams.id,
            name: '',
            page: 1,
            records: 8,
            pages: 0,
            totalRecords: 0
        }

        RegistroInspeccionVisualRepository.get($scope.parameterlist)
        .success(getSuccessCallback)
        .error(errorCallBack);
        //Fin Metodo GET

        ////////////////////////////
        $scope.totalItems = $scope.parameterlist.totalRecords;
        $scope.currentPage = $scope.parameterlist.records;

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.pageChanged = function () {
            $log.log('Page changed to: ' + $scope.currentPage);
        };

        $scope.maxSize = $scope.parameterlist.records;
        $scope.bigTotalItems = $scope.parameterlist.totalRecords;
        $scope.bigCurrentPage = $scope.parameterlist.page;

        /////////////////////////

        //Validar Tuberia a Guardar
        var validar = function (tuberia) {
            if (tuberia.Codigo == "") {
                alert('Ingrese el Código');
                return false;
            }
            if (tuberia.NoLamina == "") {
                alert('Ingrese el Número de Lamina');
                return false;
            }
            if (tuberia.Trayectoria == "") {
                alert('Ingrese la Trayectoria');
                return false;
            }
            return true;
        }
        //Fin Validar Oleoducto a Guardar

        //Agregar Nueva Tuberia
        $scope.nuevoTuberia = null;
        $scope.agregarTuberia = function () {
            $scope.nuevoTuberia = {
                "Id": 0, "OleoductoID": 0, "CodigoDelTubo": "", "NumeroAnterior": "",
                "NPS": "", "Schedule": "", "SHC": "", "TipoMaterial": "",
                "Longitud": "", "CoordenadasUTM_X": "", "CoordenadasUTM_Y": "",
                "ExtremoInicial1": "", "ExtremoInicial2": "", "ExtremoInicial3": "",
                "ExtremoInicial4": "", "BSCAN": "", "EspesorPared": "",
                "ExtremoMedio1": "", "ExtremoMedio2": "", "ExtremoMedio3": "",
                "ExtremoMedio4": "", "MapeoCorrison": "", "PitCorrosion": "",
                "ExtremoFinal1": "", "ExtremoFinal2": "", "ExtremoFinal3": "",
                "ExtremoFinal4": "", "LEFT_MINIMO": "", "EspesorRemanente": "",
                "Defecto": "", "Defecto2": "", "NumeroGrapas": "", "TipoSoporte": "",
                "Elastomero": "", "Maleza": "", "TuberiaAlrededor": "", "Pintura": "",
                "CruceCarretera": "", "TipoProteccion": "", "EstadoProteccion": "",
                "EstadoTuberia": "", "EspesorNominal": "", "EspesorMinimoRealRemanente": "",
                "ObservacionesDeLaInspeccionVisual": "", "CondicionDelTramo": "",
                "UltimaFechaDeInspeccion": "", "SeleccionarTuberia": "", "RowState": "",
                "LastUpdate": ""
            };
            $('#NuevaTuberia').modal('show');
        }
        var postSuccessCallBack = function (data, status) {
            alert('Tuberia Creada');
            $('#NuevaTuberia').modal('hide');
        }

        $scope.guardarTuberia = function (tuberia, oleoducto) {
            if (validar(tuberia)) {
                tuberia.OleoductoID = oleoducto.Id
                tuberia.LastUpdate = new Date();
                tuberia.RowState = "A";

                RegistroInspeccionVisualRepository.add(tuberia).success(postSuccessCallBack).error(errorCallBack);
                //TODO: VERIFICAR REFRESH AUTOMATICO
            }
        }
        //Fin Agregar Nueva Tuberia

        //Ver Tuberia
        $scope.verTuberia = function (tuberia) {
            $scope.reporteTuberia = tuberia;
            $('#VerTuberia').modal('show');
        }
        //Fin Ver Tuberia

        //Ver Accesorio
        $scope.VerAccesorio = function (tuberia) {
            AccesorioRepository.get(tuberia).success(putSuccessCallBack).error(errorCallBack);
            $('#VerAccesorio').modal('show');
        }
        //Fin Ver Tuberia

        //Editar Tuberia
        var putSuccessCallBack = function (data, status) {
            alert('Tuberia Actualizada');
            $('#EditarTuberia').modal('hide');
        }

        var cambiosTuberia = {
            "Id": 0,
            "NumeroOleoducto": 0,
            "CodigoDelTubo01": "",
            "TuberiaId": "",
            "Motivo": "",
            "OrdenServicio": "",
            "FechaOrdenservicio": "",
            "RowState": "",
            "LastUpdate": ""
        };




        $scope.guardarMotivo = function (cambio) {
            if (validar(cambio)) {
                cambiosTuberia.NumeroOleoducto = cambio.NumeroOleoducto;
                cambiosTuberia.CodigoDelTubo01 = cambio.CodigoDelTubo;
                cambiosTuberia.FechaOrdenservicio = cambio.Fecha;
                cambiosTuberia.OrdenServicio = cambio.OrdenServicio;
                cambiosTuberia.TuberiaId = cambio.Id;
                cambiosTuberia.Motivo = cambio.Motivo;
                cambiosTuberia.LastUpdate = new Date();
                cambiosTuberia.RowState = "A";
                CambioRepository.add(cambiosTuberia).success(postSuccessCallBack).error(errorCallBack);
            }
        }

        $scope.actualizarTuberia = function (tuberia) {
            if (validar(tuberia)) {
                tuberia.LastUpdate = new Date();
                tuberia.RowState = "A";
                RegistroInspeccionVisualRepository.update(tuberia).success(putSuccessCallBack).error(errorCallBack);
            }
        }
        $scope.EditarTuberia = function (tuberia) {
            $scope.editaTuberia = tuberia;
            $('#EditarTuberia').modal('show');
        }
        //Fin Editar Tuberia

        //Eliminar Tuberia
        var deleteSuccessCallBack = function (status) {
            alert('Tuberia Eliminada');
        }

        //Guardar Motivo


        //Validar CambioTuberia a Guardar
        var validar = function (registro) {
            if (registro.Motivo == "") {
                alert('Ingrese el Motivo');
                return false;
            }
            if (registro.OrdenServicio == "") {
                alert('Ingrese la Orden de Servicio');
                return false;
            }

            return true;
        }

        //$scope.guardarMotivo = function () {

        //    //Guardar CambioTuberia


        //    $scope.editaTuberia = tuberia;
        //    if (validar(tuberia)) {
        //        tuberia.LastUpdate = new Date();
        //        tuberia.RowState = "D";
        //        RegistroInspeccionVisualRepository.update(tuberia).success(deleteSuccessCallBack).error(errorCallBack);
        //    }
        //}

        $scope.EliminarTuberia = function (tuberia) {
            $scope.deleteTuberia = tuberia;
            $('#NuevoMotivo').modal('show');
        }
        //Fin Eliminar Tuberia


        //paginación
        $scope.firstPage = function () {
            $scope.parameterlist.page = 1;
            RegistroInspeccionVisualRepository.get($scope.parameterlist)
             .success(getSuccessCallback)
             .error(errorCallBack);
        };

        $scope.previousPage = function () {
            if ($scope.parameterlist.page > 1) {
                $scope.parameterlist.page--;
                RegistroInspeccionVisualRepository.get($scope.parameterlist)
                 .success(getSuccessCallback)
                 .error(errorCallBack);
            }
        };

        $scope.nextPage = function () {
            if ($scope.parameterlist.page < $scope.parameterlist.pages) {
                $scope.parameterlist.page++;
                RegistroInspeccionVisualRepository.get($scope.parameterlist)
                 .success(getSuccessCallback)
                 .error(errorCallBack);
            }
        };

        $scope.lastPage = function () {
            $scope.parameterlist.page = $scope.parameterlist.pages;
            RegistroInspeccionVisualRepository.get($scope.parameterlist)
             .success(getSuccessCallback)
             .error(errorCallBack);
        };
        //Fin de Paginación
    });