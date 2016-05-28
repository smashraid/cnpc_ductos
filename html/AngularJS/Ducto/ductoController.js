app.controller("ductoController", function ($scope, ductoRepository) {

    var getSuccessCallback = function (data, status)
    {
        $scope.listaDuctos = data;
    }
    var errorCallBack = function (data, status, headers, config)
    {
        alert("Ocurrio un problema");
    }

    ductoRepository.get()
    .success(getSuccessCallback)
    .error(errorCallBack);

    var nuevoDucto = null;
    $scope.agregarOleoducto = function () {
        //ducto = { "Id": 0, "Cliente": "", "Ducto1": "", "NoLamina": "", "Trayectorio": "", "Ubicacion": "", "Inspector": "", "FechaInspeccion": "", "NumeroTubos": "" };
        $('#NuevoOleoducto').modal('show');
    }
});