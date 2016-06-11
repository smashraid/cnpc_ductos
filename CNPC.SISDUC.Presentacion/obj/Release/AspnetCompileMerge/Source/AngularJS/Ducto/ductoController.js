﻿app.controller("ductoController", function ($scope, ductoRepository) {
    //Metodo GET
    var getSuccessCallback = function (data, status) {
        $scope.listaOleoductos = data.List;
        $scope.parameterlist.pages = data.TotalPages;
        $scope.parameterlist.totalRecords = data.TotalRecords;
    }
    var errorCallBack = function (data, status, headers, config) {
        alert("Ocurrio un problema");
    }

    //Paginación
    $scope.parameterlist = {
        name: '',
        page: 1,
        records: 8,
        pages: 0,
        totalRecords: 0
    }

    ductoRepository.get($scope.parameterlist)
    .success(getSuccessCallback)
    .error(errorCallBack);
    //Fin Metodo GET

    //Validar Oleoducto a Guardar
    var validar = function (ducto) {
        if (ducto.Codigo == "") {
            alert('Ingrese el Código');
            return false;
        }
        if (ducto.NoLamina == "") {
            alert('Ingrese el Número de Lamina');
            return false;
        }
        if (ducto.Trayectoria == "") {
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
            "Id": 0, "Cliente": "", "Codigo": "", "NoLamina": "",
            "Trayectoria": "", "Ubicacion": "", "Inspector": "",
            "FechaInspeccion": "", "NumeroTubos": "", "Longitud01": "",
            "Longitud02": "", "Longitud03": "", "Longitud04": "",
            "Longitud05": "", "LongitudTotal": "", "PresionDiseño": "",
            "PresionMaximaAdmisibleOperacion": "", "PresionMaximaOperacion": "",
            "PresionNormalOperacion": "", "TemperaturaMaximaOperacion": "",
            "TemperaturaNormalOperacion": "", "NPS01": "", "NPS02": "", "NPS03": "",
            "NPS04": "", "NPS05": "", "Presion": "", "BLPD": "", "Schedule1": "",
            "Schedule2": "", "Schedule3": "", "Material1": "", "Material2": "",
            "Material3": "", "Temperatura": "", "BSW": "", "Esfuerzo_S": "",
            "FactorJunta_E": "", "FactorSensibilidadError": "", "RowState": "",
            "LastUpdate": ""
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
            ductoRepository.add(oleoducto).success(postSuccessCallBack).error(errorCallBack);
        }
    }
    //Fin Agregar Nuevo Oleoducto

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
            ductoRepository.update(oleoducto).success(putSuccessCallBack).error(errorCallBack);
        }
    }
    $scope.editarOleoducto = function (oleoducto) {
        $scope.editarDucto = oleoducto;
        $('#EditarOleoducto').modal('show');
    }
    //Fin Editar Oleoducto
       
    //paginación
    $scope.firstPage = function () {
        $scope.parameterlist.page = 1;
        ductoRepository.get($scope.parameterlist)
         .success(getSuccessCallback)
         .error(errorCallBack);
    };

    $scope.previousPage = function () {
        if ($scope.parameterlist.page > 1) {
            $scope.parameterlist.page--;
            ductoRepository.get($scope.parameterlist)
             .success(getSuccessCallback)
             .error(errorCallBack);
        }
    };

    $scope.nextPage = function () {
        if ($scope.parameterlist.page < $scope.parameterlist.pages) {
            $scope.parameterlist.page++;
            ductoRepository.get($scope.parameterlist)
             .success(getSuccessCallback)
             .error(errorCallBack);
        }
    };

    $scope.lastPage = function () {
        $scope.parameterlist.page = $scope.parameterlist.pages;
        ductoRepository.get($scope.parameterlist)
         .success(getSuccessCallback)
         .error(errorCallBack);
    };
    //Fin de Paginación
});