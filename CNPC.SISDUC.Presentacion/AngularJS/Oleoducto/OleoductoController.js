app.controller("OleoductoController",
    function ($scope, OleoductoRepository) {
        //Metodo GET
        var getSuccessCallback = function (data, status) {
            $scope.listaOleoductos = data.List;
            $scope.parameterlist.pages = data.TotalPages;
            $scope.parameterlist.totalRecords = data.TotalRecords;
        }
        var errorCallBack = function (data, status, headers, config) {
            alert("Ocurrio un problema de consulta de Datos");
        }

        //Paginación
        $scope.parameterlist = {
            name: '',
            page: 1,
            records: 8,
            pages: 0,
            totalRecords: 100
        }

        OleoductoRepository.get($scope.parameterlist)
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

        //Validar Oleoducto a Guardar
        var validar = function (ducto) {
            if (ducto.Codigo === "") {
                alert('Ingrese el Código');
                return false;
            }
            if (ducto.NoLamina === "") {
                alert('Ingrese el Número de Lamina');
                return false;
            }
            if (ducto.Trayectoria === "") {
                alert('Ingrese la Trayectoria');
                return false;
            }
            return true;
        }
        //Fin Validar Oleoducto a Guardar

        //Agregar Nuevo Oleoducto
        $scope.nuevoDucto = null;
        $scope.agregarOleoducto = function () {
            $scope.nuevoDucto = {
                "Id": 0, "Cliente": "", "Codigo": "",
                "Direccion": "", "NoLamina": "", "Ubicacion": "",
                "Material1": "", "Material2": "", "Material3": "",
                "Schedule1": "", "Schedule2": "", "Schedule3": "",
                "BLPD": "", "Presion": "", "Temperatura": "","BSW": "", 
                "FechaInspeccion": "", "RowState": "", "LastUpdate": ""
                
            };
            $('#NuevoOleoducto').modal('show');
        }
        var postSuccessCallBack = function (data, status) {
            alert('Oleoducto Creado');
            $('#NuevoOleoducto').modal('hide');
        }
        $scope.guardarOleoducto = function (oleoducto) {
            if (validar(oleoducto)) {
                oleoducto.LastUpdate = new Date();
                oleoducto.RowState = "A";
                OleoductoRepository.add(oleoducto).success(postSuccessCallBack).error(errorCallBack);
            }
        }
        //Fin Agregar Nuevo Oleoducto

        //Ver Oleoducto
        $scope.verOleoducto = function (oleoducto) {
            $scope.verDucto = oleoducto;
            $('#VerOleoducto').modal('show');
        }


        //Editar Oleoducto
        var putSuccessCallBack = function (data, status) {
            alert('Oleoducto Actualizado');
            $('#EditarOleoducto').modal('hide');
        }
        $scope.actualizarOleoducto = function (oleoducto) {
            if (validar(oleoducto)) {
                oleoducto.LastUpdate = new Date();
                oleoducto.RowState = "A";
                OleoductoRepository.update(oleoducto).success(putSuccessCallBack).error(errorCallBack);
            }
        }
        $scope.editarOleoducto = function (oleoducto) {
            $scope.editarDucto = oleoducto;
            //$scope.editarDucto.FechaInspeccion = new Date(2013, 9, 22);
            
            $('#EditarOleoducto').modal('show');
        }

        //Fin Editar Oleoducto

        //paginación
        $scope.firstPage = function () {
            $scope.parameterlist.page = 1;
            OleoductoRepository.get($scope.parameterlist)
             .success(getSuccessCallback)
             .error(errorCallBack);
        };

        $scope.previousPage = function () {
            if ($scope.parameterlist.page > 1) {
                $scope.parameterlist.page--;
                OleoductoRepository.get($scope.parameterlist)
                 .success(getSuccessCallback)
                 .error(errorCallBack);
            }
        };

        $scope.nextPage = function () {
            if ($scope.parameterlist.page < $scope.parameterlist.pages) {
                $scope.parameterlist.page++;
                OleoductoRepository.get($scope.parameterlist)
                 .success(getSuccessCallback)
                 .error(errorCallBack);
            }
        };

        $scope.lastPage = function () {
            $scope.parameterlist.page = $scope.parameterlist.pages;
            OleoductoRepository.get($scope.parameterlist)
             .success(getSuccessCallback)
             .error(errorCallBack);
        };
        //Fin de Paginación
    });