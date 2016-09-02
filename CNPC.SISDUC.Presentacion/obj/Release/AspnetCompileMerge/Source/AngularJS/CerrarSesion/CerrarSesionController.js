app.controller("CerrarSesionController",
    function ($scope, CerrarSesionRepository) {
        //Metodo GET
        var getSuccessCallback = function (data, status) {
            var errorCallBack = function (data, status, headers, config) {
                alert("Ocurrio un problema al cerrar la sesin");
            }
            CerrarSesionRepository.get()
            .success(getSuccessCallback)
            .error(errorCallBack);
        }
    });