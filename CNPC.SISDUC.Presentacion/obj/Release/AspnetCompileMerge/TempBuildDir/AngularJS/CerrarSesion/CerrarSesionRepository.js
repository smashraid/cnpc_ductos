var GetCerrarSesionUrl = '/Home/CerrarSesion';

app.factory('CerrarSesionRepository', function ($http) {
    return {
        get: function () {
            return $http.get(GetCerrarSesionUrl, null);
        }        
    };
});