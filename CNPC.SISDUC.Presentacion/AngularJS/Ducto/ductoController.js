app.controller("ductoController", function ($scope, ductoRepository) {
    var getSuccessCallback = function (data, status) {
        $scope.listaOleoductos = data;
    }
    var errorCallBack = function (data, status, headers, config) {
        alert("Ocurrio un problema");
    }

    ductoRepository.get()
    .success(getSuccessCallback)
    .error(errorCallBack);

    var nuevoDucto = null;
    $scope.agregarOleoducto = function () {
        nuevoDucto = { "Id": 0, "Cliente": "", "Ducto1": "", "NoLamina": "", "Trayectorio": "", "Ubicacion": "", "Inspector": "", "FechaInspeccion": "", "NumeroTubos": "" };
        $('#NuevoOleoducto').modal('show');
    }
    $scope.verOleoducto = function (oleoducto) {
        $scope.verDucto = oleoducto;
        $('#VerOleoducto').modal('show');
    }
    $scope.editarOleoducto = function (oleoducto) {
        $scope.verDucto = oleoducto;
        $('#EditarOleoducto').modal('show');
    }
});