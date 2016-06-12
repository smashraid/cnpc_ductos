app.controller("bienvenidosController", function ($scope, bienvenidosRepository) {
    var getSuccessCallback = function (data, status) {
       
    }
    var errorCallBack = function (data, status, headers, config) {
        alert("Ocurrio un problema");
    }

    //bienvenidosRepository.get()
    //.success(getSuccessCallback)
    //.error(errorCallBack);
});