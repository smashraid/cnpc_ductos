var registrationModule = angular.module("registrationModule", ["ngRoute"])
.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: '/AngularJS/Templates/Bienvenidos.html',
        controller: 'BienvenidosController'
    });
    $routeProvider.when('/FaseDeGrupos', {
        templateUrl: '/AngularJS/Templates/FaseDeGrupos.html',
        controller: 'FaseDeGruposController'
    });
    $routeProvider.when('/OctavosDeFinal', {
        templateUrl: '/AngularJS/Templates/OctavosDeFinal.html',
        controller: 'OctavosDeFinalController'
    });
    $routeProvider.when('/CuartosDeFinal', {
        templateUrl: '/AngularJS/Templates/CuartosDeFinal.html',
        controller: 'CuartosDeFinalController'
    });
    $routeProvider.when('/SemifinalYFinal', {
        templateUrl: '/AngularJS/Templates/SemifinalYFinal.html',
        controller: 'SemifinalYFinalController'
    });
    $locationProvider.html5Mode(true);
});
