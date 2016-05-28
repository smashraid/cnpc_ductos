var app = angular.module("app", ["ngRoute"])
.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: '/AngularJS/Templates/Bienvenidos.html',
        controller: 'bienvenidosController'
    });
    $routeProvider.when('/Ducto', {
        templateUrl: '/AngularJS/Templates/Ductos.html',
        controller: 'ductoController'
    });
    //$routeProvider.when('/OctavosDeFinal', {
    //    templateUrl: '/AngularJS/Templates/OctavosDeFinal.html',
    //    controller: 'OctavosDeFinalController'
    //});
    //$routeProvider.when('/CuartosDeFinal', {
    //    templateUrl: '/AngularJS/Templates/CuartosDeFinal.html',
    //    controller: 'CuartosDeFinalController'
    //});
    //$routeProvider.when('/SemifinalYFinal', {
    //    templateUrl: '/AngularJS/Templates/SemifinalYFinal.html',
    //    controller: 'SemifinalYFinalController'
    //});
    $locationProvider.html5Mode(true);
});
