app.controller("ductoController", function ($scope, ductoRepository) {
    //Metodo GET
    var getSuccessCallback = function (data, status) {
        $scope.listaOleoductos = data;
    }
    var errorCallBack = function (data, status, headers, config) {
        alert("Ocurrio un problema");
    }

    ductoRepository.get()
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
            ductoRepository.update(oleoducto).success(putSuccessCallBack).error(errorCallBack);
        }
    }
    $scope.editarOleoducto = function (oleoducto) {
        $scope.editarDucto = oleoducto;
        $('#EditarOleoducto').modal('show');
    }
    //Fin Editar Oleoducto

});