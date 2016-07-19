app.controller("CambioController",
    function ($scope, CambioRepository) {
        //Metodo GET
        var getSuccessCallback = function (data, status) {
            $scope.listaCambio = data.List;
            $scope.parameterlist.pages = data.TotalPages;
            $scope.parameterlist.totalRecords = data.TotalRecords;
        }
        var errorCallBack = function (data, status, headers, config) {
            alert("Ocurrio un problema de consulta de Cambio");
        }

        //Paginación
        $scope.parameterlist = {
            name: '',
            page: 1,
            records: 8,
            pages: 0,
            totalRecords: 100
        }

        CambioRepository.get($scope.parameterlist)
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

        //Validar Cambio a Guardar
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
        //Fin Validar Cambio a Guardar

        //Agregar Nuevo Cambio
        $scope.nuevoCambio = null;
        $scope.agregarCambio = function () {
            $scope.nuevoDucto = {
                "Id": 0, "Motivo": "", "OrdenServicio": "",
                "Fecha": new Date()
            };
            $('#NuevoMotivo').modal('show');
        }

        var postSuccessCallBack = function (data, status) {
            alert('Motivo Guardado');
            $('#NuevoMotivo').modal('hide');
        }

        $scope.guardarCambio = function (registro) {
            if (validar(registro)) {
                registro.LastUpdate = new Date();
                registro.RowState = "A";
                CambioRepository.add(registro).success(postSuccessCallBack).error(errorCallBack);
            }
        }
        //Fin Agregar Nuevo Motivo

        //Ver Motivo
        $scope.verMotivo = function (registro) {
            $scope.verMotivoRegistro = registro;
            $('#VerMotivo').modal('show');
        }


    });