var app = angular.module("app", ["ngRoute"])
.config(function ($routeProvider, $locationProvider) {
    $routeProvider.when('/', {
        templateUrl: '/AngularJS/Templates/Bienvenidos.html',
        controller: 'bienvenidosController'
    });
    $routeProvider.when('/Oleoducto', {
        templateUrl: '/AngularJS/Templates/Ductos.html',
        controller: 'ductoController'
    });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});
