var app = angular.module("app", ["ngRoute"])
.config(function ($routeProvider, $locationProvider) {
    //$locationProvider.html5Mode({
    //    enabled: true,
    //    requireBase: true
    //});
    $routeProvider.when('/', {
        templateUrl: '/AngularJS/Templates/Bienvenidos.html',
        controller: 'bienvenidosController'
    });
    $routeProvider.when('/Oleoducto', {
        templateUrl: '/AngularJS/Templates/Oleoductos.html',
        controller: 'OleoductoController'
    });
    $routeProvider.when('/Tuberia/:id', {
        templateUrl: '/AngularJS/Templates/Tuberias.html',
        controller: 'RegistroInspeccionVisualController'
    });
    $routeProvider.when('/Home/CerrarSesion', {
        templateUrl: '/',
        controller: 'CerrarSesionController'
    });
    $locationProvider.html5Mode(true);
});
